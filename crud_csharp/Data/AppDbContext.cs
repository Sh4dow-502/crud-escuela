using Microsoft.EntityFrameworkCore;
using crud_csharp.Models;

namespace crud_csharp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Alumno> Alumnos { get; set; }
}