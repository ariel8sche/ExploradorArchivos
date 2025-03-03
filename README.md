# Explorador de Archivos en C#

Este es un explorador de archivos en consola, escrito en C#, que permite al usuario explorar directorios y realizar diversas operaciones en archivos como copiar, mover, eliminar y renombrar. El programa permite navegar por el sistema de archivos, ver los contenidos de directorios y realizar operaciones sobre los archivos seleccionados.

## Funcionalidades

- Explorar directorios y subdirectorios.
- Visualizar los archivos y carpetas en una tabla con su nombre y tipo.
- Realizar operaciones sobre los archivos:
  - **Copiar archivo**: Copia el archivo a una nueva ubicación.
  - **Mover archivo**: Mueve el archivo a una nueva ubicación.
  - **Eliminar archivo**: Elimina un archivo del sistema.
  - **Renombrar archivo**: Cambia el nombre de un archivo.

## Requisitos

- **.NET Framework** (o **.NET Core** si se compila para esa plataforma).
- **Visual Studio** o cualquier IDE compatible con C# para compilar y ejecutar el código.

## Instrucciones de Uso

1. **Ejecuta el programa**: Inicia el programa desde tu IDE o desde la línea de comandos.
2. **Ingresar ruta de directorio**: El programa pedirá que ingreses la ruta del directorio que deseas explorar. Si la ruta no es válida, te pedirá una nueva ruta.
3. **Explorar directorios**: Una vez dentro de un directorio, se te presentará una lista de archivos y subdirectorios. Puedes elegir explorar un subdirectorio o realizar operaciones sobre un archivo.
4. **Operaciones con archivos**: Al seleccionar un archivo, el programa ofrecerá opciones para copiar, mover, eliminar o renombrar el archivo.

## Ejemplo de uso

Al ejecutar el programa, se verá un menú similar a este:

Por favor ingrese la ruta del directorio: C:\MiDirectorio Contenido de: MiDirectorio

  Indice   Nombre   Tipo
- 0 archivo1.txt .txt 
- 1 subdirectorio1 Subdirectorio 
- 2 archivo2.pdf .pdf

Ingrese el numero de la opcion que desee explorar (o 'a' para ir hacia atras, 'n' para ingresar una nueva ruta, 's' para salir):

Luego, dependiendo de la opción que elijas, podrás realizar la operación deseada sobre los archivos o subdirectorios.

## Operaciones disponibles en un archivo

Cuando seleccionas un archivo, se muestran las siguientes opciones:

1. **Copiar archivo**: Copia el archivo a una nueva ubicación especificada por el usuario.
2. **Mover archivo**: Mueve el archivo a una nueva ubicación.
3. **Eliminar archivo**: Elimina el archivo seleccionado.
4. **Renombrar archivo**: Cambia el nombre del archivo.
