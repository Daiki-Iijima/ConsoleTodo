// See https://aka.ms/new-console-template for more information
using ConsoleTodo;
using ConsoleTodo.Command;
using ConsoleTodo.Command.Result;

Todo todo = new Todo();

bool isLoop = true;

TaskFileIO fileIO = new TaskFileIO();

//  タスクを読み込んで追加しておく
var tasks = fileIO.Load();
if (tasks != null) {
    todo.Add(tasks);
}

while (isLoop) {

    Console.WriteLine("Todoコマンドを入力してください");

    string? input = Console.ReadLine();

    if (input == null) {
        isLoop = false;
    }
    if (input == "exit") {
        isLoop = false;
    }

    if (input == "help") {
        Console.WriteLine("追加 : add [TaskName] ..");
        Console.WriteLine("終了 : done [TaskNo] ..");
        Console.WriteLine("削除 : remove [TaskNo] ..");
        Console.WriteLine("更新 : update [TaskNo] [TaskName] ...");
        Console.WriteLine("進行中一覧 : list");
        Console.WriteLine("終了一覧 : donelist");
    }

    //  コマンドの追加
    CommandInvoker command = new CommandInvoker();
    command.InvokeCommands.Add(new AddCommand(todo));
    command.InvokeCommands.Add(new DoneCommand(todo));
    command.InvokeCommands.Add(new DeleteCommand(todo));
    command.InvokeCommands.Add(new UpdateCommand(todo));
    command.InvokeCommands.Add(new ListCommand(todo));
    command.InvokeCommands.Add(new DoneListCommand(todo));

    //  実行
    ICommandResult result = command.Invoke(input);

    //  成功していたら保存
    if(result is SuccesTodoCommandResult succesResult) {
        List<TodoTask> resultTasks = succesResult.GetTodoCommandResult();
        OutPutTaskList(resultTasks);
        fileIO.Save(todo.GetAllTasks());
    }

    //  失敗の場合
    if (result is ErrorCommandResult) {
        Console.WriteLine(result.GetResultMessage());
    }
}

void OutPutTaskList(List<TodoTask> tasks) {
    int No = 0;
    foreach (TodoTask task in tasks) {
        Console.WriteLine(No + ":" + task.ToString());
        No++;
    }
}

