# SimulatorGit

El repositorio contiene dos proyectos relacionados con la simulación de funcionalidades básicas de Git:

- **SisorgGit:** Una aplicación de consola desarrollada en .NET que simula funciones básicas de Git como `add`, `status`, `push`, `commit`, etc.

- **TestSimuladorGit:** Un proyecto de xunit que contiene pruebas unitarias para verificar el correcto funcionamiento de las funciones implementadas en SisorgGit.

Estos dos proyectos forman una solución completa para el desarrollo y la verificación de un simulador de Git en .NET.



## Requisitos para su ejecución

- .NET SDK instalado en tu sistema ([Instrucciones de instalación](https://dotnet.microsoft.com/download))
- Visual Studio o Visual Studio Code (opcional)

## Pasos para Ejecutar la Aplicación

1. **Clona el Repositorio:**
`git clone https://github.com/a-luizaga/Sisorg-Simulator-Git.git`

2. **Navega al Directorio del Proyecto: (se debe estar dentro del directorio SisorgGit que es la que contiene la aplicacion del simulador)**
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
- `branch <nameBranch>`: Permite crear una nueva rama de trabajo. Si no se especifica ningun argumento, muestra la lista de ramas disponibles.
- `chekcout <nameBranch>`: Permite intercambiar entre una rama u otra. 
- `cls`: Limpia la consola. 

## Diagrama de clases
![Diagrama UML](./SisorgGit/Resources/SisorgGitUML.drawio.png)

## Ejecución de Tests

Para ejecutar los tests unitarios, sigue estos pasos:

1. Navega al directorio del proyecto de tests (TestSimuladorGit):
`cd TestSimuladorGit`
2. Ejecuta el comando de dotnet test:
`dotnet test`

Esto ejecutará todos los tests unitarios en el proyecto y mostrará los resultados en la consola.

## Pruebas Disponibles

El proyecto de tests incluye pruebas para las siguientes funcionalidades:

- Prueba 1: La funcion add debe agregar archivos al area de preparación.
- Prueba 2: La funcion add no debe agregar archivos repetidos al area de preparación.
- Prueba 3: La funcion reset debe remover el archivo especficado del area de preparación.
- Prueba 4: La funcion reset debe remover todos los archivos del area de preparación si no se le pasa parametros.
- Prueba 5: La funcion commit no debe realizar el commit si no hay archivos en el area de preparación.


## Proceso de Despliegue en la Nube utilizando Docker y AWS

Para lograr el despliegue de la aplicación utilizando la arquitectura en la nube, se siguieron los siguientes pasos:

### Dockerización de la Aplicación:
- Se creó un Dockerfile para definir cómo construir la imagen Docker de la aplicación. Este mismo se encuentra disponible en el repositorio.
- La aplicación se encapsuló en un contenedor Docker para asegurar la portabilidad y consistencia del entorno.


### Subida de la Imagen a Docker Hub:
- Una vez construida la imagen Docker, se subió al registro público de imágenes Docker, Docker Hub.
- Esto permitió disponer de la imagen de la aplicación en un repositorio centralizado y accesible desde cualquier máquina que ejecute Docker.


### Provisión de una Instancia EC2 en AWS:
- Se lanzó una instancia EC2 en Amazon Web Services (AWS) para alojar la aplicación en la nube. La instancia EC2 se configuró con una plataforma de Linux.


### Configuración del Entorno Docker en la VM:
- Una vez que la instancia EC2 estuvo en funcionamiento, se configuró el entorno Docker en la máquina virtual.

### Descarga de la Imagen Docker y Ejecución del Contenedor:
- Finalmente, se descargó la imagen Docker de la aplicación desde Docker Hub a la instancia EC2.
- Se ejecutó el contenedor Docker en la instancia EC2 en modo interactivo para que la aplicación funcione correctamente con el siguiente comando: `docker run -it aluizaga/simulator_git`, lo que permitió que la aplicación estuviera disponible para su acceso y uso.

## Contacto