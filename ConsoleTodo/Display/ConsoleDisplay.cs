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

        public void PrintTasks(List<TodoTask> tasks) {
            int nameMaxLength = 0;
            if (0 < tasks.Count) {
                nameMaxLength = tasks.Max(t => GetDisplayLength(t.ToString()));
            }

            string name = "Name";
            string header = $"| No | {name.PadRight(nameMaxLength)} |";

            string separator = new string('=', header.Length);

            Console.WriteLine(separator);
            Console.WriteLine(header);
            Console.WriteLine(separator);

            for (int i = 0; i < tasks.Count; i++) {
                string paddedName = PadRightConsideringFullWidth(tasks[i].ToString(), nameMaxLength);
                Console.WriteLine("| {0} | {1} |", i.ToString().PadRight(2), paddedName);
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
    }
}
