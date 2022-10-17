namespace NotePad__
{
    internal class Program
    {
        static void Main(string[] args) //Хочу стать индусом
        {
            //обявление переменных
            List<Note> notes;
            notes = new List<Note>();
            int VerPos = 1;
            ConsoleKey key;
            DateTime date = DateTime.Today;

            do
            {
                //отрисовка
                Menu(date);
                WriteCursor(VerPos);

                key = Console.ReadKey().Key;
                switch (key) //выбор действия с мейн меню
                {
                    case ConsoleKey.W:
                        VerPos--;
                        if (VerPos < 1)
                        {
                            VerPos = 1;
                        }
                        break;
                    case ConsoleKey.S:
                        VerPos++;
                        if (VerPos > 4)
                        {
                            VerPos = 4;
                        };
                        break;
                    case ConsoleKey.A:
                        date = date.AddDays(-1);
                        break;
                    case ConsoleKey.D:
                        date = date.AddDays(1);
                        break;
                    case ConsoleKey.Enter:
                        switch (VerPos)
                        {
                            case 1: //Тута читаем записи
                                ReadNotes(date, notes);
                                break;
                            case 2: //Тута добавляем записи
                                AppendNotes(date, notes);
                                break;
                            case 3: //Тута удаляем записи
                                break;
                            case 4: //Тута выходим из проги нафик
                                Environment.Exit(0);
                                break;
                        }
                        break;
                }
                Console.Clear();
            } while (true);
        }

        static void Menu(DateTime date) //вывод мейн менюшки
        {
            Console.WriteLine($"{date.ToString("D")}");
            Console.WriteLine("   1. Посмотреть все заметки на этот день");
            Console.WriteLine("   2. Создать заметку на этот день");
            Console.WriteLine("   3. Удалить заметку с этого дня");
            Console.WriteLine("   4. Выйти из программы");
        }
        static void ReadNotes(DateTime date, List<Note> notes)
        {
            Console.Clear();
            Console.WriteLine($"{date.ToString("D")}");
            Console.WriteLine("=========================================");
            foreach (Note note in notes)
            {
                Console.WriteLine(note.name);
            }
            Console.WriteLine("=========================================");
            Console.WriteLine("Введите любой символ для возвращения");
            Console.ReadKey();
        }
        static void AbouteNote(DateTime date)
        {
            Console.WriteLine($"{date.ToString("D")}");
            Console.WriteLine("=========================================");
            Console.WriteLine($""); //Вывод даты заметки
            Console.WriteLine($""); //Вывод названия заметки
            Console.WriteLine($""); //Вывод описания заметки
            Console.WriteLine($""); //Вывод содержимого заметки
            Console.WriteLine("=========================================");
        }
        static void AppendNotes(DateTime date, List<Note> notes) //создание заметок
        {
            Console.Clear();
            Console.WriteLine("Введите название заметки:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите описание завметки:");
            string description = Console.ReadLine();
            Console.WriteLine("Введите основной текст заметки:");
            string text = Console.ReadLine();
            notes.Add(new Note() { date = date, name = name, description = description, text = text });
        }
        static void WriteCursor(int VerPos) //создание курсора в позиции
        {
            Console.SetCursorPosition(0, VerPos);
            Console.WriteLine("-->");
        }
        static void Trash() //ненужный в данный момент код
        {
            int pos = 1;
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                }

            }
        }
    }
}