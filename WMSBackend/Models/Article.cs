namespace WMSBackend.Models
{
    public class Article
    {
        public int Id { get; set; } // Artikel-ID, muss größer als 0 sein
        public string Name { get; set; } // Name des Artikels, mindestens 3 Zeichen

        public Article(int id, string name)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                throw new ArgumentException("Name must be at least 3 characters long");

            Id = id;
            Name = name;
        }
    }
}
