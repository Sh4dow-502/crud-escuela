package com.crudescuela.crud_java.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import com.crudescuela.crud_java.entity.AlumnoEntity;

public interface AlumnoRepository extends JpaRepository<AlumnoEntity, Long> {

  boolean existsByTelefono(String telefono);

  boolean existsByTelefonoAndIdNot(String telefono, Long id);

}
