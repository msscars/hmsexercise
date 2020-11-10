using Hms.Exercise.Domain.ResultAggregate;
using Hms.Exercise.Domain.Services;
using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Exercise.App.ConsoleApp.Commands
{
    [Command(Name = "hms", OptionsComparison = StringComparison.InvariantCultureIgnoreCase)]
    public class HmsCommand : HmsCommandBase
    {
        private readonly IConsole console;
        private readonly ITransform transformService;
        private readonly IResultRepository repository;
        private Result currentResult = null;

        public HmsCommand(IConsole console, ITransform transformService, IResultRepository repository)
        {
            this.console = console;
            this.transformService = transformService;
            this.repository = repository;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var loop = true;

            while(loop)
            {
                loop = await this.PromptForCommand();
            }

            return 0;
        }


        private async Task<bool> PromptForCommand()
        {
            var input = Prompt.GetString($"Select a command calc/save/list/exit:");

            switch (input.ToLower())
            {
                case "calc":
                    this.Calculate();
                    return true;

                case "save":
                    await this.Save();
                    return true;

                case "list":
                    this.List();
                    return true;

                case "exit":
                    return false;

                default:
                    this.console.WriteLine($"command {input} could not be found!");
                    return true;
            }
        }


        private void Calculate()
        {
            var input = Prompt.GetString($"Provide a number to calculate the palindrome for:");
            
            try
            {
                int convertedInput = int.Parse(input);

                var palindrome = this.transformService.Palindrome(convertedInput);

                this.console.WriteLine($"result: {palindrome} cycles: {this.transformService.CyclesNeeded}");

                this.currentResult = new Result
                {
                    Id = Guid.NewGuid(),
                    Input = convertedInput,
                    Palindrome = palindrome,
                    Cycles = this.transformService.CyclesNeeded,
                };


            }
            catch (Exception)
            {
                this.console.WriteLine("Input was not in a correct format. Please try again");
                this.Calculate();
            }
        }

        private async Task Save()
        {
            if (this.currentResult != null)
            {
                await this.repository.AddAsync(this.currentResult);
            }
        }

        private void List()
        {
            var results = this.repository.GetAll().ToList();

            foreach (var item in results)
            {
                this.console.WriteLine($"Id: {item.Id}, Input: {item.Input}, Palindrome: {item.Palindrome}, Cycles: {item.Cycles}");
            }
        }

    }
}
