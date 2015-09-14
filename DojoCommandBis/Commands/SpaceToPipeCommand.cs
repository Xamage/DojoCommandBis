using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoCommandBis.Commands
{
    public class SpaceToPipeCommand : CommandBase
    {
        public string Input { get; set; }

        public string Result { get; set; }

        public override void Execute()
        {
            this.Result = this.Input.Replace(" ", "|");
        }

        public override void Undo()
        {
            this.Result = this.Input.Replace("|", " ");
        }
    }
}
