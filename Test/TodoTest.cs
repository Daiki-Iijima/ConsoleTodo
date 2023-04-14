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
    }
}