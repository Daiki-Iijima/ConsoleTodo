using ConsoleTodo;

namespace Todo�I�u�W�F�N�g�𑀍삷��_CRUD�N���X {
    public class Todo_Test {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void test����͂����test��������task�𐶐�����() {
            //  ����&���s
            TodoTask task = new TodoTask("test");

            //  ����
            Assert.AreEqual(new TodoTask("test"), task);
        }

        [Test]
        public void _1234T����͂����_1234T��������task�𐶐�����() {
            //  ����&���s
            TodoTask task = new TodoTask("_1234T");

            //  ����
            Assert.AreEqual(new TodoTask("_1234T"), task);
        }

        [Test]
        public void test��������task�I�u�W�F�N�g�������ē������X�g�ɕۑ����ǉ��������X�g��Ԃ�() {
            Todo todo = new Todo();

            List<TodoTask> resultList = todo.add(new TodoTask("test"));

            List<TodoTask> tasks = new List<TodoTask>();
            tasks.Add(new TodoTask("test"));

            //   ����
            Assert.AreEqual(tasks, resultList);
        }

        [Test]
        public void test1_test2��������task�I�u�W�F�N�g�������ē������X�g�ɕۑ����ǉ��������X�g��Ԃ�() {
            Todo todo = new Todo();

            todo.add(new TodoTask("test1"));
            List<TodoTask> resultList = todo.add(new TodoTask("test2"));

            List<TodoTask> tasks = new List<TodoTask>();
            tasks.Add(new TodoTask("test1"));
            tasks.Add(new TodoTask("test2"));

            //   ����
            Assert.AreEqual(tasks, resultList);
        }
    }
}