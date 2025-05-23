namespace Lab_3.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }

        public List<Portfolio>? Portfolios { get; set; }
    }
}
