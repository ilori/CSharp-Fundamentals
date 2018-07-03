namespace p10_SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            // • 	1 someString - appends someString to the end of the text
            // •	2 count - erases the last count elements from the text
            // •	3 index - returns the element at position index from the text
            // •	4 - undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation

            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            var text = string.Empty;

            for (var i = 0; i < n; i++)
            {
                var commands = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var commandName = commands[0];

                switch (commandName)
                {
                    case "1":
                        text = TextToAppend(stack, text, commands);
                        break;
                    case "2":
                        text = TextToDelete(stack, text, commands);
                        break;
                    case "3":
                        TextDoDisplay(text, commands);
                        break;
                    case "4":
                        text = RevertChanges(stack);
                        break;
                }
            }
        }

        private static string RevertChanges(Stack<string> stack)
        {
            return stack.Pop();
        }

        private static void TextDoDisplay(string text, string[] commands)
        {
            var index = int.Parse(commands[1]);
            var textToDisplay = text[index - 1];
            Console.WriteLine(textToDisplay);
        }

        private static string TextToDelete(Stack<string> stack, string text, string[] commands)
        {
            stack.Push(text);
            var sizeToDelete = int.Parse(commands[1]);
            var length = text.Length - sizeToDelete;
            var textToDelete = text.Substring(0, length);
            text = textToDelete;
            return text;
        }

        private static string TextToAppend(Stack<string> stack, string text, string[] commands)
        {
            var textToAppend = commands[1];

            stack.Push(text);

            text += textToAppend;

            return text;
        }
    }
}