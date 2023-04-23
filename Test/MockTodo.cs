using ConsoleTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    public class MockTodo : ITodo {
        public List<TodoTask> Add(TodoTask todoTask) {
            return new List<TodoTask>();
        }

        public List<TodoTask> Delete(List<int> deleteList) {
            return new List<TodoTask>();
        }

        public List<TodoTask> List(List<int> noList = null) {

            return new List<TodoTask>();
        }

        public List<TodoTask> Update(Dictionary<int, string> targetDic) {
            return new List<TodoTask>();
        }
    }
}
