using ConsoleTodo;
using System.Diagnostics.CodeAnalysis;

namespace Todo�I�u�W�F�N�g�𑀍삷��_CRUD�N���X {
    public class Todo_Test {

        class �ǉ� {

            private Todo todo;

            [SetUp]
            public void Setup() {
                todo = new Todo();
            }

            [Test]
            public void ���͂�_test_�̏ꍇ_���̃^�X�N��ǉ������ŐV�̃^�X�N���X�g���Ԃ����() {
                //  ���s
                List<TodoTask> resultList = todo.Add(new TodoTask("test"));

                //  ����
                List<TodoTask> tasks = new List<TodoTask> {
                    new TodoTask("test")
                };
                Assert.AreEqual(tasks, resultList);
            }

            [Test]
            public void ���͂�_test1_��_test2_�̏ꍇ_���̃^�X�N��ǉ������ŐV�̃^�X�N���X�g���Ԃ����() {
                //  ���s
                _ = todo.Add(new TodoTask("test1"));
                List<TodoTask> resultList = todo.Add(new TodoTask("test2"));

                List<TodoTask> tasks = new List<TodoTask> {
                    new TodoTask("test1"),
                    new TodoTask("test2")
                };

                //   ����
                Assert.AreEqual(tasks, resultList);
            }
        }

        class �I�� {
            private Todo todo;
            [SetUp]
            public void Setup() {
                todo = new Todo();
            }
            [Test]
            public void ���͂�_0_�̏ꍇ_�^�X�N���X�g��_0�Ԗ�_�̃^�X�N���I�����X�g�ֈړ������ŐV�^�X�N���X�g���Ԃ����() {

                todo.Add(new TodoTask("Test"));

                List<TodoTask> doneList = todo.Done(new List<int> { 0 });

                List<TodoTask> expected = new List<TodoTask> {
                    new TodoTask("Test")
                };

                Assert.AreEqual(expected,doneList);
            }

            [Test]
            public void ���͂�_0_1_�̏ꍇ_�^�X�N���X�g��_0�Ԗ�_1�Ԗ�_�̃^�X�N���I�����X�g�ֈړ������ŐV�^�X�N���X�g���Ԃ����() {

                todo.Add(new TodoTask("Test1"));
                todo.Add(new TodoTask("Test2"));

                List<TodoTask> doneList = todo.Done(new List<int> { 0, 1 });

                List<TodoTask> expected = new List<TodoTask> {
                    new TodoTask("Test1"),
                    new TodoTask("Test2")
                };

                Assert.AreEqual(expected,doneList);
            }
        }

        class �ꗗ {
            class �i�s���^�X�N�ꗗ {

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
                public void ���͂������ꍇ���łɃ^�X�N���X�g�ɒǉ�����Ă��邷�ׂẴ^�X�N���X�g���Ԃ����() {

                    List<TodoTask> taskList = todo.List();

                    Assert.AreEqual(tasks, taskList);
                }

                [Test]
                public void ���͂�_0_�ꍇ_���łɃ^�X�N���X�g�ɒǉ�����Ă���^�X�N��_0�Ԗ�_�̃^�X�N���Ԃ����() {
                    //  ���s
                    List<TodoTask> actual = todo.List(new List<int>() { 0 });

                    //  ����
                    Assert.AreEqual(1, actual.Count);
                    Assert.AreEqual(new TodoTask("test1"), actual[0]);
                }

                [Test]
                public void ���͂�_0_1_2_�̏ꍇ_���łɃ^�X�N���X�g�ɒǉ�����Ă���^�X�N��_0�Ԗ�_1�Ԗ�_2�Ԗ�_�̃^�X�N���Ԃ����() {
                    //  ���s
                    List<TodoTask> actual = todo.List(new List<int>() { 0, 1, 2 });

                    //  ����
                    Assert.AreEqual(tasks, actual);
                }

            }
            class �I���^�X�N�ꗗ {

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
            }
        }

        class �X�V {
            [Test]
            public void test��Test1�ɍX�V���ĕύX����Todo��Ԃ�() {

                Todo todo = new Todo();
                todo.Add(new TodoTask("test"));

                //  �Ώۃf�[�^�ƍX�V�f�[�^�̃Z�b�g�𐶐�
                Dictionary<int, string> updateData = new Dictionary<int, string> {
                    { 0, "Test1" }
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

                //  �Ώۃf�[�^�ƍX�V�f�[�^�̃Z�b�g�𐶐�
                Dictionary<int, string> updateData = new Dictionary<int, string> {
                    { 0, "Test1" },
                    { 1, "TTTT2" },
                    { 2, "AAA" }
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