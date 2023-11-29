using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ11OSN
{
    internal class Program
    {


        static void DisplayBooks(Book[] books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}, {book.Author}, {book.Publisher}");
            }
        }


        static void Main(string[] args)
        {
            //Все про рациональные числа 
            Console.WriteLine("После каждого действия нажимайте ENTERб чтобы продолжить");
            Console.ReadKey();
            Console.WriteLine("Введите числитель первой дроби");

            bool a = Int32.TryParse(Console.ReadLine(), out int numeration1);
            Console.WriteLine("Введите знаменатель первой дроби");

            bool b = Int32.TryParse(Console.ReadLine(), out int denominator1);
            Console.WriteLine("Введите числитель второй дроби");

            bool c = Int32.TryParse(Console.ReadLine(), out int numeration2);
            Console.WriteLine("Введите знаменатель второй дроби");

            bool d = Int32.TryParse(Console.ReadLine(), out int denominator2);
            Rational r1 = new Rational(numeration1, denominator1);
            Rational r2 = new Rational(numeration2, denominator2);

            Console.WriteLine("Выберите операцию: + - * /");


            char operation = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Rational result;

            switch (operation)
            {
                case '+':
                    result = r1 + r2;
                    break;
                case '-':
                    result = r1 - r2;
                    break;
                case '*':
                    result = r1 * r2;
                    break;
                case '/':
                    if(numeration2 == 0)
                    {
                        Console.WriteLine("На 0 нельзя делить");
                    }
                    result = r1 / r2;
                    
                    break;
                default: throw new InvalidOperationException("Неизвестная операция");

            }
            Console.ReadKey();
            Console.WriteLine($"Результат: {result}");
            Console.ReadKey();
            // Тестик комплексных чисел 
            Complex num1 = new Complex(1, 2); // 
            Complex num2 = new Complex(3, 4); 

            Complex sum = num1 + num2; 
            Complex difference = num1 - num2; 
            Complex product = num1 * num2; 
            bool areEqual = num1 == num2; 

            Console.WriteLine($"{num1} + {num2} = {sum}");
            Console.WriteLine($"{num1} - {num2} = {difference}");
            Console.WriteLine($"{num1} * {num2} = {product}");
            Console.WriteLine($"{num1} == {num2} = {areEqual}");
            Console.ReadKey();

            // Про сортровку книг 
            Book[] books =
            {
                new Book("Мастер и Маргарита", "М.А.Булгаков", "АСТ"),
                new Book("Портрет Дориана Грея", "Оскар Уайльд", "Эксмо"),
                new Book("Шоколад", "Джовнн Харрис", "Эксмо"),
                new Book("Николай II", "А.Н.Боханов", "Проспект"),



            };
            BookCollection collection = new BookCollection(books);

            Console.WriteLine("How would you like to sort the books?");
            Console.WriteLine("1: По названию");
            Console.WriteLine("2: По авторам");
            Console.WriteLine("3: По изданию");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Сортировка по названию...");
                    collection.Sort((x, y) => x.Title.CompareTo(y.Title));
                    break;
                case "2":
                    Console.WriteLine("Сортировка по Авторам...");
                    collection.Sort((x, y) => x.Author.CompareTo(y.Author));
                    break;
                case "3":
                    Console.WriteLine("Сортировка по Изданию...");
                    collection.Sort((x, y) => x.Publisher.CompareTo(y.Publisher));
                    break;
                default:
                    Console.WriteLine("Ошибка");
                    return;
            }

            DisplayBooks(books); // Вывод запрошенной отсортированной коллекции 
            Console.ReadKey();


        }
    }

}