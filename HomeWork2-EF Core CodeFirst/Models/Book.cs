namespace HomeWork2_EF_Core_CodeFirst.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
