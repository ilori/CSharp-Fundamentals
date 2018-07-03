namespace Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Factories;
    using Models;

    public class Program
    {
        public static void Main()
        {
            ILogger logger = InitializeLogger();

            ErrorFactory errorFactory = new ErrorFactory();

            Engine engine = new Engine(logger, errorFactory);

            engine.Run();
        }

        private static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();

            LayoutFactory layoutFactory = new LayoutFactory();

            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int appenderCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appenderCount; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();

                string appenderType = tokens[0];

                string layoutType = tokens[1];

                string errorLevel = "INFO";


                if (tokens.Length == 3)
                {
                    errorLevel = tokens[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);

                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }
    }
}