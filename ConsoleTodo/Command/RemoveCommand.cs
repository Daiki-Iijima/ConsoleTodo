using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class RemoveCommand:BaseCommand {

        public RemoveCommand(string wakeWord,ITodo todo) : base(wakeWord,todo) {
        }

        public override ICommandResult ExcuteFunc() {
            if (int.TryParse(arg[0], out int parseInt)) {
                return new SuccesTodoCommandResult(todo.Delete(new List<int> { parseInt }), arg, "成功");
            }

            return new ErrorCommandResult();
        }
    }
}
