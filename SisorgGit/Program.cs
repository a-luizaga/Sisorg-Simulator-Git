// See https://aka.ms/new-console-template for more information
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
        var user = new User("Alex");        
        
        var controllerGit = new ControllerGit(userView, user);


        Console.Write("SimulatorGit - Sisorg\n");

        while (true)
        {
            controllerGit.Run();
        }

    }
}