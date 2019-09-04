using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientSystem
{
    public class Bank
    {
        public string _name { get; set; }
        public string _bankInfo { get; }
        public Account[] _account;
        public int _acountCount = 0;

        public Account this[int index]
        {
            get
            {
                return _account[index];
            }
            set
            {
                _account[index] = value;
            }
        }
        public Bank()
        {
            _name = "Столичный филиал АО <<ЦЕСНАБАНК>>";
            _bankInfo = "г. Астана, ул Сарайшык 5А тел +7172 58 58 45";
            _account = new Account [0];
        }

        public void AddBalance(Account obj, int sum)
        {
            obj._balance += sum;
            Console.WriteLine($"Успешно пополнено на {sum}. Баланс {obj._balance}");
        }

        public void WithdrawBalance(Account obj, int sum)
        {
            if (obj._balance < sum)
            {
                Console.WriteLine($"Невозможно снять {sum}. Баланс {obj._balance}");
                return;
            }
            obj._balance -= sum;
            Console.WriteLine($"Успешно снятие со счета на сумму {sum}. Баланс {obj._balance}");
        }

        public void AccountRegister(Account obj)
        {
            Console.WriteLine("Для онлайн регистрации введите желаемый логин");
            obj._login = Console.ReadLine();
            ++_acountCount;
            Array.Resize(ref _account, _acountCount);
            _account[_acountCount - 1] = obj;
            Console.WriteLine("Вы успешно зарегистрировали нового пользователя в системе \nВаш логин - " + obj._login + "\nВаш пароль - " + obj._password);
            Console.WriteLine("Ваш номер счета - " + obj._accountNumber + "\nПожалуйста сохраните свои данные");
        }
    }
}
