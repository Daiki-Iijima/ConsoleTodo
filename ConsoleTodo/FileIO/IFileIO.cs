using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.FileIO {
    public interface IFileIO {
        string FilePath { get; }
        string DirectoryPath { get; }
        bool Save(List<TodoTask> tasks);
        List<TodoTask> Load();
    }
}
