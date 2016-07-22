using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace mobileApp
{
    public partial class PageDepartment : ContentPage
    {
        public PageDepartment()
        {
            InitializeComponent();
        }


        string WebServiceUrl = "http://localhost:55447/api/Departements/";

        public async Task<List<Departement>> GetDepartement()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var Departements = JsonConvert.DeserializeObject<List<Departement>>(json);

            return Departements;
        }

        public async void PostDepartement(Departement Departement)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(Departement);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);


        }

        public async void PutDepartement(int id, Departement Departement)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(Departement);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);
        }

        public async void DeleteDepartement(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);
        }
        private void PostBtn_OnClicked(object sender, EventArgs e)
        {
            Departement D = new Departement();
            D.Name = Txtpostname.Text;
           
            PostDepartement(D);
        }

        private void PutBtn_OnClicked(object sender, EventArgs e)
        {
            Departement D = new Departement();
            D.Name = Txtputname.Text;
            D.DepartementId = int.Parse(TxtputDepartementId.Text);
          

            var id = D.DepartementId;
            PutDepartement(id, D);
        }

        private void DeleteBtn_OnClicked(object sender, EventArgs e)
        {
            var id = int.Parse(TxtDeleteDepartementId.Text);
            DeleteDepartement(id);
        }

        private async void Getbtn_OnClicked(object sender, EventArgs e)
        {
            List<Departement> departements = await GetDepartement();
            Mainlist.ItemsSource = departements;
        }
    }
}
