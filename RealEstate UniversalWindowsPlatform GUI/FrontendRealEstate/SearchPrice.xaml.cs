using FrontendRealEstate.DataProvider;
using System;
using System.Collections.Generic;
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

using System.Collections.ObjectModel;
using FrontendRealEstate.Models;
using System.Text.RegularExpressions;

namespace FrontendRealEstate
{
    

    public sealed partial class SearchPrice : Page
    {
        public ObservableCollection<Estate> searchPData;
        int minprice;
        int maxprice;
        public SearchPrice()
        {
            this.InitializeComponent();
            searchPData = new ObservableCollection<Estate>();
            APIHelper.InitilizeClient();
            getDataS();
        }

        public async void getDataS()
        {

            DataProviderC qdp = new DataProviderC();
            var currenciesL = await qdp.GetEstatesData();
            

            foreach (var o in currenciesL)
            {
               
                searchPData.Add(o);
            }

        }

        private async void SearchByPriceClick(object sender, RoutedEventArgs e)
        {
            bool res = int.TryParse(minPriceBox.Text, out minprice);
            if (res == false)
            {
                minprice = 0;
            }
            bool res1 = int.TryParse(maxPriceBox.Text, out maxprice);
            if (res1 == false)
            {
                maxprice = 0;
            }
            APIHelper.InitilizeClient();
            DataProviderC qdp = new DataProviderC();
            searchPData.Clear();
            var searchByPriceResultList = await qdp.SearhByPriceGet(minprice, maxprice);
           
            foreach(var o in searchByPriceResultList)
            {
                searchPData.Add(o);
            }

           
        }

        private void TextBox_OnBeforeTextChanging1(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}
