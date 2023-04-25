using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo {
    public class Todo : ITodo {

        private List<TodoTask> tasks = new List<TodoTask>();

        private List<TodoTask> doneTasks = new List<TodoTask>();

        public Todo() { }

        public List<TodoTask> Add(TodoTask todoTask) {
            tasks.Add(todoTask);
            return tasks;
        }

        public List<TodoTask> Delete(List<int> deleteList) {
            tasks = tasks.Where((task, i) => !deleteList.Contains(i)).ToList();
            return tasks;
        }

        public List<TodoTask> Done(List<int> numList) {
            List<TodoTask> machTask = tasks.Where((t, i) => numList.Contains(i)).ToList();
            doneTasks.AddRange(machTask);
            return doneTasks;
        }

        public List<TodoTask> List(List<int> noList = null) {
            //  すべて返す
            if (noList == null) {
                return tasks;
            }

            List<TodoTask> retTask = tasks.Where((task, i) => noList.Contains(i)).ToList();

            return retTask;
        }

        public List<TodoTask> Update(Dictionary<int, string> targetDic) {

            //  変更対象のタスクを取得
            List<TodoTask> targetTask = List(targetDic.Keys.ToList());

            //  対象データと更新データのセットを生成
            Dictionary<TodoTask, TodoTask> updateData = new Dictionary<TodoTask, TodoTask>();

            for (int i = 0; i < targetDic.Count; i++) {
                updateData.Add(targetTask[i], new TodoTask(targetDic[i]));
            }

            List<TodoTask> retTasks = new List<TodoTask>();

            foreach (var task in tasks) {
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
