using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ConsoleTodo.Command.Result {
    public class SuccesTodoCommandResult : ITodoCommandResult {
        private List<TodoTask> result;
        private string message;
        private List<string> args;
        public SuccesTodoCommandResult(List<TodoTask> result,List<string> args,string message) {
            this.result = result;
            this.message = message;
            this.args = args;
        }

        public List<string> GetArgs() {
            return args;
        }

        public string GetResultMessage() {
            return message;
        }

        public List<TodoTask> GetTodoCommandResult() {
            return result;
        }
    }
}
