using CommunityToolkit.Mvvm.ComponentModel;
using Fitnessapp.Model;
using System.Collections.Generic;
using System.IO;
using Csv;
using System.Diagnostics;

namespace Fitnessapp.ViewModel
{
    public class ListViewModel : ObservableObject
    {
        public Command? AddFood {  get; set; }

        public Command? info { get; set; }
        public string? labelText { get; set; }
        public bool? visibility {  get; set; }
        public string? Name {  get; set; }
        public string? measure { get; set; }
        public int? grams {  get; set; }
        public int? calories {  get; set; }
        public int? protein {  get; set; }

        public int? fat { get; set; }
        public int? Sat_Fat {  get; set; }
        public int? Fiber {  get; set; }
        public int? Carbs { get; set; }
        public int? category {  get; set; }


        public List<CollectionViewClass> Items { get; set; }

    

        public ListViewModel()
        {

           
                Items = new List<CollectionViewClass>();
                var path = Path.Combine(FileSystem.Current.AppDataDirectory, "nutritionDataSet.csv");
                var csv = File.ReadAllText(path);

            Debug.WriteLine("bofa");

            foreach (var item in CsvReader.ReadFromText(csv))
            {
                CollectionViewClass a = new()
                {
                    Name = item[0],
                    measure = item[1],
                    grams = TryParseInt(item[2]),
                    calories = TryParseInt(item[3]),
                    protein = TryParseInt(item[4]),
                    fat = TryParseInt(item[5]),
                    Sat_Fat = TryParseInt(item[6]),
                    Fiber = TryParseInt(item[7]),
                    Carbs = TryParseInt(item[8]),
                    category = item[9]
                };

                Items.Add(a);
            }
        }

        public int TryParseInt(string val)
        {
            Debug.WriteLine("bofa container");
            try
            {
                return int.Parse(val);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }


        public void ExecuteCommand()
        {

        }
        
    }
}
