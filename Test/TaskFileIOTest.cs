using ConsoleTodo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Todoオブジェクトを操作する_CRUDクラス;

namespace タスクデータ永続化機能_TaskFileIOクラス {
    public class TaskFileIOTest {
        public class タスクリストを渡すとファイル名_task_json_に保存される {

            private TaskFileIO fileIO;

            private List<TodoTask> tasks;

            [SetUp]
            public void SetUp() {
                fileIO = new TaskFileIO();
                Directory.Delete(fileIO.DirectoryPath, true); //  ディレクトリごと消去

                tasks = new List<TodoTask>();
            }

            [Test]
            public void TodoApp_ディレクトリがない場合生成される() {
                fileIO.Save(tasks);

                //  あることの検証
                Assert.IsTrue(Directory.Exists(fileIO.DirectoryPath));
            }

            [Test]
            public void ファイルがない場合生成して保存されているか() {
                fileIO.Save(tasks);

                //  あることの検証
                Assert.IsTrue(File.Exists(fileIO.FilePath));
            }

            [Test]
            //  戻り値: "[{"taskName":"Test"},{"taskName":"Test1"}]"
            //  単体テスト
            public void 内部に_Test_Test1_を持っているタスクリストを渡すとJson文字列が返ってくる() {

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(new List<TodoTask>() { new TodoTask("Test"),new TodoTask("Test1")});

                //  検証結果
                Assert.AreEqual("[{\"taskName\":\"Test\"},{\"taskName\":\"Test1\"}]", json);
            }

            [Test]
            public void _test1_test2_を持ったタスクリストを渡したときにファイルにJson文字列が書き込まれるか() {
                //  実行
                fileIO.Save(new List<TodoTask>() { new TodoTask("test1"), new TodoTask("test2") });

                //   検証結果
                string json = File.ReadAllText(fileIO.FilePath);    //  ファイルから読み取り
                Assert.AreEqual("[{\"taskName\":\"test1\"},{\"taskName\":\"test2\"}]", json);
            }
        }
    }
}
