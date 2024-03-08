namespace LibSys.Models
{
    public class Book
    {
        public string Name{ get; set; }
        public string Author{ get; set; }
        public string Genre{ get; set; }
        public DateTime PublishDate{ get; set; }
        public Category Category{ get; set; }
    }
}
