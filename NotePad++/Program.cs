using System.Collections.Generic;

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
            int MinVerPos;
            int MaxVerPos;

            ConsoleKey key;
            DateTime date = DateTime.Today;
            int menu = 1; //Номер меню, которое должно выыводиться 1 - основное, 2 - показ записей
            do
            {
                // Дни
                var DaysNotes =
                    from note in notes
                    where note.date == date
                    select note;
                
                switch (menu) //отрисовка
                {
                    case 1:
                        Menu(date);
                        break;
                    case 2:
                        ReadNotes(date, DaysNotes);
                        break;
                }
                WriteCursor(VerPos);

                key = Console.ReadKey().Key;
                switch (menu)
                {
                    case 1:
                        MinVerPos = 1;
                        MaxVerPos = 3;
                        VerPos = UpdateCursorPos(VerPos, MaxVerPos, MinVerPos, key);
                        switch (key) //выбор действия с мейн меню
                        {
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
                                        menu = 2;
                                        break;
                                    case 2: //Тута добавляем записи
                                        AppendNotes(date, notes);
                                        break;
                                    case 3: //Тута выходим из проги нафик
                                        Environment.Exit(0);
                                        break;
                                }
                                break;
                        }
                        break;
                    case 2:
                        MinVerPos = 1;
                        MaxVerPos = MinVerPos+1;
                        
                        foreach (Note note in DaysNotes)
                        {
                            MaxVerPos++;
                        }
                        VerPos = UpdateCursorPos(VerPos, MaxVerPos, MinVerPos, key);

                        switch (key) //выбор действия с меню выбора заметок
                        {
                            case ConsoleKey.Enter:
                                if (VerPos == MaxVerPos)
                                {
                                    menu = 1;
                                }
                                else if (VerPos == MaxVerPos - 1)
                                {
                                    break;
                                }
                                else if (VerPos >= MinVerPos)
                                {
                                    AbouteNote(date, DaysNotes.ToList()[VerPos-1]);
                                }
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
            Console.WriteLine("   3. Выйти из программы");
        }

        static void ReadNotes(DateTime date, IEnumerable<Note> DayNotes)
        {
            Console.Clear();
            Console.WriteLine($"Дата заметок - {date.ToString("D")}");
            foreach (Note note in DayNotes)
            {
                Console.WriteLine($"   {note.name}");
            }
            Console.WriteLine("   ");
            Console.WriteLine("   Выход в меню");
        }

        static void AbouteNote(DateTime date, Note note)
        {
            Console.Clear();
            Console.WriteLine($"{date.ToString("D")}");
            Console.WriteLine("=========================================");
            Console.WriteLine($"{note.name}"); //Вывод названия заметки
            Console.WriteLine($"{note.text}"); //Вывод содержимого заметки
            Console.WriteLine("=========================================");
            Console.WriteLine("Нажмите любую клавишу, чтобы выйти из этого меню");
            Console.ReadKey();
        }

        static void AppendNotes(DateTime date, List<Note> notes) //создание заметок
        {
            Console.Clear();
            Console.WriteLine("Введите название заметки:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите основной текст заметки:");
            string text = Console.ReadLine();
            notes.Add(new Note() { date = date, name = name, text = text });
        }

        static int UpdateCursorPos(int VerPos, int MaxVerPos, int MinVerPos, ConsoleKey key) //Изменение позиции курсора
        {
            switch (key)
            {
                case ConsoleKey.W:
                    VerPos--;
                    if (VerPos < MinVerPos)
                    {
                        VerPos = MinVerPos;
                    }
                    break;
                case ConsoleKey.S:
                    VerPos++;
                    if (VerPos > MaxVerPos)
                    {
                        VerPos = MaxVerPos;
                    };
                    break;
            }
            return VerPos;
        }

        static void WriteCursor(int VerPos) //создание курсора в позиции
        {
            Console.SetCursorPosition(0, VerPos);
            Console.WriteLine("-->");
        }
    }
}