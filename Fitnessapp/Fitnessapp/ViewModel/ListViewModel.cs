
using CommunityToolkit.Mvvm.ComponentModel;

using Csv;
using Fitnessapp.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Fitnessapp.ViewModel
{
    public class ListViewModel : ObservableObject
    {
        public string Name {  get; set; }
        public ObservableCollection<List<CollectionViewClass>> Items { get; } = new ObservableCollection<List<CollectionViewClass>>();
        public ListViewModel()
        {
            var tempList = new List<CollectionViewClass>();
            var path = Path.Combine(FileSystem.Current.AppDataDirectory, "nutritionDataSet.csv");
            var csv = File.ReadAllText(path);
           
            int count =0;
        
                foreach (var item in CsvReader.ReadFromText(csv))
                {
               var a =  new CollectionViewClass()
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
                tempList.Add(a);
                Items.Insert(count, tempList);
                count++;
                }
            
            

            

        }

        public int TryParseInt(string val)
        {
            try
            {
                return int.Parse(val);
            }catch (Exception e)
            {
                return 0;
            }

            
        }


    }


}