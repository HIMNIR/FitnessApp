using Fitnessapp.ViewModel;
using System.Diagnostics;
using Microsoft.Maui.Devices.Sensors;
using Fitnessapp.Pages;
using Fitnessapp.Model;

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
            InitializeViewModel();
            BindingContext = mpVM;

         
        }


        private void InitializeViewModel()
        {
            goalsVM = new GoalsViewModel();
            uiVM = new UserInfoViewModel();

            mpVM = new MainPageViewModel()
            {
                Name = uiVM.load().UserName,
                TotalSteps = goalsVM.load().Steps,
                TotalCALOS = goalsVM.load().Calories,
                TotalWat = goalsVM.load().Water,
                TotalFats = goalsVM.load().Fat,
                TotalFibers = goalsVM.load().Fiber,
                TotalPro = goalsVM.load().Protein,
                TotalCarbs = goalsVM.load().Carbs,
                TotalSugar = goalsVM.load().Sugar,
            };

            BindingContext = mpVM;
        }

        public MainPage(UserTempData data) : this()
        {
            mpVM.CountingCALOS += data.AddedCalories;
            mpVM.CountingCarbs += data.AddedCarbs;
            mpVM.CountingPro += data.AddedProtein;
            mpVM.CountingFats += data.AddedFats;
            mpVM.CountingFibers += data.AddedFibers;
            mpVM.CountingSugar += data.AddedSugar;
        }


        public double checkNull(double x)
        {
            try
            {
                if (x == 0) return 1;
                return (double)x;
            }catch(Exception ex)
            {
                return 1;
            }
        }

        private void myInfoTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserInfo());
        }
        private void Add_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListViewClass());
        }

     
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Goals());
        }
        


    }
}
