using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class CommandInvoker {

        public List<ICommand> InvokeCommands = new List<ICommand>();

        public bool Invoke(string commandStr) {
            bool commandResult = false;

            foreach (ICommand command in InvokeCommands) {
                commandResult = command.Execute(commandStr);
                if (commandResult) {
                    break;
                }
            }

            return commandResult;
        }
    }
}
