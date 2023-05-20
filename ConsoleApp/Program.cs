// See https://aka.ms/new-console-template for more information
using ConsoleTodo;
using ConsoleTodo.Command;
using ConsoleTodo.Command.Result;
using ConsoleTodo.Commands;
using ConsoleTodo.Display;
using ConsoleTodo.FileIO;
using System.Diagnostics;

Todo todo = new Todo();

bool isLoop = true;

IFileIO fileIO = new TaskFileIO();

IDisplay display = new ConsoleDisplay();

//  タスクを読み込んで追加しておく
var tasks = fileIO.Load();
if (tasks != null) {
    todo.Add(tasks);
}

//  コマンドの追加
CommandInvoker commandInvoker = new CommandInvoker();
commandInvoker.InvokeCommands.Add(new AddCommand(todo));
commandInvoker.InvokeCommands.Add(new DoneCommand(todo));
commandInvoker.InvokeCommands.Add(new DeleteCommand(todo));
commandInvoker.InvokeCommands.Add(new UpdateCommand(todo));
commandInvoker.InvokeCommands.Add(new ListCommand(todo));
commandInvoker.InvokeCommands.Add(new DoneListCommand(todo));
commandInvoker.InvokeCommands.Add(new ProgressCommand(todo));

while (isLoop) {

    Console.WriteLine("Todoコマンドを入力してください");

    string? input = Console.ReadLine();

    if (input == null) {
        isLoop = false;
        return;
    }
    if (input == "exit") {
        isLoop = false;
        return;
    }

    if (input == "help") {
        Console.WriteLine("===============================");
        foreach (ICommandHelpProvider helpProvider in commandInvoker.InvokeCommands) {
            Console.WriteLine(helpProvider.GetHelp());
        }
        Console.WriteLine("===============================");
        continue;
    }

    //  実行
    ICommandResult result = commandInvoker.Invoke(input);

    //  成功していたら保存
    if(result is SuccesTodoCommandResult succesResult) {
        bool showDone = false;
        if(succesResult.CommandName == "progress") {
            display.PrintProgress(float.Parse(succesResult.GetResultMessage()));
            showDone = true;
        }

        List<TodoTask> resultTasks = succesResult.GetTodoCommandResult();
        display.PrintTasks(resultTasks,showDone);

        fileIO.Save(todo.GetAllList());
    }

    //  失敗の場合
    if (result is ErrorCommandResult) {
        display.PrintError(result);
    }
}

