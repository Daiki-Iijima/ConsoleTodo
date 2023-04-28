using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class AddCommand : BaseCommand {

        public AddCommand(ITodo todo) : base("add",todo) {
        }

        /// <summary>
        /// 実行できたか
        /// 引数を主にチェック
        /// </summary>
        public override ICommandResult ExcuteFunc() {
            if (arg[0] != null) {
                List<TodoTask> tasks = new List<TodoTask>();
                foreach (string taskName in arg) {
                    tasks = todo.Add(new TodoTask(taskName));
                }
                return new SuccesTodoCommandResult(tasks, arg, "成功");
            }

            return new ErrorCommandResult("追加コマンドエラー");
        }
    }
}
