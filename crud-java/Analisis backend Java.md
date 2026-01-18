### 1. Las herramientas que voy a usar

- **Java (el lenguaje):** Es el idioma en el que escribiré el código.
- **Spring Boot (el marco):** Es como el kit de construcción que ya trae todo listo para API.
- **Maven (el organizador):** Es el que se encarga de descargar las librerías que necesito, como si fuera el npm <command>

Usage:

npm install        install all the dependencies in your project
npm install <foo>  add the <foo> dependency to your project
npm test           run this project's tests
npm run <foo>      run the script named <foo>
npm <command> -h   quick help on <command>
npm -l             display usage info for all commands
npm help <term>    search for help on <term>
npm help npm       more involved overview

All commands:

    access, adduser, audit, bugs, cache, ci, completion,
    config, dedupe, deprecate, diff, dist-tag, docs, doctor,
    edit, exec, explain, explore, find-dupes, fund, get, help,
    help-search, init, install, install-ci-test, install-test,
    link, ll, login, logout, ls, org, outdated, owner, pack,
    ping, pkg, prefix, profile, prune, publish, query, rebuild,
    repo, restart, root, run, sbom, search, set, shrinkwrap,
    star, stars, start, stop, team, test, token, undeprecate,
    uninstall, unpublish, unstar, update, version, view, whoami

Specify configs in the ini-formatted file:
    /home/santos/.npmrc
or on the command line via: npm <command> --key=value

More configuration info: npm help config
Configuration fields: npm help 7 config

npm@11.7.0 /usr/lib/node_modules/npm de Node.js.

---

### 2. Estructura del proyecto

- **El Modelo:** Una clase que solo dice qué datos tiene un Alumno (nombre, apellido, etc.).
- El Servicio: Una clase en donde va toda la logica de negocio
- **El Repositorio:** La parte que habla con PostgreSQL (hace los  y ).
- **El Controlador:** El que recibe las peticiones de la URL (como ) y responde.

---

### 3. Lógica

1. **Conectarse a la base:** Usar la misma clave y la misma base de datos ().
2. **No repetir teléfonos:** Antes de guardar a alguien, el programa debe revisar si ese teléfono ya existe. Si existe, debe avisar con un error.
3. **Permitir visitas:** Configurar algo llamado **CORS**, que es básicamente darle permiso a mi página web para que pueda hablar con este nuevo servidor Java.

---

### 4. Dependencias - Maven

- **Spring Web:** Para que mi Java sepa qué es una URL y un JSON.
- **PostgreSQL:** Para que Java entienda el idioma de mi base de datos.
- **JPA:** Para manejar la base de datos por medio de Objectos o Clases
