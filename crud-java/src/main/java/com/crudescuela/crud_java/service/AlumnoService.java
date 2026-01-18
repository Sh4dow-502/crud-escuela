package com.crudescuela.crud_java.service;

import org.springframework.data.domain.Sort;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;

import com.crudescuela.crud_java.entity.AlumnoEntity;
import com.crudescuela.crud_java.repository.AlumnoRepository;

@Service
public class AlumnoService {

  private final AlumnoRepository alumnoRepository;

  public AlumnoService(AlumnoRepository repository) {
    this.alumnoRepository = repository;
  }

  public AlumnoEntity crearAlumno(AlumnoEntity alumno) {
    if (alumnoRepository.existsByTelefono(alumno.getTelefono())) {
      throw new ResponseStatusException(HttpStatus.CONFLICT, "El numero de telefono ya esta registrado");
    }

    try {
      return alumnoRepository.save(alumno);
    } catch (Exception e) {
      throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error al crear alumno");

    }
  }

  public List<AlumnoEntity> obtenerAlumnos() {
    return alumnoRepository.findAll(Sort.by(Sort.Direction.ASC, "id"));
  }

  public AlumnoEntity actualizarAlumno(Long id, AlumnoEntity alumno) {
    AlumnoEntity alumnoActualizado = alumnoRepository.findById(id).orElseThrow(
        () -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Alumno no encontrado"));

    if (alumnoRepository.existsByTelefonoAndIdNot(alumno.getTelefono(), id)) {
      throw new ResponseStatusException(HttpStatus.CONFLICT, "El numero de telefono ya esta registrado");
    }

    alumnoActualizado.setNombre(alumno.getNombre());
    alumnoActualizado.setApellido(alumno.getApellido());
    alumnoActualizado.setTelefono(alumno.getTelefono());
    alumnoActualizado.setDireccion(alumno.getDireccion());

    return alumnoRepository.save(alumnoActualizado);

  }

  public String eliminarAlumno(Long id) {

    AlumnoEntity alumnoBorrar = alumnoRepository.findById(id).orElseThrow(
        () -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Alumno no encontrado"));
    try {
      alumnoRepository.delete(alumnoBorrar);
    } catch (Exception e) {
      throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error eliminando alumno");
    }
    return "Alumno Eliminado";
  }
}
