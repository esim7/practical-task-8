using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientSystem
{
    public class Client
    {
        public string _fullName { get; set; }
        public string _iin { get; set; }//поле ИИН :)
        public int _age { get; set; }
        public string _phoneNumber { get; set; }

        public Client()
        {
            _fullName = "";
            _iin = "";
            _age = 0;
            _phoneNumber = "+77";
        }
        public Client(string FullName, string IIN, int Age, string PhoneNumber)
        {
            _fullName = FullName;
            _iin = IIN;
            _age = Age;
            _phoneNumber = PhoneNumber;
        }
    }
}
