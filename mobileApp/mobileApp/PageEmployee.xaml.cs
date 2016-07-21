using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace mobileApp
{
    public partial class PageEmployee : ContentPage
    {
        public PageEmployee()
        {
            InitializeComponent();
        }

        string WebServiceUrl = "http://localhost:55447/api/Employees/";

        public async Task<List<Employee>> GetEmployee()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            return employees;
        }

        public async void PostEmployee(Employee employee)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(employee);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

           
        }

        public async void PutEmployee(int id, Employee employee)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(employee);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);
        }

        public async void DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);
        }

        private void PostBtn_OnClicked(object sender, EventArgs e)
        {
          Employee E=new Employee();
            E.Name = Txtpostname.Text;
            E.Age = int.Parse(TxtpostAge.Text);
            E.DepartementId =int.Parse(TxtpostdepartementId.Text) ;
            PostEmployee(E);
        }

        private void PutBtn_OnClicked(object sender, EventArgs e)
        {
       Employee E=new Employee();
            E.Name = Txtputname.Text;
            E.Age = int.Parse(TxtputAge.Text);
            E.DepartementId = int.Parse(TxtputdepartementId.Text);
            E.EmployeeId = int.Parse(TxtputEmployeeId.Text);

            var id = E.EmployeeId;
            PutEmployee(id,E);
        }

        private void DeleteBtn_OnClicked(object sender, EventArgs e)
        {
            var id =int.Parse(TxtDeleteEmployeeId.Text);
            DeleteEmployee(id);
        }

        private async void Getbtn_OnClicked(object sender, EventArgs e)
        {
            List<Employee> Employees = await GetEmployee();
            Mainlist.ItemsSource = Employees;
        }
    }
}
