using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpClientConnection;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace HttpClientConnection
{
    public class APIReponse
    {
        public string message { get; set; }
        public ObservableCollection<Book> data { get; set; }
        public ObservableCollection<Category> data2 { get; set; }
    }
    public class Book
    {
        public int id_book { get; set; }
        public string booTitle { get; set; }
        public int booPageCount { get; set; }
        public string booExcerpt { get; set; }
        public string booSummary { get; set; }
        public string booAvgRating { get; set; } // Changed data type to string
        public string booCoverImage { get; set; }
        public DateTime booPublishDate { get; set; }
        public int fk_user { get; set; }
        public int fk_publisher { get; set; }
    }
    public class Category
    {
        public int id_category { get; set; }
        public string catName { get; set; }

    }
    class HTTP
    {
        public static async Task<List<Book>> GetBooks()
        {
            using (var http = new HttpClient())
            {
                var endpoint = "http://10.0.2.2:3000/api/books/";
                var result = await http.GetAsync(endpoint);
                var json = await result.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                APIReponse obj = JsonSerializer.Deserialize<APIReponse>(json);
                //Debug.WriteLine(obj.data);
                List<Book> books = new List<Book>();
                foreach (var item in obj.data) 
                {
                    books.Add(item);
                }
                return books;
            }
        }
        public static async Task<List<Category>> GetCategories()
        {
            using (var http = new HttpClient())
            {
                var endpoint = "http://10.0.2.2:3000/api/categories/";
                var result = await http.GetAsync(endpoint);
                var json = await result.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                APIReponse obj = JsonSerializer.Deserialize<APIReponse>(json);
                //Debug.WriteLine(obj.data);
                List<Category> categories = new List<Category>();
                foreach (var item in obj.data2)
                {
                    categories.Add(item);
                }
                return categories;
            }
        }
    }
}
