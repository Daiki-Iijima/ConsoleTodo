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
                    //  引数に空白が含まれている場合エラー
                    if (string.IsNullOrEmpty(taskName)) {
                        return new ErrorCommandResult("空白は追加できません");
                    }

                    tasks.Add(new TodoTask(taskName));
                }
                tasks = todo.Add(tasks);
                return new SuccesTodoCommandResult(WakeWord, tasks, arg, "成功");
            }

            return new ErrorCommandResult(WakeWord,"追加コマンドエラー");
        }

        public override string GetHelp() {
            return "追加 : add [taskname] ..";
        }
    }
}
