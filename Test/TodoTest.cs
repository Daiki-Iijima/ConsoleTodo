using ConsoleTodo;

namespace Todoオブジェクトを操作する_CRUDクラス {
    public class Todo_Test {
        [SetUp]
        public void Setup() {
        }

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

        [Test]
        public void testを持ったtaskオブジェクト生成して内部リストに保存し追加したリストを返す() {
            Todo todo = new Todo();

            List<TodoTask> resultList = todo.add(new TodoTask("test"));

            List<TodoTask> tasks = new List<TodoTask>();
            tasks.Add(new TodoTask("test"));

            //   検証
            Assert.AreEqual(tasks, resultList);
        }

        [Test]
        public void test1_test2を持ったtaskオブジェクト生成して内部リストに保存し追加したリストを返す() {
            Todo todo = new Todo();

            todo.add(new TodoTask("test1"));
            List<TodoTask> resultList = todo.add(new TodoTask("test2"));

            List<TodoTask> tasks = new List<TodoTask>();
            tasks.Add(new TodoTask("test1"));
            tasks.Add(new TodoTask("test2"));

            //   検証
            Assert.AreEqual(tasks, resultList);
        }
    }
}