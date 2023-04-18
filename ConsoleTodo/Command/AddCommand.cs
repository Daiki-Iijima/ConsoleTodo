using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class AddCommand {

        public string WakeWord { get; private set; }

        public Action<string> ExcuteAction { get; set; }

        private List<string> arg = new List<string>();

        public AddCommand(string wakeWord, Action<string> excuteAction) {
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

        /// <summary>
        /// 実行できたか
        /// 引数を主にチェック
        /// </summary>
        public bool Execute() {
            if (arg[0] != null) {
                ExcuteAction?.Invoke(arg[0]);
                return true;
            } else {
                return false;
            }
        }
    }
}
