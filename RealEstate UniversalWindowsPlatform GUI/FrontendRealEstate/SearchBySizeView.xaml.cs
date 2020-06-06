using FrontendRealEstate.DataProvider;
using FrontendRealEstate.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace FrontendRealEstate
{
   
    public sealed partial class SearchBySizeView : Page
    {
        public ObservableCollection<Estate> searchSData;
        
        public SearchBySizeView()
        {
            this.InitializeComponent();
            searchSData = new ObservableCollection<Estate>();
            APIHelper.InitilizeClient();
            

            getDataS();
        }

        public async void getDataS()
        {

            DataProviderC qdp = new DataProviderC();
            var currenciesL = await qdp.GetEstatesData();


            foreach (var o in currenciesL)
            {

                searchSData.Add(o);
            }

        }

        private async void SearchBySizeGet(object sender, RoutedEventArgs e)
        {
            int minsize = 0;
            int maxsize = 0;           

            bool res = int.TryParse(minSizeBox.Text, out minsize);
            if (res == false)
            {
                minsize = 0;
            }
            bool res1 = int.TryParse(maxSizeBox.Text, out maxsize);
            if (res1 == false)
            {
                maxsize = 0;
            }
          
            APIHelper.InitilizeClient();
            DataProviderC qdp = new DataProviderC();
            searchSData.Clear();
            var searchByPriceResultList = await qdp.SearhBySizeGet(minsize, maxsize);

            foreach (var o in searchByPriceResultList)
            {
                searchSData.Add(o);
            }

        }

        private void TextBox_OnBeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            sender.Text = new String(sender.Text.Where(char.IsDigit).ToArray());
        }
    }
}
