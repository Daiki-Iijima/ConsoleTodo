using ConsoleTodo;
using ConsoleTodo.Command;
using ConsoleTodo.Command.Result;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Consoleクラスのテスト {
    public class ConsoleCommandTest {
        public class 追加コマンド {
            private CommandInvoker commandInvoker;
            [SetUp]
            public void SetUp() {
                //  準備
                commandInvoker = new CommandInvoker();
            }

            [Test]
            public void 文字列add_testを渡すとaddコマンドが発火して文字列testが引数として分解され結果ととも返される() {
                commandInvoker.InvokeCommands.Add(new AddCommand("add", new MockTodo()));

                //  実行
                ICommandResult result = commandInvoker.Invoke("add test");

                //  検証
                Assert.AreEqual("test", result.GetArgs()[0]);
            }
        }

        public class 削除コマンド {

            private CommandInvoker commandInvoker;
            [SetUp]
            public void SetUp() {
                //  準備
                commandInvoker = new CommandInvoker();
            }

            [Test]
            public void 文字列remove_1を渡すとremoveコマンドが発火して引数として1が返される() {

                commandInvoker.InvokeCommands.Add(new RemoveCommand("remove", new MockTodo()));

                //  実行
                ICommandResult result = commandInvoker.Invoke("remove 1");

                //  検証
                Assert.AreEqual("1", result.GetArgs()[0]);
            }

            [Test]
            public void 文字列remove_aaを渡すとremoveコマンドが発火せずに失敗する() {

                commandInvoker.InvokeCommands.Add(new RemoveCommand("remove",new MockTodo()));
                //  実行
                ICommandResult result = commandInvoker.Invoke("remove aa");

                //  検証
                Assert.IsTrue(result is ErrorCommandResult);
            }
        }

        public class 更新コマンド {

            private CommandInvoker commandInvoker;
            [SetUp]
            public void SetUp() {
                //  準備
                commandInvoker = new CommandInvoker();
            }

            [Test]
            public void 文字列update_0_ttt1を渡すとupdateコマンドが発火して引数として辞書型の0_test1が返ってくる() {
                //  準備
                commandInvoker = new CommandInvoker();

                Dictionary<int, string> argDic = new Dictionary<int, string>();
                commandInvoker.InvokeCommands.Add(new UpdateCommand("update",new MockTodo()));

                //  実行
                ICommandResult result = commandInvoker.Invoke("update 0 ttt1");

                //  検証
                Dictionary<int, string> expDic = new Dictionary<int, string>() { { 0, "ttt1" } };
                argDic.Add(int.Parse(result.GetArgs()[0]), result.GetArgs()[1]);
                Assert.AreEqual(expDic, argDic);
            }

            [Test]
            public void 文字列_update_test_を渡すとupdateコマンドが発火せずに失敗する() {
                //  準備
                commandInvoker = new CommandInvoker();

                commandInvoker.InvokeCommands.Add(new UpdateCommand("update", new MockTodo()));
                //  実行
                ICommandResult result = commandInvoker.Invoke("update ttt1");

                //  検証
                Assert.IsTrue(result is ErrorCommandResult);
            }
        }

        public class 表示コマンド {
            private CommandInvoker commandInvoker;
            [SetUp]
            public void SetUp() {
                //  準備
                commandInvoker = new CommandInvoker();
            }

            [Test]
            public void 文字列_show_を渡すとshowコマンドが発火する() {
                //  準備
                commandInvoker = new CommandInvoker();

                commandInvoker.InvokeCommands.Add(new ShowCommand("show",new MockTodo()));
                //  実行
                ICommandResult result = commandInvoker.Invoke("show");

                //  検証
                Assert.IsTrue(result is SuccesTodoCommandResult);
            }
        }
    }
}
