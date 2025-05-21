using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DATA.ModelData;

[Index("MateriaId", Name = "UQ__Profesor__0D019D805F0080C1", IsUnique = true)]
public partial class ProfesorMateria
{
    [Key]
    [Column("ProfesorMateriaID")]
    public int ProfesorMateriaId { get; set; }

    [Column("ProfesorID")]
    public int ProfesorId { get; set; }

    [Column("MateriaID")]
    public int MateriaId { get; set; }

    [ForeignKey("MateriaId")]
    [InverseProperty("ProfesorMateria")]
    public virtual Materia Materia { get; set; } = null!;

    [ForeignKey("ProfesorId")]
    [InverseProperty("ProfesorMateria")]
    public virtual Profesore Profesor { get; set; } = null!;
}
