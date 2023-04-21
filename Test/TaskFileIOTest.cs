using ConsoleTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Todoオブジェクトを操作する_CRUDクラス;

namespace タスクデータ永続化機能_TaskFileIOクラス {
    public class TaskFileIOTest {
        public class タスクリストを渡すとファイル名_task_json_に保存される {

            [Test]
            public void ファイルがない場合生成して保存されているか() {
                //  準備
                TaskFileIO io = new TaskFileIO();
                File.Delete(io.FilePath);

                //  ないことの検証
                Assert.IsFalse(File.Exists(io.FilePath));

                List<TodoTask> tasks = new List<TodoTask>();
                bool result = io.Save(tasks);
                Assert.IsTrue(result);

                //  あることの検証
                Assert.IsTrue(File.Exists(io.FilePath));
            }
        }
    }
}
