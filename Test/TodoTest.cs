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
                List<TodoTask> resultList = todo.Add(new List<TodoTask>() { new TodoTask("test") });

                //  ����
                List<TodoTask> tasks = new List<TodoTask> {
                    new TodoTask("test")
                };
                Assert.AreEqual(tasks, resultList);
            }

            [Test]
            public void ���͂�_test1_��_test2_�̏ꍇ_���̃^�X�N��ǉ������ŐV�̃^�X�N���X�g���Ԃ����() {
                //  ���s
                _ = todo.Add(new List<TodoTask>() { new TodoTask("test1") });
                List<TodoTask> resultList = todo.Add(new List<TodoTask>() { new TodoTask("test2") });

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
                todo.Add(new List<TodoTask>() { new TodoTask("Test1"), new TodoTask("Test2"), new TodoTask("Test3") });
            }
            [Test]
            public void ���͂�_0_�̏ꍇ_�^�X�N���X�g��_0�Ԗ�_�̃^�X�N���I�����X�g�ֈړ������ŐV�̐i�s���^�X�N���X�g���Ԃ����() {

                List<TodoTask> doneList = todo.Done(new List<int> { 0 });

                List<TodoTask> expected = new List<TodoTask> {
                    new TodoTask("Test2"),
                    new TodoTask("Test3")
                };

                Assert.AreEqual(expected,doneList);
            }

            [Test]
            public void ���͂�_0_1_�̏ꍇ_�^�X�N���X�g��_0�Ԗ�_1�Ԗ�_�̃^�X�N���I�����X�g�ֈړ������ŐV�̐i�s���^�X�N���X�g���Ԃ����() {

                List<TodoTask> doneList = todo.Done(new List<int> { 0, 1 });

                List<TodoTask> expected = new List<TodoTask> {
                    new TodoTask("Test3")
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
                    tasks = new List<TodoTask>() {
                        new TodoTask("test1"),
                        new TodoTask("test2"),
                        new TodoTask("test3"),
                    };

                    todo = new Todo();
                    todo.Add(tasks);
                }

                [Test]
                public void ���͂������ꍇ���łɃ^�X�N���X�g�ɒǉ�����Ă��邷�ׂẴ^�X�N���X�g���Ԃ����() {

                    List<TodoTask> taskList = todo.ActiveList();

                    Assert.AreEqual(tasks, taskList);
                }

                [Test]
                public void ���͂�_0_�ꍇ_���łɃ^�X�N���X�g�ɒǉ�����Ă���^�X�N��_0�Ԗ�_�̃^�X�N���Ԃ����() {
                    //  ���s
                    List<TodoTask> actual = todo.ActiveList(new List<int>() { 0 });

                    //  ����
                    Assert.AreEqual(1, actual.Count);
                    Assert.AreEqual(new TodoTask("test1"), actual[0]);
                }

                [Test]
                public void ���͂�_0_1_2_�̏ꍇ_���łɃ^�X�N���X�g�ɒǉ�����Ă���^�X�N��_0�Ԗ�_1�Ԗ�_2�Ԗ�_�̃^�X�N���Ԃ����() {
                    //  ���s
                    List<TodoTask> actual = todo.ActiveList(new List<int>() { 0, 1, 2 });

                    //  ����
                    Assert.AreEqual(tasks, actual);
                }

            }
            class �I���^�X�N�ꗗ {

                private Todo todo;

                [SetUp]
                public void SetUp() {
                    //  ����
                    todo = new Todo();
                    todo.Add(new List<TodoTask>() { new TodoTask("test1"), new TodoTask("test2"), new TodoTask("test3") });

                    //  �^�X�N���I��������
                    todo.Done(new List<int>() { 0, 1, 2 });
                }

                [Test]
                public void ���͂������ꍇ_���łɏI���^�X�N���X�g�ɒǉ�����Ă��邷�ׂĂ̏I���^�X�N���X�g���Ԃ����() {
                    List<TodoTask> doneAllTasks = todo.DoneList();

                    List<TodoTask> expectedTasks = new List<TodoTask>() {
                        new TodoTask("test1"),
                        new TodoTask("test2"),
                        new TodoTask("test3")
                    };

                    Assert.AreEqual(expectedTasks,doneAllTasks);
                }

                [Test]
                public void ���͂�_0_�ꍇ���łɏI���^�X�N���X�g�ɒǉ�����Ă���I���^�X�N��_0�Ԗ�_�̏I���^�X�N���Ԃ����() {
                    List<TodoTask> doneAllTasks = todo.DoneList(new List<int>() { 0 });

                    List<TodoTask> expectedTasks = new List<TodoTask>() {
                        new TodoTask("test1"),
                    };

                    Assert.AreEqual(expectedTasks,doneAllTasks);
                }

                [Test]
                public void ���͂�_0_1_2_�̏ꍇ���łɏI���^�X�N���X�g�ɒǉ�����Ă���I���^�X�N��_0�Ԗ�_1�Ԗ�_2�Ԗ�_�̏I���^�X�N���Ԃ����() {
                    List<TodoTask> doneAllTasks = todo.DoneList(new List<int>() { 0, 1, 2 });

                    List<TodoTask> expectedTasks = new List<TodoTask>() {
                        new TodoTask("test1"),
                        new TodoTask("test2"),
                        new TodoTask("test3"),
                    };

                    Assert.AreEqual(expectedTasks,doneAllTasks);
                }
            }
        }

        class �X�V {
            [Test]
            public void ���͂�_0_Test1_�̏ꍇ_���łɃ^�X�N���X�g�ɒǉ�����Ă���_0�Ԗ�_�̃^�X�N����_Test1_�ɕϊ�����_�ŐV�̃^�X�N���X�g���Ԃ����() {

                Todo todo = new Todo();
                todo.Add(new List<TodoTask>() { new TodoTask("test"), new TodoTask("test1") });

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
            public void ���͂�_0_Test1_1_Test2_�̏ꍇ_���łɃ^�X�N���X�g�ɒǉ�����Ă���_0�Ԗ�_1�Ԗ�_�̃^�X�N����_Test1_Test2_�ɕϊ�����_�ŐV�̃^�X�N���X�g���Ԃ����() {
                Todo todo = new Todo();
                todo.Add(new List<TodoTask>() { new TodoTask("test"), new TodoTask("test1") });

                //  �Ώۃf�[�^�ƍX�V�f�[�^�̃Z�b�g�𐶐�
                Dictionary<int, string> updateData = new Dictionary<int, string> {
                    { 0, "Test1" },
                    { 1, "Test2" },
                };

                //  ���s
                List<TodoTask> actual = todo.Update(updateData);

                //  ����
                List<TodoTask> task = new List<TodoTask>() { new TodoTask("Test1"), new TodoTask("Test2") };

                Assert.AreEqual(task, actual);
            }
        }

        class �폜 {

            private Todo todo;

            [SetUp]
            public void SetUp() {
                todo = new Todo();
                todo.Add(new List<TodoTask>() { new TodoTask("test"), new TodoTask("test1"), new TodoTask("test2") });
            }
            [Test]
            public void ���͂�_0_�̏ꍇ�^�X�N���X�g����_0�Ԗ�_�̃^�X�N���폜���čŐV�̃^�X�N���X�g���Ԃ����() {

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
            public void ���͂�_1_��_2_�̏ꍇ�^�X�N���X�g����_1�Ԗ�_��_2�Ԗ�_�̃^�X�N���폜���čŐV�̃^�X�N���X�g���Ԃ����() {

                List<int> deleteList = new List<int>() { 1, 2 };

                List<TodoTask> deleteResultTasks = todo.Delete(deleteList);

                //  ����
                List<TodoTask> tasks = new List<TodoTask>() {
                    new TodoTask("test"),
                };

                Assert.AreEqual(tasks, deleteResultTasks);
            }
        }
    }
}