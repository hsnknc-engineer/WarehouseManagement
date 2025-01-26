using System;
using System.Collections.Generic;
using System.Linq;
using WMSBackend.Models; // Referenz zu deinem Artikel-Modell


namespace WMSBackend.Repositories
{
    public class ArticleRepository
    {
        // Deklaration der Liste _articles
        private readonly List<Article> _articles; // Liste, die Artikel speichert


        // Constructor
        public ArticleRepository()
        {
            // Initialisierung der Liste _articles im Konstruktor
            _articles = new List<Article>// Beispielhafte Artikel für eine In-Memory-Datenbank
            {
                new Article(1, "Artikel A"),
                new Article(2, "Artikel B"),
                new Article(3, "Artikel C")
            };
        }

        public List<Article> GetAllArticles()
        {
            return _articles; // Gibt die gesamte Artikelliste zurück
        }


        public Article SearchArticleById(int id)
        {
            // 1. Validierung: ID muss größer als 0 sein.
            if (id <= 0)
            {
                throw new ArgumentException("Die ID muss größer als 0 sein.", nameof(id));
            }

            // 2. Suche den Artikel in der Liste
            var article = _articles.FirstOrDefault(a => a.Id == id);

            // 3. Überprüfen, ob ein Artikel gefunden wurde
            if (article == null)
            {
                throw new ArgumentException("Artikel mit dieser ID wurde nicht gefunden.", nameof(id));
            }

            // 4. Artikel zurückgeben
            return article;
        }


        public void AddArticle(Article article)
        {
            // Überprüfe, ob der Artikel null ist
            if (article == null)
                throw new ArgumentNullException(nameof(article), "Artikel darf nicht null sein.");

            // Überprüfe, ob ein Artikel mit derselben ID bereits existiert
            if (_articles.Any(a => a.Id == article.Id))
                throw new ArgumentException("Ein Artikel mit dieser ID existiert bereits.", nameof(article.Id));

            // Füge den Artikel zur Liste hinzu
            _articles.Add(article);
        }


        public bool DeleteArticle(int id)
        {
            // Validierung der ID
            if (id <= 0)
            {
                throw new ArgumentException("Die ID muss größer als 0 sein.", nameof(id));
            }

            // Suche den Artikel mit der angegebenen ID
            var articleToDelete = _articles.FirstOrDefault(a => a.Id == id);

            // Überprüfen, ob der Artikel existiert
            if (articleToDelete == null)
            {
                return false; // Kein Artikel gefunden
            }

            // Entferne den Artikel aus der Liste
            _articles.Remove(articleToDelete);
            return true; // Artikel erfolgreich gelöscht
        }


    }
}