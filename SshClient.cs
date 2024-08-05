using Renci.SshNet;
using Renci.SshNet.Common;
using System.Net;

namespace Ssh
{
    public class SshClient : ISshClient, IDisposable
    {
        private readonly SshCredential _credential;
        private Renci.SshNet.SshClient _client = null!;

        public SshClient(SshCredential credential, int TimeOutInSecond = 30, int ReconnectionAttempts = 0)
        {
            _credential = credential;
            InitilizeClient(TimeOutInSecond, ReconnectionAttempts);
            Connect();
        }

        public void Connect()
        {
            if (_client.IsConnected)
            {
                return;
            }

            try
            {
                _client.Connect();
            }
            catch (Exception ex)
            {
                throw new SshException(ex.Message);
            }
        }

        public bool IsConnected()
        {
            return _client.IsConnected;
        }

        public SshCommandResult ExecuteCommand(string command)
        {
            if (!_client.IsConnected)
            {
                Reconnect();
            }

            var cmd = _client.CreateCommand(command);
            var output = cmd.Execute();
            var error = cmd.Error;
            var exitStatus = cmd.ExitStatus;

            return new SshCommandResult(output, error, exitStatus);
        }

        public void Disconnect()
        {
            if (!_client.IsConnected)
            {
                return;
            }

            _client.Disconnect();
        }

        public void Dispose()
        {
            _client?.Disconnect();
            _client?.Dispose();
        }

        private void Reconnect(int reconnectionAppempt = 3)
        {
            for (int i = 0; i < reconnectionAppempt; i++)
            {
                try
                {
                    Connect();
                    if (_client.IsConnected)
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    System.Threading.Tasks.Task.Delay(1000).Wait();
                }
            }

            if (!_client.IsConnected)
            {
                throw new SshException("Cannot reconnect to the device using ssh.");
            }
        }

        private void InitilizeClient(int TimeOut ,int ReconnectionAppempt)
        {
            _client = new Renci.SshNet.SshClient(_credential.HostName, _credential.UserName, _credential.Password);
            _client.ConnectionInfo.Timeout = TimeSpan.FromSeconds(TimeOut);
            _client.ErrorOccurred += (sender, e) => Reconnect(ReconnectionAppempt);
        }
    }
}