using Castle.Components.DictionaryAdapter;
using ConsoleTodo;
using ConsoleTodo.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    public class CommandInvokerTest {

        private ITodo todo;
        private CommandInvoker commandInvoker;

        [SetUp]
        public void SetUp() {
            todo = new Todo();

            commandInvoker = new CommandInvoker();
            commandInvoker.InvokeCommands.Add(new DoneCommand(todo));
            commandInvoker.InvokeCommands.Add(new DeleteCommand(todo));
            commandInvoker.InvokeCommands.Add(new UpdateCommand(todo));
            commandInvoker.InvokeCommands.Add(new AddCommand(todo));
            commandInvoker.InvokeCommands.Add(new ListCommand(todo));
            commandInvoker.InvokeCommands.Add(new DoneListCommand(todo));
        }

        //  単体テスト
        [Test]
        public void コマンドの追加順序がdone_delete_update_add_List_DoneListの場合_add_1コマンドが正常に実行される() {
            ICommandResult result = commandInvoker.Invoke("add 1");
            Assert.AreEqual("add", result.CommandName);
        }

        [Test]
        public void コマンドの追加順序が異なる場合でも_add_1コマンドが正常に実行される() {
            Random rng = new Random();
            commandInvoker.InvokeCommands = commandInvoker.InvokeCommands.OrderBy(x => rng.Next()).ToList();

            ICommandResult result = commandInvoker.Invoke("add 1");
            Assert.AreEqual("add", result.CommandName);
        } 
    }
}
