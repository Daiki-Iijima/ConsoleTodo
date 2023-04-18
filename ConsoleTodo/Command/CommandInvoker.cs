using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class CommandInvoker {

        public List<Command> InvokeCommands = new List<Command>();

        public bool Invoke(string commandStr) {
            bool commandResult = false;

            foreach (Command command in InvokeCommands) {
                if (command.Check(commandStr)) {
                    commandResult = command.Execute();
                    break;
                }
            }

            return commandResult;
        }
    }
}
