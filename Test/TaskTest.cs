using ConsoleTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest {
    public class TodoTaskクラスのテスト {
        class タスク生成 {
            [Test]
            public void 入力が_test_の場合タスク名が_test_になる() {
                //  準備&実行
                TodoTask task = new TodoTask("test");

                //  検証
                Assert.AreEqual(new TodoTask("test"), task);
            }

            [Test]
            public void 入力が_1234T_の場合_タスク名が_1234T_になる() {
                //  準備&実行
                TodoTask task = new TodoTask("1234T");

                //  検証
                Assert.AreEqual(new TodoTask("1234T"), task);
            }
        }
    }
}
