using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoonkieMonkey.Helpers.LocalStorange
{
    public interface IFoonkieDB<User>
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<int> SaveUserAsync(User user);
    }
}
