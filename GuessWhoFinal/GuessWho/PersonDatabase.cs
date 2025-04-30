using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWho

{
    public class PersonDatabase
    {
        SQLiteAsyncConnection Database;
        public PersonDatabase()
        {
        }
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Models.Person>();
        }

        public async Task<List<Models.Person>> GetPersonAsync()
        {
            await Init();
            return await Database.Table<Models.Person>().ToListAsync();
        }

        public async Task<Models.Person> GetPersonAsync(int id)
        {
            await Init();
            return await Database.Table<Models.Person>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SavePersonAsync(Models.Person person)
        {
            await Init();
            if (person.ID != 0)
            {
                return await Database.UpdateAsync(person);
            }
            else
            {
                return await Database.InsertAsync(person);
            }
        }

        public async Task<int> DeletePersonAsync(Models.Person person)
        {
            await Init();
            return await Database.DeleteAsync(person);
        }

        public async Task<int> DeleteAllPeopleAsync()
        {
            await Init();
            return await Database.DeleteAllAsync<Models.Person>();
        }
    }
}
