using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command.Result {
    public class ErrorCommandResult : ICommandResult {
        private string message;
        public ErrorCommandResult(string message = "Error") {
            this.message = message;
        }

        public List<string> GetArgs() {
            return new List<string>();
        }

        public string GetResultMessage() {
            return message;
        }
    }
}
