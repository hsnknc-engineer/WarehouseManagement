using System;
using System.Collections.Generic;
using System.Linq;
using WMSBackend.Data;
using WMSBackend.Models;

namespace WMSBackend.Repositories
{
    public class ArticleRepository
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        // Artikel hinzufügen
        public void AddArticle(Article article)
        {
            if (article == null)
                throw new ArgumentNullException(nameof(article));

            _context.SqlArticles.Add(article); // ID wird automatisch generiert
            _context.SaveChanges(); // Speichern in der Datenbank
        }

        // Artikel per ID suchen
        public Article SearchArticleById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Die ID muss größer als 0 sein.", nameof(id));

            var article = _context.SqlArticles.FirstOrDefault(a => a.Id == id);
            if (article == null)
                throw new KeyNotFoundException($"Kein Artikel mit der ID {id} gefunden.");

            return article;
        }

        // Alle Artikel abrufen
        public List<Article> GetAllArticles()
        {
            return _context.SqlArticles.ToList();
        }

        // Artikel löschen
        public void DeleteArticle(int id)
        {
            var articleToDelete = SearchArticleById(id);
            _context.SqlArticles.Remove(articleToDelete);
            _context.SaveChanges();
        }
    }
}
