namespace AnimalRecognizer.Model
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
        enum Type { Cat, Dog }
        public string Breed { get; set; }
        public bool Sterilized { get; set; }
        public bool Passport { get; set; }

    }
}
