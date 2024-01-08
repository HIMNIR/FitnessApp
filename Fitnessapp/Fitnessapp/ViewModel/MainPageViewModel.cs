using CommunityToolkit.Mvvm.ComponentModel;
using Plugin.DeviceSensors;
using Plugin.DeviceSensors.Shared;
using System.Diagnostics;

namespace Fitnessapp.ViewModel
{
    public class MainPageViewModel : ObservableObject
    {
        private string name;
        private int countingsteps;
        private double totalsteps;
        private string steps;
        private double CALOS;
        private double Pro;
        private double carbs;
        private double fibers;
        private double fats;
        private double wat;
        private double sugar;
        private DateTime _lastStepTime;
        private const double Threshold = 1.1;
        private const int MinTimeBetweenStepsMs = 500;
        private DateTime lastStepCountTimestamp;


        public Command addWater { get; set; }

        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public string Steps
        {
            get => steps;
            set
            {
                SetProperty(ref steps, value);
                OnPropertyChanged(nameof(DisplaySteps));
            }
        }

        public string DisplayName => $"Welcome {Name}!";

        public string DisplaySteps => $"{CountingSteps}/{TotalSteps}";

        public double Calories
        {
            get => CALOS;
            set => CALOS = value;
        }

        public double Protein
        {
            get => Pro;
            set => Pro = value;
        }

        public double Carbs
        {
            get => carbs;
            set => carbs = value;
        }

        public double Fiber
        {
            get => fibers;
            set => fibers = value;
        }

        public double Fat
        {
            get => fats;
            set => fats = value;
        }

        public double Water
        {
            get => wat;
            set => wat = value;
        }

        public double Sugar
        {
            get => sugar;
            set => sugar = value;
        }

        public int CountingSteps
        {
            get => countingsteps;
            set
            {
                SetProperty(ref countingsteps, value);
                OnPropertyChanged(nameof(DisplaySteps)); // Add this line
                Preferences.Set("CurrentSteps", countingsteps);
                Preferences.Set("LastStepCountTimestamp", DateTime.Now);
            }
        }

        // Update TotalSteps property like this
        public double TotalSteps
        {
            get => totalsteps;
            set
            {
                SetProperty(ref totalsteps, value);
                OnPropertyChanged(nameof(DisplaySteps)); // Add this line
            }
        }

        public MainPageViewModel()
        {
            countingsteps = Preferences.Get("CurrentSteps",0);
            lastStepCountTimestamp = Preferences.Get("LastStepCountTimestamp", DateTime.Now);

            if ( (DateTime.Now - lastStepCountTimestamp) > TimeSpan.FromHours(24)){
                CountingSteps = 0;
                Preferences.Set("CurrentSteps", countingsteps);
                lastStepCountTimestamp = DateTime.Now;
                Preferences.Set("LastStepCountTimestamp", lastStepCountTimestamp);
            }


            addWater = new Command(executeAddWater);

            try
            {
                StartAccelerometer();
            } catch (Exception ex)
            {
                Debug.WriteLine("Already running");
                Debug.WriteLine(ex.StackTrace);
            }
               
               
          
               

            
        }
      

        private void executeAddWater()
        {
            // Your logic for adding water
        }
        private void StartAccelerometer()
        {
            if (Accelerometer.Default.IsSupported)
            {
                
                _lastStepTime = DateTime.Now;
                Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
                Accelerometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                Debug.Write("Accelerometer is not supported on this device.");
            }
        }

        private void Accelerometer_ReadingChanged(object? sender, AccelerometerChangedEventArgs e)
        {
            var x = e.Reading.Acceleration.X;
            var y = e.Reading.Acceleration.Y;
            var z = e.Reading.Acceleration.Z;
            var mag = Math.Sqrt(x * x + y * y+z*z);
           
            MainThread.BeginInvokeOnMainThread(() =>
            {

                if (mag > Threshold && mag<6.0 && (DateTime.Now - _lastStepTime).TotalMilliseconds > MinTimeBetweenStepsMs)
                {
                    Debug.WriteLine(mag);
                    CountingSteps++;
                    _lastStepTime = DateTime.Now;
                }
            });
        }



    }
}
