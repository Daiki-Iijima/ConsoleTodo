using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Display {
    public interface IDisplay {
        void PrintTasks(List<TodoTask> tasks,bool showDone);
        void PrintError(ICommandResult result);
        void PrintProgress(float progress);
    }
}
