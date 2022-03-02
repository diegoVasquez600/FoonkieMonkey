using FoonkieMonkey.Models;
using FoonkieMonkey.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoonkieMonkey.ViewModels
{
    public class UserDetailViewModel:BaseViewModel
    {
        private UserDataStore _userDataStore;
        public User UserData { get; set; }
        public UserDetailViewModel(User user)
        {
            _userDataStore = new UserDataStore();
            UserData = user;
        }
    }
}
