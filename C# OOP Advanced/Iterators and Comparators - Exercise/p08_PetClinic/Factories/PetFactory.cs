namespace p08_PetClinic.Factories
{
    public static class PetFactory
    {
        public static Pet CreatePet(params string[] args)
        {
            string name = args[0];

            int age = int.Parse(args[1]);

            string kind = args[2];

            return new Pet(name, age, kind);
        }
    }
}