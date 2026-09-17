import re

csharp_template = """using System;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Data
{
    public class VocationalDbContext : DbContext
    {
        public VocationalDbContext(DbContextOptions<VocationalDbContext> options) : base(options) { }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Areas
            modelBuilder.Entity<Area>().HasData(
                new Area { Id = 1, Nombre = "Arte y Creatividad" },
                new Area { Id = 2, Nombre = "Ciencias Sociales" },
                new Area { Id = 3, Nombre = "Económica, Administrativa y Financiera" },
                new Area { Id = 4, Nombre = "Ciencia y Tecnología" },
                new Area { Id = 5, Nombre = "Ciencias Ecológicas, Biológicas y de la Salud" }
            );

            // Seed Actividades
            modelBuilder.Entity<Actividad>().HasData(
{actividades_seed}
            );
        }
    }
}
"""

actividades = []
with open('2_Specify.md', 'r', encoding='utf-8') as f:
    lines = f.readlines()
    
    in_act = False
    for line in lines:
        if line.startswith('### Actividades'):
            in_act = True
            continue
            
        if in_act:
            line = line.strip()
            if not line: continue
            if '|' in line:
                parts = [p.strip() for p in line.split('|')]
                if len(parts) >= 3 and parts[0].isdigit():
                    num = int(parts[0])
                    area = int(parts[1])
                    texto = parts[2].replace('"', '\\"')
                    actividades.append(f'                new Actividad {{ Id = {num}, Numero = {num}, AreaId = {area}, TextoActividad = "{texto}" }}')

seed_str = ",\n".join(actividades)
final_code = csharp_template.replace('{actividades_seed}', seed_str)

import os
os.makedirs('src/Data', exist_ok=True)
with open('src/Data/VocationalDbContext.cs', 'w', encoding='utf-8') as f:
    f.write(final_code)

print("VocationalDbContext.cs generated successfully with", len(actividades), "activities.")
