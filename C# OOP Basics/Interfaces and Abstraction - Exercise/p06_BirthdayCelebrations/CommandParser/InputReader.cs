public static class InputReader
{
    public static IResidence Read(string[] args)
    {
        if (args[0].ToLower() == "citizen")
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var id = args[3];
            var birthDate = args[4];
            return new Citizen(name, age, id, birthDate);
        }

        else if (args[0].ToLower() == "robot")
        {
            var model = args[0];
            var id = args[1];
            return new Robot(model, id);
        }
        else if (args[0].ToLower() == "pet")
        {
            var name = args[1];
            var birthDate = args[2];
            return new Pet(name, birthDate);
        }

        return null;
    }
}