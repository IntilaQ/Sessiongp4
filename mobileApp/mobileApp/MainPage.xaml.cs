using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Employeebtn_OnClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new PageEmployee());
        }


        private void Departementbtn_OnClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new PageDepartment());
        }
    }
}
