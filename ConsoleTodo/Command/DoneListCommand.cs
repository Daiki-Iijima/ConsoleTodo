using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class DoneListCommand : BaseCommand {

        public DoneListCommand(ITodo todo) : base("donelist", todo) {

        }
        public override ICommandResult ExcuteFunc() {
            //  文字列を数字に変換できるか
            if (!arg.All(str => int.TryParse(str, out int num))) {
                return new ErrorCommandResult(WakeWord);
            }

            //  変換
            List<int> nums = arg.Select(str => int.Parse(str)).ToList();

            //  処理実行
            List<TodoTask> result = todo.DoneList(nums);

            return new SuccesTodoCommandResult(WakeWord, result, arg, "成功");
        }
    }
}
