using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine : IRunnable
{
    private IRepository repository;
    private IUnitFactory unitFactory;

    public Engine(IRepository repository, IUnitFactory unitFactory)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                string[] data = input.Split();
                string commandName = data[0];
                string result = InterpredCommand(data, commandName);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private string InterpredCommand(string[] data, string commandName)
    {
        commandName = commandName[0].ToString().ToUpper() + commandName.Substring(1) + "Command";

        Type type = Type.GetType(commandName);

        IExecutable command = (IExecutable) Activator.CreateInstance(type, new object[] {data});

        IEnumerable<FieldInfo> fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(x => x.GetCustomAttributes(false)
                .Any(a => a.GetType() == typeof(InjectAttribute)));

        foreach (FieldInfo field in fields)
        {
            Object classInfo = typeof(Engine)
                .GetField(field.Name, BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(this);

            field.SetValue(command, classInfo);
        }

        string result = command.Execute();

        return result;
    }
}