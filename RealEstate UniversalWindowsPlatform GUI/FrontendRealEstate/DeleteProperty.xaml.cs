using FrontendRealEstate.DataProvider;
using FrontendRealEstate.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FrontendRealEstate
{
    
    public sealed partial class DeleteProperty : Page
        
    {
        public HttpClient ApiClientD { get; set; }
        public ObservableCollection<Estate> dataDS;
        public DeleteProperty()
        {
            this.InitializeComponent();
            dataDS = new ObservableCollection<Estate>();
            APIHelper.InitilizeClient();
            getData();
        }

        private async void getData()
        {
            DataProviderC qdp = new DataProviderC();
            var currenciesL = await qdp.GetEstatesData();

            foreach (var o in currenciesL)
            {

                dataDS.Add(o);
            }

        }

        private void TextBox_OnBeforeTextChangingDL(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            sender.Text = new String(sender.Text.Where(char.IsDigit).ToArray());
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            int idInt;
         
            string idDel;
            idDel = delIDBox.Text;

            bool isNum = int.TryParse(delIDBox.Text, out idInt);
            if (isNum == false)
            {
                idInt = 0;
            }

            List<int> idList = dataDS.Select(x => x.ID).ToList();
            var exists = idList.Contains(idInt);
        
            if(exists)
            {
                if (idDel == "" || idDel == null)
                {
                    infoDelTextBlock.Text = "";
                }
                else
                {
                    DeleteProductAsync(idDel);
                    infoDelTextBlock.Text = "Property with ID: " + idDel + " is deleted successfully";
                }
            }
            else
            {
                infoDelTextBlock.Text = "You wrote ID that does not exist, please try again";
            }
           
                                                   
        }

         async void DeleteProductAsync(string id)
        {
            ApiClientD = new HttpClient();

            HttpResponseMessage response = await ApiClientD.DeleteAsync(
                $"https://realestatewebapi.azurewebsites.net/api/estates/{id}");

            dataDS.Clear();
            getData();

        }
    }
}
