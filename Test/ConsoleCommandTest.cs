using ConsoleTodo.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public void 文字列add_test_を渡すとaddコマンドが発火してtestが返ってくる() {
                string argStr = "";

                commandInvoker.InvokeCommands.Add(new AddCommand("add", (str) => {
                    argStr = str;
                }));

                //  実行
                bool result = commandInvoker.Invoke("add test");

                //  検証
                Assert.IsTrue(result);
                Assert.AreEqual("test", argStr);
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
            public void 文字列remove_1を渡すとremoveコマンドが発火して引数で1が返ってくる() {

                int argInt = -1;
                commandInvoker.InvokeCommands.Add(new RemoveCommand("remove", (i) => {
                    argInt = i;
                }));

                //  実行
                bool result = commandInvoker.Invoke("remove 1");

                //  検証
                Assert.IsTrue(result);
                Assert.AreEqual(1, argInt);
            }

            [Test]
            public void 文字列remove_aaを渡すとremoveコマンドが発火せずに失敗する() {

                int argInt = -1;
                commandInvoker.InvokeCommands.Add(new RemoveCommand("remove", (i) => {
                    argInt = i;
                }));

                //  実行
                bool result = commandInvoker.Invoke("remove aa");

                //  検証
                Assert.IsFalse(result);
                Assert.AreEqual(-1, argInt);
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
            public void 文字列_update_0_ttt1_を渡すとupdateコマンドが発火して引数で辞書型の0_test1が返ってくる() {
                //  準備
                commandInvoker = new CommandInvoker();

                Dictionary<int, string> argDic = new Dictionary<int, string>();
                commandInvoker.InvokeCommands.Add(new UpdateCommand("update", (dic) => {
                    argDic = dic;
                }));

                //  実行
                bool result = commandInvoker.Invoke("update 0 ttt1");

                //  検証
                Assert.IsTrue(result);

                Dictionary<int, string> expDic = new Dictionary<int, string>() { { 0, "ttt1" } };
                Assert.AreEqual(expDic, argDic);
            }

            [Test]
            public void 文字列_update_test_を渡すとupdateコマンドが発火せずに失敗する() {
                //  準備
                commandInvoker = new CommandInvoker();

                Dictionary<int, string> argDic = new Dictionary<int, string>();
                commandInvoker.InvokeCommands.Add(new UpdateCommand("update", (dic) => {
                    argDic = dic;
                }));

                //  実行
                bool result = commandInvoker.Invoke("update ttt1");

                //  検証
                Assert.IsFalse(result);

                Dictionary<int, string> expDic = new Dictionary<int, string>();
                Assert.AreEqual(expDic, argDic);
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

                bool isInvoked = false;
                commandInvoker.InvokeCommands.Add(new ShowCommand("show", _ => {
                    isInvoked = true;
                }));

                //  実行
                bool result = commandInvoker.Invoke("show");

                //  検証
                Assert.IsTrue(result);
                Assert.IsTrue(isInvoked);
            }
        }
    }
}
