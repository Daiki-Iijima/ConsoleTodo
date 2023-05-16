using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Display {
    public class ConsoleDisplay : IDisplay {
        public void PrintError(ICommandResult result) {
            Console.WriteLine(result.GetResultMessage());
        }

        public void PrintTasks(List<TodoTask> tasks) {
            int No = 0;
            foreach (TodoTask task in tasks) {
                Console.WriteLine(No + ":" + task.ToString());
                No++;
            }
        }
    }
}
