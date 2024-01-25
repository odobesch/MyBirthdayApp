using MyBirthdayApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthdayApp.Data
{
    public class DatabaseContext : IDisposable
    {
        static SQLiteConnection _db;
        bool disposed;

        public DatabaseContext()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyBirthdayAppPeople.db");
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<Person>();
        }

        public ObservableCollection<Person> GetAll()
        {
            var people = new ObservableCollection<Person>();
            var test = _db.Table<Person>();
            foreach (var item in test)
            {
                people.Add(item);
            }
            return people;
        }

        public void Delete(int id)
        {
            _db.Delete<Person>(id);
        }

        public int Update(Person p)
        {
            int result = 0;
            result = _db.Update(p);
            return result;
        }

        public void Insert(Person p)
        {
            _db.Insert(p);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
