using InventoryAPI.Contexts;
using InventoryAPI.Models;

namespace InventoryAPI.Repositories
{
    public class UserRepository : Repository<string, User>
    {
        public UserRepository(InventoryContext context) : base(context)
        {
            
        }
        public override ICollection<User> GetAll()
        {
            var users = _context.Users;
            if (users.Count() == 0)
                throw new Exception("No users found");
            return users.ToList();
        }

        public override User GetById(string key)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == key);
            if (user == null)
                throw new Exception($"No such user with username {key}");
            return user;
        }
    }
}
