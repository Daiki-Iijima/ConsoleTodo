using ConsoleTodo;
using ConsoleTodo.Command;
using ConsoleTodo.Command.Result;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleクラスのテスト {
    public class ConsoleCommandTest {

        /// <summary>
        /// 初期化のヘルパーメソッド
        /// </summary>
        /// <param name="mockTodo"></param>
        /// <param name="tasks"></param>
        /// <param name="commandInvoker"></param>
        protected static void SetUpCommonLogic(out Mock<ITodo> mockTodo, out List<TodoTask> tasks, out CommandInvoker commandInvoker) {
            mockTodo = new Mock<ITodo>();
            tasks = new List<TodoTask>();
            commandInvoker = new CommandInvoker();
        }

        public class 追加コマンド {

#nullable disable
            private Mock<ITodo> mockTodo;
            private List<TodoTask> tasks;
            private CommandInvoker commandInvoker;
#nullable enable

            [SetUp]
            public void SetUp() {
                //  準備
                SetUpCommonLogic(out mockTodo, out tasks, out commandInvoker);

                //  Addメソッドが実行された時の動作を記述
                mockTodo.Setup(todo => todo.Add(It.IsAny<List<TodoTask>>())).
                    Callback<List<TodoTask>>(taskValues => tasks.AddRange(taskValues));

                commandInvoker.InvokeCommands.Add(new AddCommand(mockTodo.Object));
            }

            [Test]
            public void 入力が_add_test_の場合_testタスク_がタスクリストに追加される() {
                //  実行
                _ = commandInvoker.Invoke("add test");

                //  検証
                List<TodoTask> expectedTasks = new List<TodoTask>() {
                    new TodoTask("test")
                };

                CollectionAssert.AreEqual(expectedTasks, tasks);
                mockTodo.Verify(m => m.Add(It.IsAny<List<TodoTask>>()), Times.Once());
            }

            [Test]
            public void 入力が_add_test_test2_の場合_testタスク_test2タスク_がタスクリストに追加される() {
                //  実行
                _ = commandInvoker.Invoke("add test test2");

                //  検証
                List<TodoTask> expectedTasks = new List<TodoTask>() {
                    new TodoTask("test"),
                    new TodoTask("test2")
                };

                CollectionAssert.AreEqual(expectedTasks, tasks);
                mockTodo.Verify(m => m.Add(It.IsAny<List<TodoTask>>()), Times.Once());
            }

            [Test]
            public void 入力が_add_test_の場合_実行されたコマンドがaddであると分かる結果が返ってくる() {
                SuccesTodoCommandResult result = (SuccesTodoCommandResult)commandInvoker.Invoke("add test");

                CollectionAssert.AreEqual("add", result.CommandName);
                mockTodo.Verify(m => m.Add(It.IsAny<List<TodoTask>>()), Times.Once());
            }

            [Test]
            public void 入力が_add_space_の場合_エラーになる() {
                ICommandResult result = commandInvoker.Invoke("add  ");

                Assert.IsTrue(result is ErrorCommandResult);
                mockTodo.Verify(m => m.Add(It.IsAny<List<TodoTask>>()), Times.Never());
            }

        }

        public class 終了コマンド {

#nullable disable
            private Mock<ITodo> mockTodo;
            private List<TodoTask> tasks;
            private List<TodoTask> doneTasks;
            private CommandInvoker commandInvoker;
#nullable enable

            [SetUp]
            public void SetUp() {

                SetUpCommonLogic(out mockTodo, out tasks, out commandInvoker);

                doneTasks = new List<TodoTask>();

                //  準備
                tasks = new List<TodoTask> {
                    new TodoTask("test1"),
                    new TodoTask("test2"),
                    new TodoTask("test3")
                };


                //  Addメソッドが実行された時の動作を記述
                mockTodo.Setup(todo => todo.Done(It.IsAny<List<int>>())).
                    Callback<List<int>>(numList => {
                        //  終了タスクの抽出
                        List<TodoTask> dones = tasks.Where((task, i) => numList.Contains(i)).ToList();

                        //   既存タスクを消去
                        numList.Sort();
                        numList.Reverse();
                        foreach (int i in numList) {
                            tasks.RemoveAt(i);
                        }

                        doneTasks.AddRange(dones);
                    });

                commandInvoker.InvokeCommands.Add(new DoneCommand(mockTodo.Object));
            }

            [Test]
            public void 入力が_done_0_の場合_タスクリストの_0番目_のタスクが終了タスクリストに追加される() {
                //  実行
                _ = commandInvoker.Invoke("done 0");

                //  検証
                CollectionAssert.AreEqual(new List<TodoTask>() { new TodoTask("test1") }, doneTasks);
                mockTodo.Verify(m => m.Done(It.IsAny<List<int>>()), Times.Once());
            }

            [Test]
            public void 入力が_done_0_の場合_タスクリストの_0番目_のタスクがタスクリストから消去される() {
                //  実行
                _ = commandInvoker.Invoke("done 0");

                //  検証
                CollectionAssert.AreEqual(new List<TodoTask>() { new TodoTask("test2"), new TodoTask("test3") }, tasks);
                mockTodo.Verify(m => m.Done(It.IsAny<List<int>>()), Times.Once());
            }

            [Test]
            public void 入力が_done_0_1_の場合_タスクリストの_0番目_1番目_のタスクが終了タスクリストに追加される() {
                //  実行
                _ = commandInvoker.Invoke("done 0 1");

                //  検証
                CollectionAssert.AreEqual(new List<TodoTask>() { new TodoTask("test1"), new TodoTask("test2") }, doneTasks);
                mockTodo.Verify(m => m.Done(It.IsAny<List<int>>()), Times.Once());
            }

            [Test]
            public void 入力が_done_0_1_の場合_タスクリストの_0番目_1番目_のタスクがタスクリストから消去される() {
                //  実行
                _ = commandInvoker.Invoke("done 0 1");

                //  検証
                CollectionAssert.AreEqual(new List<TodoTask>() { new TodoTask("test3") }, tasks);
                mockTodo.Verify(m => m.Done(It.IsAny<List<int>>()), Times.Once());
            }

            [Test]
            public void 入力が_done_0_の場合_実行されたコマンドがdoneであると分かる結果が返ってくる() {
                SuccesTodoCommandResult result = (SuccesTodoCommandResult)commandInvoker.Invoke("done 0");

                CollectionAssert.AreEqual("done", result.CommandName);
                mockTodo.Verify(m => m.Done(It.IsAny<List<int>>()), Times.Once());
            }
        }

        public class 削除コマンド {

#nullable disable
            private Mock<ITodo> mockTodo;
            private List<TodoTask> tasks;
            private CommandInvoker commandInvoker;
#nullable enable

            [SetUp]
            public void SetUp() {

                SetUpCommonLogic(out mockTodo, out tasks, out commandInvoker);

                //  準備
                tasks = new List<TodoTask> {
                    new TodoTask("test1"),
                    new TodoTask("test2"),
                    new TodoTask("test3")
                };

                //  Addメソッドが実行された時の動作を記述
                mockTodo.Setup(todo => todo.Delete(It.IsAny<List<int>>())).
                    Callback<List<int>>(numList => {
                        numList.Sort();
                        numList.Reverse();
                        foreach (int i in numList) {
                            tasks.RemoveAt(i);
                        }
                    });

                commandInvoker.InvokeCommands.Add(new DeleteCommand(mockTodo.Object));
            }

            [Test]
            public void 入力が_delete_0_の場合_タスクリストの_0番目_のタスクが消去される() {
                //  実行
                _ = commandInvoker.Invoke("delete 0");

                //  検証
                List<TodoTask> expectedTasks = new List<TodoTask> {
                    new TodoTask("test2"),
                    new TodoTask("test3")
                };
                CollectionAssert.AreEqual(expectedTasks, tasks);
                mockTodo.Verify(m => m.Delete(It.IsAny<List<int>>()), Times.Once());
            }

            [Test]
            public void 入力が_delete_0_1_の場合_タスクリストの_0番目_1番目_のタスクが消去さる() {
                //  実行
                _ = commandInvoker.Invoke("delete 0 1");

                //  検証
                List<TodoTask> expectedTasks = new List<TodoTask> {
                    new TodoTask("test3")
                };

                CollectionAssert.AreEqual(expectedTasks, tasks);
                mockTodo.Verify(m => m.Delete(It.IsAny<List<int>>()), Times.Once());
            }

            [Test]
            public void 入力が_delete_aa_の場合_コマンドが失敗する() {
                //  実行
                ICommandResult result = commandInvoker.Invoke("remove aa");

                //  検証
                Assert.IsTrue(result is ErrorCommandResult);
                mockTodo.Verify(m => m.Delete(It.IsAny<List<int>>()), Times.Never());
            }

            [Test]
            public void 入力が_delete_0_の場合_実行されたコマンドが_delete_であると分かる結果が返ってくる() {
                SuccesTodoCommandResult result = (SuccesTodoCommandResult)commandInvoker.Invoke("delete 0");

                CollectionAssert.AreEqual("delete", result.CommandName);
                mockTodo.Verify(m => m.Delete(It.IsAny<List<int>>()), Times.Once());
            }

        }

        public class 更新コマンド {

#nullable disable
            private CommandInvoker commandInvoker;
            private Mock<ITodo> mockTodo;
            private List<TodoTask> expectedTasks;
            private List<TodoTask> actualTasks;
#nullable enable

            [SetUp]
            public void SetUp() {
                //  準備
                SetUpCommonLogic(out mockTodo, out expectedTasks, out commandInvoker);

                commandInvoker.InvokeCommands.Add(new UpdateCommand(mockTodo.Object));

                expectedTasks = new List<TodoTask>() {
                    new TodoTask("test1"),
                    new TodoTask("test2"),
                    new TodoTask("test3"),
                };

                actualTasks = new List<TodoTask>(expectedTasks);

                //  Addメソッドが実行された時の動作を記述
                mockTodo.Setup(todo => todo.Update(It.IsAny<Dictionary<int, string>>())).
                    Callback<Dictionary<int, string>>(dic => {
                        foreach (int key in dic.Keys) {
                            actualTasks[key] = new TodoTask(dic[key]);
                        }
                    });

            }

            [Test]
            public void 入力が_update_0_ttt1_の場合_タスクリストの_0番目_のタスクがttt1に変更される() {
                //  実行
                ICommandResult result = commandInvoker.Invoke("update 0 ttt1");

                //  検証
                expectedTasks[0] = new TodoTask("ttt1");
                CollectionAssert.AreEqual(expectedTasks, actualTasks);
                mockTodo.Verify(m => m.Update(It.IsAny<Dictionary<int, string>>()), Times.Once());
            }

            [Test]
            public void 入力が_update_0_ttt1_1_ttt2_の場合_タスクリストの_0番目_1番目_のタスクが_ttt1_ttt2_に変更される() {
                //  実行
                ICommandResult result = commandInvoker.Invoke("update 0 ttt1 1 ttt2");

                //  検証
                expectedTasks[0] = new TodoTask("ttt1");
                expectedTasks[1] = new TodoTask("ttt2");
                CollectionAssert.AreEqual(expectedTasks, actualTasks);
                mockTodo.Verify(m => m.Update(It.IsAny<Dictionary<int, string>>()), Times.Once());
            }

            [Test]
            public void 入力が_update_test_の場合_コマンドが失敗する() {
                //  実行
                ICommandResult result = commandInvoker.Invoke("update test");

                //  検証
                Assert.IsTrue(result is ErrorCommandResult);
                mockTodo.Verify(m => m.Update(It.IsAny<Dictionary<int, string>>()), Times.Never());
            }

            [Test]
            public void 入力が_update_0_ttt1_の場合_実行されたコマンドが_update_であると分かる結果が返ってくる() {
                SuccesTodoCommandResult result = (SuccesTodoCommandResult)commandInvoker.Invoke("update 0 ttt1");

                CollectionAssert.AreEqual("update", result.CommandName);
                mockTodo.Verify(m => m.Update(It.IsAny<Dictionary<int, string>>()), Times.Once());
            }
        }

        public class 表示コマンド {
#nullable disable
            private CommandInvoker commandInvoker;
            private Mock<ITodo> mockTodo;
#nullable enable

            private List<TodoTask> expectedTasks;
            private List<TodoTask> actualTasks;

            [SetUp]
            public void SetUp() {
                //  準備
                SetUpCommonLogic(out mockTodo, out expectedTasks, out commandInvoker);

                commandInvoker.InvokeCommands.Add(new ListCommand(mockTodo.Object));

                expectedTasks = new List<TodoTask>() {
                    new TodoTask("test1"),
                    new TodoTask("test2"),
                    new TodoTask("test3"),
                };

                actualTasks = new List<TodoTask>(expectedTasks);

                //  Addメソッドが実行された時の動作を記述
                mockTodo.Setup(todo => todo.ActiveList(It.IsAny<List<int>>())).
                    Returns((List<int> numList) => {
                        if (numList == null) {
                            return expectedTasks;
                        }

                        List<TodoTask> retTasks = expectedTasks.Where((task, i) => numList.Contains(i)).ToList();
                        return retTasks;
                    });
            }

            [Test]
            public void 入力が_list_の場合_タスク一覧が返される() {
                //  実行
                ITodoCommandResult result = (ITodoCommandResult)commandInvoker.Invoke("list");

                //  検証
                CollectionAssert.AreEqual(expectedTasks, result.GetTodoCommandResult());
                mockTodo.Verify(m => m.ActiveList(It.IsAny<List<int>>()), Times.Once());
            }

            [Test]
            public void 入力が_list_0_の場合_タスクリストの0番目のタスクが返される() {
                //  実行
                ITodoCommandResult result = (ITodoCommandResult)commandInvoker.Invoke("list 0");

                //  検証
                CollectionAssert.AreEqual(new List<TodoTask>() { new TodoTask("test1") }, result.GetTodoCommandResult());
                mockTodo.Verify(m => m.ActiveList(It.IsAny<List<int>>()), Times.Once());
            }

            [Test]
            public void 入力が_list_0_の場合_実行されたコマンドが_list_であると分かる結果が返ってくる() {
                SuccesTodoCommandResult result = (SuccesTodoCommandResult)commandInvoker.Invoke("list 0");

                CollectionAssert.AreEqual("list", result.CommandName);
                mockTodo.Verify(m => m.ActiveList(It.IsAny<List<int>>()), Times.Once());
            }
        }

        public class 終了タスク一覧コマンド {
#nullable disable
            private CommandInvoker commandInvoker;
            private Mock<ITodo> mockTodo;
#nullable enable

            private List<TodoTask> expectedTasks;

            [SetUp]
            public void SetUp() {
                //  準備
                SetUpCommonLogic(out mockTodo, out expectedTasks, out commandInvoker);

                commandInvoker.InvokeCommands.Add(new DoneListCommand(mockTodo.Object));

                expectedTasks = new List<TodoTask>() {
                    new TodoTask("test1"),
                    new TodoTask("test2"),
                    new TodoTask("test3"),
                };

                //  Addメソッドが実行された時の動作を記述
                mockTodo.Setup(todo => todo.DoneList(It.IsAny<List<int>>())).
                    Returns((List<int> numList) => {
                        if (numList.Count == 0) {
                            return expectedTasks;
                        }

                        List<TodoTask> retTasks = expectedTasks.Where((task, i) => numList.Contains(i)).ToList();
                        return retTasks;
                    });
            }

            [Test]
            public void 入力が_donelist_の場合_終了タスク一覧が返される() {
                //  実行
                SuccesTodoCommandResult result = (SuccesTodoCommandResult)commandInvoker.Invoke("donelist");

                //  検証
                CollectionAssert.AreEqual(expectedTasks, result.GetTodoCommandResult());
                mockTodo.Verify(m => m.DoneList(It.IsAny<List<int>>()), Times.Once());
            }

            [Test]
            public void 入力が_donelist_0_の場合_終了タスクリストの0番目のタスクが返される() {
                //  実行
                SuccesTodoCommandResult result = (SuccesTodoCommandResult)commandInvoker.Invoke("donelist 0");

                //  検証
                CollectionAssert.AreEqual(new List<TodoTask>() { new TodoTask("test1") }, result.GetTodoCommandResult());
                mockTodo.Verify(m => m.DoneList(It.IsAny<List<int>>()), Times.Once());
            }

            [Test]
            public void 入力が_donelist_0_の場合_実行されたコマンドが_donelist_であると分かる結果が返ってくる() {
                SuccesTodoCommandResult result = (SuccesTodoCommandResult)commandInvoker.Invoke("donelist 0");

                CollectionAssert.AreEqual("donelist", result.CommandName);
                mockTodo.Verify(m => m.DoneList(It.IsAny<List<int>>()), Times.Once());
            }

        }
    }
}
