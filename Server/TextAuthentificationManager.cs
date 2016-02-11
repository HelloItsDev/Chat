using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class TextAuthentificationManager : AuthentificationManager
    {
        public void addUser(string login, string _password)
        {
            try
            {
                using (var entities = new DatabaseEntities() )
                {
                    if (entities.Users.Where(User => User.username == login).Count() == 0)
                    {
                        entities.Users.Add(new User()
                        {
                            username = login,
                            password = _password
                        });

                        entities.SaveChanges();
                    }
                    else
                    {
                        throw new System.ArgumentException("Alias already used", "userExist");
                    }

                }

            }
            catch
            {

            }
        }

        public bool login(string login, string password)
        {
            try
            {
                using (var entities = new DatabaseEntities())
                {
                    if ((entities.Users.Where(User => User.username == login).Count() != 0))
                    {
                        
                        foreach (var user in entities.Users)
                        {
                            
                            if (login == user.username && ("      " + password) == user.password)
                            {
                                
                                return true;
                            }
                        }
                    }
                    else
                    {
                        throw new System.ArgumentException("Alias already used", "userExist");
                    }

                }

            }
            catch
            {
               
                return false;
            }
            
            return true;
        }
    }
}
