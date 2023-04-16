// See https://aka.ms/new-console-template for more information
using ConsoleTodo;
using ConsoleTodo.Command;

Todo todo = new Todo();

bool isLoop = true;
while (isLoop) {

    Console.WriteLine("Todoコマンドを入力してください");

    string? input = Console.ReadLine();

    if (input == null) {
        isLoop = false;
    }
    if(input == "exit") {
        isLoop = false;
    }

    if(input == "help") {
        Console.WriteLine("追加 : add [TaskName]");
        Console.WriteLine("削除 : remove [TaskNo]");
        Console.WriteLine("更新 : update [TaskNo] [TaskName]");
        Console.WriteLine("一覧 : show");
    }

    //  コマンド分解
    Command command = new Command();
    command.AddEvent += (arg1) => {
        List<TodoTask> taskList = todo.Add(new TodoTask(arg1));

        int No = 0;
        foreach (TodoTask task in taskList) {
            No++;
            Console.WriteLine(No + ":" + task.ToString());
        }
    };

    if (command.CheckCommand(input)) {
    } else {
        Console.WriteLine("コマンドが間違っています。");
    }

}
