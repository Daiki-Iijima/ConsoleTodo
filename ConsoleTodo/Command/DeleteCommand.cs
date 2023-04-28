using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class DeleteCommand:BaseCommand {

        public DeleteCommand(ITodo todo) : base("delete",todo) {
        }

        public override ICommandResult ExcuteFunc() {
            List<int> nums = new List<int>();
            foreach (var argStr in arg) {
                if (int.TryParse(argStr, out int parseInt)) {
                    nums.Add(parseInt);
                } else {
                    nums = null;
                    break;
                }
            }

            if (nums == null) {

                return new ErrorCommandResult();
            }

            return new SuccesTodoCommandResult(todo.Delete(nums), arg, "成功");

        }
    }
}
