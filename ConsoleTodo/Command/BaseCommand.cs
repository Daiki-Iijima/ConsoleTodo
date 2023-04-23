using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public abstract class BaseCommand : ICommand {

        public string WakeWord { get; private set; }

        protected List<string> arg = new List<string>();

        protected ITodo todo;

        public BaseCommand(string wakeWord,ITodo todo) {
            WakeWord = wakeWord;
            this.todo = todo;
        }

        private string Parse(string commandStr) {
            List<string> commandAry = SplitCommnad(commandStr);
            arg = commandAry.GetRange(1, commandAry.Count - 1);
            return commandAry[0];
        }

        /// <summary>
        /// コマンドが発火したときの実装を行う
        /// </summary>
        public abstract ICommandResult ExcuteFunc();

        public ICommandResult Execute(string commandStr) {
            string command = Parse(commandStr);
            if (command == WakeWord) {
                 return ExcuteFunc();
            }

            return new ErrorCommandResult();
        }

        private List<string> SplitCommnad(string commandStr) {
            return commandStr.Split(' ').ToList();
        }
    }
}
