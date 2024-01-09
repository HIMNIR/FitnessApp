using Csv;
using Fitnessapp.Model;
using Fitnessapp.ViewModel;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials;


namespace Fitnessapp.Pages
{
    public partial class ListViewClass : ContentPage
    {
        public ListViewClass()
        {
            InitializeComponent();

            var lvModel = new ListViewModel();
            BindingContext = lvModel;
           
        }



        
    }
}
