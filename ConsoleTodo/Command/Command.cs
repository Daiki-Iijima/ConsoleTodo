using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class Command {
        public Action<string> AddEvent { get; set; }
        public Action<int> RemoveEvenet { get; set; }

        public bool CheckCommand(string commandStr) {
            AddCommand addCommand = new AddCommand("add", AddEvent);
            RemoveCommand removeCommand = new RemoveCommand("remove", RemoveEvenet);

            bool commandResult = false;

            if (addCommand.Check(commandStr)) {
                commandResult = addCommand.Execute();
            }

            if (removeCommand.Check(commandStr)) {
                commandResult = removeCommand.Execute();
            }

            return commandResult;
        }
    }
}
