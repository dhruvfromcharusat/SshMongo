using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ssh.DeviceCommands
{
    public static class Command
    {
        public static double GetCO2Level(this SshClient sshClient)
        {
            var result = sshClient.ExecuteCommand("python3 get_co2.py");
            return double.Parse(result.Output);
        }

        public static double GetTemperature(this SshClient sshClient)
        {
            var result = sshClient.ExecuteCommand("python3 get_temperature.py");
            return double.Parse(result.Output);
        }

        public static double GetHumidity(this SshClient sshClient)
        {
            var result = sshClient.ExecuteCommand("python3 get_humidity.py");
            return double.Parse(result.Output);
        }

        public static double GetPollution(this SshClient sshClient)
        {
            var result = sshClient.ExecuteCommand("python3 get_pollution.py");
            return double.Parse(result.Output);
        }

        public static double GetNoiseLevel(this SshClient sshClient)
        {
            var result = sshClient.ExecuteCommand("python3 get_noise.py");
            return double.Parse(result.Output);
        }

        public static double GetLightLevel(this SshClient sshClient)
        {
            var result = sshClient.ExecuteCommand("python3 get_light.py");
            return double.Parse(result.Output);
        }
    }
}