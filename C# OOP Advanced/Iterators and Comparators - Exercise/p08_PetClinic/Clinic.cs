namespace p08_PetClinic
{
    using System;
    using System.Linq;

    public class Clinic
    {
        private Pet[] rooms;
        private readonly int addIndex;
        private readonly int releaseIndex;

        public Clinic(string name, int rooms)
        {
            this.rooms = new Pet[rooms];
            this.Name = name;
            this.addIndex = rooms / 2;
            this.releaseIndex = rooms / 2;
        }

        public string Name { get; }

        public Pet[] Rooms
        {
            get => this.rooms;
            private set
            {
                if (value.Length % 2 == 0)
                {
                    throw new InvalidOperationException("Invalid Operation!");
                }

                this.rooms = value;
            }
        }

        public bool Add(Pet pet)
        {
            if (pet == null)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            for (int i = 0; i <= addIndex; i++)
            {
                if (rooms[addIndex - i] == null)
                {
                    rooms[addIndex - i] = pet;
                    return true;
                }

                if (rooms[addIndex + i] == null)
                {
                    rooms[addIndex + i] = pet;
                    return true;
                }
            }

            return false;
        }

        public bool Release()
        {
            for (int i = releaseIndex; i < rooms.Length; i++)
            {
                if (rooms[i] != null)
                {
                    rooms[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < releaseIndex; i++)
            {
                if (rooms[i] != null)
                {
                    rooms[i] = null;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.rooms.Any(x => x == null);
        }

        public void PrintSingleRoom(int number)
        {
            string result = rooms[number - 1] != null ? $"{rooms[number - 1]}" : "Room empty";

            Console.WriteLine(result);
        }

        public void PrintAllRooms()
        {
            foreach (var pet in rooms)
            {
                if (pet == null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(pet);
                }
            }
        }
    }
}