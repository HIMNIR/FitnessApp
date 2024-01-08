using Fitnessapp.ViewModel;

namespace Fitnessapp;

public partial class Goals : ContentPage
{
	public Goals()
	{
		InitializeComponent();
		var GoalsViewModel = new GoalsViewModel().load();
		BindingContext = GoalsViewModel;
	}

    private void Save_Button_Clicked(object sender, EventArgs e)
    {
        var GoalsViewModel = new GoalsViewModel().load();
        BindingContext = GoalsViewModel;

    }


    private void Main_Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}