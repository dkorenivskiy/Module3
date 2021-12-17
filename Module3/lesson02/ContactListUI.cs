using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson02
{
    class ContactListUI
    {
        private char[] englishAlphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private char[] russianAlphabet = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
        private Dictionary<string, ContactsList> languages = new Dictionary<string, ContactsList>();

        public void Run()
        {
            string choice;
            Console.WriteLine("Choose language");
            Console.WriteLine("1 - English");
            Console.WriteLine("2 - Russian");
            Console.WriteLine("0 - exit");
            choice = Console.ReadLine();

            string contactChoise;
            switch (choice)
            {
                case "2":
                    languages.Add("Russian", new ContactsList(russianAlphabet));
                    do
                    {
                        Console.WriteLine("Вы выбрали Русский язык");

                        Console.WriteLine("1 - Добавить контакт");
                        Console.WriteLine("2 - Показать все контакты");
                        contactChoise = Console.ReadLine();

                        switch (contactChoise)
                        {
                            case "1":
                                Console.WriteLine("Введите имя:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите номер телефона:");
                                string number = Console.ReadLine();

                                languages["Russian"].AddContact(name, number);
                                Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case "2":
                                languages["Russian"].PrintContactGroups();
                                Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    } while (contactChoise != "0");
                    break;

                case "1":
                default:
                    languages.Add("English", new ContactsList(englishAlphabet));
                    do
                    {
                        Console.WriteLine("You've chosen English language");

                        Console.WriteLine("1 - Add contact");
                        Console.WriteLine("2 - Show all contacts");
                        Console.WriteLine("0 - exit");
                        contactChoise = Console.ReadLine();

                        switch (contactChoise)
                        {
                            case "1":
                                Console.WriteLine("Enter the name:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter the phone number:");
                                string number = Console.ReadLine();

                                languages["English"].AddContact(name, number);
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case "2":
                                languages["English"].PrintContactGroups();
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            default:
                                break;
                        }
                    } while (contactChoise != "0");
                    break;
            }
        }
    }
}
