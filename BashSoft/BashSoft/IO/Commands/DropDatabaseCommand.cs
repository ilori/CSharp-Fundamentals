namespace BashSoft.IO.Commands
{
    using Exceptions;
    using Repository;
    using SimpleJudge;

    public class DropDatabaseCommand : Command
    {
        public DropDatabaseCommand(string input, string[] data, Tester judge, StudentsRepository repository,
            IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.Repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}