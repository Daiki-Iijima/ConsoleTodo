using ConsoleTodo;
using System.Diagnostics.CodeAnalysis;

namespace Todo�I�u�W�F�N�g�𑀍삷��_CRUD�N���X {
    public class Todo_Test {
        class �ǉ� {
            class �^�X�N�̐��� {

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
            }

            private Todo todo;

            [SetUp]
            public void Setup() {
                todo = new Todo();
            }

            [Test]
            public void test��������task�I�u�W�F�N�g�������ē������X�g�ɕۑ����ǉ��������X�g��Ԃ�() {
                //  ���s
                List<TodoTask> resultList = todo.add(new TodoTask("test"));

                //  ����
                List<TodoTask> tasks = new List<TodoTask> {
                    new TodoTask("test")
                };

                //   ����
                Assert.AreEqual(tasks, resultList);
            }

            [Test]
            public void test1_test2��������task�I�u�W�F�N�g�������ē������X�g�ɕۑ����ǉ��������X�g��Ԃ�() {
                //  ����
                //  �߂�l�͋A���Ă��Ă��邪�Ō�Ɉ�C�Ƀ`�F�b�N����̂ŃX���[
                todo.add(new TodoTask("test1"));

                //  ���s
                List<TodoTask> resultList = todo.add(new TodoTask("test2"));

                List<TodoTask> tasks = new List<TodoTask> {
                    new TodoTask("test1"),
                    new TodoTask("test2")
                };

                //   ����
                Assert.AreEqual(tasks, resultList);
            }
        }

        class �ꗗ {

            private Todo todo;
            private List<TodoTask> tasks;

            [SetUp]
            public void SetUp() {
                //  ����
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
            public void �ǉ�����Ă���test1_test2_test3��Task���X�g��Ԃ�() {
                //  ���s
                List<TodoTask> actual = todo.GetList();

                //  ����
                Assert.AreEqual(tasks, actual);
            }

            [Test]
            public void �^�X�N���X�g��1�Ԗڂ̃^�X�N��Ԃ�() {
                //  ���s
                List<TodoTask> actual = todo.GetList(0);

                //  ����
                Assert.AreEqual(new TodoTask("test1"), actual[0]);
            }
        }
    }
}