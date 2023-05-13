using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command.Result {
    public interface ITodoCommandResult : ICommandResult{
        List<TodoTask> GetTodoCommandResult();
    }
}
