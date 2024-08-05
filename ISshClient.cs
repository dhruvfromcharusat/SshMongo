using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ssh
{
    internal interface ISshClient
    {
        void Connect();

        bool IsConnected();

        void Disconnect();

        SshCommandResult ExecuteCommand(string command);
    }
}
