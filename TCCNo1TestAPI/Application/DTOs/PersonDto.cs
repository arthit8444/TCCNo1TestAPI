namespace TCCNo1TestAPI.Application.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? Address { get; set; }

        public DateOnly Birthday { get; set; }

        public int Age { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
