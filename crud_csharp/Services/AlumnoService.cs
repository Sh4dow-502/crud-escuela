using crud_csharp.Data;
using crud_csharp.Models;
using Microsoft.EntityFrameworkCore;


namespace crud_csharp.Services;

public class AlumnoService(AppDbContext context) : IAlumnoService
{
    private readonly AppDbContext _context = context;

    // Obtener todos los alumnos
    public async Task<IEnumerable<Alumno>> GetAllAsync()
    {
        return await _context.Alumnos.ToListAsync();
    }


    // Crear un nuevo alumno
    public async Task<Alumno> CreateAsync(Alumno nuevoAlumno)
    {
        _context.Alumnos.Add(nuevoAlumno);
        await _context.SaveChangesAsync();
        return nuevoAlumno;
    }


    // Actualizar un alumno
    public async Task<Alumno?> UpdateAsync(int id, Alumno alumnoActualizado)
    {
        var alumnoExistente = await _context.Alumnos.FindAsync(id);
        if (alumnoExistente == null)
        {
            return null;
        }

        alumnoExistente.Nombre = alumnoActualizado.Nombre;
        alumnoExistente.Apellido = alumnoActualizado.Apellido;
        alumnoExistente.Telefono = alumnoActualizado.Telefono;
        alumnoExistente.Direccion = alumnoActualizado.Direccion;

        await _context.SaveChangesAsync();
        return alumnoExistente;
    }



    // Eliminar un alumno
    public async Task<bool> DeleteAsync(int id)
    {
        var alumnoExistente = await _context.Alumnos.FindAsync(id);
        if (alumnoExistente == null)
        {
            return false;
        }

        _context.Alumnos.Remove(alumnoExistente);
        await _context.SaveChangesAsync();
        return true;
    }


}