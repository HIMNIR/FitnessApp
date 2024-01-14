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
        private double tempCal;
        private double tempPro;
        private double tempCarbs;
        private double tempFats;
        private double tempFibers;
        private double tempSugar;


        ListViewModel lvModel;

        public double TempCal { get => tempCal; set => tempCal = value; }
        public double TempPro { get => tempPro; set => tempPro = value; }
        public double TempCarbs { get => tempCarbs; set => tempCarbs = value; }
        public double TempFats { get => tempFats; set => tempFats = value; }
        public double TempFibers { get => tempFibers; set => tempFibers = value; }
        public double TempSugar { get => tempSugar; set => tempSugar = value; }

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
                                   $"Protein: {selectedName.protein}\n" +
                                   $"Calories: {selectedName.calories}\n" +
                                   $"Fat: {selectedName.fat}\n" +
                                   $"Sat Fat: {selectedName.Sat_Fat}\n" +
                                   $"Fiber: {selectedName.Fiber}\n" +
                                   $"Carbs: {selectedName.Carbs}\n" +
                                   $"Category: {selectedName.category}";

            bool answer = await DisplayAlert("Details: ", message, "Add", "Cancel");

            if (answer)
            {
                TempCal += selectedName.calories;
                TempPro += selectedName.protein;
                TempCarbs += selectedName.Carbs;
                TempFats += selectedName.fat;
                TempFibers += selectedName.Fiber;
                TempSugar += selectedName.Sat_Fat;



            }


        }

       

    


        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is CollectionViewClass selectedName)
            {
                DisplayDetails(selectedName);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage((new UserTempData(TempCal, TempPro, TempCarbs, TempFats, TempFibers, TempSugar))));
        }
    }
}
