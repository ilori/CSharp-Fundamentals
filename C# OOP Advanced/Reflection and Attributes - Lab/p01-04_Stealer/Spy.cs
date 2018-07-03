using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requiredFields)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(investigatedClass);

        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                                 BindingFlags.NonPublic);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {classInstance.GetType().FullName}");

        foreach (FieldInfo fieldInfo in fields.Where(x => requiredFields.Contains(x.Name)))
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string investigatedClass)
    {
        Type type = Type.GetType(investigatedClass);

        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in privateMethods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in publicMethods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        Type type = Type.GetType(investigatedClass);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {type.FullName}").AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (MethodInfo method in methods)
        {
            sb.AppendLine($"{method.Name}");
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string investigatedClass)
    {
        Type type = Type.GetType(investigatedClass);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (MethodInfo method in methods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (MethodInfo method in methods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}