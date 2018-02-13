using System.Collections.Generic;
using iWater.Persistence;
using SQLite;
using Xamarin.Forms;
using System;

namespace iWater
{
    public partial class iWaterPage : ContentPage
    {
        SQLiteAsyncConnection _connection;
        string wmrID;
        string wmwcID;

        public iWaterPage( )
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }
    

        public iWaterPage(List<consumerDetails> list): this()
        {
            //set the data in the reading screen...
            foreach (var data in list)
            {
                wmrID = data.wmrid;
                wmwcID = data.wmwcid;
                lbl_serialno.Text = data.serialno;
                lbl_name.Text = data.ownername;
                lbl_prevValue.Text = data.prevreadingvalue.ToString();
            }
        }

        protected override async void OnAppearing(){
            await _connection.CreateTableAsync<WMSYNC>();
            NavigationPage.SetHasBackButton(this,false);
            base.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void OnSave(object sender, System.EventArgs e)
        {
            double readVal = 0;
            double.TryParse(readingValue.Text,out readVal);
           
            var readingdata = new WMSYNC { wmwc_id = wmwcID , wmr_id = wmrID, readingdate = readingdate.Date, readingvalue =  readVal};

            await _connection.UpdateAsync(readingdata);
            //await DisplayAlert("Save Reading","Done","Ok");
            await Navigation.PopAsync();
        }

        async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
