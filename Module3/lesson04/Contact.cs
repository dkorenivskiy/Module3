using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson04
{
    public class Contact : IComparable<Contact>
    {
        public string Name { get; set; }

        public string TelephoneNumber { get; set; }

        public string Group { get; set; }

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
