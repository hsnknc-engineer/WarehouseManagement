namespace WMSBackend.Models
{
    public class Article
    {
        public int Id { get; set; } // Automatisch generierte ID

        private string _name = string.Empty; // Standardwert
        public required string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                    throw new ArgumentException("Name must be at least 3 characters long");
                _name = value;
            }
        }

        // Parameterloser Konstruktor (für Entity Framework benötigt)
        public Article() { }
    }
}
