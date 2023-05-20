using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Display {
    public class ConsoleDisplay : IDisplay {
        public void PrintError(ICommandResult result) {
            Console.WriteLine(result.GetResultMessage());
        }

        public void PrintTasks(List<TodoTask> tasks,bool showDone) {
            int nameMaxLength = 0;
            if (0 < tasks.Count) {
                nameMaxLength = tasks.Max(t => GetDisplayLength(t.ToString()));
            }

            string name = "Name";
            string header = $"| No | {name.PadRight(nameMaxLength)} | isDone |";

            string separator = new string('=', header.Length);

            Console.WriteLine(separator);
            Console.WriteLine(header);
            Console.WriteLine(separator);

            for (int i = 0; i < tasks.Count; i++) {
                string paddedName = PadRightConsideringFullWidth(tasks[i].ToString(), nameMaxLength);
                string paddedIsDone = tasks[i].IsCompleted ? PadRightConsideringFullWidth("\u2713", 6) : new string(' ', 6);
                Console.WriteLine("| {0} | {1} | {2} |", i.ToString().PadRight(2), paddedName, paddedIsDone);
            }

            Console.WriteLine(separator);
        }

        private string PadRightConsideringFullWidth(string s, int totalWidth) {
            int currentWidth = GetDisplayLength(s);
            int diff = totalWidth - currentWidth;
            return s + new string(' ', diff);
        }

        private int GetDisplayLength(string s) {
            int length = 0;
            foreach (char c in s) {
                if ((c >= 0x00 && c < 0x81) || (c == 0xf8f0) || (c >= 0xff61 && c < 0xffa0) || (c >= 0xf8f1 && c < 0xf8f4)) {
                    length += 1;  // 半角文字
                } else {
                    length += 2;  // 全角文字
                }
            }
            return length;
        }

        public void PrintProgress(float progress) {
            // progressは0~100の範囲にあるため、パーセント表示に変換する必要はありません
            progress = Math.Max(0, Math.Min(100, progress)); // 念のために範囲を0~100に制限

            // 進捗バーの幅を設定します（ここでは50としています）
            const int totalBlocks = 50;

            // 進捗状況に基づいて塗りつぶすブロックの数を計算します
            // 進捗率が0~100であるため、それを進捗バーのブロック数に変換するためには100で割ります
            var filledBlocks = (int)(totalBlocks * progress / 100);

            // 進捗バーを作成します
            var progressBar = new StringBuilder("[");
            progressBar.Append(new string('#', filledBlocks));  // 塗りつぶすブロックを追加
            progressBar.Append(new string('-', totalBlocks - filledBlocks));  // 残りのブロックを追加
            progressBar.Append("]");

            // 進捗率を表示します
            var progressPercentage = progress.ToString("0.00");

            // 進捗バーと進捗率を表示します
            Console.WriteLine($"{progressBar} {progressPercentage}%");
        }
    }
}
