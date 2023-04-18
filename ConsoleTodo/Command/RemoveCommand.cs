using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class RemoveCommand {
        public string WakeWord { get; private set; }
        public Action<int> ExcuteAction { get; set; }

        private List<string> arg = new List<string>();

        public RemoveCommand(string wakeWord, Action<int> excuteAction) {
            WakeWord = wakeWord;
            ExcuteAction = excuteAction;
        }

        public bool Check(string command) {
            string[] commandAry = command.Split(' ');
            if (commandAry[0].Contains(WakeWord)) {
                arg = commandAry.ToList().GetRange(1, commandAry.Length - 1);
                return true;
            } else {
                return false;
            }
        }

        public bool Execute() {
            if (int.TryParse(arg[0], out int parseInt)) {
                ExcuteAction?.Invoke(parseInt);
                return true;
            } else {
                return false;
            }
        }
    }
}
