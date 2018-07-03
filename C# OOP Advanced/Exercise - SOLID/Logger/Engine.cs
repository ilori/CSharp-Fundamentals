namespace Logger
{
    using System;
    using System.Linq;
    using Contracts;
    using Factories;
    using Models;

    public class Engine
    {
        private readonly ILogger logger;
        private readonly ErrorFactory errorFactory;


        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split("|").ToArray();

                string errorLevel = tokens[0];

                string dateTime = tokens[1];

                string message = tokens[2];

                IError error = errorFactory.CreateError(dateTime, errorLevel, message);

                this.logger.Log(error);

                input = Console.ReadLine();
            }

            Console.WriteLine("Logger info");

            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}