using ConsoleTodo;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

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
                List<TodoTask> resultList = todo.Add(new TodoTask("test"));

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
                todo.Add(new TodoTask("test1"));

                //  ���s
                List<TodoTask> resultList = todo.Add(new TodoTask("test2"));

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
            public void �ǉ�����Ă���test1_test2_test3��Task���X�g��Ԃ�() {
                //  ���s
                List<TodoTask> actual = todo.List();

                //  ����
                Assert.AreEqual(tasks, actual);
            }

            [Test]
            public void �^�X�N���X�g��1�Ԗڂ̃^�X�N��Ԃ�() {
                //  ���s
                List<TodoTask> actual = todo.List(new List<int>() { 0 });

                //  ����
                Assert.AreEqual(new TodoTask("test1"), actual[0]);
            }

            [Test]
            public void �^�X�N���X�g��1_2_3�Ԗڂ̃^�X�N��Ԃ�() {
                //  ���s
                List<TodoTask> actual = todo.List(new List<int>() { 0, 1, 2 });

                //  ����
                Assert.AreEqual(tasks, actual);
            }
        }

        class �X�V {
            [Test]
            public void test��Test1�ɍX�V���ĕύX����Todo��Ԃ�() {

                Todo todo = new Todo();
                todo.Add(new TodoTask("test"));

                //  �ύX�Ώۂ̃^�X�N���擾
                List<TodoTask> targetTask = todo.List(new List<int>() { 0 });

                //  �Ώۃf�[�^�ƍX�V�f�[�^�̃Z�b�g�𐶐�
                Dictionary<TodoTask, TodoTask> updateData = new Dictionary<TodoTask, TodoTask> {
                    { targetTask[0], new TodoTask("Test1") }
                };

                //  ���s
                List<TodoTask> actual = todo.Update(updateData);

                //  ����
                List<TodoTask> task = new List<TodoTask>() { new TodoTask("Test1") };

                Assert.AreEqual(task, actual);
            }

            [Test]
            public void test_test1_test2��Test1_TTTT2_AAA�ɍX�V���ĕύX����Todo��Ԃ�() {
                Todo todo = new Todo();
                todo.Add(new TodoTask("test"));
                todo.Add(new TodoTask("test1"));
                todo.Add(new TodoTask("test2"));

                //  �ύX�Ώۂ̃^�X�N���擾
                List<TodoTask> targetTask = todo.List(new List<int>() { 0, 1, 2 });

                //  �Ώۃf�[�^�ƍX�V�f�[�^�̃Z�b�g�𐶐�
                Dictionary<TodoTask, TodoTask> updateData = new Dictionary<TodoTask, TodoTask> {
                    { targetTask[0], new TodoTask("Test1") },
                    { targetTask[1], new TodoTask("TTTT2") },
                    { targetTask[2], new TodoTask("AAA") }
                };

                //  ���s
                List<TodoTask> actual = todo.Update(updateData);

                //  ����
                List<TodoTask> task = new List<TodoTask>() { new TodoTask("Test1"), new TodoTask("TTTT2"), new TodoTask("AAA") };

                Assert.AreEqual(task, actual);
            }
        }

        class �폜 {

            private Todo todo;

            [SetUp]
            public void SetUp() {
                todo = new Todo();
                todo.Add(new TodoTask("test"));
                todo.Add(new TodoTask("test1"));
                todo.Add(new TodoTask("test2"));
            }
            [Test]
            public void �^�X�N1���폜����_�폜��̈ꗗ��Ԃ�() {

                List<int> deleteList = new List<int>() { 0 };

                List<TodoTask> deleteResultTasks = todo.Delete(deleteList);

                //  ����
                List<TodoTask> tasks = new List<TodoTask>() {
                new TodoTask("test1"),
                new TodoTask("test2"),
            };

                Assert.AreEqual(tasks, deleteResultTasks);
            }

            [Test]
            public void �^�X�N1_�^�X�N3���폜����_�폜��̈ꗗ��Ԃ�() {

                List<int> deleteList = new List<int>() { 0, 2 };

                List<TodoTask> deleteResultTasks = todo.Delete(deleteList);

                //  ����
                List<TodoTask> tasks = new List<TodoTask>() {
                    new TodoTask("test1"),
                };

                Assert.AreEqual(tasks, deleteResultTasks);
            }
        }

        class ������ϊ� {
            [Test]
            public void �^�X�N��_AAA1�������Ă���^�X�N��ToString�ŕ\�������AAA1���Ԃ��Ă���() {

                TodoTask task = new TodoTask("AAA1");

                //  ����
                Assert.AreEqual("AAA1", task.ToString());
            }
        }
    }
}