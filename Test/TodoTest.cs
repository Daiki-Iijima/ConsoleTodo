using ConsoleTodo;

namespace Todoオブジェクトを操作する_CRUDクラス {
    public class Todo_Test{
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void testを入力するとtestを持ったTodoを生成する() {
            //  準備&実行
            TodoTask task = new TodoTask("test");

            //  検証
            Assert.AreEqual(new TodoTask("test"), task);
        }

        [Test]
        public void _1234Tを入力すると_1234Tを持ったTodoを生成する() {
            //  準備&実行
            TodoTask task = new TodoTask("_1234T");

            //  検証
            Assert.AreEqual(new TodoTask("_1234T"), task);
        }
    }
}