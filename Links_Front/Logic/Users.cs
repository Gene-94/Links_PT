using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Links_Front.Data;
using Links_Front.Models;


namespace Links_Front.Logic
{
    public class Users
    {
        static public User? Validate(User user)
        {
            try
            {
                using(var db = new ProjectDbContext())
                {
                    var match = db.Users.Single(_user => _user.Email == user.Email); 
                    
                    if (match is not null && match.Password == user.Password)
                    {
                        if (match.Active)
                        {
                            match.LastLogin = DateTime.Now;
                            db.SaveChanges();
                        }
                        return match;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public static List<User>? UserList()
        {

            List<User> _users;

            try
            {
                using (var db = new ProjectDbContext())
                {
                    _users = db.Users.ToList();

                }
                return _users;
            }
            catch
            {
                return null;
            }
        }

        static public bool Exists(User user)
        {
            try
            {
                using (var db = new ProjectDbContext())
                {
                    var match = db.Users.Single(_user => _user.Email == user.Email);

                    if (match is not null)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        static public bool AddUser(User user)
        {
            user.Active = true;
            try
            {
                using (var db = new ProjectDbContext())
                {
                    db.Users.Add(user);

                    var check = db.SaveChanges();

                    if (check != 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public static void DropInctive()
        {
            // Linq syntax is also confusing and there is a lack of a good grasp of its functions, therefore at this point I'm not able to filter for a list of inactive clients
        }



        public static void GenerateUser(string email, char role, int id_person)
        {

            // string password = Membership.GeneratePassword();

            string password = new String(Enumerable.Range(0, 9).Select(n => (Char)((new Random()).Next(32, 127))).ToArray());

            var _user = new User() { Email = email, Password = password, Role = role, Active = true, ReferenceId = id_person };


        }
    }
}
