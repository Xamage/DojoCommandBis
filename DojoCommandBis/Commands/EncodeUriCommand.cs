using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DojoCommandBis.Commands
{
    public class EncodeUriCommand : CommandBase
    {
        public string Input { get; set; }

        public string Result { get; set; }

        public override void Execute()
        {
            string encoded = HttpUtility.UrlEncode(this.Input);

            this.Result = encoded;
        }

        public override void Undo()
        {
            this.Result = HttpUtility.UrlDecode(this.Result);
        }
    }
}