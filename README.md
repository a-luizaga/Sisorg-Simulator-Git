# SimulatorGit

El repositorio contiene dos proyectos relacionados con la simulaci�n de funcionalidades b�sicas de Git:

- **SisorgGit:** Una aplicaci�n de consola desarrollada en .NET que simula funciones b�sicas de Git como `add`, `status`, `push`, `commit`, etc.

- **TestSimuladorGit:** Un proyecto de xunit que contiene pruebas unitarias para verificar el correcto funcionamiento de las funciones implementadas en SisorgGit.

Estos dos proyectos forman una soluci�n completa para el desarrollo y la verificaci�n de un simulador de Git en .NET.



## Requisitos para su ejecuci�n

- .NET SDK instalado en tu sistema ([Instrucciones de instalaci�n](https://dotnet.microsoft.com/download))
- Visual Studio o Visual Studio Code (opcional)

## Pasos para Ejecutar la Aplicaci�n

1. **Clona el Repositorio:**
`git clone https://github.com/a-luizaga/Sisorg-Simulator-Git.git`

2. **Navega al Directorio del Proyecto: (se debe estar dentro del directorio SisorgGit que es la que contiene la aplicacion del simulador)**
`cd ruta/al/proyecto/SisorgGit`
	
3. **Compila el Proyecto:**
`dotnet build`

4. **Ejecuta la Aplicaci�n:**
`dotnet run`


## Funcionalidades Solicitadas

- `add <archivo>`: Agrega un archivo al �rea de preparaci�n. Tambien se puede argegar varios archivos de la siguiente forma: `add nameFile1 nameFile2`
- `commit -m <mensaje>`: Realiza un commit con los archivos en el �rea de preparaci�n.
- `push`: Envia los commits locales a un servidor remoto.
- `log`: Muestra el registro de commits locales.

## Funcionalidades Adicionales
- `status`: Muestra los arhivos que se encuentran en el �rea de preparaci�n.
- `reset <archivo>`: Quita un archivo especifico. Se puede quitar todos los archivos si no se pasa como argumento ningun archivo.
- `remote`: Muestra el registro de commits del server remoto.
- `branch <nameBranch>`: Permite crear una nueva rama de trabajo. Si no se especifica ningun argumento, muestra la lista de ramas disponibles.
- `chekcout <nameBranch>`: Permite intercambiar entre una rama u otra. 
- `cls`: Limpia la consola. 

## Diagrama de clases
![Diagrama UML](./SisorgGit/Resources/SisorgGitUML.drawio.png)

## Ejecuci�n de Tests

Para ejecutar los tests unitarios, sigue estos pasos:

1. Navega al directorio del proyecto de tests (TestSimuladorGit):
`cd TestSimuladorGit`
2. Ejecuta el comando de dotnet test:
`dotnet test`

Esto ejecutar� todos los tests unitarios en el proyecto y mostrar� los resultados en la consola.

## Pruebas Disponibles

El proyecto de tests incluye pruebas para las siguientes funcionalidades:

- Prueba 1: La funcion add debe agregar archivos al area de preparaci�n.
- Prueba 2: La funcion add no debe agregar archivos repetidos al area de preparaci�n.
- Prueba 3: La funcion reset debe remover el archivo especficado del area de preparaci�n.
- Prueba 4: La funcion reset debe remover todos los archivos del area de preparaci�n si no se le pasa parametros.
- Prueba 5: La funcion commit no debe realizar el commit si no hay archivos en el area de preparaci�n.


## Proceso de Despliegue en la Nube utilizando Docker y AWS

Para lograr el despliegue de la aplicaci�n utilizando la arquitectura en la nube, se siguieron los siguientes pasos:

### Dockerizaci�n de la Aplicaci�n:
- Se cre� un Dockerfile para definir c�mo construir la imagen Docker de la aplicaci�n. Este mismo se encuentra disponible en el repositorio.
- La aplicaci�n se encapsul� en un contenedor Docker para asegurar la portabilidad y consistencia del entorno.


### Subida de la Imagen a Docker Hub:
- Una vez construida la imagen Docker, se subi� al registro p�blico de im�genes Docker, Docker Hub.
- Esto permiti� disponer de la imagen de la aplicaci�n en un repositorio centralizado y accesible desde cualquier m�quina que ejecute Docker.


### Provisi�n de una Instancia EC2 en AWS:
- Se lanz� una instancia EC2 en Amazon Web Services (AWS) para alojar la aplicaci�n en la nube. La instancia EC2 se configur� con una plataforma de Linux.


### Configuraci�n del Entorno Docker en la VM:
- Una vez que la instancia EC2 estuvo en funcionamiento, se configur� el entorno Docker en la m�quina virtual.

### Descarga de la Imagen Docker y Ejecuci�n del Contenedor:
- Finalmente, se descarg� la imagen Docker de la aplicaci�n desde Docker Hub a la instancia EC2.
- Se ejecut� el contenedor Docker en la instancia EC2 en modo interactivo para que la aplicaci�n funcione correctamente con el siguiente comando: `docker run -it aluizaga/simulator_git`, lo que permiti� que la aplicaci�n estuviera disponible para su acceso y uso.

## Contacto