using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessapp.Model
{
    public  class UserTempData
    {
     

        public double AddedCalories { get; set; }
        public double AddedProtein { get; set; }
        public double AddedCarbs { get; set; }
        public double AddedFats { get; set; }
        public double AddedFibers { get; set; }
        public double AddedSugar { get; set; }

        public UserTempData(double addedCalories, double addedProtein, double addedCarbs, double addedFats, double addedFibers, double addedSugar)
        {
            AddedCalories = addedCalories;
            AddedProtein = addedProtein;
            AddedCarbs = addedCarbs;
            AddedFats = addedFats;
            AddedFibers = addedFibers;
            AddedSugar = addedSugar;
        }
    }
}
