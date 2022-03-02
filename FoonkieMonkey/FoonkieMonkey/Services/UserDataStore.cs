using FoonkieMonkey.Helpers;
using FoonkieMonkey.Helpers.LocalStorange;
using FoonkieMonkey.Models;
using FoonkieMonkey.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoonkieMonkey.Services
{
    public class UserDataStore: IUserDataStore<User>
    {
        HttpClient _httpClient;
        List<User> _users;
        public UserDataStore()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"{API.UsersURI}users")
            };
            _users = new List<User>();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            Foonkie database = await Foonkie.Instance;
            var users = await database.GetUsersAsync();
            return users;
        }

        public async Task<User> GetUserByIdAsync(User user)
        {
            Foonkie database = await Foonkie.Instance;
            var selectedUser = await database.GetUserAsync(user.Id);
            return selectedUser;
        }

        public async Task SaveUsersToLocal(ObservableCollection<User> users)
        {
            Foonkie database = await Foonkie.Instance;
            foreach (var item in users)
            {
                var user = await GetUserByIdAsync(item);
                if (user == null)
                    await database.SaveUserAsync(user);
            }

        }

        public async Task<List<User>> GetUsersAsync(string page)
        {
            
            var json = await _httpClient.GetStringAsync($"?page={page}");
            var response = await Task.Run(() => JsonConvert.DeserializeObject<UserResponse>(json));
            App.TotalUsers = response.Total;
            for (int i = 0; i < response.Data.Count; i++)
            {

                User user = new User
                {
                    Id = response.Data[i].Id,
                    First_Name = response.Data[i].First_Name,
                    Last_Name = response.Data[i].Last_Name,
                    Avatar = response.Data[i].Avatar,
                    Email = response.Data[i].Email,
                };
                _users.Add(user);
            }
            return _users;
        }

        public async Task<int> SaveUserAsync(User user)
        {
            Foonkie database = await Foonkie.Instance;
            var findUser = await GetUserByIdAsync(user);
            if (findUser == null)
                return await database.SaveUserAsync(user);
            else
                return 0;
        }
    }
}
