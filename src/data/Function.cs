using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datapackager.src.data
{
    internal class Function
    {
        private string path;
        private string packNamespace;
        private List<string> commands;

        public Function(string path, string packNamespace)
        {
            this.path = path;
            this.packNamespace = packNamespace;
            this.commands = new List<string>();
        }

        public Function(string name, string packNamespace, string command) : this(name, packNamespace)
        {
            addCommand(command);
        }

        public string getFilePath()
        {
            return packNamespace + "\\functions\\" + path + ".mcfunction";
        }

        public void addCommand(string command)
        {
            commands.Add(command);
        }

        public List<string> getCommands()
        {
            return commands;
        }

        public string getCommandsString()
        {
            string functionString = "";
            foreach (string command in commands)
            {
                functionString += command + "\n";
            }
            return functionString;
        }

        public string getFunctionPath()
        {
            return packNamespace + ":" + path.Replace("\\", "/");
        }
    }
}
