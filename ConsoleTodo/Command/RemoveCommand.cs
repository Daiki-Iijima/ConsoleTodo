using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class RemoveCommand:Command<int> {

        public RemoveCommand(string wakeWord, Action<int> excuteAction) : base(wakeWord, excuteAction) {
        }

        public override bool Run() {
            if (int.TryParse(arg[0], out int parseInt)) {
                ExcuteAction?.Invoke(parseInt);
                return true;
            } else {
                return false;
            }
        }
    }
}
