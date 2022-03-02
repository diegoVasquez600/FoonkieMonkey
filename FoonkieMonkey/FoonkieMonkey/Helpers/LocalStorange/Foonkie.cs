using FoonkieMonkey.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoonkieMonkey.Helpers.LocalStorange
{
    public class Foonkie: IFoonkieDB<User>
    {
        static SQLiteAsyncConnection DataBase;
        public static readonly AsyncLazy<Foonkie> Instance = new AsyncLazy<Foonkie>(async () =>
        {
            var instance = new Foonkie();
            CreateTableResult result = await DataBase.CreateTableAsync<User>();
            return instance;
        });

        public Foonkie()
        {
            DataBase = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<User>> GetUsersAsync()
        {
            return DataBase.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            return DataBase.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return DataBase.InsertAsync(user);
        }
    }
}
