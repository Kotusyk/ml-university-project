﻿namespace AnimalRecognizer.Model
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int QuantityOfPets { get; set; }

        public ICollection<Pet> Pets { get; set; }

    }
}
