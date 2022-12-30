using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datapackager.src.data
{
    internal class Function
    {
        private string name;
        private List<string> commands;

        public Function(string name)
        {
            this.name = name;
            this.commands = new List<string>();
        }

        public Function(string name, string command) : this(name)
        {
            addCommand(command);
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
    }
}
