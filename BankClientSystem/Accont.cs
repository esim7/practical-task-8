using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientSystem
{

    public class Account
    {
        const int passwordLength = 6;
        const int accountNumberLegth = 11;
        private static Random random;

        public Client _client { get; set; }
        public string _login { get; set; }
        public string _password { get; set; }
        public string _accountNumber { get; set; }
        public int _balance { get; set; }
        public bool _isBlocked { get; set; } //поле которое отвечает за блокировку аккаунта

        public Account(Client obj)
        {
            random = new Random();
            _client = obj;
            _login = "";
            _password = "";
            for (int i = 0; i < passwordLength; i++)
            {
                char symbol = (char)random.Next(48, 58);
                _password += symbol;
            }
            _balance = 0;
            _accountNumber = "KZ";
            for (int i = 0; i < accountNumberLegth; i++)
            {
                char symbol = (char)random.Next(48, 58);
                _accountNumber += symbol;
            }
            _isBlocked = false;
        }
    }
}
