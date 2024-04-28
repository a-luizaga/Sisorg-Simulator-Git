using Microsoft.VisualBasic;
using SisorgGit.Models;
using SisorgGit.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SisorgGit.Utilities;
using System.Net.Http.Headers;
using Microsoft.Win32;

namespace SisorgGit.Controller
{
    public class ControllerGit
    {

        public readonly UserView view;
        public User user;

        public ControllerGit(UserView view, User user)
        {
            this.view = view;
            this.user = user;
        }


        public void Run()
        {
            var instructionFromKeyboard = view.ReadFromKeyboard();

            var arrayIntruction = instructionFromKeyboard.Split(' ');

            string command = arrayIntruction[0];

            // Validar Comando en listas de comandos
            if (!CommandConstants.IsAValidCommand(command))
            {
                Console.WriteLine("Comando no reconocido.");
                return;
            }

            var instruction = GenerateInstruction(command, arrayIntruction);

            string result;

            switch (command)
            {
                case "add":

                    result = AddFunction(instruction.Arguments);
                    Console.WriteLine(result);
                    break;
                case "status":

                    if (instruction.Arguments.Length > 0)
                        Console.WriteLine("Este comando no admite parametros");
                    else
                        StatusFunction();

                    break;
                case "reset":

                    result = ResetFunction(instruction.Arguments);
                    Console.WriteLine(result);
                    break;
                case "commit":

                    // Validar stage
                    if (user.Stage.Count > 0)
                    {
                        string msg = string.Join(" ", instruction.Arguments);

                        var msgCommit = ValidateMsgCommit(msg);

                        if (msgCommit == "")
                            Console.WriteLine("Error en comando.  Solo se debe indicar el mje del commit encerrado entre comillas dobles");
                        else
                            CommitFunction(msgCommit);
                    }
                    else
                        Console.WriteLine("No se puede realizar el commit. El area de preparacion esta vacio");

                    break;

                case "push":

                    if (instruction.Arguments.Length > 0)
                        Console.WriteLine("Este comando no admite parametros");
                    else                        
                        PushFunction();
                    
                    break;

                case "log":

                    if (instruction.Arguments.Length > 0)
                        Console.WriteLine("Este comando no admite parametros");
                    else
                        LogFunction();

                    break;

                case "remote":

                    if (instruction.Arguments.Length > 0)
                        Console.WriteLine("Este comando no admite parametros");
                    else
                        RemoteFunction();

                    break;

                case "help":

                    if (instruction.Arguments.Length > 0)
                        Console.WriteLine("Este comando no admite parametros");
                    else
                        HelpCommand.ShowHelp();

                    break;

                case "exit":

                    if (instruction.Arguments.Length > 0)
                        Console.WriteLine("Este comando no admite parametros");
                    else
                        Environment.Exit(0);

                    break;                

                default:
                    Console.WriteLine("Comando no reconocido.");
                    break;
            }

        }

        public string ValidateMsgCommit(string msgCommit)
        {

            string msg = "";

            if (msgCommit.Length > 0 && msgCommit[0] == '\"' && msgCommit[msgCommit.Length - 1] == '\"')
            {
                // Quitar el primer carácter
                string removeFirstCharacter = msgCommit.Substring(1);

                // Quitar el último carácter
                msg = removeFirstCharacter.Substring(0, removeFirstCharacter.Length - 1);
            }

            return msg;
        }

        public Instruction GenerateInstruction(string command, string[] arrayIntruction)
        {
            // Crear una lista de strings
            List<string> arguments = new List<string>();

            for (int i = 1; i < arrayIntruction.Length; i++)
            {
                if (arrayIntruction[i] != "")
                    arguments.Add(arrayIntruction[i]);
            }

            var intrucution = new Instruction(command, arguments.ToArray());

            return intrucution;

        }

        public string AddFunction(string[] arguments)
        {
            string msg;

            if (arguments.Length != 0)
            {

                // Se podria agregar una verificacion de la sintaxis del
                // archivo file.txt

                foreach (var item in arguments)
                {
                    if (!user.Stage.Contains(item))
                        user.Stage.Add(item);
                }

                msg = arguments.Length > 1 ?
                    "El archivo fue agregado al area de operacion" :
                    "Los archivos fueron agregados al area de operacion";

            }
            else
                msg = "No se espifico ningun archivo";


            return msg;
        }

        public string StatusFunction()
        {
            Console.WriteLine("Stage: ");
            foreach (var item in user.Stage)
            {
                Console.WriteLine(item);
            }


            return "Ok";
        }

        public string ResetFunction(string[] arguments)
        {
            string msg;

            if (arguments.Length != 0)
            {
                foreach (var file in arguments)
                {
                    if (user.Stage.Contains(file))
                        user.Stage.Remove(file);
                    else
                    {
                        // TODO: informar que ese file no existe
                    }
                }

                msg = "Los siguientes archivos fueron removidos del area de preaparacion";
                // TODO: hacer la lista de los archivos que fueron removidos


            }
            else
            {

                user.Stage.Clear();

                msg = "Todos los archivos del stage fueron removidos";
            }


            return msg;
        }

        public void CommitFunction(string msgCommit)
        {

            DateTime dateCommit = DateTime.Now;

            // TO DO: ID commit hardcodeado :/

            var commit = new Commit("1", msgCommit, dateCommit, user.Stage.ToArray());


            // Armar directorio
            string commitsUserPath = Path.Combine(Directory.GetCurrentDirectory(), "Users", "commits.json");

            try
            {
                // Verificar si el archivo existe
                if (!File.Exists(commitsUserPath)) // Aca hay que hacer mejor la pregunta :B
                {
                    // Si el archivo no existe, crearlo y escribir el commit
                    using (StreamWriter sw = File.CreateText(commitsUserPath))
                    {
                        List<Commit> listCommits = new()
                        {
                            commit
                        };

                        // Serializar el commit a formato JSON
                        string commitJson = JsonConvert.SerializeObject(listCommits, Formatting.Indented);

                        sw.WriteLine(commitJson);
                    }
                }
                else
                {
                    // Si el archivo ya existe...

                    // Leer el contenido del archivo en una cadena
                    string content = File.ReadAllText(commitsUserPath);

                    // Deserializar la cadena JSON en una lista de objetos JSON
                    var listCommit = JsonConvert.DeserializeObject<List<Commit>>(content);


                    if (listCommit != null)
                    {
                        listCommit.Add(commit);

                        // Serializar la lista de objetos JSON en un arreglo JSON
                        string commitJson = JsonConvert.SerializeObject(listCommit, Formatting.Indented);

                        // Escribir el contenido JSON en el archivo
                        File.WriteAllText(commitsUserPath, commitJson);
                    }

                }

                user.Stage.Clear();

                Console.WriteLine("Se ha registrado el commit con exito");
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                Console.WriteLine("Error al registrar el commit en el archivo: " + ex.Message);
            }

        }

        public void LogFunction()
        {

            // Armar directorio al archivo de commits locales
            string pathLocalCommits = Path.Combine(Directory.GetCurrentDirectory(), "Users", "commits.json");

            PrintCommits(pathLocalCommits);
           
        }

        public void PushFunction()
        {
            // Armar directorio
            string commitsUserPath = Path.Combine(Directory.GetCurrentDirectory(), "Users", "commits.json");


            // Verificar si el archivo existe
            if (File.Exists(commitsUserPath))
            {

                try
                {
                    // Leer todo el contenido del archivo en una cadena
                    string content = File.ReadAllText(commitsUserPath);

                    // Convertir la cadena JSON en una lista de objetos de tu modelo
                    List<Commit> listLocalCommits = JsonConvert.DeserializeObject<List<Commit>>(content);

                    if (listLocalCommits != null)
                    {
                        if (listLocalCommits.Count == 0)
                            Console.WriteLine("El registro de commits esta vacio");
                        else
                        {
                            // Pushear en una lista y persistirlo en un archivo como simulacion de servidor remoto

                            // Serializar la lista de objetos JSON en un arreglo JSON
                            string commitJson = JsonConvert.SerializeObject(listLocalCommits, Formatting.Indented);

                            // Armar directorio
                            string serverRemotePath = Path.Combine(Directory.GetCurrentDirectory(), "Users", "commitsRemote.json");

                            // Verificar si el archivo existe
                            if (!File.Exists(serverRemotePath))
                            {
                                try
                                {
                                    // Creamos el archivo vacío
                                    File.Create(serverRemotePath).Close();                                    
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Ocurrió un error al crear el archivo: " + ex.Message);
                                }
                            }

                            // Escribir el contenido JSON en el archivo
                            File.WriteAllText(serverRemotePath, commitJson);

                            Console.WriteLine("Los commits locales han sido enviados al servidor remoto");

                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al procesar el archivo de commits: " + ex.Message);
                }

            }
            else
            {
                Console.WriteLine("El registro de commits esta vacio");
            }
        }

        public void RemoteFunction()
        {

            // Armar directorio al archivo de commits remoto
            string pathRemoteCommits = Path.Combine(Directory.GetCurrentDirectory(), "Users", "commitsRemote.json");

            PrintCommits(pathRemoteCommits);
            
        }


        public void PrintCommits(string pathCommitsFile)
        {
            // Verificar si el archivo existe
            if (File.Exists(pathCommitsFile))
            {

                try
                {
                    // Leer todo el contenido del archivo en una cadena
                    string content = File.ReadAllText(pathCommitsFile);

                    // Convertir la cadena JSON en una lista de objetos de tu modelo
                    List<Commit> listCommits = JsonConvert.DeserializeObject<List<Commit>>(content);

                    if (listCommits != null)
                    {
                        if (listCommits.Count == 0)
                            Console.WriteLine("El registro de commits esta vacio");
                        else
                        {
                            // Invertir la lista
                            listCommits.Reverse();

                            // Procesar los registros, comenzando desde el último hasta el primero
                            foreach (var registro in listCommits)
                            {
                                Console.WriteLine("\nMensaje Commit: " + registro.MsgCommit);
                                Console.WriteLine("Fecha Commit: " + registro.DateCommit);
                                Console.WriteLine("Archivos modificados: ");

                                foreach (var file in registro.FilesCommit)
                                {
                                    Console.WriteLine("\t" + file);
                                }
                                //Console.WriteLine("");
                            }
                        }

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al procesar el archivo de commits: " + ex.Message);
                }

            }
            else
            {
                Console.WriteLine("El registro de commits esta vacio");
            }
        }


        public int GetCountLocalsCommits()
        {
            int countCommits = 0;

            // Armar directorio al archivo de commits locales
            string pathLocalCommits = Path.Combine(Directory.GetCurrentDirectory(), "Users", "commits.json");

            // Verificar si el archivo existe
            if (File.Exists(pathLocalCommits))
            {

                try
                {
                    // Leer todo el contenido del archivo en una cadena
                    string content = File.ReadAllText(pathLocalCommits);

                    // Convertir la cadena JSON en una lista de objetos de tu modelo
                    List<Commit> listCommits = JsonConvert.DeserializeObject<List<Commit>>(content);

                    countCommits = listCommits.Count;

                    return countCommits;


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al procesar el archivo de commits: " + ex.Message);

                    countCommits = -1;

                    return countCommits;
                }

            }
            else
            {
                return countCommits;
            }

        }

    }
}
