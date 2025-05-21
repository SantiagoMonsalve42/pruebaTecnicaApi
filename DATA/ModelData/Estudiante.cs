using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DATA.ModelData;

[Index("Email", Name = "UQ__Estudian__A9D1053414999D7F", IsUnique = true)]
public partial class Estudiante
{
    [Key]
    [Column("EstudianteID")]
    public int EstudianteId { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    public string Apellido { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(512)]
    public string Contraseña { get; set; } = null!;

    [InverseProperty("Estudiante")]
    public virtual ICollection<EstudianteMateria> EstudianteMateria { get; set; } = new List<EstudianteMateria>();
}
