namespace BashSoft.IO.Commands
{
    using Exceptions;
    using Repository;
    using SimpleJudge;

    public class ShowCourseCommand : Command
    {
        public ShowCourseCommand(string input, string[] data, Tester judge, StudentsRepository repository,
            IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (Data.Length == 2)
            {
                string courseName = Data[1];
                this.Repository.GetAllStudentsFromCourse(courseName);
            }
            else if (Data.Length == 3)
            {
                string courseName = Data[1];
                string userName = Data[2];
                this.Repository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}