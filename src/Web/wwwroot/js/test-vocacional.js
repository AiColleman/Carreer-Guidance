// ==========================================
// TEST VOCACIONAL - Swipe Card Logic
// ==========================================
(function () {
    'use strict';

    const sesionId = document.getElementById('sesionId').value;
    const totalCards = parseInt(document.getElementById('totalCards').value);
    const cardStack = document.getElementById('cardStack');
    const progressFill = document.getElementById('progressFill');
    const progressText = document.getElementById('progressText');
    const btnLike = document.getElementById('btnLike');
    const btnNope = document.getElementById('btnNope');

    let currentIndex = 0;
    let isDragging = false;
    let startX = 0;
    let currentX = 0;
    let isAnimating = false;

    // ---- Get current active card ----
    function getActiveCard() {
        return cardStack.querySelector('.swipe-card.active');
    }

    // ---- Update progress bar ----
    function updateProgress() {
        const progress = ((currentIndex + 1) / totalCards) * 100;
        progressFill.style.width = progress + '%';
        progressText.textContent = Math.min(currentIndex + 1, totalCards) + ' / ' + totalCards;
    }

    // ---- Send swipe response to server ----
    async function sendSwipe(actividadId, meInteresa) {
        try {
            await fetch('/Test/Swipe', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    sesionId: sesionId,
                    actividadId: parseInt(actividadId),
                    meInteresa: meInteresa
                })
            });
        } catch (err) {
            console.error('Error al enviar respuesta:', err);
        }
    }

    // ---- Swipe card with animation ----
    function swipeCard(direction) {
        if (isAnimating) return;
        const card = getActiveCard();
        if (!card) return;

        isAnimating = true;
        const meInteresa = direction === 'right';
        const actividadId = card.dataset.actividadId;

        // Add fly animation
        card.classList.add(direction === 'right' ? 'fly-right' : 'fly-left');

        // Send response
        sendSwipe(actividadId, meInteresa);

        // After animation ends, reveal next card
        setTimeout(function () {
            card.classList.remove('active', 'fly-right', 'fly-left', 'swiping-left', 'swiping-right');
            card.style.display = 'none';

            currentIndex++;
            updateProgress();

            // Check if test is complete
            if (currentIndex >= totalCards) {
                window.location.href = '/Test/Results?sesionId=' + sesionId;
                return;
            }

            // Activate next card
            const nextCard = cardStack.querySelector('.swipe-card[data-index="' + currentIndex + '"]');
            if (nextCard) {
                nextCard.style.display = '';
                nextCard.classList.add('active');
                nextCard.style.transform = '';
            }

            // Show card behind for depth effect
            const behindCard = cardStack.querySelector('.swipe-card[data-index="' + (currentIndex + 1) + '"]');
            if (behindCard) {
                behindCard.style.display = '';
            }
            const behindCard2 = cardStack.querySelector('.swipe-card[data-index="' + (currentIndex + 2) + '"]');
            if (behindCard2) {
                behindCard2.style.display = '';
            }

            isAnimating = false;
        }, 450);
    }

    // ---- Button handlers ----
    btnLike.addEventListener('click', function () { swipeCard('right'); });
    btnNope.addEventListener('click', function () { swipeCard('left'); });

    // ---- Touch / Mouse drag support ----
    function handleDragStart(x) {
        if (isAnimating) return;
        const card = getActiveCard();
        if (!card) return;
        isDragging = true;
        startX = x;
        card.style.transition = 'none';
    }

    function handleDragMove(x) {
        if (!isDragging) return;
        const card = getActiveCard();
        if (!card) return;

        currentX = x - startX;
        const rotation = currentX * 0.08;
        card.style.transform = 'translateX(' + currentX + 'px) rotate(' + rotation + 'deg)';

        // Show overlay indicator
        card.classList.remove('swiping-left', 'swiping-right');
        if (currentX > 50) {
            card.classList.add('swiping-right');
        } else if (currentX < -50) {
            card.classList.add('swiping-left');
        }
    }

    function handleDragEnd() {
        if (!isDragging) return;
        isDragging = false;
        const card = getActiveCard();
        if (!card) return;

        card.style.transition = '';
        card.classList.remove('swiping-left', 'swiping-right');

        const threshold = 100;
        if (currentX > threshold) {
            swipeCard('right');
        } else if (currentX < -threshold) {
            swipeCard('left');
        } else {
            // Snap back
            card.style.transform = '';
        }
        currentX = 0;
    }

    // Mouse events
    cardStack.addEventListener('mousedown', function (e) { handleDragStart(e.clientX); });
    document.addEventListener('mousemove', function (e) { handleDragMove(e.clientX); });
    document.addEventListener('mouseup', handleDragEnd);

    // Touch events
    cardStack.addEventListener('touchstart', function (e) {
        handleDragStart(e.touches[0].clientX);
    }, { passive: true });
    document.addEventListener('touchmove', function (e) {
        handleDragMove(e.touches[0].clientX);
    }, { passive: true });
    document.addEventListener('touchend', handleDragEnd);

    // ---- Keyboard support ----
    document.addEventListener('keydown', function (e) {
        if (e.key === 'ArrowRight') swipeCard('right');
        if (e.key === 'ArrowLeft') swipeCard('left');
    });

    // Initial state
    updateProgress();
})();
