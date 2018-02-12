using System.Collections.Generic;
using iWater.Persistence;
using SQLite;
using Xamarin.Forms;

namespace iWater
{
    public partial class iWaterPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;

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
                lbl_serialno.Text = data.serialno;
                lbl_name.Text = data.ownername;
                lbl_prevValue.Text = data.prevreadingvalue.ToString();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void OnSave(object sender, System.EventArgs e)
        {
            double readVal = 0;
            double.TryParse(readingValue.Text,out readVal);
            var readingdata = new consumerDetails { readingdate = readingdate.Date, readingvalue =  readVal};

            await _connection.UpdateAsync(readingdata);
            await Navigation.PopAsync();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
