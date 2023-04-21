using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class UpdateCommand : Command<Dictionary<int, string>> {

        public UpdateCommand(string wakeWord,Action<Dictionary<int, string>> executeAction) : base(wakeWord,executeAction) {
            ExcuteAction = executeAction;
        }

        public override bool Run() {

            if (arg.Count % 2 == 0 && !string.IsNullOrEmpty(arg[0]) && !string.IsNullOrEmpty(arg[1]) && int.TryParse(arg[0], out int argInt)) {
                ExcuteAction?.Invoke(new Dictionary<int, string> { { argInt, arg[1] } });
                return true;
            }

            return false;
        }
    }
}
