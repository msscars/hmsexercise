using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Exercise.App.ConsoleApp.Commands
{
    public abstract class HmsCommandBase
    {
        protected abstract Task<int> OnExecute(CommandLineApplication app);
    }
}
