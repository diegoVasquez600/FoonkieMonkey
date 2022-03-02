using FoonkieMonkey.Models;
using FoonkieMonkey.Services;
using FoonkieMonkey.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoonkieMonkey.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public ObservableCollection<User> UsersCollection { get; set; }
        public Command UserSelectedCommand { get; set; }
        public INavigation Navigation { get; set; }
        public User SelectedUser
        {
            get { return _selectedUser; }
            set 
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    LocalDataStoreAsync(SelectedUser);
                }
            } 
        }

      

        private User _selectedUser { get; set; }
        readonly UserDataStore _getUserData;
        public UsersViewModel(INavigation navigation)
        {
            UsersCollection = new ObservableCollection<User>();
            _getUserData = new UserDataStore();
            Navigation = navigation;
            LoadUsersDataAsync("1");
        }

        private async void LoadUsersDataAsync(string page)
        {
            var users = await _getUserData.GetUsersAsync(page);
            foreach (var item in users)
            {
                UsersCollection.Add(new User
                {
                    Id = item.Id,
                    First_Name = item.First_Name,
                    Last_Name = item.Last_Name,
                    Email = item.Email,
                    Avatar = item.Avatar
                });
                await _getUserData.SaveUserAsync(item);
            }
            if (UsersCollection.Count < App.TotalUsers)
            {
                users.Clear();
                LoadUsersDataAsync("2");
            }
        }
        private async void LocalDataStoreAsync(User user)
        {
            Debug.Write($"Selected User: {user.First_Name} {user.Last_Name} {user.Email}");
            var userFromLocal = await _getUserData.GetUserByIdAsync(user);
            await Navigation.PushModalAsync(new UserDetailFromLocal(userFromLocal));
        }
    }
}
