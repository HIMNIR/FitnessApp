using Fitnessapp.Pages;
using Fitnessapp.ViewModel;
using System.Diagnostics;

namespace Fitnessapp
{
    public partial class App : Application
    {
     

        public App()
        {
            InitializeComponent();


            MainPage = new ListViewClass();
        }
       

       
    }
}

