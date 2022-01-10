using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson04
{
    public class ContactsList
    {
        private char[] _alphabet;
        private List<Contact> _contacts = new List<Contact>();
        private const string _unknownContactGroup = "#";
        private const string _numericContactGroup = "0-9";


        public ContactsList(char[] alphabet)
        {
            _alphabet = alphabet;
        }

        public void AddContact(string name, string telephoneNumber)
        {
            var contact = new Contact(name, telephoneNumber);

            char firstLetter = name.FirstOrDefault<char>();

            bool firstLetterCheck = _alphabet.Any(letter => letter == firstLetter);
            if (firstLetterCheck == true)
            {
                contact.Group = firstLetter.ToString();
            }
            else
            {
                if (char.IsDigit(firstLetter))
                {
                    contact.Group = "0-9";
                }
                else
                {
                    contact.Group = "#";
                }
            }

            _contacts.Add(contact);
        }

        public void PrintContactGroups()
        {
            var groupedContacts = from contact in _contacts
                                  orderby contact.Name
                                  select contact;

            var groupedContacts2 = from contact in groupedContacts
                                   group contact by contact.Group;

            foreach (IGrouping<string, Contact> group in groupedContacts2)
            {
                Console.WriteLine(group.Key);

                foreach (var contact in group)
                {
                    contact.PrintContact();
                }
            }
        }
    }
}
