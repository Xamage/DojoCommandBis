using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoCommandBis.Commands
{
    public class CommandProcessor
    {
        public static CommandProcessor Instance = new CommandProcessor();

        public Stack<CommandBase> History { get; set; }
        public Stack<CommandBase> Canceled { get; set; }

        private CommandProcessor() 
        {
            History = new Stack<CommandBase>();
            Canceled = new Stack<CommandBase>();
        }

        public void Do(CommandBase command)
        {
            command.Execute();
            this.History.Push(command);
        }

        public void Undo()
        {
            if (this.History.Count == 0)
            {
                return;
            }

            var lastExecutedCommand = this.History.Pop();
            lastExecutedCommand.Undo();
            this.Canceled.Push(lastExecutedCommand);
        }

        public void Redo()
        {
            var lastCanceledCommand = this.Canceled.Pop();
            lastCanceledCommand.Execute();
            this.History.Push(lastCanceledCommand);
        }
    }
}
