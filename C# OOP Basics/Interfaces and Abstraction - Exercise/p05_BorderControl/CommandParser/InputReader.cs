public static class InputReader
{
    public static IResidence Read(string[] args)
    {
        if (args.Length == 3)
        {
            var name = args[0];
            var age = int.Parse(args[1]);
            var id = args[2];
            return new Citizen(name, age, id);
        }

        if (args.Length == 2)
        {
            var model = args[0];
            var id = args[1];
            return new Robot(model, id);
        }

        return null;
    }
}