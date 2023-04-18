using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class ShowCommand : Command {
        public Action ExcuteAction { get; set; }

        public ShowCommand(string wakeWord,Action executeAction) : base(wakeWord) {
            ExcuteAction = executeAction;
        }

        public override bool Execute() {
            ExcuteAction?.Invoke();

            return true;
        }
    }
}
