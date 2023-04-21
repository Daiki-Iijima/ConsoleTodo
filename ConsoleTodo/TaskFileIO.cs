using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo {
    public class TaskFileIO {
        public string FilePath { get; private set; }

        public TaskFileIO() {
            FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "task.json");
        }

        public bool Save(List<TodoTask> tasks) {
            File.WriteAllText(FilePath, "test");
            return true;
        }
    }
}
