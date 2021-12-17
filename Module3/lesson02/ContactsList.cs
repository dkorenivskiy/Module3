using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lesson02
{
    public class ContactsList
    {
        private char[] _alphabet;
        private SortedDictionary<string, ContactGroup> _groupedContacts = new SortedDictionary<string, ContactGroup>();
        private const string _unknownContactGroup = "#";
        private const string _numericContactGroup = "0-9";


        public ContactsList(char[] alphabet)
        {
            _alphabet = alphabet;
        }

        public void AddContact(string name, string telephoneNumber)
        {
            char firstLetter = name[0];

            Contact contact = new Contact(name, telephoneNumber);

            foreach (char letter in _alphabet)
            {
                if (firstLetter == Char.ToUpper(letter))
                {
                    if (!_groupedContacts.ContainsKey(firstLetter.ToString()))
                    {
                        _groupedContacts.Add(letter.ToString(), new ContactGroup(contact));
                        return;
                    }
                    else
                    {
                        _groupedContacts[letter.ToString()].AddContact(contact);
                        return;
                    }
                }
            }

            if (Char.IsDigit(firstLetter))
            {
                if (!_groupedContacts.ContainsKey(_numericContactGroup))
                {
                    _groupedContacts.Add(_numericContactGroup, new ContactGroup(contact));
                    return;
                }
                else
                {
                    _groupedContacts[_numericContactGroup].AddContact(contact);
                    return;
                }
            }

            if (!_groupedContacts.ContainsKey(_numericContactGroup))
            {
                _groupedContacts.Add(_unknownContactGroup, new ContactGroup(contact));
                return;
            }
            else
            {
                _groupedContacts[_unknownContactGroup].AddContact(contact);
                return;
            }
        }

        public void PrintContactGroups()
        {
            foreach(KeyValuePair<string, ContactGroup> contactGroup in _groupedContacts)
            {
                Console.WriteLine(contactGroup.Key);
                foreach(Contact contact in _groupedContacts[contactGroup.Key].Contacts)
                {
                    contact.PrintContact();
                }
                Console.WriteLine();
            }
        }
    }
}
