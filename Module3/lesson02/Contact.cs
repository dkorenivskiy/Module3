﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace lesson02
{
    public class Contact : IComparable<Contact>
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
            Console.WriteLine($"\t{Name} {"",15}{TelephoneNumber}");
        }

        public int CompareTo(Contact other)
        {
            if (other != null)
            {
                return string.Compare(this.Name, other.Name);
            }

            throw new InvalidOperationException();
        }
    }
}
