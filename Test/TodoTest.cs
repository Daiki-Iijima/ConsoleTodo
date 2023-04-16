using ConsoleTodo;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace Todoオブジェクトを操作する_CRUDクラス {
    public class Todo_Test {
        class 追加 {
            class タスクの生成 {

                [Test]
                public void testを入力するとtestを持ったtaskを生成する() {
                    //  準備&実行
                    TodoTask task = new TodoTask("test");

                    //  検証
                    Assert.AreEqual(new TodoTask("test"), task);
                }

                [Test]
                public void _1234Tを入力すると_1234Tを持ったtaskを生成する() {
                    //  準備&実行
                    TodoTask task = new TodoTask("_1234T");

                    //  検証
                    Assert.AreEqual(new TodoTask("_1234T"), task);
                }
            }

            private Todo todo;

            [SetUp]
            public void Setup() {
                todo = new Todo();
            }

            [Test]
            public void testを持ったtaskオブジェクト生成して内部リストに保存し追加したリストを返す() {
                //  実行
                List<TodoTask> resultList = todo.Add(new TodoTask("test"));

                //  検証
                List<TodoTask> tasks = new List<TodoTask> {
                    new TodoTask("test")
                };

                //   検証
                Assert.AreEqual(tasks, resultList);
            }

            [Test]
            public void test1_test2を持ったtaskオブジェクト生成して内部リストに保存し追加したリストを返す() {
                //  準備
                //  戻り値は帰ってきているが最後に一気にチェックするのでスルー
                todo.Add(new TodoTask("test1"));

                //  実行
                List<TodoTask> resultList = todo.Add(new TodoTask("test2"));

                List<TodoTask> tasks = new List<TodoTask> {
                    new TodoTask("test1"),
                    new TodoTask("test2")
                };

                //   検証
                Assert.AreEqual(tasks, resultList);
            }
        }

        class 一覧 {

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
            public void 追加されているtest1_test2_test3のTaskリストを返す() {
                //  実行
                List<TodoTask> actual = todo.List();

                //  結果
                Assert.AreEqual(tasks, actual);
            }

            [Test]
            public void タスクリストの1番目のタスクを返す() {
                //  実行
                List<TodoTask> actual = todo.List(new List<int>() { 0 });

                //  結果
                Assert.AreEqual(new TodoTask("test1"), actual[0]);
            }

            [Test]
            public void タスクリストの1_2_3番目のタスクを返す() {
                //  実行
                List<TodoTask> actual = todo.List(new List<int>() { 0, 1, 2 });

                //  結果
                Assert.AreEqual(tasks, actual);
            }
        }

        class 更新 {
            [Test]
            public void testをTest1に更新して変更したTodoを返す() {

                Todo todo = new Todo();
                todo.Add(new TodoTask("test"));

                //  変更対象のタスクを取得
                List<TodoTask> targetTask = todo.List(new List<int>() { 0 });

                //  対象データと更新データのセットを生成
                Dictionary<TodoTask, TodoTask> updateData = new Dictionary<TodoTask, TodoTask> {
                    { targetTask[0], new TodoTask("Test1") }
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

                //  変更対象のタスクを取得
                List<TodoTask> targetTask = todo.List(new List<int>() { 0, 1, 2 });

                //  対象データと更新データのセットを生成
                Dictionary<TodoTask, TodoTask> updateData = new Dictionary<TodoTask, TodoTask> {
                    { targetTask[0], new TodoTask("Test1") },
                    { targetTask[1], new TodoTask("TTTT2") },
                    { targetTask[2], new TodoTask("AAA") }
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