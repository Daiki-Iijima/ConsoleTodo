using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class ShowCommand : BaseCommand {
        public ShowCommand(string wakeWord, ITodo todo) : base(wakeWord, todo) {
        }

        public override ICommandResult ExcuteFunc() {
            return new SuccesTodoCommandResult(todo.ActiveList(),arg,"成功");
        }
    }
}
