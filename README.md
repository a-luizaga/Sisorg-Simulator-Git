# SimuladorGit

Esta es una aplicación de consola desarrollada en .NET que simula algunas funciones básicas de Git, como `add`, `status`, `push`, `commit`, etc.

## Requisitos para su ejecución

- .NET SDK instalado en tu sistema ([Instrucciones de instalación](https://dotnet.microsoft.com/download))
- Visual Studio o Visual Studio Code (opcional)

## Pasos para Ejecutar la Aplicación

1. **Clona el Repositorio:**
`git clone https://github.com/a-luizaga/Simulador-Git.git`

2. **Navega al Directorio del Proyecto:**
`cd ruta/al/proyecto/SisorgGit`
	
3. **Compila el Proyecto:**
`dotnet build`

4. **Ejecuta la Aplicación:**
`dotnet run`


## Funcionalidades Solicitadas

- `add <archivo>`: Agrega un archivo al área de preparación. Tambien se puede argegar varios archivos de la siguiente forma: `add nameFile1 nameFile2`
- `commit -m <mensaje>`: Realiza un commit con los archivos en el área de preparación.
- `push`: Envia los commits locales a un servidor remoto.
- `log`: Muestra el registro de commits locales.

## Funcionalidades Adicionales
- `status`: Muestra los arhivos que se encuentran en el área de preparación.
- `reset <archivo>`: Quita un archivo especifico. Se puede quitar todos los archivos si no se pasa como argumento ningun archivo.
- `remote`: Muestra el registro de commits del server remoto.

## Diagrama de clases
![Diagrama UML](./SisorgGit/Resources/SisorgGitUML.drawio.png)


## Contribución

¡Las contribuciones son bienvenidas! Si deseas contribuir a este proyecto, sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz commit (`git commit -am 'Agrega una nueva funcionalidad'`).
4. Haz push a la rama (`git push origin feature/nueva-funcionalidad`).
5. Crea un nuevo Pull Request.

## Contacto

Si tienes alguna pregunta o sugerencia, no dudes en ponerte en contacto con el equipo de desarrollo en [dev@example.com](mailto:dev@example.com).

