using System.Linq;
using static System.Console;

namespace Hospital
{
    class Programm
    {
        static void Main()
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }

    class Menu
    {
        private const string ShowAllCommand = "1";
        private const string NameSortCommand = "2";
        private const string AgeSortCommand = "3";
        private const string DeseeseShowCommand = "4";
        private const string Exit = "0";

        public void Run()
        {
            string userInput;
            bool isExit = false;

            DataBase dataBase = new DataBase();
            dataBase.CreatePatients();

            while (isExit == false)
            {
                WriteLine();
                WriteLine(ShowAllCommand + " - Показать всех");
                WriteLine(NameSortCommand + " - Сортировка по ФИО");
                WriteLine(AgeSortCommand + " - Сортировка по возрасту");
                WriteLine(DeseeseShowCommand + " - Отобразить пациентов по болезни");
                WriteLine(Exit + " - Выход\n");

                userInput = ReadLine();

                switch (userInput)
                {
                    case ShowAllCommand:
                        dataBase.ShowAllPatients();
                        break;

                    case NameSortCommand:
                        dataBase.SortByName();
                        break;

                    case AgeSortCommand:
                        dataBase.SortByAge();
                        break;

                    case DeseeseShowCommand:
                        dataBase.ShowByDesesse();
                        break;

                    case Exit:
                        isExit = true;
                        break;
                }
            }
        }
    }

    class Patient
    {
        public Patient()
        {
            Name = GetName();
            Deseese = GetDesesse();
            Age = GetAge();
        }

        public string Name { get; private set; }
        public string Deseese { get; private set; }
        public int Age { get; private set; }

        private string GetName()
        {
            string[] criminalNames = new string[]
            {
        "Толя Руль",
        "Вася Шнырь",
        "Петруха Кабан",
        "Гриша Гопник",
        "Дима Толкач",
        "Санек Бульба",
        "Женя Лапоть",
        "Коля Барсук",
        "Леша Халтурка",
        "Сергей Косой",
        "Миша Череп",
        "Олег Огурец",
        "Игорь Чебурек",
        "Витя Колотушка",
        "Юра Мясник",
        "Андрей Бычок",
        "Макс Карась",
        "Павел Колесо",
        "Саша Котлета",
        "Кирилл Бутерброд",
        "Артем Брызгало",
        "Денис Крошка",
        "Никита Пельмень",
        "Стас Пельменище",
        "Ольга Гречка",
        "Елена Блинная",
        "Таня Лапша",
        "Алиса Пирожок",
        "Вика Щи",
        "Яна Афёра",
        "Витя Застрелю",
        "Паша Кабриолет",
        "Коля Чмырь",
        "Миша Мафиозник"
            };

            string name = criminalNames[Utils.GetRandomNumber(criminalNames.Length - 1)];
            return name;
        }

        private string GetDesesse()
        {
            string[] deseesses = new string[]
            {
        "Грипп",
        "Заноза",
        "Красноглазие",
        "Отвал жопы",
        "Шиза",
        "Потеря нюха",
        "Перелом ногтя",
        "Потеря ориентации",
        "Затупление",
        "Передозировка курсов",
        "Воспаление хитрости",
        "Нервный тик-так",
        "Тиктокерство",
        "ФГМ",
        "ПГМ",
        "ЧСВ",
        "Вконтактофилия",
        "Твиттерастия"
            };

            string desesse = deseesses[Utils.GetRandomNumber(deseesses.Length - 1)];
            return desesse;
        }

        private int GetAge()
        {
            int minAge = 18;
            int maxAge = 110;

            return Utils.GetRandomNumber(minAge, maxAge);
        }
    }

    class DataBase
    {
        private int ammountOfRecords = 20;
        private List<Patient> _patients = new List<Patient>();

        public void ShowAllPatients()
        {
            foreach (var patient in _patients)
            {
                WriteLine($"{patient.Name}, Рост {patient.Age}, {patient.Deseese}");
            }
        }

        public void SortByName()
        {
            WriteLine("Пациенты отсортированные по ФИО");

            var patientsByName = _patients.OrderBy(patient => patient.Name).ToList();

            foreach (var patient in patientsByName)
            {
                WriteLine($"{patient.Name}, Рост {patient.Age}, {patient.Deseese}");
            }
        }

        public void SortByAge()
        {
            WriteLine("Пациенты отсортированные по возрасту");

            var patientsByAge = _patients.OrderBy(patient =>patient.Age).ToList();

            foreach (var criminal in patientsByAge)
            {
                WriteLine($"{criminal.Name}, Рост {criminal.Age}, {criminal.Deseese}");
            }
        }

        public void ShowByDesesse()
        {
            WriteLine("Введите название болезни:");

            string deseesse = ReadLine();

            var patients = from Patient patient in _patients where patient.Deseese.ToLower() == deseesse.ToLower() select patient;

            if (patients.Count() == 0)
            {
                WriteLine("Ничего не найдено");
            }

            foreach (var patient in patients)
            {
                WriteLine($"{patient.Name}, Рост {patient.Age}, {patient.Deseese}");
            }
        }

        public void CreatePatients()
        {
            for (int i = 0; i < ammountOfRecords; i++)
            {
                _patients.Add(new Patient());
            }
        }
    }

    class Utils
    {
        private static Random s_random = new Random();

        public static int GetRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }

        public static int GetRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }
    }
}

//У вас есть список больных(минимум 10 записей)
//Класс больного состоит из полей: ФИО, возраст, заболевание.
//Требуется написать программу больницы, в которой перед пользователем будет меню со следующими пунктами:
//1)Отсортировать всех больных по фио
//2)Отсортировать всех больных по возрасту
//3)Вывести больных с определенным заболеванием
//(название заболевания вводится пользователем с клавиатуры) 