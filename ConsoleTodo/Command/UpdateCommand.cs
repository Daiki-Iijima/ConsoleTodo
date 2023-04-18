using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class UpdateCommand : Command {
        public Action<int, string> ExcuteAction { get; set; }

        public UpdateCommand(string wakeWord,Action<int,string> executeAction) : base(wakeWord) {
            ExcuteAction = executeAction;
        }

        public override bool Execute() {

            if (arg.Count % 2 == 0 && !string.IsNullOrEmpty(arg[0]) && !string.IsNullOrEmpty(arg[1]) && int.TryParse(arg[0], out int argInt)) {
                ExcuteAction?.Invoke(argInt,arg[1]);
                return true;
            }

            return false;
        }
    }
}
