using System;
using System.Collections.Generic;


interface IBook
{
    string Title { get; set; }
    string Author { get; set; }
    string ISBN { get; set; }
    int Copies { get; set; }
}

interface IReader
{
    string Name { get; set; }
    int ReaderId { get; set; }
}

interface ILibrary
{
    void AddBook(IBook book);
    void RemoveBook(string isbn);
    void RegisterReader(IReader reader);
    void RemoveReader(int readerId);
    void LendBook(string isbn, int readerId);
    void ReturnBook(string isbn, int readerId);
}

class Book : IBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int Copies { get; set; }

    public Book(string title, string author, string isbn, int copies)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Copies = copies;
    }
}


class Reader : IReader
{
    public string Name { get; set; }
    public int ReaderId { get; set; }

    public Reader(string name, int readerId)
    {
        Name = name;
        ReaderId = readerId;
    }
}


class Library : ILibrary
{
    private List<IBook> books = new List<IBook>();
    private List<IReader> readers = new List<IReader>();

    public void AddBook(IBook book)
    {
        books.Add(book);
        Console.WriteLine($"Книга '{book.Title}' добавлена.");
    }

    public void RemoveBook(string isbn)
    {
        IBook bookToRemove = books.Find(b => b.ISBN == isbn);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"Книга '{bookToRemove.Title}' удалена.");
        }
        else
        {
            Console.WriteLine("Книга не найдена.");
        }
    }

    public void RegisterReader(IReader reader)
    {
        readers.Add(reader);
        Console.WriteLine($"Читатель '{reader.Name}' зарегистрирован.");
    }

    public void RemoveReader(int readerId)
    {
        IReader readerToRemove = readers.Find(r => r.ReaderId == readerId);
        if (readerToRemove != null)
        {
            readers.Remove(readerToRemove);
            Console.WriteLine($"Читатель '{readerToRemove.Name}' удален.");
        }
        else
        {
            Console.WriteLine("Читатель не найден.");
        }
    }

    public void LendBook(string isbn, int readerId)
    {
        IBook bookToLend = books.Find(b => b.ISBN == isbn);
        IReader reader = readers.Find(r => r.ReaderId == readerId);

        if (bookToLend != null && reader != null)
        {
            if (bookToLend.Copies > 0)
            {
                bookToLend.Copies--;
                Console.WriteLine($"Книга '{bookToLend.Title}' выдана читателю '{reader.Name}'.");
            }
            else
            {
                Console.WriteLine($"Нет доступных экземпляров книги '{bookToLend.Title}'.");
            }
        }
        else
        {
            Console.WriteLine("Книга или читатель не найдены.");
        }
    }

    public void ReturnBook(string isbn, int readerId)
    {
        IBook bookToReturn = books.Find(b => b.ISBN == isbn);
        IReader reader = readers.Find(r => r.ReaderId == readerId);

        if (bookToReturn != null && reader != null)
        {
            bookToReturn.Copies++;
            Console.WriteLine($"Книга '{bookToReturn.Title}' возвращена читателем '{reader.Name}'.");
        }
        else
        {
            Console.WriteLine("Книга или читатель не найдены.");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        ILibrary library = new Library(); 
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Удалить книгу");
            Console.WriteLine("3. Зарегистрировать читателя");
            Console.WriteLine("4. Удалить читателя");
            Console.WriteLine("5. Выдать книгу");
            Console.WriteLine("6. Вернуть книгу");
            Console.WriteLine("7. Выйти");
            Console.Write("Введите ваш выбор: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите название книги: ");
                    string title = Console.ReadLine();
                    Console.Write("Введите автора: ");
                    string author = Console.ReadLine();
                    Console.Write("Введите ISBN: ");
                    string isbn = Console.ReadLine();
                    Console.Write("Введите количество экземпляров: ");
                    int copies = int.Parse(Console.ReadLine());

                    IBook newBook = new Book(title, author, isbn, copies); // Используем интерфейс IBook
                    library.AddBook(newBook);
                    break;

                case 2:
                    Console.Write("Введите ISBN книги, которую хотите удалить: ");
                    string removeIsbn = Console.ReadLine();
                    library.RemoveBook(removeIsbn);
                    break;

                case 3:
                    Console.Write("Введите имя читателя: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите ID читателя: ");
                    int readerId = int.Parse(Console.ReadLine());

                    IReader newReader = new Reader(name, readerId); // Используем интерфейс IReader
                    library.RegisterReader(newReader);
                    break;

                case 4:
                    Console.Write("Введите ID читателя, которого хотите удалить: ");
                    int removeReaderId = int.Parse(Console.ReadLine());
                    library.RemoveReader(removeReaderId);
                    break;

                case 5:
                    Console.Write("Введите ISBN книги для выдачи: ");
                    string lendIsbn = Console.ReadLine();
                    Console.Write("Введите ID читателя: ");
                    int lendReaderId = int.Parse(Console.ReadLine());
                    library.LendBook(lendIsbn, lendReaderId);
                    break;

                case 6:
                    Console.Write("Введите ISBN книги для возврата: ");
                    string returnIsbn = Console.ReadLine();
                    Console.Write("Введите ID читателя: ");
                    int returnReaderId = int.Parse(Console.ReadLine());
                    library.ReturnBook(returnIsbn, returnReaderId);
                    break;

                case 7:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
