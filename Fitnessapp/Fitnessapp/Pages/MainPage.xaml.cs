using Fitnessapp.ViewModel;
using System.Diagnostics;
using Microsoft.Maui.Devices.Sensors;
using Fitnessapp.Pages;

namespace Fitnessapp
{
    public partial class MainPage : ContentPage
    {
        private double trackWater;
        private ListViewModel lvvM;
        private UserInfoViewModel uiVM;
        private GoalsViewModel goalsVM;
        private MainPageViewModel mpVM;

        
        public MainPage()
        {
            InitializeComponent();

        goalsVM = new GoalsViewModel();




            uiVM = new UserInfoViewModel();

            lvvM = new ListViewModel();


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
                CountingCALOS = checkNull(lvvM.calories),
                CountingPro = checkNull(lvvM.protein),
                CountingCarbs = checkNull(lvvM.Carbs),
                CountingFats = checkNull(lvvM.fat),
                CountingFibers = checkNull(lvvM.Fiber),
                CountingSugar = checkNull(lvvM.Sat_Fat)
            };



            BindingContext = mpVM;

         
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
