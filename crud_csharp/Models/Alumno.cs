using System.ComponentModel.DataAnnotations.Schema;

namespace crud_csharp.Models;


[Table("alumnos")]
public class Alumno
{
    [Column("id")]
    public int Id { get; set; }
    [Column("nombre")]
    public string Nombre { get; set; } = String.Empty;
    [Column("apellido")]
    public string Apellido { get; set; } = String.Empty;
    [Column("telefono")]
    public string Telefono { get; set; } = String.Empty;
    [Column("direccion")]
    public string Direccion { get; set; } = String.Empty;
}