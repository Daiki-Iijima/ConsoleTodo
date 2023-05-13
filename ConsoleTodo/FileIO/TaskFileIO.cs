using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTodo.FileIO;
using Newtonsoft.Json;

namespace ConsoleTodo {
    public class TaskFileIO: IFileIO {

        private static readonly string DirectoryName = "TodoApp";
        private static readonly string FileName = "task.json";

        public string FilePath { get; private set; }
        public string DirectoryPath { get; private set; }

        public TaskFileIO() {

            DirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),DirectoryName);
            FilePath = Path.Combine(DirectoryPath, FileName);
        }

        public bool Save(List<TodoTask> tasks) {

            //  ディレクトリが無ければ生成する
            if (!Directory.Exists(DirectoryPath)) {
                Directory.CreateDirectory(DirectoryPath);
            }

            string json = JsonConvert.SerializeObject(tasks);
            File.WriteAllText(FilePath, json);

            return true;
        }

        public List<TodoTask> Load() {
            try {
                string loadJson = File.ReadAllText(FilePath);

                List<TodoTask> tasks = JsonConvert.DeserializeObject<List<TodoTask>>(loadJson);

                return tasks;
            } catch (FileNotFoundException) {
                return null;
            } catch (DirectoryNotFoundException) {  //  ディレクトリが見つからなかったので読み取り失敗
                return null;
            }

        }


    }
}
