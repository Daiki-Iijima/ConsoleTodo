using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class RemoveCommand:Command {
        public Action<int> ExcuteAction { get; set; }

        public RemoveCommand(string wakeWord, Action<int> excuteAction):base(wakeWord) {
            ExcuteAction = excuteAction;
        }

        public override bool Execute() {
            if (int.TryParse(arg[0], out int parseInt)) {
                ExcuteAction?.Invoke(parseInt);
                return true;
            } else {
                return false;
            }
        }
    }
}
