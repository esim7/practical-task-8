using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientSystem
{
    class Program
    {
        const int zero = 0;

        static void Main(string[] args)
        {
            bool isActive = true;
            int key;
            Bank bank = new Bank();
            do
            {   
                if(bank._acountCount == zero)
                {
                    Client client = new Client();
                    Console.WriteLine("Уважаемый клиент приветствуем Вас в нашей онлайн службе банка " + bank._name);
                    Console.WriteLine("Введите как мы можем к Вам обращаться");
                    client._fullName = Console.ReadLine();
                    Console.WriteLine("Введите сколько Вам лет");
                    client._age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите Ваш ИИН");
                    client._iin = Console.ReadLine();
                    Console.WriteLine("Введите Ваш мобильный номер телефона");
                    client._phoneNumber = Console.ReadLine();
                    Account account = new Account(client);
                    bank.AccountRegister(account);
                    Console.ReadKey();
                }
                Console.Clear();
                Console.WriteLine("1. Зарегистрировать пользователя (Открыть счет) \n2. Личный кабинет пользователя(Только зарегистрированные пользователи)" +
                                  "\n3. Информация о банке \n4. Выход");
                try
                {
                    key = int.Parse(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Client client = new Client();
                                Console.WriteLine("Введите как мы можем к Вам обращаться");
                                client._fullName = Console.ReadLine();
                                Console.WriteLine("Введите сколько Вам лет");
                                client._age = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите Ваш ИИН");
                                client._iin = Console.ReadLine();
                                Console.WriteLine("Введите Ваш мобильный номер телефона");
                                client._phoneNumber = Console.ReadLine();
                                Account account = new Account(client);
                                bank.AccountRegister(account);
                            }
                            break;
                        case 2:
                            {
                                Console.Clear();
                                int attempt = 3;
                                int index = 0;
                                bool isTrueAccount = false;
                                Console.WriteLine("Введите имя пользователя для входа в личный кабинет");
                                string login = Console.ReadLine();
                                for(int i = 0; i < bank._acountCount; i++)
                                {
                                    if(bank._account[i]._login == login)
                                    {
                                        index = i;
                                        isTrueAccount = true;
                                        break;
                                    }
                                }
                                if (!isTrueAccount)
                                {
                                    Console.WriteLine("Ошибка! Данный аккаунт не заригестрирован в системе");
                                }
                                else if (isTrueAccount && bank[index]._isBlocked == true)
                                {
                                    Console.WriteLine("Аккаунт заблокирован, обратитесь в отделение банка");
                                }
                                else if (isTrueAccount)
                                {
                                    bool backToMainMenu = false;
                                    while (!bank[index]._isBlocked && !backToMainMenu)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите пароль");                                    
                                        string password = Console.ReadLine();
                                        if (bank[index]._password != password && attempt != 0)
                                        {
                                            Console.WriteLine("Пароль не верный, повторите попытку.\nОсталось " + (attempt - 1) + " попыток до блокировки \nПовторите ввод");
                                            attempt--;
                                        }
                                        else if (attempt == 0)
                                        {
                                            Console.WriteLine("Пользователь " + bank[index]._login + " заблокирован, обратитесь в Банк");
                                            bank[index]._isBlocked = true;
                                        }
                                        else if (bank[index]._password == password && attempt != 0)
                                        {
                                            Console.Clear();
                                            int command;
                                            Console.WriteLine("1. Пополнить счет\n2. Снятие со счета\n3. Вывести остаток на экран");
                                            command = int.Parse(Console.ReadLine());
                                            if(command == 1)
                                            {
                                                Console.WriteLine("Введите сумму пополнения (тенге)");
                                                int sum = int.Parse(Console.ReadLine());
                                                bank.AddBalance(bank._account[index], sum);
                                                Console.WriteLine("0. Выйти из программы \n1. Вернуться в главное меню");
                                                int action = int.Parse(Console.ReadLine());
                                                if (action == 0)
                                                {
                                                    backToMainMenu = true;
                                                    isActive = false;
                                                }
                                                else if (action == 1)
                                                {
                                                    backToMainMenu = true;
                                                }
                                            }
                                            else if(command == 2)
                                            {
                                                Console.WriteLine("Введите сумму для снятия (тенге)");
                                                int sum = int.Parse(Console.ReadLine());
                                                bank.WithdrawBalance(bank._account[index], sum);
                                                Console.WriteLine("0. Выйти из программы \n1. Вернуться в главное меню");
                                                int action = int.Parse(Console.ReadLine());
                                                if (action == 0)
                                                {
                                                    backToMainMenu = true;
                                                    isActive = false;
                                                }
                                                else if (action == 1)
                                                {
                                                    backToMainMenu = true;
                                                }
                                            }
                                            else if (command == 3)
                                            {
                                                Console.WriteLine("Остаток денег на счету клиента " + bank._account[index]._login
                                                            + " равен " + bank._account[index]._balance + " тенге");
                                                Console.WriteLine("0. Выйти из программы \n1. Вернуться в главное меню");
                                                int action = int.Parse(Console.ReadLine());
                                                if (action == 0)
                                                {
                                                    backToMainMenu = true;
                                                    isActive = false;
                                                }
                                                else if (action == 1)
                                                {
                                                    backToMainMenu = true;
                                                }
                                            }
                                        }
                                        Console.ReadKey();
                                    }
                                }
                            }
                            break;
                        case 3:
                            {
                                Console.WriteLine("г. Астана, ул. Сыганак, 24 \nТелефоны: +7(7172) 58 - 77 - 11\nФакс: +7(7172) 770–195\nE - mail: info@tsb.kz");
                            }
                            break;
                        case 0:
                            isActive = false;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверная команда, для выбора комманды нужно ввести целое число!!!");
                }
                Console.ReadLine();

            } while (isActive != false);
        }
    }
}