using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Shell;
using Microsoft.VisualStudio.Modeling.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SPbSU.RobotsLanguage
{
    /// <summary>
    /// Double-derived class to allow easier code customization.
    /// </summary>
    /// 
    internal partial class RobotsLanguageCommandSet
    {
        private Guid guidCustomMenuCmdSet = new Guid("7F6BE63C-313B-4C60-9AB7-7B6EA2E3C52B");
        private const int cmdidMyContextMenuCommand = 1;
        private const int cmdidSendMenuCommand = 2;
        private void OnStatusMyContextMenuCommand(object sender, EventArgs e)
        {
            MenuCommand command = sender as MenuCommand;
            command.Visible = command.Enabled = false;
            if (IsDiagramSelected())
            {
                command.Visible = command.Enabled = true;
            }
        }
        private void OnMenuMyContextMenuCommand(object sender, EventArgs e)
        {
            MenuCommand command = sender as MenuCommand;
            Store store = this.CurrentDocData.Store; 
            using (Transaction transaction =
                 store.TransactionManager.BeginTransaction("My command"))
            {
                this.CurrentRobotsLanguageDocData.ValidationController.Validate(this.CurrentDocData.RootElement, ValidationCategories.Menu);
                if (CurrentRobotsLanguageDocData.ValidationController.ErrorMessages.Count == 0)
                {
                    RuntimeTextTemplate1 run = new RuntimeTextTemplate1((RobotModel)this.CurrentDocData.RootElement);
                    String pageContent = run.TransformText();
                    System.IO.File.WriteAllText(this.CurrentRobotsLanguageDocView.CurrentDiagram.Name+".js", pageContent);
                    //this.CurrentRobotsLanguageDocData.Load(this.CurrentRobotsLanguageDocView.CurrentDiagram.Name + ".js", 3, 1);
                }
                transaction.Commit();  
            }
        }
        protected override IList<MenuCommand> GetMenuCommands()
        {
            // Get the list of generated commands.  
            IList<MenuCommand> commands = base.GetMenuCommands();
            // Add a custom command:  
            DynamicStatusMenuCommand myContextMenuCommand =
              new DynamicStatusMenuCommand(
                new EventHandler(OnStatusMyContextMenuCommand),
                new EventHandler(OnMenuMyContextMenuCommand),
                new CommandID(guidCustomMenuCmdSet, cmdidMyContextMenuCommand));
            commands.Add(myContextMenuCommand);

            DynamicStatusMenuCommand sendMenuCommand =
              new DynamicStatusMenuCommand(
                new EventHandler(OnStatusMyContextMenuCommand),
                new EventHandler(OnMenuSendMenuCommand),
                new CommandID(guidCustomMenuCmdSet, cmdidSendMenuCommand));
            commands.Add(sendMenuCommand);
            // Add more commands here.  
            return commands;
        }

        private void OnMenuSendMenuCommand(object sender, EventArgs e)
        {
            MenuCommand command = sender as MenuCommand;
            Store store = this.CurrentDocData.Store;
            using (Transaction transaction =
                 store.TransactionManager.BeginTransaction("Send command"))
            {
                this.CurrentRobotsLanguageDocData.ValidationController.Validate(this.CurrentDocData.RootElement, ValidationCategories.Menu);
                if (CurrentRobotsLanguageDocData.ValidationController.ErrorMessages.Count == 0)
                {
                    RuntimeTextTemplate1 run = new RuntimeTextTemplate1((RobotModel)this.CurrentDocData.RootElement);
                    String pageContent = run.TransformText();
                    //System.IO.File.WriteAllText(this.CurrentRobotsLanguageDocView.CurrentDiagram.Name + ".js", pageContent);
                    string hostname = ((RobotModel) CurrentDocData.RootElement).Hostname;

                    using (TcpClient client = new TcpClient(hostname, 8888))
                    using (BinaryWriter writer = new BinaryWriter(client.GetStream()))
                    {
                        writer.Write("directScript: " + pageContent);
                    }
                }
                transaction.Commit();
            }
        }
        
    }
}
