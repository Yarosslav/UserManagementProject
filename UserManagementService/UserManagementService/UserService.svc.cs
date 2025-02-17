using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using UserManagementService;

namespace UserManagementService
{
    public class UserService : IUserService
    {
       
        public List<UserDTO> GetUsers()
        {
            using (var db = new UserDbContext()) 
            {
                return db.Users.ToList();
            }
        }

       
        public UserDTO GetUser(int id)
        {
            using (var db = new UserDbContext())
            {
                return db.Users.Find(id); 
            }
        }
        public void AddUser(UserDTO user)
        {
            using (var db = new UserDbContext())
            {
                user.DateCreated = DateTime.Now;
                user.DateModified = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges(); 
            }
        }

       
        public void UpdateUser(UserDTO user)
        {
            using (var db = new UserDbContext())
            {
                var existingUser = db.Users.Find(user.Id);
                if (existingUser != null)
                {
                    existingUser.FullName = user.FullName;
                    existingUser.DRFO = user.DRFO;
                    existingUser.Email = user.Email;
                    existingUser.Phone = user.Phone;
                    existingUser.DateModified = DateTime.Now;

                    db.SaveChanges();
                }
            }
        }

      
        public void DeleteUser(int id)
        {
            using (var db = new UserDbContext())
            {
                var user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges(); // Сохраняем изменения
                }
            }
        }
    }
}
