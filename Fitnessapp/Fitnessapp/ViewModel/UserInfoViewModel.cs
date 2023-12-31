using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json;


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

     public string UserName { get => userName; set => userName = value; }
    public int Age { get => age; set => age = value; }
    public double Weight { get => userWeight; set => userWeight = value; }
    public double getHeight { get => userHeight; set => userHeight = value; }
    public string Gender { get => userGender; set => userGender = value; }
    public double Bmi { get => userBMI; set => userBMI = CalculateBMI(); }


    public UserInfoViewModel() 
        {
            SaveCommand = new Command(ExecuteSaveCommand);

        
        }
    
 

    public double CalculateBMI()
    {
        double heightInMeters = userHeight / 100.0;
        if (userWeight >0 && userHeight > 0)
        {
            userBMI =  userWeight / (heightInMeters * heightInMeters);
            return userBMI;
        }
        return 0;
    }

    public void savetoJSON(String fileName)
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
            String f = Path.Combine(FileSystem.AppDataDirectory, fileName);
            if (File.Exists(f))
            {
                string json = File.ReadAllText(f);
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