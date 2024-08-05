using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ssh
{
    public class SshCredential
    {
        public required string HostName { get; set; }

        public required string UserName { get; set; }

        public required string Password { get; set; }

        public SshCredential(string hostName, string userName, string password)
        {
            if (string.IsNullOrEmpty(hostName) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Any property of the ssh credentials cannot be null.");
            }

            HostName = hostName;
            UserName = userName;
            Password = password;
        }
    }
}
