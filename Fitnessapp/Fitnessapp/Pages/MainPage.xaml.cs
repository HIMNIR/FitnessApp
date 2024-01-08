using Fitnessapp.ViewModel;
using System.Diagnostics;
using Microsoft.Maui.Devices.Sensors;

namespace Fitnessapp
{
    public partial class MainPage : ContentPage
    {
        private UserInfoViewModel uiVM;
        private GoalsViewModel goalsVM;
        private MainPageViewModel mpVM;
     
        public MainPage()
        {
            InitializeComponent();

        goalsVM = new GoalsViewModel();




            uiVM = new UserInfoViewModel();




            mpVM = new MainPageViewModel()
            {
                Name = uiVM.load().UserName,
                TotalSteps = goalsVM.load().Steps,

                Calories = goalsVM.load().Calories,
                Water = goalsVM.load().Water,
                Fat = goalsVM.load().Fat,
                Fiber = goalsVM.load().Fiber,
                Protein = goalsVM.load().Protein,
                Carbs = goalsVM.load().Carbs,
                Sugar = goalsVM.load().Sugar,
               
            };



            BindingContext = mpVM;

         
        }

        private void myInfoTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserInfo());
        }

        private void waterAdded(object sender, EventArgs e)
        {
     
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Goals());
        }
        


    }
}
