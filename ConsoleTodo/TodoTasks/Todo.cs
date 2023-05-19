using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo {

    public class Todo : ITodo {

        private List<TodoTask> tasks = new List<TodoTask>();

        public Todo() { }

        public List<TodoTask> Add(List<TodoTask> todoTask) {
            tasks.AddRange(todoTask);
            return tasks;
        }

        public List<TodoTask> Delete(List<int> deleteList) {
            tasks = tasks.Where((task, i) => !deleteList.Contains(i)).ToList();
            return tasks;
        }

        public List<TodoTask> Done(List<int> numList) {
            for (int i = 0; i < tasks.Count; i++) {
                if (numList.Contains(i)) {
                    tasks[i].Done();
                }
            }
            return new List<TodoTask>(tasks.Where(task => task.IsCompleted));
        }

        public List<TodoTask> DoneList(List<int> num = null) {
            List<TodoTask> doneList = tasks.Where(task => task.IsCompleted).ToList();
            if (num == null || num.Count == 0) {
                return doneList;
            }

            return doneList.Where((task, i) => num.Contains(i)).ToList();
        }

        public List<TodoTask> ActiveList(List<int> noList = null) {
            //  すべて返す
            if (noList == null || noList.Count == 0) {
                return tasks.Where(task => !task.IsCompleted).ToList();
            }

            List<TodoTask> retTask = tasks.Where((task, i) => noList.Contains(i)).ToList();

            return retTask;
        }

        public List<TodoTask> Update(Dictionary<int, string> targetDic) {

            //  変更対象のタスクを取得
            List<TodoTask> targetTask = ActiveList(targetDic.Keys.ToList());

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

        public List<TodoTask> GetAllList() {
            return tasks;
        }
    }
}
