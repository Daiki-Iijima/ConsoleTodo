using ConsoleTodo;
using System.Diagnostics.CodeAnalysis;

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
                List<TodoTask> resultList = todo.add(new TodoTask("test"));

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
                todo.add(new TodoTask("test1"));

                //  実行
                List<TodoTask> resultList = todo.add(new TodoTask("test2"));

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
                todo.add(new TodoTask("test1"));
                todo.add(new TodoTask("test2"));
                todo.add(new TodoTask("test3"));

                tasks = new List<TodoTask>() {
                    new TodoTask("test1"),
                    new TodoTask("test2"),
                    new TodoTask("test3"),
                };
            }

            [Test]
            public void 追加されているtest1_test2_test3のTaskリストを返す() {
                //  実行
                List<TodoTask> actual = todo.GetList();

                //  結果
                Assert.AreEqual(tasks, actual);
            }

            [Test]
            public void タスクリストの1番目のタスクを返す() {
                //  実行
                List<TodoTask> actual = todo.GetList(0);

                //  結果
                Assert.AreEqual(new TodoTask("test1"), actual[0]);
            }
        }
    }
}