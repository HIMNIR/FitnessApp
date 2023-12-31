namespace Fitnessapp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
           
            InitializeComponent();
           
        }
        private void myInfoTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserInfo());
        }

        private void waterAdded(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserInfo());
        }





    }

}
