namespace BashSoft.IO.Commands
{
    using Exceptions;
    using Repository;
    using SimpleJudge;

    public class ChangeAbsolutePathCommand : Command
    {
        public ChangeAbsolutePathCommand(string input, string[] data, Tester judge, StudentsRepository repository,
            IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string absolutePath = Data[1];
            this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }
    }
}