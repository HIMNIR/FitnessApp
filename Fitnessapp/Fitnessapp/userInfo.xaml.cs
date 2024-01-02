using CommunityToolkit.Mvvm.ComponentModel;
using Fitnessapp.ViewModel;
using Microsoft.Maui.Controls;
using System;

namespace Fitnessapp
{
    public partial class UserInfo : ContentPage
    {

        public UserInfo()
        {
            InitializeComponent();

            var UserInfoViewModel = new UserInfoViewModel().load();


            BindingContext = UserInfoViewModel;
            UserInfoViewModel.Bmi = UserInfoViewModel.CalculateBMI();

            
        }
        public void Saved(object sender, EventArgs e)
        {
            var UserInfoViewModel = new UserInfoViewModel().load();
            BindingContext = UserInfoViewModel;

            UserInfoViewModel.Bmi = UserInfoViewModel.CalculateBMI();
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new MainPage());


            return true;
        }

    }

}