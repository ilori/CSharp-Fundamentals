﻿namespace p06_Twitter.IO
{
    using System;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}