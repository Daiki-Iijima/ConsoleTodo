using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class ListCommand : BaseCommand {
        public ListCommand(ITodo todo) : base("list", todo) {
        }

        public override ICommandResult ExcuteFunc() {
            return new SuccesTodoCommandResult(todo.ActiveList(),arg,"成功");
        }
    }
}
