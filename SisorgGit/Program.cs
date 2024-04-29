// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using SisorgGit.Controller;
using SisorgGit.Models;
using SisorgGit.View;

//Console.WriteLine("Hello, World!");

class Program
{
    static void Main(string[] args)
    {
        string usersDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Users");
        
        if (!Directory.Exists(usersDirectory))
        {
            // Si no existe, crearla
            Directory.CreateDirectory(usersDirectory);
        }


        var userView = new UserView();

        // Un harcodeo del user
        var user = new User("Admin");

        // Si no hay un archivo de admin, crearlo
        // Armar directorio
        string fileUserInfoPath = Path.Combine(Directory.GetCurrentDirectory(), "Users", $"{user.Alias}.json");

        // Verificar si el archivo existe
        if (!File.Exists(fileUserInfoPath))            
            CreateUserInfoFile(user, fileUserInfoPath);
        else
        {
            // Si existe lo leo y seteo al User
            ReadUserInfoFileAndSetUser(user, fileUserInfoPath);
        }

        
        var controllerGit = new ControllerGit(userView, user);


        Console.Write("SimulatorGit - Sisorg\n");

        while (true)
        {
            controllerGit.Run();
        }

    }

    public static void ReadUserInfoFileAndSetUser(User user, string fileUserInfoPath)
    {
        try
        {
            // Leer todo el contenido del archivo en una cadena
            string content = File.ReadAllText(fileUserInfoPath);

            // Convertir la cadena JSON en una lista de objetos de tu modelo
            User userInfo = JsonConvert.DeserializeObject<User>(content);

            if(userInfo != null)
            {
                user.Stage = userInfo.Stage;

                user.CurrentBranch = userInfo.CurrentBranch;

                user.ListBranchs = userInfo.ListBranchs;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al procesar el archivo de commits: " + ex.Message);
        }
    }

    public static void CreateUserInfoFile(User user, string fileUserInfoPath)
    {
        // Serializar la lista de objetos JSON en un arreglo JSON
        string userJson = JsonConvert.SerializeObject(user, Formatting.Indented);

        // Escribir el contenido JSON en el archivo
        File.WriteAllText(fileUserInfoPath, userJson);
    }
}