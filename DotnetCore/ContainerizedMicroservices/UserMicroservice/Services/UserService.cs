using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Data;
using UserMicroservice.Model;
using UserMicroservice.Services.Interface;

namespace UserMicroservice.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _dbContext;

        public UserService(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User AddUser(User user)
        {
            var result = _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteUser(int Id)
        {
            var filteredData = _dbContext.Users.Where(x => x.UserId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
        }

        public IEnumerable<User> GetUserList()
        {
            return _dbContext.Users.ToList();
        }

        public User UpdateUser(User user)
        {
            var result = _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
