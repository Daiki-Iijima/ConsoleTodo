using ConsoleTodo;
using System.Diagnostics.CodeAnalysis;

namespace Todoオブジェクトを操作する_CRUDクラス {
    public class Todo_Test {

        class 追加 {

            private Todo todo;

            [SetUp]
            public void Setup() {
                todo = new Todo();
            }

            [Test]
            public void 入力が_test_の場合_そのタスクを追加した最新のタスクリストが返される() {
                //  実行
                List<TodoTask> resultList = todo.Add(new TodoTask("test"));

                //  検証
                List<TodoTask> tasks = new List<TodoTask> {
                    new TodoTask("test")
                };
                Assert.AreEqual(tasks, resultList);
            }

            [Test]
            public void 入力が_test1_と_test2_の場合_そのタスクを追加した最新のタスクリストが返される() {
                //  実行
                _ = todo.Add(new TodoTask("test1"));
                List<TodoTask> resultList = todo.Add(new TodoTask("test2"));

                List<TodoTask> tasks = new List<TodoTask> {
                    new TodoTask("test1"),
                    new TodoTask("test2")
                };

                //   検証
                Assert.AreEqual(tasks, resultList);
            }
        }

        class 終了 {
            private Todo todo;
            [SetUp]
            public void Setup() {
                todo = new Todo();
            }
            [Test]
            public void 入力が_0_の場合_タスクリストの_0番目_のタスクを終了リストへ移動させ最新タスクリストが返される() {

                todo.Add(new TodoTask("Test"));

                List<TodoTask> doneList = todo.Done(new List<int> { 0 });

                List<TodoTask> expected = new List<TodoTask> {
                    new TodoTask("Test")
                };

                Assert.AreEqual(expected,doneList);
            }

            [Test]
            public void 入力が_0_1_の場合_タスクリストの_0番目_1番目_のタスクを終了リストへ移動させ最新タスクリストが返される() {

                todo.Add(new TodoTask("Test1"));
                todo.Add(new TodoTask("Test2"));

                List<TodoTask> doneList = todo.Done(new List<int> { 0, 1 });

                List<TodoTask> expected = new List<TodoTask> {
                    new TodoTask("Test1"),
                    new TodoTask("Test2")
                };

                Assert.AreEqual(expected,doneList);
            }
        }

        class 一覧 {
            class 進行中タスク一覧 {

                private Todo todo;
                private List<TodoTask> tasks;

                [SetUp]
                public void SetUp() {
                    //  準備
                    todo = new Todo();
                    todo.Add(new TodoTask("test1"));
                    todo.Add(new TodoTask("test2"));
                    todo.Add(new TodoTask("test3"));

                    tasks = new List<TodoTask>() {
                        new TodoTask("test1"),
                        new TodoTask("test2"),
                        new TodoTask("test3"),
                    };
                }

                [Test]
                public void 入力が無い場合すでにタスクリストに追加されているすべてのタスクリストが返される() {

                    List<TodoTask> taskList = todo.List();

                    Assert.AreEqual(tasks, taskList);
                }

                [Test]
                public void 入力が_0_場合_すでにタスクリストに追加されているタスクの_0番目_のタスクが返される() {
                    //  実行
                    List<TodoTask> actual = todo.List(new List<int>() { 0 });

                    //  結果
                    Assert.AreEqual(1, actual.Count);
                    Assert.AreEqual(new TodoTask("test1"), actual[0]);
                }

                [Test]
                public void 入力が_0_1_2_の場合_すでにタスクリストに追加されているタスクの_0番目_1番目_2番目_のタスクが返される() {
                    //  実行
                    List<TodoTask> actual = todo.List(new List<int>() { 0, 1, 2 });

                    //  結果
                    Assert.AreEqual(tasks, actual);
                }

            }
            class 終了タスク一覧 {

                private Todo todo;
                private List<TodoTask> tasks;

                [SetUp]
                public void SetUp() {
                    //  準備
                    todo = new Todo();
                    todo.Add(new TodoTask("test1"));
                    todo.Add(new TodoTask("test2"));
                    todo.Add(new TodoTask("test3"));

                    tasks = new List<TodoTask>() {
                        new TodoTask("test1"),
                        new TodoTask("test2"),
                        new TodoTask("test3"),
                    };
                }
            }
        }

        class 更新 {
            [Test]
            public void testをTest1に更新して変更したTodoを返す() {

                Todo todo = new Todo();
                todo.Add(new TodoTask("test"));

                //  対象データと更新データのセットを生成
                Dictionary<int, string> updateData = new Dictionary<int, string> {
                    { 0, "Test1" }
                };

                //  実行
                List<TodoTask> actual = todo.Update(updateData);

                //  結果
                List<TodoTask> task = new List<TodoTask>() { new TodoTask("Test1") };

                Assert.AreEqual(task, actual);
            }

            [Test]
            public void test_test1_test2をTest1_TTTT2_AAAに更新して変更したTodoを返す() {
                Todo todo = new Todo();
                todo.Add(new TodoTask("test"));
                todo.Add(new TodoTask("test1"));
                todo.Add(new TodoTask("test2"));

                //  対象データと更新データのセットを生成
                Dictionary<int, string> updateData = new Dictionary<int, string> {
                    { 0, "Test1" },
                    { 1, "TTTT2" },
                    { 2, "AAA" }
                };

                //  実行
                List<TodoTask> actual = todo.Update(updateData);

                //  結果
                List<TodoTask> task = new List<TodoTask>() { new TodoTask("Test1"), new TodoTask("TTTT2"), new TodoTask("AAA") };

                Assert.AreEqual(task, actual);
            }
        }

        class 削除 {

            private Todo todo;

            [SetUp]
            public void SetUp() {
                todo = new Todo();
                todo.Add(new TodoTask("test"));
                todo.Add(new TodoTask("test1"));
                todo.Add(new TodoTask("test2"));
            }
            [Test]
            public void タスク1を削除して_削除後の一覧を返す() {

                List<int> deleteList = new List<int>() { 0 };

                List<TodoTask> deleteResultTasks = todo.Delete(deleteList);

                //  検証
                List<TodoTask> tasks = new List<TodoTask>() {
                new TodoTask("test1"),
                new TodoTask("test2"),
            };

                Assert.AreEqual(tasks, deleteResultTasks);
            }

            [Test]
            public void タスク1_タスク3を削除して_削除後の一覧を返す() {

                List<int> deleteList = new List<int>() { 0, 2 };

                List<TodoTask> deleteResultTasks = todo.Delete(deleteList);

                //  検証
                List<TodoTask> tasks = new List<TodoTask>() {
                    new TodoTask("test1"),
                };

                Assert.AreEqual(tasks, deleteResultTasks);
            }
        }

        class 文字列変換 {
            [Test]
            public void タスク名_AAA1を持っているタスクをToStringで表示するとAAA1が返ってくる() {

                TodoTask task = new TodoTask("AAA1");

                //  検証
                Assert.AreEqual("AAA1", task.ToString());
            }
        }
    }
}