using FrontendRealEstate.DataProvider;
using FrontendRealEstate.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FrontendRealEstate
{
    public sealed partial class CreateNewProperty : Page
    {
        public HttpClient ApiClientM { get; set; }

        EstateDataPost estateToCreate;
        public CreateNewProperty()
        {
            this.InitializeComponent();
        }

        private async void CreateNewEstate(object sender, RoutedEventArgs e)
        {
            infoTextBlock.Text = "";
            int size;
            int price;
            bool res = int.TryParse(sizeTextBox.Text, out size);
            if (res == false)
            {
                size = 0;
            }
            bool res1 = int.TryParse(priceTextBox.Text, out price);
            if (res1 == false)
            {
                price = 0;
            }
            estateToCreate = new EstateDataPost()
            {
                type = typeTextBox.Text,
                location = locationTextBox.Text,
                description = descriptionTextBox.Text,
                size = size,
                price = price
            };

            ApiClientM = new HttpClient();
            HttpResponseMessage response = await ApiClientM.PostAsJsonAsync(
            "https://realestatewebapinb.azurewebsites.net/api/estates", estateToCreate);
            response.EnsureSuccessStatusCode();

            typeTextBox.Text = "";
            locationTextBox.Text = "";
            descriptionTextBox.Text = "";
            sizeTextBox.Text = "";
            priceTextBox.Text = "";
            infoTextBlock.Text = "Property is saved successfully";

        }

        private void TextBox_OnBeforeTextChangingC(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            sender.Text = new String(sender.Text.Where(char.IsDigit).ToArray());
        }
    }
}
