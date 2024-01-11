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
        ListViewModel lvModel;
        public ListViewClass()
        {
            InitializeComponent();

            lvModel = new ListViewModel();
            BindingContext = lvModel;
           
        }
        private async void DisplayDetails(CollectionViewClass selectedName) {

            string message = $"Name: {selectedName.Name}\n" +
                                   $"Measure: {selectedName.measure}\n" +
                                   $"Grams: {selectedName.grams}\n" +
                                   $"Calories: {selectedName.calories}\n" +
                                   $"Fat: {selectedName.fat}\n" +
                                   $"Sat Fat: {selectedName.Sat_Fat}\n" +
                                   $"Fiber: {selectedName.Fiber}\n" +
                                   $"Carbs: {selectedName.Carbs}\n" +
                                   $"Category: {selectedName.category}";

            await DisplayAlert("Details", message, "OK");


        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            BindingContext = lvModel;
            if (e.Item is CollectionViewClass selectedName)
            {
                DisplayDetails(selectedName);
            }
        }


    }
}
