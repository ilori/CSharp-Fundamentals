public static class InputReader
{
    public static IBuyer Read(string[] args)
    {
        switch (args.Length)
        {
            case 3:

                var name = args[0];
                var age = int.Parse(args[1]);
                var group = args[2];
                return new Rebel(name, age, group);


            case 4:
                name = args[0];
                age = int.Parse(args[1]);
                var id = args[2];
                var birthDate = args[3];
                return new Citizen(name, age, id, birthDate);
            default: return null;
        }
    }
}