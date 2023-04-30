using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command.Result {
    public class ErrorCommandResult : ICommandResult {
        private string message;
        public string CommandName { get; private set; }

        public ErrorCommandResult(string commnadName,string errorMessage = "Error") {
            this.message = errorMessage;
            this.CommandName = commnadName;
        }

        public List<string> GetArgs() {
            return new List<string>();
        }

        public string GetResultMessage() {
            return message;
        }
    }
}
