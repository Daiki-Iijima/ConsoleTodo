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
            if (commandStr.Contains("add")) {
                string[] commandAry = commandStr.Split(' ');
                AddEvent?.Invoke(commandAry[1]);
                return true;
            }

            if (commandStr.Contains("remove")) {
                string[] commandAry = commandStr.Split(' ');
                if (int.TryParse(commandAry[1], out int i)) {
                    RemoveEvenet?.Invoke(i);
                    return true;
                } else {
                    return false;
                }
            }

            return false;
        }
    }
}
