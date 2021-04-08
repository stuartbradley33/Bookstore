using System;

namespace Bookstore
{
    class Program
    {
        private const double _deliveryFee = 5.95;
        private const double _taxCharge = 1.10;
        private const double _discount = 0.95;

        static void Main(string[] args)
        {
            Console.WriteLine("Your order: " + Environment.NewLine);

            try
            {

                BookService bookService = new BookService();
                var bookList = bookService.GetBooks();

                double runningTotal = 0;
                double runningTotalIncTax = 0;

                foreach (var book in bookList)
                {
                    if (book.Selected)
                    {
                        Console.WriteLine(book.Title);

                        if (book.Genre == "Crime")
                        {
                            runningTotal += (book.Price * _discount);
                            runningTotalIncTax += ((book.Price * _discount) * _taxCharge);
                        }
                        else
                        {
                            runningTotal += book.Price;
                            runningTotalIncTax += (book.Price * _taxCharge);
                        }
                    }
                }

                if (runningTotal < 20)
                {
                    runningTotal += _deliveryFee;
                }

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Total: $" + runningTotal.ToString("0.00"));
                Console.WriteLine("Total Inc. GST: $" + runningTotalIncTax.ToString("0.00"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message) ;
            }

            Console.ReadLine();
        }
    }
}
