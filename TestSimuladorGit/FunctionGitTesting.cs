using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using SisorgGit.Controller;
using SisorgGit.Models;
using SisorgGit.View;

namespace TestSimuladorGit
{
    public class FunctionGitTesting
    {

        private readonly ControllerGit _controllerGit;        

        public FunctionGitTesting()
        {
            // Puedes crear mocks o stubs para tus dependencias si es necesario
            var userView = new Mock<UserView>();
            var user = new Mock<User>("Admin");

            _controllerGit = new ControllerGit(userView.Object, user.Object);
            
        }

        [Fact]
        public void Add_ShouldAddFileToStagingArea()
        {
            // Arrange
            string fileName = "example.txt";

            string[] listFileName = { fileName };

            // Act
            _controllerGit.AddFunction(listFileName);

            // Assert
            Assert.Contains(fileName, _controllerGit.user.Stage);
        }

        [Fact]
        public void Add_DuplicateFile_NotAddedToStagingArea()
        {
            // Arrange
            string fileName = "example.txt";
            string[] listFileName = { fileName };

            // Act
            _controllerGit.AddFunction(listFileName);
            _controllerGit.AddFunction(listFileName);
            _controllerGit.AddFunction(listFileName);

            // Assert
            Assert.Single(_controllerGit.user.Stage); // Asserting that the file is added only once
            Assert.Contains(fileName, _controllerGit.user.Stage); // Asserting that the file is in the staging area
        }

        [Fact]
        public void Reset_ShouldRemoveFileFromStagingArea()
        {
            // Arrange
            string fileName = "file1.txt";
            string[] listFileName = { fileName };
            
            _controllerGit.AddFunction(listFileName);

            // Act
            _controllerGit.ResetFunction(listFileName);

            // Assert
            // Verificar que el archivo ya no esté en el área de preparación (stage)
            Assert.DoesNotContain(fileName, _controllerGit.user.Stage);
        }

        [Fact]
        public void Reset_WithoutParameters_ShouldClearStage()
        {
            // Arrange
            string fileName1 = "file1.txt";
            string fileName2 = "file2.txt";
            string[] listFileNames = { fileName1, fileName2 };

            // Agregar archivos al área de preparación (stage)
            _controllerGit.AddFunction(listFileNames);

            
            string[] emptyArray = Array.Empty<string>();


            // Act
            _controllerGit.ResetFunction(emptyArray);

            // Assert
            // Verificar que el área de preparación (stage) esté vacía
            Assert.Empty(_controllerGit.user.Stage);
        }

        [Fact]
        public void Commit_DoNotCommitWhioutFilesInStage()
        {
            // Act
            _controllerGit.CommitFunction("msg commit");
            

            // Assert

            // Se verifica que no hay ningun commit realizado en el registro de commits locales
            Assert.Equal(0, _controllerGit.GetCountLocalsCommits());
            
        }



    }
}