/*Завдання 3
Створіть додаток «Список книг до прочитання». Додаток
має дозволяти додавати книги до списку, видаляти книги
зі списку, перевіряти чи є книга у списку, і т.д. 
Використовуйте механізм властивостей, навантаження операторів,
індексаторів*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace My_Bookshelf
{
    class BookList
    {
        private List<string> books;

        public BookList()
        {
            books = new List<string>();
        }

        public void AddBook(string title)
        {
            books.Add(title);
        }

        public void RemoveBook(string title)
        {
            books.Remove(title);
        }

        public bool ContainsBook(string title)
        {
            return books.Contains(title);
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < books.Count)
                {
                    return books[index];
                }
                return null;
            }
        }

        public int Count
        {
            get { return books.Count; }
        }

        public static BookList operator +(BookList bookList, string title)
        {
            bookList.AddBook(title);
            return bookList;
        }

        public static BookList operator -(BookList bookList, string title)
        {
            bookList.RemoveBook(title);
            return bookList;
        }

        public static bool operator ==(BookList bookList, string title)
        {
            return bookList.ContainsBook(title);
        }

        public static bool operator !=(BookList bookList, string title)
        {
            return !bookList.ContainsBook(title);
        }
    }

    class Program
    {
        static BookList myBookList = new BookList();

        static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Проверить наличие книги");
                Console.WriteLine("4. Вывести список книг");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите пункт меню: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Введите название книги для добавления: ");
                            string bookToAdd = Console.ReadLine();
                            myBookList += bookToAdd;
                            Console.WriteLine("Книга успешно добавлена.");
                            break;
                        case 2:
                            Console.Write("Введите название книги для удаления: ");
                            string bookToRemove = Console.ReadLine();
                            myBookList -= bookToRemove;
                            Console.WriteLine("Книга успешно удалена.");
                            break;
                        case 3:
                            Console.Write("Введите название книги для проверки: ");
                            string bookToCheck = Console.ReadLine();
                            if (myBookList == bookToCheck)
                            {
                                Console.WriteLine("У вас есть такая книга в списке.");
                            }
                            else
                            {
                                Console.WriteLine("У вас нет такой книги в списке.");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Список книг:");
                            for (int i = 0; i < myBookList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {myBookList[i]}");
                            }
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }
            }
        }
    }
}

