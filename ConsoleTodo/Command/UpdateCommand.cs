using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class UpdateCommand : BaseCommand {

        public UpdateCommand(ITodo todo) : base("update",todo) {
        }

        public override ICommandResult ExcuteFunc() {
            if (arg.Count % 2 != 0) {
                return new ErrorCommandResult();
            }

            //  処理できない情報が入っている場合
            if (arg.All(value => string.IsNullOrEmpty(value))) {
                return new ErrorCommandResult();
            }

            int targetNum = 0;
            Dictionary<int, string> updateTaskPair = new Dictionary<int, string>();
            for (int i = 0; i < arg.Count; i++) {
                if (i % 2 == 0) {
                    if (int.TryParse(arg[i], out int argInt)) {
                        targetNum = argInt;
                    }
                } else {
                    updateTaskPair.Add(targetNum, arg[i]);
                }
            }

            var tasks = todo.Update(updateTaskPair);

            return new SuccesTodoCommandResult(tasks, arg, "成功");
        }
    }
}
