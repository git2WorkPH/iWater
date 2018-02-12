using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using iWater.Droid.Persistence;
using iWater.Persistence;

[assembly: Dependency(typeof(SQLiteDb))]
namespace iWater.Droid.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection(){

            var dbname = "iWaterDB.db";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, dbname);

            return new SQLiteAsyncConnection(path);
        }
    }
}
