using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo.Command {
    public interface ICommand : ICommandHelpProvider {
        ICommandResult Execute(string commandStr);
    }
}
