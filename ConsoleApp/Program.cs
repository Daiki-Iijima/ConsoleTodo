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

    //  コマンドの追加
    CommandInvoker command = new CommandInvoker();
    command.InvokeCommands.Add(new AddCommand("add", (arg1) => {
        List<TodoTask> taskList = todo.Add(new TodoTask(arg1));
        OutPutTaskList(taskList);
    }));

    command.InvokeCommands.Add(new RemoveCommand("remove", (arg1) => {
        List<TodoTask> taskList = todo.Delete(new List<int>() { arg1 });
        OutPutTaskList(taskList);
    }));

    //  実行
    bool result = command.Invoke(input);

    //  事項できなかった場合
    if (!result) {
        Console.WriteLine("コマンドが間違っています。");
    }
}

void OutPutTaskList(List<TodoTask> tasks) {
    int No = 0;
    foreach (TodoTask task in tasks) {
        No++;
        Console.WriteLine(No + ":" + task.ToString());
    }
}

