using ConsoleTodo.Command;
using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Commands {
    public class ProgressCommand : BaseCommand {
        public ProgressCommand(ITodo todo) : base("progress", todo) {
        }

        public override ICommandResult ExcuteFunc() {

            float allTaskCount = todo.GetAllList().Count;
            float doneListCount = todo.DoneList().Count;

            string progressStr = "100";

            //  ゼロ除算対策
            if (0 < allTaskCount) {
                progressStr = ((doneListCount / allTaskCount) * 100).ToString();
            }

            return new SuccesTodoCommandResult(WakeWord, todo.GetAllList(), arg, progressStr);
        }

        public override string GetHelp() {
            return "進捗 : progress";
        }
    }
}
