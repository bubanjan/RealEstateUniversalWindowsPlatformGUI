using FrontendRealEstate.DataProvider;
using FrontendRealEstate.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class AllView : Page
    {

        public ObservableCollection<Estate> dataS;
        public AllView()
        {
            this.InitializeComponent();
            dataS = new ObservableCollection<Estate>();
            APIHelper.InitilizeClient();
            getData();

        }
        public async void getData()
        {
            
            DataProviderC qdp = new DataProviderC();
            var currenciesL = await qdp.GetEstatesData();

            foreach (var o in currenciesL)
            {
                
                dataS.Add(o);
            }

        }

    }
}
