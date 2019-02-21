using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetLibrary.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZIP { get; set; }
        public string Town { get; set; }
        public string Telephone { get; set; }

        public Customer(int id, string name, string address, string zIP, string town, string telephone)
        {
            Id = id;
            Name = name;
            Address = address;
            ZIP = zIP;
            Town = town;
            Telephone = telephone;
        }
        public override string ToString()
        {
            return $"{Id},{Name},{Address},{ZIP},{Town},{Telephone}";
        }
    }
}
