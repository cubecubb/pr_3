using pr_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_3
{
    public class Helper
    {
        private static UVD_BDEntities4 s_uVD_BDEntities1;
        public static UVD_BDEntities4 GetContext()
        {
            if (s_uVD_BDEntities1 == null)
            {
                s_uVD_BDEntities1 = new UVD_BDEntities4();
            }
            return s_uVD_BDEntities1;
        }

        public string FindUsers(string Login, string Password)
        {
            var register = s_uVD_BDEntities1.register.Where(x => x.Login == Login).FirstOrDefault();
            if (register == null)
            {
                return "Такого пользователя нет";
            }
            else
            {
                if (Password == register.Password)
                {
                    switch (register.ID_role)
                    {
                        case 1:
                            return "Вы авторизовались, как администратор";
                            break;
                        case 2:
                            return "Вы авторизовались, как пользователь";
                            break;
                        case 3:
                            return "Вы авторизовались, как модератор";
                            break;
                        case 4:
                            return "Вы авторизовались, как офицер";
                            break;
                        default: return "Такого пользователя нет";
                    }
                }
                else return "Неправильно введен пароль";
            }

        }
    }
}