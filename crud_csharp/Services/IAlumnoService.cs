using crud_csharp.Models;


namespace crud_csharp.Services;


public interface IAlumnoService
{
    Task<IEnumerable<Alumno>> GetAllAsync();
    Task<Alumno> CreateAsync(Alumno nuevoAlumno);
    Task<Alumno?> UpdateAsync(int id, Alumno alumnoActualizado);
    Task<bool> DeleteAsync(int id);
}