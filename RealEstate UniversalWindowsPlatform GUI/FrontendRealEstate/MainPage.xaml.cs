using FrontendRealEstate.DataProvider;
using FrontendRealEstate.Models;
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

namespace FrontendRealEstate
{
   
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();           
            ContentFrame.Navigate(typeof(AllView));                  
        }
   
        private void MenuSelected(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

            var item = NavView.SelectedItem as NavigationViewItem;
            switch (item.Tag)
            {
                case "showAll":
                    ContentFrame.Navigate(typeof(AllView));
                    NavView.Header = "Real Estate Agency";
                    break;
                case "searchBySize":
                    ContentFrame.Navigate(typeof(SearchBySizeView));
                    NavView.Header = "Real Estate Agency";

                    break;
                case "searchByPrice":
                    ContentFrame.Navigate(typeof(SearchPrice));
                    NavView.Header = "Real Estate Agency";
                    break;
                case "CreateNewProperty":
                    ContentFrame.Navigate(typeof(CreateNewProperty));
                    NavView.Header = "Real Estate Agency";
                    break;
                case "DeleteProperty":
                    ContentFrame.Navigate(typeof(DeleteProperty));
                    NavView.Header = "Real Estate Agency";
                    break;
              
                case "About":
                    ContentFrame.Navigate(typeof(About));
                    NavView.Header = "Real Estate Agency";
                    break;
            }
        }
    }
}
