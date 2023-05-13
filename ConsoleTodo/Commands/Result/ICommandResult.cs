using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo {
    public interface ICommandResult {
        string CommandName { get; }
        List<string> GetArgs();
        string GetResultMessage();
    }
}
