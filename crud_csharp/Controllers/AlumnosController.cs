using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crud_csharp.Models;
using crud_csharp.Data;
using crud_csharp.Services;

namespace crud_csharp.Controllers;


[ApiController]
[Route("alumnos")]
public class AlumnosController(IAlumnoService _alumnoService) : ControllerBase
{
    private readonly IAlumnoService _alumnoService = _alumnoService;


    // Obtener todos los alumnos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Alumno>>> GetAll()
    {
        var alumnos = await _alumnoService.GetAllAsync();
        return Ok(alumnos);
    }



    // Crear alumno
    [HttpPost]
    public async Task<ActionResult<Alumno>> Create([FromBody] Alumno alumno)
    {
        var createdAlumno = await _alumnoService.CreateAsync(alumno);
        return CreatedAtAction(nameof(GetAll), new { id = createdAlumno.Id }, createdAlumno);
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Alumno alumno)
    {
        var updatedAlumno = await _alumnoService.UpdateAsync(id, alumno);
        if (updatedAlumno == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // Eliminar alumno
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _alumnoService.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}