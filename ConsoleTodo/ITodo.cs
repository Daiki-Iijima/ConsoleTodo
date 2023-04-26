using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo {
    public interface ITodo {
        List<TodoTask> Add(TodoTask todoTask);

        List<TodoTask> Delete(List<int> deleteList);

        List<TodoTask> ActiveList(List<int> noList = null);

        List<TodoTask> Update(Dictionary<int, string> targetDic);
    }
}
