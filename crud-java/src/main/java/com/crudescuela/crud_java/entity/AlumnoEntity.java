package com.crudescuela.crud_java.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Pattern;
import jakarta.validation.constraints.Size;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "alumnos")
public class AlumnoEntity {

  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  private Long id;

  @Column(length = 150, nullable = false)
  @NotBlank
  @Size(max = 150)
  private String nombre;

  @Column(length = 150, nullable = false)
  @NotBlank
  @Size(max = 150)
  private String apellido;

  @Column(length = 9, nullable = false, unique = true)
  @NotBlank
  @Pattern(regexp = "\\d{1,9}")
  private String telefono;

  @Column(length = 100, nullable = false)
  @NotBlank
  @Size(max = 100)
  private String direccion;

}