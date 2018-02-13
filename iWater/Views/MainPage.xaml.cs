using System;
using System.Collections.Generic;
using iWater.Model;
using iWater.Persistence;
using Xamarin.Forms;
using SQLite;
using System.Collections.ObjectModel;

namespace iWater
{
    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private List<WMSYNC> _list;
        private ObservableCollection<WMSYNC> _wmsync;

        public MainPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<WMSYNC>();
            _list = await _connection.Table<WMSYNC>().ToListAsync();
            _wmsync = new ObservableCollection<WMSYNC>(_list);

            conlist.ItemsSource = _wmsync;

            base.OnAppearing();
        }

        async void onItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var detail = new iWaterPage();
            // pass the specific consumer data for reading, don't pass everything in the list.
            var data = e.SelectedItem as WMSYNC;
            var details = new List<consumerDetails>(){
                new consumerDetails{wmrid = data.wmr_id, wmwcid = data.wmwc_id, serialno = data.serialno, ownername = data.ownername, prevreadingvalue = data.prevreadingvalue }
            };
            //detail.BindingContext = details;
            //await DisplayAlert("name", name.ownername, "ok");
            await Navigation.PushAsync(new iWaterPage(details));
        }
    }
}
