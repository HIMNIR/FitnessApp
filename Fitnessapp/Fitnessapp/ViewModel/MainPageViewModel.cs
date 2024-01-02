using CommunityToolkit.Mvvm.ComponentModel;

namespace Fitnessapp.ViewModel
{
    public class MainPageViewModel : ObservableObject
    {
        private string name;
        private double steps;
        private double CALOS;
        private double Pro;
        private double carbs;
        private double fibers;
        private double fats;
        private double wat;
        private double sugar;
      
       public Command addWater {  get; set;}
        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                OnPropertyChanged(nameof(DisplayName));
            }
        }
        public double Steps
        {
            get => steps;
            set
            {
                SetProperty(ref steps, value);
                OnPropertyChanged(nameof(DisplaySteps));
            }
        }

        public string DisplayName => $"Welcome {Name}!";
        public double DisplaySteps => steps;

        public double Calories { get => CALOS; set => CALOS = value; }
        public double Protein { get => Pro; set => Pro = value; }
        public double Carbs { get => carbs; set => carbs = value; }
        public double Fiber { get => fibers; set => fibers = value; }
        public double Fat { get => fats; set => fats = value; }
        public double Water { get => wat; set => wat = value; }
        public double Sugar { get => sugar; set => sugar = value; }

        public MainPageViewModel()
        {

        }
        private void executeAddWater()
        {

        }
       
           
    }
  
}
