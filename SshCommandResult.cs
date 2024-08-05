using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ssh
{
    public class SshCommandResult(string output, string error, int? exitCode)
    {
        public string? Output { get; } = output;

        public string? Error { get; } = error;

        public int? ExitCode { get; } = exitCode;
    }
}
