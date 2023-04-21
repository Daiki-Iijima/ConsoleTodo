using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public abstract class Command<T> : ICommand {

        public string WakeWord { get; private set; }

        protected List<string> arg = new List<string>();

        public Action<T> ExcuteAction { get; set; }

        public Command(string wakeWord,Action<T> excuteAction) {
            WakeWord = wakeWord;
            ExcuteAction = excuteAction;
        }

        private string Parse(string commandStr) {
            List<string> commandAry = SplitCommnad(commandStr);
            arg = commandAry.GetRange(1, commandAry.Count - 1);
            return commandAry[0];
        }

        public abstract bool Run();

        public bool Execute(string commandStr) {
            string command = Parse(commandStr);
            if (command == WakeWord) {
                return Run();
            }
            return false;
        }

        private List<string> SplitCommnad(string commandStr) {
            return commandStr.Split(' ').ToList();
        }
    }
}
