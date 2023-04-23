using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class AddCommand : BaseCommand {

        public AddCommand(string wakeWord,ITodo todo) : base(wakeWord,todo) {
        }

        /// <summary>
        /// 実行できたか
        /// 引数を主にチェック
        /// </summary>
        public override ICommandResult ExcuteFunc() {
            if (arg[0] != null) {
                List<TodoTask> tasks = todo.Add(new TodoTask(arg[0]));
                return new SuccesTodoCommandResult(tasks, arg,"成功");
            }

            return new ErrorCommandResult("追加コマンドエラー");
        }
    }
}
