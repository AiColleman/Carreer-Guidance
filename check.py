import sqlite3
import json

conn = sqlite3.connect('src/Web/vocational.db')
cursor = conn.execute('SELECT SesionId, COUNT(*) FROM Respuestas GROUP BY SesionId ORDER BY MAX(Id) DESC LIMIT 1')
result = cursor.fetchone()
if result:
    sesion_id = result[0]
    total_respuestas = result[1]
    
    true_count = conn.execute('SELECT COUNT(*) FROM Respuestas WHERE SesionId=? AND MeInteresa=1', (sesion_id,)).fetchone()[0]
    
    print(f"Latest Session: {sesion_id}")
    print(f"Total Respuestas: {total_respuestas}")
    print(f"MeInteresa True count: {true_count}")
    
    # Also check if this session exists in Sesiones table
    sesion_exists = conn.execute('SELECT COUNT(*) FROM Sesiones WHERE Id=?', (sesion_id,)).fetchone()[0]
    print(f"Sesion exists in Sesiones table: {sesion_exists > 0}")
else:
    print("No responses found in DB.")
