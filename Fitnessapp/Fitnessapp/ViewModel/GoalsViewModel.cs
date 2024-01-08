using CommunityToolkit.Mvvm.ComponentModel;
using Fitnessapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fitnessapp.ViewModel
{


    public class GoalsViewModel : ObservableObject
    {

        private double steps;
        private double calories;
        private double protein;
        private double carbs;
        private double sugar;
        private double fiber;
        private double fat;
        private double water;

        public Command SaveCommand { get; set; }
        public double Steps { get => steps; set => steps = value; }
        public double Calories { get => calories; set => calories = value; }
        public double Protein { get => protein; set => protein = value; }
        public double Carbs { get => carbs; set => carbs = value; }
        public double Sugar { get => sugar; set => sugar = value; }
        public double Fiber { get => fiber; set => fiber = value; }
        public double Fat { get => fat; set => fat = value; }
        public double Water { get => water; set => water = value; }

        public GoalsViewModel()
        {
            SaveCommand = new Command(executeSaveCommand);
        }

        private void saveToJSON(string fileName)
        {
            var tobeSaved = new userGoalsSettings
            {
                calories = Calories,
                steps = Steps,
                protein = Protein,
                carbs = Carbs,
                sugar = Sugar,
                fiber = Fiber,
                water = Water,
                fat = Fat


            };
            string json = JsonSerializer.Serialize(tobeSaved);
            File.WriteAllText(fileName, json);
        }

        private static GoalsViewModel LoadFromJSON(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                var userSettings = JsonSerializer.Deserialize<userGoalsSettings>(json);

                return new GoalsViewModel
                {
                   Steps = userSettings.steps,
                   Protein = userSettings.protein,
                   Carbs = userSettings.carbs,
                   sugar = userSettings.sugar,
                   fiber = userSettings.fiber,
                   water = userSettings.water,
                   Calories = userSettings.calories,
                   Fat = userSettings.fat

                };
            }

            return new GoalsViewModel();
        }

        public GoalsViewModel load()
        {
            return LoadFromJSON(Path.Combine(FileSystem.AppDataDirectory, "userGoalSettings.json"));
        }

        public void executeSaveCommand()
        {

            saveToJSON(Path.Combine(FileSystem.AppDataDirectory, "userGoalSettings.json"));
            LoadFromJSON(Path.Combine(FileSystem.AppDataDirectory, "userGoalSettings.json"));
        }
    }

}
