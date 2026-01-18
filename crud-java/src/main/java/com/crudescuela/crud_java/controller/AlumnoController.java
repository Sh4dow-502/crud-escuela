package com.crudescuela.crud_java.controller;

import java.util.List;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.crudescuela.crud_java.entity.AlumnoEntity;
import com.crudescuela.crud_java.service.AlumnoService;

@RestController
@RequestMapping("/alumnos")
@CrossOrigin(origins = "*")
public class AlumnoController {

  private final AlumnoService alumnoService;

  public AlumnoController(AlumnoService service) {
    this.alumnoService = service;
  }

  @GetMapping
  public List<AlumnoEntity> obtenerAlumnos() {
    return alumnoService.obtenerAlumnos();
  }

  @PostMapping
  public ResponseEntity<AlumnoEntity> crearAlumno(@RequestBody AlumnoEntity alumno) {
    return ResponseEntity.status(HttpStatus.CREATED).body(alumnoService.crearAlumno(alumno));
  }

  @PutMapping("/{id}")
  public ResponseEntity<AlumnoEntity> actualizarAlumno(@PathVariable Long id, @RequestBody AlumnoEntity alumno) {
    AlumnoEntity actualizado = alumnoService.actualizarAlumno(id, alumno);
    return ResponseEntity.ok(actualizado);
  }

  @DeleteMapping("/{id}")
  public ResponseEntity<String> eliminarAlumno(@PathVariable Long id) {
    return ResponseEntity.ok(alumnoService.eliminarAlumno(id));
  }
}
