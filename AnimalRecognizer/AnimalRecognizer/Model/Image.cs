namespace AnimalRecognizer.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
        public Pet? Pet { get; set; }
    }
}
