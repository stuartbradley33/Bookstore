using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Bookstore
{
    public class BookService
    {
        public List<BookModel> GetBooks()
        {
            try
            {
                string _filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

                string json = File.ReadAllText(_filePath + "/books.json");
                var bookList = JsonSerializer.Deserialize<List<BookModel>>(json);

                return bookList;                        
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
