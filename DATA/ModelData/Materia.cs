using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DATA.ModelData;

public partial class Materia
{
    [Key]
    [Column("MateriaID")]
    public int MateriaId { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    public int Creditos { get; set; }

    [InverseProperty("Materia")]
    public virtual ICollection<EstudianteMateria> EstudianteMateria { get; set; } = new List<EstudianteMateria>();

    [InverseProperty("Materia")]
    public virtual ProfesorMateria? ProfesorMateria { get; set; }
}
