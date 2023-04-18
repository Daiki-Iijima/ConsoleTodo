using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public abstract class Command {

        public string WakeWord { get; private set; }

        protected List<string> arg = new List<string>();

        public Command(string wakeWord) {
            WakeWord = wakeWord;
        }

        public bool Check(string commandStr) {
            List<string> commandAry = SplitCommnad(commandStr);

            if (commandAry[0] == WakeWord) {
                arg = commandAry.GetRange(1, commandAry.Count - 1);
                return true;
            }

            return false;
        }

        public abstract bool Execute();

        private List<string> SplitCommnad(string commandStr) {
            return commandStr.Split(' ').ToList();
        }
    }
}
