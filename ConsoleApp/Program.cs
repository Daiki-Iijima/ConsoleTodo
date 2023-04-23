// See https://aka.ms/new-console-template for more information
using ConsoleTodo;
using ConsoleTodo.Command;

Todo todo = new Todo();

bool isLoop = true;

TaskFileIO fileIO = new TaskFileIO();

//  タスクを読み込んで追加しておく
var tasks = fileIO.Load();
if (tasks != null) {
    foreach (var task in tasks) {
        todo.Add(task);
    }
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
        Console.WriteLine("追加 : add [TaskName]");
        Console.WriteLine("削除 : remove [TaskNo]");
        Console.WriteLine("更新 : update [TaskNo] [TaskName]");
        Console.WriteLine("一覧 : show");
    }

    //  コマンドの追加
    CommandInvoker command = new CommandInvoker();

    command.InvokeCommands.Add(new AddCommand("add", (arg1) => {
        List<TodoTask> taskList = todo.Add(new TodoTask(arg1));
        fileIO.Save(taskList);
        OutPutTaskList(taskList);
    }));

    command.InvokeCommands.Add(new RemoveCommand("remove", (arg1) => {
        List<TodoTask> taskList = todo.Delete(new List<int>() { arg1 });
        fileIO.Save(taskList);
        OutPutTaskList(taskList);
    }));

    command.InvokeCommands.Add(new UpdateCommand("update", dic => {
        List<TodoTask> taskList = todo.Update(dic);

        fileIO.Save(todo.List());

        //  変更したタスクだけを出す
        foreach (TodoTask task in taskList) {
            Console.WriteLine(task.ToString());
        }
    }));

    command.InvokeCommands.Add(new ShowCommand("show", _ => {
        List<TodoTask> taskList = todo.List();
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
        Console.WriteLine(No + ":" + task.ToString());
        No++;
    }
}

