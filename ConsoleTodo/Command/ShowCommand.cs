using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class ShowCommand : Command<object> {

        public ShowCommand(string wakeWord,Action<object> executeAction) : base(wakeWord,executeAction) {
        }

        public override bool Run() {
            ExcuteAction?.Invoke(null);

            return true;
        }
    }
}
