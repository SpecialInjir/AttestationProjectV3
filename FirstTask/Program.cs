using FirstTask.Handlers;
using FirstTask.Models;
using FirstTask.Models.Phones;
using FirstTask.Models.Phones.Base;
using FirstTask.Stations;

namespace FirstTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dockStation = new DockStation();
            var dockStation3G = new DockStation3G();

            var callHandler = new CallHandler();

            var defaultPhone = new Phone("123456789123456");
            var threeGPhone = new Phone3G("023456789123456");

            dockStation.Register(defaultPhone);
            dockStation3G.Register(threeGPhone);

            defaultPhone.Called += callHandler.HandleCall;
            threeGPhone.Called += callHandler.HandleCall;

            var contacts = new List<Contact>
            {
                new("Вероника", "111111111"),
                new("Ника", "222222222"),
                new("Алина", "333333333"),
                new("Кирилл", "444444444"),
                new("Максим", "555555555"),
                new("Даниил", "666666666"),
                new("Айбулат", "99999999"),
                new("Лена", "7777777777"),
                new("Павел", "121221212"),
            };

            foreach (var contact in contacts)
            {
                defaultPhone.AddContact(contact);
                threeGPhone.AddContact(contact);
            }

            RunMenu(contacts, defaultPhone, threeGPhone);
        }

        /// <summary>
        /// Запускает главное меню программы.
        /// </summary>
        /// <param name="contacts">Список контактов.</param>
        /// <param name="defaultPhone">Обычный телефон.</param>
        /// <param name="threeGPhone">3G телефон.</param>
        static void RunMenu(List<Contact> contacts, Phone defaultPhone, Phone3G threeGPhone)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Выберите телефон для звонка:");
                Console.WriteLine("1. Обычный телефон");
                Console.WriteLine("2. 3G телефон");
                Console.WriteLine("3. Выйти");

                var phoneChoice = Console.ReadLine();

                switch (phoneChoice)
                {
                    case "1":
                        MakeCall(contacts, defaultPhone);
                        break;
                    case "2":
                        MakeCall(contacts, threeGPhone);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Выполняет звонок с выбранного телефона.
        /// </summary>
        /// <param name="contacts">Список контактов.</param>
        /// <param name="selectedPhone">Выбранный телефон.</param>
        static void MakeCall(List<Contact> contacts, PhoneBase selectedPhone)
        {
            Console.WriteLine("Выберите контакт для звонка:");
            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contacts[i].Name}");
            }
            Console.WriteLine($"{contacts.Count + 1}. Ввести номер вручную");

            var contactChoice = Console.ReadLine();

            if (int.TryParse(contactChoice, out int contactIndex) && contactIndex >= 1 && contactIndex <= contacts.Count)
            {
                selectedPhone.Call(contacts[contactIndex - 1].Number);
            }
            else if (contactChoice == (contacts.Count + 1).ToString())
            {
                Console.WriteLine("Введите номер телефона:");
                var number = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(number))
                {
                    Console.WriteLine("Номер телефона не может быть пустым.");
                }
                else
                {
                    selectedPhone.Call(number);
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
            }
        }
    }
}