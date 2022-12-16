using console_pr3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_pr3
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
        public bool FindUsers(string Login)
        {
            var register = s_uVD_BDEntities1.register.Where(x => x.Login == Login);
            if (register.Count() > 0) { return true; }
            else { return false; }
        }

        public bool CreateUsers(register register)
        {
            if (FindUsers(register.Login))
            {
                return false;
            }
            else
            {
                try
                {
                    s_uVD_BDEntities1.register.Add(register);
                    s_uVD_BDEntities1.SaveChanges();
                    return true;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (DbEntityValidationResult validationError in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Object: " + validationError.Entry.Entity.ToString());
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            Console.WriteLine(err.ErrorMessage);
                        }
                    }
                    return false;
                }
            }
        }
    }
}