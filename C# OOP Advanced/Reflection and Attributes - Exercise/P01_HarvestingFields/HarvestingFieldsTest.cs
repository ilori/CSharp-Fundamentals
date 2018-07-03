using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HarvestingFieldsTest
{
    private static readonly Type Type = typeof(HarvestingFields);

    public static void Main()
    {
        string input = Console.ReadLine();

        StringBuilder sb = new StringBuilder();

        IEnumerable<FieldInfo> fields = null;

        while (input != "HARVEST")
        {
            switch (input)
            {
                case "private":
                    fields = GetAllPrivateFields();
                    break;
                case "protected":
                    fields = GetAllProtectedFields();
                    break;
                case "public":
                    fields = GetAllPublicFields();
                    break;
                case "all":
                    fields = GetAllFields();
                    break;
            }

            foreach (FieldInfo field in fields)
            {
                string accessModifier = field.Attributes.ToString().ToLower() == "family"
                    ? "protected"
                    : field.Attributes.ToString().ToLower();

                sb.AppendLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(sb.ToString().Trim());
    }

    private static IEnumerable<FieldInfo> GetAllFields()
    {
        return Type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    }

    private static IEnumerable<FieldInfo> GetAllPublicFields()
    {
        return Type.GetFields(BindingFlags.Instance | BindingFlags.Public);
    }

    private static IEnumerable<FieldInfo> GetAllProtectedFields()
    {
        return Type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsFamily);
    }

    private static IEnumerable<FieldInfo> GetAllPrivateFields()
    {
        return Type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsPrivate);
    }
}