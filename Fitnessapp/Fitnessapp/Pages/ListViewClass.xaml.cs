using Csv;
using Fitnessapp.Model;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials;


namespace Fitnessapp.Pages
{
    public partial class ListViewClass : ContentPage
    {
        public ListViewClass()
        {
            InitializeComponent();
            LoadAndParseCsvFileAsync();
        }

        private async void LoadAndParseCsvFileAsync()
        {
            string filePath = "nutrients_csvfile.csv"; // Update with your actual file path

            try
            {
                string csvContent = await ReadTextFile(filePath);

                foreach (var line in CsvReader.ReadFromText(csvContent))
                {
                    var firstCell = line[0];
                    var secondCell = line[1];
                    Debug.WriteLine("This is " + firstCell + ", " + secondCell);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task<string> ReadTextFile(string filePath)
        {
            using (Stream fileStream = await Microsoft.Maui.Storage.FileSystem.OpenAppPackageFileAsync(filePath))
            using (StreamReader reader = new StreamReader(fileStream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
