using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class AddCommand : Command {

        public Action<string> ExcuteAction { get; set; }

        public AddCommand(string wakeWord, Action<string> excuteAction) : base(wakeWord) {
            ExcuteAction = excuteAction;
        }

        /// <summary>
        /// 実行できたか
        /// 引数を主にチェック
        /// </summary>
        public override bool Execute() {
            if (arg[0] != null) {
                ExcuteAction?.Invoke(arg[0]);
                return true;
            } else {
                return false;
            }
        }
    }
}
