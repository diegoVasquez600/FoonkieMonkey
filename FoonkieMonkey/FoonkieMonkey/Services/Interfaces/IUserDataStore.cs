using FoonkieMonkey.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FoonkieMonkey.Services.Interfaces
{
    public interface IUserDataStore<User>
    {
        Task<List<User>> GetUsersAsync(string page);
        Task SaveUsersToLocal(ObservableCollection<User> users);
        Task<int> SaveUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(User user);
    }
}
