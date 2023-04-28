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
                List<TodoTask> resultList = todo.Add(new List<TodoTask>() { new TodoTask("test") });

                //  検証
                List<TodoTask> tasks = new List<TodoTask> {
                    new TodoTask("test")
                };
                Assert.AreEqual(tasks, resultList);
            }

            [Test]
            public void 入力が_test1_と_test2_の場合_そのタスクを追加した最新のタスクリストが返される() {
                //  実行
                _ = todo.Add(new List<TodoTask>() { new TodoTask("test1") });
                List<TodoTask> resultList = todo.Add(new List<TodoTask>() { new TodoTask("test2") });

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
                todo.Add(new List<TodoTask>() { new TodoTask("Test1"), new TodoTask("Test2"), new TodoTask("Test3") });
            }
            [Test]
            public void 入力が_0_の場合_タスクリストの_0番目_のタスクを終了リストへ移動させ最新の進行中タスクリストが返される() {

                List<TodoTask> doneList = todo.Done(new List<int> { 0 });

                List<TodoTask> expected = new List<TodoTask> {
                    new TodoTask("Test2"),
                    new TodoTask("Test3")
                };

                Assert.AreEqual(expected,doneList);
            }

            [Test]
            public void 入力が_0_1_の場合_タスクリストの_0番目_1番目_のタスクを終了リストへ移動させ最新の進行中タスクリストが返される() {

                List<TodoTask> doneList = todo.Done(new List<int> { 0, 1 });

                List<TodoTask> expected = new List<TodoTask> {
                    new TodoTask("Test3")
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
                    tasks = new List<TodoTask>() {
                        new TodoTask("test1"),
                        new TodoTask("test2"),
                        new TodoTask("test3"),
                    };

                    todo = new Todo();
                    todo.Add(tasks);
                }

                [Test]
                public void 入力が無い場合すでにタスクリストに追加されているすべてのタスクリストが返される() {

                    List<TodoTask> taskList = todo.ActiveList();

                    Assert.AreEqual(tasks, taskList);
                }

                [Test]
                public void 入力が_0_場合_すでにタスクリストに追加されているタスクの_0番目_のタスクが返される() {
                    //  実行
                    List<TodoTask> actual = todo.ActiveList(new List<int>() { 0 });

                    //  結果
                    Assert.AreEqual(1, actual.Count);
                    Assert.AreEqual(new TodoTask("test1"), actual[0]);
                }

                [Test]
                public void 入力が_0_1_2_の場合_すでにタスクリストに追加されているタスクの_0番目_1番目_2番目_のタスクが返される() {
                    //  実行
                    List<TodoTask> actual = todo.ActiveList(new List<int>() { 0, 1, 2 });

                    //  結果
                    Assert.AreEqual(tasks, actual);
                }

            }
            class 終了タスク一覧 {

                private Todo todo;

                [SetUp]
                public void SetUp() {
                    //  準備
                    todo = new Todo();
                    todo.Add(new List<TodoTask>() { new TodoTask("test1"), new TodoTask("test2"), new TodoTask("test3") });

                    //  タスクを終了させる
                    todo.Done(new List<int>() { 0, 1, 2 });
                }

                [Test]
                public void 入力が無い場合_すでに終了タスクリストに追加されているすべての終了タスクリストが返される() {
                    List<TodoTask> doneAllTasks = todo.DoneList();

                    List<TodoTask> expectedTasks = new List<TodoTask>() {
                        new TodoTask("test1"),
                        new TodoTask("test2"),
                        new TodoTask("test3")
                    };

                    Assert.AreEqual(expectedTasks,doneAllTasks);
                }

                [Test]
                public void 入力が_0_場合すでに終了タスクリストに追加されている終了タスクの_0番目_の終了タスクが返される() {
                    List<TodoTask> doneAllTasks = todo.DoneList(new List<int>() { 0 });

                    List<TodoTask> expectedTasks = new List<TodoTask>() {
                        new TodoTask("test1"),
                    };

                    Assert.AreEqual(expectedTasks,doneAllTasks);
                }

                [Test]
                public void 入力が_0_1_2_の場合すでに終了タスクリストに追加されている終了タスクの_0番目_1番目_2番目_の終了タスクが返される() {
                    List<TodoTask> doneAllTasks = todo.DoneList(new List<int>() { 0, 1, 2 });

                    List<TodoTask> expectedTasks = new List<TodoTask>() {
                        new TodoTask("test1"),
                        new TodoTask("test2"),
                        new TodoTask("test3"),
                    };

                    Assert.AreEqual(expectedTasks,doneAllTasks);
                }
            }
        }

        class 更新 {
            [Test]
            public void 入力が_0_Test1_の場合_すでにタスクリストに追加されている_0番目_のタスク名が_Test1_に変換され_最新のタスクリストが返される() {

                Todo todo = new Todo();
                todo.Add(new List<TodoTask>() { new TodoTask("test"), new TodoTask("test1") });

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
            public void 入力が_0_Test1_1_Test2_の場合_すでにタスクリストに追加されている_0番目_1番目_のタスク名が_Test1_Test2_に変換され_最新のタスクリストが返される() {
                Todo todo = new Todo();
                todo.Add(new List<TodoTask>() { new TodoTask("test"), new TodoTask("test1") });

                //  対象データと更新データのセットを生成
                Dictionary<int, string> updateData = new Dictionary<int, string> {
                    { 0, "Test1" },
                    { 1, "Test2" },
                };

                //  実行
                List<TodoTask> actual = todo.Update(updateData);

                //  結果
                List<TodoTask> task = new List<TodoTask>() { new TodoTask("Test1"), new TodoTask("Test2") };

                Assert.AreEqual(task, actual);
            }
        }

        class 削除 {

            private Todo todo;

            [SetUp]
            public void SetUp() {
                todo = new Todo();
                todo.Add(new List<TodoTask>() { new TodoTask("test"), new TodoTask("test1"), new TodoTask("test2") });
            }
            [Test]
            public void 入力が_0_の場合タスクリスト内の_0番目_のタスクを削除して最新のタスクリストが返される() {

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
            public void 入力が_1_と_2_の場合タスクリスト内の_1番目_と_2番目_のタスクを削除して最新のタスクリストが返される() {

                List<int> deleteList = new List<int>() { 1, 2 };

                List<TodoTask> deleteResultTasks = todo.Delete(deleteList);

                //  検証
                List<TodoTask> tasks = new List<TodoTask>() {
                    new TodoTask("test"),
                };

                Assert.AreEqual(tasks, deleteResultTasks);
            }
        }
    }
}