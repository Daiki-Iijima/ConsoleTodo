using ConsoleTodo;

namespace Todo�I�u�W�F�N�g�𑀍삷��_CRUD�N���X {
    public class Todo_Test{
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void test����͂����test��������Todo�𐶐�����() {
            //  ����&���s
            TodoTask task = new TodoTask("test");

            //  ����
            Assert.AreEqual(new TodoTask("test"), task);
        }

        [Test]
        public void _1234T����͂����_1234T��������Todo�𐶐�����() {
            //  ����&���s
            TodoTask task = new TodoTask("_1234T");

            //  ����
            Assert.AreEqual(new TodoTask("_1234T"), task);
        }
    }
}