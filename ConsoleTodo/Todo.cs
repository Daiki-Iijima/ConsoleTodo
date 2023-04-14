using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo {
    public class TodoTask {

        private string taskName;

        public TodoTask(string str) {
            taskName = str;
        }

        public override bool Equals(object obj) {
            if (obj is TodoTask task) {
                return taskName.Equals(task.taskName);
            }

            return false;
        }
    }
}
