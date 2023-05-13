using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public class CommandInvoker {

        public List<ICommand> InvokeCommands = new List<ICommand>();

        public ICommandResult Invoke(string commandStr) {
            foreach (ICommand command in InvokeCommands) {
                var commandResult = command.Execute(commandStr);
                //  成功の場合はルーを終了
                if (commandResult is SuccesTodoCommandResult) {
                    return commandResult;
                }
            }

            return new ErrorCommandResult("コマンドが見つかりませんでした");
        }
    }
}
