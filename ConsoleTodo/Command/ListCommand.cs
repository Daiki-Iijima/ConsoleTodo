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
            if(arg.Count == 0) {
                return new SuccesTodoCommandResult(todo.ActiveList(), arg, "成功");
            }

            //  文字列を数字に変換できるか
            if (!arg.All(str => int.TryParse(str, out int num))) {
                return new ErrorCommandResult();
            }

            //  変換
            List<int> nums = arg.Select(str => int.Parse(str)).ToList();

            //  処理実行
            List<TodoTask> result = todo.ActiveList(nums);

            return new SuccesTodoCommandResult(result, arg, "成功");
        }
    }
}
