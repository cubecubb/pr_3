using console_pr3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace console_pr3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashPassword.Passhash hash = new HashPassword.Passhash();
            Helper helper = new Helper();
            UVD_BDEntities4 db = Helper.GetContext();
            Console.Write("Создание новой учетной записи для пользователя\n\nВыберите роль (1 - администратор, 2 - пользователь, 3 - модератор, 4 - офицер.): ");
            int role = 0;
            int gender = 0;
            try
            {
                role = Convert.ToInt32(Console.ReadLine());
                while (role < 1 && role > 4)
                {
                    Console.Write("Неверный вариант роли. Выберите роль (1 - администратор, 2 - пользователь, 3 - модератор, 4 - офицер.): ");
                    role = Convert.ToInt32(Console.ReadLine());
                }
                Console.Write("Введите имя пользователя: ");
                string name = Console.ReadLine();
                Console.Write("Введите фамилию пользователя: ");
                string surname = Console.ReadLine();
                Console.Write("Введите отчество пользователя (при отсутствии нажмите Enter): ");
                string lastname = Console.ReadLine();
                Console.Write("Введите пол (1 - мужской, 2 - женский, 3 - non-binary.): ");
                gender = Convert.ToInt32(Console.ReadLine());
                while (gender < 1 && gender > 3)
                {
                    Console.Write("Неверный пол. Выберите пол (1 - мужской, 2 - женский, 3 - non-binary.): ");
                    gender = Convert.ToInt32(Console.ReadLine());
                }
                Console.Write("Введите логин пользователя: ");
                string login = Console.ReadLine();
                Console.Write("Введите пароль пользователя: ");
                string password = Console.ReadLine();

                password = hash.HashPassword(password);
                Console.WriteLine("Хешированный пароль пользователя: " + password);

                register register = new register();//создаем экземпляр
                register.Login = login;
                register.Password = password;
                register.Name = name;
                register.Surname = surname;
                register.Last_Name = lastname;
                register.ID_gender = gender;
                register.ID_role = role;

                if (helper.CreateUsers(register))
                {
                    Console.WriteLine("Учетная запись добавлена.");
                }
                else
                {
                    Console.WriteLine("Такой пользователь уже существует.");
                }
                Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода. Вам нужно ввести число.");
                Console.ReadLine();
            }
        }
    }
}

