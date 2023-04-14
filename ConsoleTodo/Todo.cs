using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo {
    public class Todo {

        private List<TodoTask> tasks = new List<TodoTask>();

        public Todo() { }

        public List<TodoTask> add(TodoTask todoTask) {
            tasks.Add(todoTask);
            return tasks;
        }

        public List<TodoTask> GetList(int no = -1) {
            if (no != -1) {
                return new List<TodoTask>() { tasks[no] };
            }

            return tasks;
        }
    }
}
