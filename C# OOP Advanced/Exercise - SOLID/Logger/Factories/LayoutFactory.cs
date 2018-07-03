namespace Logger.Factories
{
    using System;
    using Contracts;
    using Models;

    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            switch (layoutType)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                case "JsonLayout":
                    return new JsonLayout();
                default:
                    throw new ArgumentException($"Invalid Layout!");
            }
        }
    }
}