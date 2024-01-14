using CommunityToolkit.Mvvm.ComponentModel;
using Fitnessapp.Model;
using Fitnessapp.Pages;
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
    

        private double countingCALOS;
        private double totalCALOS;
      
        private double countingPro;
        private double totalPro;
      
        private double countingCarbs;
        private double totalCarbs;
       
        private double countingFibers;
        private double totalFibers;
      
        private double countingFats;
        private double totalFats;
    
        private double countingWat;
        private double totalWat;
     
        private double countingSugar;
        private double totalSugar;
        private DateTime _lastStepTime;
        private const double Threshold = 1.1;
        private const int MinTimeBetweenStepsMs = 500;
        private DateTime lastStepCountTimestamp;
        private DateTime lastCALOSCountTimestamp;
        private DateTime lastProCountTimestamp;
        private DateTime lastCarbsCountTimestamp;
        private DateTime lastFibersCountTimestamp;
        private DateTime lastFatsCountTimestamp;
        private DateTime lastWatCountTimestamp;
        private DateTime lastSugarCountTimestamp;


       




      



      

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



        public string DisplayName => $"Welcome {Name}!";

      

        public int CountingSteps
        {
            get => countingsteps;
            set
            {
                SetProperty(ref countingsteps, value);
                OnPropertyChanged(nameof(DisplaySteps));
                OnPropertyChanged(nameof(StepsProgress));
                OnPropertyChanged(nameof(StepsPercentage));
                Preferences.Set("CurrentSteps", countingsteps);
                Preferences.Set("LastStepCountTimestamp", DateTime.Now);
            }
        }


        public double TotalSteps
        {
            get => totalsteps;
            set
            {
                SetProperty(ref totalsteps, value);
                OnPropertyChanged(nameof(DisplaySteps));
                OnPropertyChanged(nameof(StepsProgress));
                OnPropertyChanged(nameof(StepsPercentage));
            }
        }

        public string DisplaySteps => $"{CountingSteps}/{TotalSteps}";

        public double StepsProgress => CountingSteps / TotalSteps;

        public double StepsPercentage => StepsProgress * 100;



        public double CountingCALOS
        {
            get => countingCALOS;
            set
            {
                SetProperty(ref countingCALOS, value);
                OnPropertyChanged(nameof(DisplayCALOS));
                OnPropertyChanged(nameof(CalosProgress));
                OnPropertyChanged(nameof(CalosPercentage));
                Preferences.Set("CurrentCALOS", countingCALOS);
                Preferences.Set("LastCALOSCountTimestamp", DateTime.Now);
            }
        }

        public double TotalCALOS
        {
            get => totalCALOS;
            set
            {
                SetProperty(ref totalCALOS, value);
                OnPropertyChanged(nameof(DisplayCALOS));
                OnPropertyChanged(nameof(CalosProgress));
                OnPropertyChanged(nameof(CalosPercentage));
            }
        }

        public string DisplayCALOS => $"{CountingCALOS}/{TotalCALOS}";

        public double CalosProgress => CountingCALOS / TotalCALOS;

        public double CalosPercentage => CalosProgress * 100;

        public double CountingPro
        {
            get => countingPro;
            set
            {
                SetProperty(ref countingPro, value);
                OnPropertyChanged(nameof(DisplayPro));
                OnPropertyChanged(nameof(ProProgress));
                OnPropertyChanged(nameof(ProPercentage));
                Preferences.Set("CurrentPro", countingPro);
                Preferences.Set("LastProCountTimestamp", DateTime.Now);
            }
        }

        public double TotalPro
        {
            get => totalPro;
            set
            {
                SetProperty(ref totalPro, value);
                OnPropertyChanged(nameof(DisplayPro));
                OnPropertyChanged(nameof(ProProgress));
                OnPropertyChanged(nameof(ProPercentage));
            }
        }

        public string DisplayPro => $"{CountingPro}/{TotalPro}";

        public double ProProgress => CountingPro / TotalPro;

        public double ProPercentage => ProProgress * 100;




        public double CountingCarbs
        {
            get => countingCarbs;
            set
            {
                SetProperty(ref countingCarbs, value);
                OnPropertyChanged(nameof(DisplayCarbs));
                OnPropertyChanged(nameof(CarbsProgress));
                OnPropertyChanged(nameof(CarbsPercentage));
                Preferences.Set("CurrentCarbs", countingCarbs);
                Preferences.Set("LastCarbsCountTimestamp", DateTime.Now);
            }
        }

        public double TotalCarbs
        {
            get => totalCarbs;
            set
            {
                SetProperty(ref totalCarbs, value);
                OnPropertyChanged(nameof(DisplayCarbs));
                OnPropertyChanged(nameof(CarbsProgress));
                OnPropertyChanged(nameof(CarbsPercentage));
            }
        }

        public string DisplayCarbs => $"{CountingCarbs}/{TotalCarbs}";

        public double CarbsProgress => CountingCarbs / TotalCarbs;

        public double CarbsPercentage => CarbsProgress * 100;








        public double CountingFibers
        {
            get => countingFibers;
            set
            {
                SetProperty(ref countingFibers, value);
                OnPropertyChanged(nameof(DisplayFibers));
                OnPropertyChanged(nameof(FiberProgres));
                OnPropertyChanged(nameof(FiverPercentage));
                Preferences.Set("CurrentFibers", countingFibers);
                Preferences.Set("LastFibersCountTimestamp", DateTime.Now);
            }
        }

        public double TotalFibers
        {
            get => totalFibers;
            set
            {
                SetProperty(ref totalFibers, value);
                OnPropertyChanged(nameof(DisplayFibers));
                OnPropertyChanged(nameof(FiberProgres));
                OnPropertyChanged(nameof(FiverPercentage));
            }
        }

        public string DisplayFibers => $"{CountingFibers}/{TotalFibers}";

        public double FiberProgres => CountingFibers / TotalFibers;
        public double FiverPercentage => FiberProgres * 100;




        public double CountingFats
        {
            get => countingFats;
            set
            {
                SetProperty(ref countingFats, value);
                OnPropertyChanged(nameof(DisplayFats));
                OnPropertyChanged(nameof(FatsProgress));
                OnPropertyChanged(nameof(FatsPercentage));
                Preferences.Set("CurrentFats", countingFats);
                Preferences.Set("LastFatsCountTimestamp", DateTime.Now);
            }
        }

        public double TotalFats
        {
            get => totalFats;
            set
            {
                SetProperty(ref totalFats, value);
                OnPropertyChanged(nameof(DisplayFats));
                OnPropertyChanged(nameof(FatsProgress));
                OnPropertyChanged(nameof(FatsPercentage));
            }
        }

        public string DisplayFats => $"{CountingFats}/{TotalFats}";


        public double FatsProgress => CountingFats / TotalFats;
        public double FatsPercentage => FatsProgress * 100;


        public double CountingWat
        {
            get => countingWat;
            set
            {
                SetProperty(ref countingWat, value);
                OnPropertyChanged(nameof(DisplayWat));
                Preferences.Set("CurrentWat", countingWat);
                OnPropertyChanged(nameof(WatProgress));
              
                Preferences.Set("LastWatCountTimestamp", DateTime.Now);
            }
        }

        public double TotalWat
        {
            get => totalWat;
            set
            {
                SetProperty(ref totalWat, value);
                OnPropertyChanged(nameof(DisplayWat));
                OnPropertyChanged(nameof(WatProgress));
               
            }
        }

        public string DisplayWat => $"{CountingWat}/{TotalWat}";

         public double WatProgress => CountingWat / TotalWat;
       




        public double CountingSugar
        {
            get => countingSugar;
            set
            {
                SetProperty(ref countingSugar, value);
                OnPropertyChanged(nameof(DisplaySugar));
                OnPropertyChanged(nameof(SugarProgress));
                OnPropertyChanged(nameof(SugarPercentage));
                Preferences.Set("CurrentSugar", countingSugar);
                Preferences.Set("LastSugarCountTimestamp", DateTime.Now);
            }
        }

        public double TotalSugar
        {
            get => totalSugar;
            set
            {
                SetProperty(ref totalSugar, value);
                OnPropertyChanged(nameof(DisplaySugar));
                OnPropertyChanged(nameof(SugarProgress));
                OnPropertyChanged(nameof(SugarPercentage));
            }
        }

        public string DisplaySugar => $"{CountingSugar}/{TotalSugar}";

        public double SugarProgress => CountingSugar / TotalSugar;

        public double SugarPercentage => SugarProgress * 100;


        public void valueTimers()
        {
            countingsteps = Preferences.Get("CurrentSteps", 0);
            lastStepCountTimestamp = Preferences.Get("LastStepCountTimestamp", DateTime.Now);

            if ((DateTime.Now - lastStepCountTimestamp) > TimeSpan.FromHours(24))
            {
                CountingSteps = 0;
                Preferences.Set("CurrentSteps", countingsteps);
                lastStepCountTimestamp = DateTime.Now;
                Preferences.Set("LastStepCountTimestamp", lastStepCountTimestamp);
            }
            // -------------------------------------------------------------------------------------------------------------------------------------------------------
            countingCALOS = Preferences.Get("CurrentCALOS", 0.0);
            lastCALOSCountTimestamp = Preferences.Get("LastCALOSCountTimeStamp", DateTime.Now);

            if ((DateTime.Now - lastCALOSCountTimestamp) > TimeSpan.FromHours(24))
            {
                CountingCALOS = 0.0;
                Preferences.Set("CurrentCALOS", countingCALOS);
                lastCALOSCountTimestamp = DateTime.Now;
                Preferences.Set("LastCALOSCountTimestamp", lastCALOSCountTimestamp);
            }
            // -------------------------------------------------------------------------------------------------------------------------------------------------------
            countingCarbs = Preferences.Get("CurrentCarbs", 0.0);
            lastCarbsCountTimestamp = Preferences.Get("LastCarbsCountTimestamp", DateTime.Now);

            if ((DateTime.Now - lastCarbsCountTimestamp) > TimeSpan.FromHours(24))
            {
                CountingCarbs = 0.0;
                Preferences.Set("CurrentCarbs", countingCarbs);
                lastCarbsCountTimestamp = DateTime.Now;
                Preferences.Set("LastCarbsCountTimestamp", lastCarbsCountTimestamp);
            }
            // -------------------------------------------------------------------------------------------------------------------------------------------------------
            countingPro = Preferences.Get("CurrentPro", 0.0);
            lastProCountTimestamp = Preferences.Get("LastProCountTimestamp", DateTime.Now);

            if ((DateTime.Now - lastProCountTimestamp) > TimeSpan.FromHours(24))
            {
                CountingPro = 0.0;
                Preferences.Set("CurrentPro", countingPro);
                lastProCountTimestamp = DateTime.Now;
                Preferences.Set("LastProCountTimestamp", lastProCountTimestamp);
            }
            // -------------------------------------------------------------------------------------------------------------------------------------------------------
            countingFats = Preferences.Get("CurrentFats", 0.0);
            lastFatsCountTimestamp = Preferences.Get("LastFatsCountTimestamp", DateTime.Now);

            if ((DateTime.Now - lastFatsCountTimestamp) > TimeSpan.FromHours(24))
            {
                CountingFats = 0.0;
                Preferences.Set("CurrentFats", countingFats);
                lastFatsCountTimestamp = DateTime.Now;
                Preferences.Set("LastFatsCountTimestamp", lastFatsCountTimestamp);
            }
            // -------------------------------------------------------------------------------------------------------------------------------------------------------
            countingFibers = Preferences.Get("CurrentFibers", 0.0);
            lastFibersCountTimestamp = Preferences.Get("LastFibersCountTimestamp", DateTime.Now);

            if ((DateTime.Now - lastFibersCountTimestamp) > TimeSpan.FromHours(24))
            {
                CountingFibers = 0.0;
                Preferences.Set("CurrentFibers", countingFibers);
                lastFibersCountTimestamp = DateTime.Now;
                Preferences.Set("LastFibersCountTimestamp", lastFibersCountTimestamp);
            }
            // -------------------------------------------------------------------------------------------------------------------------------------------------------
            countingSugar = Preferences.Get("CurrentSugar", 0.0);
            lastSugarCountTimestamp = Preferences.Get("LastSugarCountTimestamp", DateTime.Now);

            if ((DateTime.Now - lastSugarCountTimestamp) > TimeSpan.FromHours(24))
            {
                CountingSugar = 0.0;
                Preferences.Set("CurrentSugar", countingSugar);
                lastSugarCountTimestamp = DateTime.Now;
                Preferences.Set("LastSugarCountTimestamp", lastSugarCountTimestamp);
            }
            // -------------------------------------------------------------------------------------------------------------------------------------------------------
            countingWat = Preferences.Get("CurrentWat", 0.0);
            lastWatCountTimestamp = Preferences.Get("LastWatCountTimestamp", DateTime.Now);

            if ((DateTime.Now - lastWatCountTimestamp) > TimeSpan.FromHours(24))
            {
                CountingWat = 0.0;
                Preferences.Set("CurrentWat", countingWat);
                lastWatCountTimestamp = DateTime.Now;
                Preferences.Set("LastWatCountTimestamp", lastWatCountTimestamp);
            }

            // -------------------------------------------------------------------------------------------------------------------------------------------------------
        }

        public MainPageViewModel()
        {
      
            addWater = new Command(executeAddWater);

            try
            {
                StartAccelerometer();
            } catch (Exception ex)
            {
                Debug.WriteLine("Already running");
                Debug.WriteLine(ex.StackTrace);
            }


            valueTimers();



        }

    
        private void executeAddWater()
        {
            CountingWat += 0.25;
         

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
            var mag = Math.Sqrt(x*x + y*y+ z*z);
           
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
