using System.Collections.Generic;
using iWater.Persistence;
using SQLite;
using Xamarin.Forms;

namespace iWater.Services
{
    public class SQLService
    {
        private SQLiteAsyncConnection _connection;
        private List<WMSYNC> _list;

        public SQLService()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public async void populateList(ListView conListView){
            
            await _connection.CreateTableAsync<WMSYNC>();
            _list = await _connection.Table<WMSYNC>().ToListAsync();

            conListView.ItemsSource = _list;

        }

        public void itemSelected(List<WMSYNC> selected){

            var detail = new iWaterPage();
            // pass the specific consumer data for reading, don't pass everything in the list.

            var details = new List<consumerDetails>() { };
            foreach(var data in details){
                
            }
            //detail.BindingContext = details;
            //await DisplayAlert("name", name.ownername, "ok");
           // await Navigation.PushAsync(new NavigationPage(new iWaterPage(details)));
        }
    }
}
