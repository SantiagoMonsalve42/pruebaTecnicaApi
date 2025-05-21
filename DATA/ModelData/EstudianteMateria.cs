using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DATA.ModelData;

[Index("EstudianteId", "MateriaId", Name = "UQ__Estudian__6FA69AE1C8094C0B", IsUnique = true)]
public partial class EstudianteMateria
{
    [Key]
    [Column("EstudianteMateriaID")]
    public int EstudianteMateriaId { get; set; }

    [Column("EstudianteID")]
    public int EstudianteId { get; set; }

    [Column("MateriaID")]
    public int MateriaId { get; set; }

    [ForeignKey("EstudianteId")]
    [InverseProperty("EstudianteMateria")]
    public virtual Estudiante Estudiante { get; set; } = null!;

    [ForeignKey("MateriaId")]
    [InverseProperty("EstudianteMateria")]
    public virtual Materia Materia { get; set; } = null!;
}
