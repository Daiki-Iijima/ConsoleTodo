﻿using ConsoleTodo.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoleクラスのテスト {
    public class ConsoleCommandTest {
        [Test]
        public void 文字列add_test_を渡すとaddコマンドが発火してtestが返ってくる() {
            //  準備
            Command command = new Command();
            string argStr  = "";
            command.AddEvent += (str) => {
                argStr = str;
            };

            //  実行
            bool result = command.CheckCommand("add test");

            //  検証
            Assert.IsTrue(result);
            Assert.AreEqual("test", argStr);
        }

        [Test]
        public void 文字列remove_1を渡すとremoveコマンドが発火して引数で1が返ってくる() {
            //  準備
            Command command = new Command();
            int argInt  = -1;
            command.RemoveEvenet += (i) => {
                argInt = i;
            };

            //  実行
            bool result = command.CheckCommand("remove 1");

            //  検証
            Assert.IsTrue(result);
            Assert.AreEqual(1, argInt);
        }

        [Test]
        public void 文字列remove_aaを渡すとremoveコマンドが発火せずに失敗する() {
            //  準備
            Command command = new Command();
            int argInt  = -1;
            command.RemoveEvenet += (i) => {
                argInt = i;
            };

            //  実行
            bool result = command.CheckCommand("remove aa");

            //  検証
            Assert.IsFalse(result);
            Assert.AreEqual(-1, argInt);
        }
    }
}