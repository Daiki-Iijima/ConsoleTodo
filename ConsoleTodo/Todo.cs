using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo {
    public class Todo {

        private List<TodoTask> tasks = new List<TodoTask>();

        public Todo() { }

        public List<TodoTask> Add(TodoTask todoTask) {
            tasks.Add(todoTask);
            return tasks;
        }

        public List<TodoTask> Delete(List<int> deleteList) {
            tasks = tasks.Where((task, i) =>!deleteList.Contains(i)).ToList();
            return tasks;
        }

        public List<TodoTask> List(List<int> noList = null) {
            //  すべて返す
            if (noList == null) {
                return tasks;
            }

            List<TodoTask> retTask = tasks.Where((task, i) => noList.Contains(i)).ToList();

            return retTask;
        }

        public List<TodoTask> Update(Dictionary<TodoTask, TodoTask> updateData) {
            List<TodoTask> retTasks = new List<TodoTask>();

            foreach(var task in tasks) {
                foreach (var keyData in updateData.Keys) {
                    if (task.Equals(keyData)) {
                        task.Update(updateData[keyData]);
                        retTasks.Add(task);
                    }
                }
            }

            return retTasks;
        }
    }
}
