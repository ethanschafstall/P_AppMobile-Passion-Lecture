using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace HttpClientConnection
{
    public class Book
    {
        public int id_book { get; set; }
        public string booTitle { get; set; }
        public int booPageCount { get; set; }
        public string booExcerpt { get; set; }
        public string booSummary { get; set; }
        public double booAvgRating { get; set; }
        public string booCoverImage { get; set; }
        public DateTime booPublishDate { get; set; }
        public int fk_category { get; set; }
        public int fk_publisher { get; set; }

    }

    class CallAPI
    {
        private static HttpClient client = new()
        {
            BaseAddress = new Uri("http://localhost:3000/"),
        };
        public static void GetSunrise()
        {
            HttpClient client = new HttpClient();
            var response = client.GetFromJsonAsync<Book>("http://localhost:3000/api/books/").Result;
            Console.WriteLine(response);
        }
        static void ShowProduct(Book product)
            {
                Console.WriteLine($"Name: {product.booTitle}\tPrice: " +
                    $"{product.booPageCount}\tCategory: {product.fk_category}");
            }

            static async Task<Uri> CreateProductAsync(Book product)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "api/products", product);
                response.EnsureSuccessStatusCode();

                // return URI of the created resource.
                return response.Headers.Location;
            }

            public static async Task<Book> GetProductAsync(string path)
            {
                Book product = null;
                using HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
                
                var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");
            if (response.IsSuccessStatusCode)
                {
                    product = await response.Content.ReadFromJsonAsync<Book>();
                }
                return product;
            }

            static async Task<Book> UpdateProductAsync(Book book)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(
                    $"api/products/{book.id_book}", book);
                response.EnsureSuccessStatusCode();

                // Deserialize the updated product from the response body.
                book = await response.Content.ReadFromJsonAsync<Book>();
                return book;
            }

            static async Task<HttpStatusCode> DeleteProductAsync(int id)
            {
                HttpResponseMessage response = await client.DeleteAsync(
                    $"api/products/{id}");
                return response.StatusCode;
            }

            static void Main()
            {
                RunAsync().GetAwaiter().GetResult();
            }

            static async Task RunAsync()
            {
                // Update port # in the following line.
                client.BaseAddress = new Uri("http://localhost:3000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Create a new product
                    Book book = new Book
                    {
                        id_book = 1,
                        booTitle = "Test",
                        booPageCount = 1,
                        booAvgRating = 1,
                        booCoverImage = "Test",
                        booExcerpt = "Test",
                        booPublishDate = DateTime.Now,
                        booSummary = "Test",
                        fk_category = 1,
                        fk_publisher = 2
                    };

                    var url = await CreateProductAsync(book);
                    Console.WriteLine($"Created at {url}");

                    // Get the product
                    book = await GetProductAsync(url.PathAndQuery);
                    ShowProduct(book);

                    // Update the product
                    Console.WriteLine("Updating price...");
                    book.booPageCount = 80;
                    await UpdateProductAsync(book);

                    // Get the updated product
                    book = await GetProductAsync(url.PathAndQuery);
                    ShowProduct(book);

                    // Delete the product
                    var statusCode = await DeleteProductAsync(book.id_book);
                    Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.ReadLine();
            }
        }
}