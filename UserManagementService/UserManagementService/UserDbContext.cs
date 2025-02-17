using System.Collections.Generic;
using System.Data.Entity;

namespace UserManagementService
{
    public class UserDbContext : DbContext
    {
        
        public UserDbContext() : base("UserDB") { }

       
        public DbSet<UserDTO> Users { get; set; }
    }
}