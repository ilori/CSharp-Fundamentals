namespace p08_PetClinic.Factories
{
    public static class ClinicFactory
    {
        public static Clinic CreateClinic(params string[] args)
        {
            string name = args[0];

            int rooms = int.Parse(args[1]);

            return new Clinic(name, rooms);
        }
    }
}