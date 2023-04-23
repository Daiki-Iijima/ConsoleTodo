using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class UpdateCommand : BaseCommand {

        public UpdateCommand(string wakeWord,ITodo todo) : base(wakeWord,todo) {
        }

        public override ICommandResult ExcuteFunc() {
            if (arg.Count % 2 == 0 && !string.IsNullOrEmpty(arg[0]) &&
                int.TryParse(arg[0], out int argInt) &&
                !string.IsNullOrEmpty(arg[1])) {
                var tasks = todo.Update(new Dictionary<int, string> { { argInt, arg[1] } });
                return new SuccesTodoCommandResult(tasks, arg, "成功");
            }

            return new ErrorCommandResult();
        }
    }
}
