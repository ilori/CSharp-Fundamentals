﻿namespace BashSoft
{
    using IO;
    using Repository;
    using SimpleJudge;

    public class Launcher
    {
        public static void Main()
        {
            var tester = new Tester();
            var ioManager = new IOManager();
            var repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());
            var currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            var reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}