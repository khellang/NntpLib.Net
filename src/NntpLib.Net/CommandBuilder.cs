using System;
using System.Collections.Generic;
using System.Linq;

namespace NntpLib.Net
{
    internal class CommandBuilder
    {
        private readonly List<string> _parameters = new List<string>();

        private readonly string _command;

        private CommandBuilder(string command)
        {
            _command = command;
        }

        public void AddParameter<T>(T parameter)
        {
            _parameters.Add(parameter.ToString());
        }

        public void AddParameter(string format, params object[] args)
        {
            _parameters.Add(string.Format(format, args));
        }

        public void AddDateAndTimeParameters(DateTime date)
        {
            AddParameter(date.ToString("yyyyMMdd"));
            AddParameter(date.ToString("HHmmss"));
        }

        public override string ToString()
        {
            return _parameters.Any() ? string.Join(" ", new[] { _command }.Union(_parameters)) : _command;
        }

        public static string Build(string command, Action<CommandBuilder> builder)
        {
            var commandBuilder = new CommandBuilder(command);

            builder(commandBuilder);

            return commandBuilder.ToString();
        }
    }
}