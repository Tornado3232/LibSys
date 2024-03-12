namespace LibSys.Dtos.Book
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public DateTime? PublishDate { get; set; }
        public GetCategoryDto? Category { get; set; }
    }
}
