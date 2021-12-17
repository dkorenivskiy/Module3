using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace lesson02
{
    public class ContactGroup : IComparable<string>
    {
        public string Name { get; set; }

        public SortedSet<Contact> Contacts { get; set; } = new SortedSet<Contact>();
        
        public ContactGroup(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public int CompareTo(string other)
        {
            if (other != null)
            {
                return Name.CompareTo(other);
            }

            throw new InvalidOperationException();
        }
    }
}
