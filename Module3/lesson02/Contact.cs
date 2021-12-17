using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace lesson02
{
    public class Contact : IComparable<string>
    {
        public string Name { get; set; }

        public string TelephoneNumber { get; set; }

        public Contact(string name, string number)
        {
            Name = name;
            TelephoneNumber = number;
        }

        public void PrintContact()
        {
            Console.WriteLine($"\t{Name} {0,15}{TelephoneNumber}");
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
