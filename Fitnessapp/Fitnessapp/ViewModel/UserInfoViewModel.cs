using CommunityToolkit.Mvvm.ComponentModel;
using System.IO;
using System.Text.Json;
using Microsoft.Maui.Controls;
using Fitnessapp.Model;


namespace Fitnessapp.ViewModel
{
    public class UserInfoViewModel : ObservableObject
    {
        private string userName;
        private int age;
        private double userWeight;
        private double userHeight;
        private string userGender;
        private double userBMI;

        public Command SaveCommand { get; }

        public string UserName
        {
            get => userName;
            set
            {
                SetProperty(ref userName, value);
                OnPropertyChanged(nameof(Bmi)); 
            }
        }

        public int Age
        {
            get => age;
            set
            {
                SetProperty(ref age, value);
                OnPropertyChanged(nameof(Bmi)); 
            }
        }

        public double Weight
        {
            get => userWeight;
            set
            {
                SetProperty(ref userWeight, value);
                OnPropertyChanged(nameof(Bmi)); 
            }
        }

        public double getHeight
        {
            get => userHeight;
            set
            {
                SetProperty(ref userHeight, value);
                OnPropertyChanged(nameof(Bmi));
            }
        }

        public string Gender
        {
            get => userGender;
            set
            {
                SetProperty(ref userGender, value);
                OnPropertyChanged(nameof(Bmi)); 
            }
        }

        public double Bmi
        {
            get => userBMI;
            set => SetProperty(ref userBMI, value);
        }
  

        public UserInfoViewModel()
        {
            SaveCommand = new Command(ExecuteSaveCommand);
        }

        public double CalculateBMI()
        {
            double heightInMeters = userHeight / 100.0;
            if (userWeight > 0 && userHeight > 0)
            {
                userBMI = userWeight / (heightInMeters * heightInMeters);
                return userBMI;
            }
            return 0;
        }

        public void savetoJSON(string fileName)
        {
            var userInformation = new UserInformation
            {
                UserName = UserName,
                Age = Age,
                Weight = Weight,
                Height = getHeight,
                Gender = Gender,
                BMI = Bmi
            };

            string json = JsonSerializer.Serialize(userInformation);
            File.WriteAllText(fileName, json);
        }

        public static UserInfoViewModel LoadFromJSON(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                var userSettings = JsonSerializer.Deserialize<UserInformation>(json);

                return new UserInfoViewModel
                {
                    UserName = userSettings.UserName,
                    Age = userSettings.Age,
                    Weight = userSettings.Weight,
                    getHeight = userSettings.Height,
                    Gender = userSettings.Gender,
                    Bmi = userSettings.BMI
                };
            }

            return new UserInfoViewModel();
        }

        public UserInfoViewModel load()
        {
            return LoadFromJSON(Path.Combine(FileSystem.AppDataDirectory, "userInfo.json"));
        }

        private void ExecuteSaveCommand()
        {
         
            savetoJSON(Path.Combine(FileSystem.AppDataDirectory, "userInfo.json"));
            LoadFromJSON(Path.Combine(FileSystem.AppDataDirectory, "userInfo.json"));
         
            
        }

     
    }
}
