using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessapp.Model
{
  public class CollectionViewClass: IComparable<CollectionViewClass>
    {
        public string Name { get; set; }

        public string measure {  get; set; }

        public int grams { get; set; }

        public int calories { get; set; }

        public int protein { get; set; }

        public int fat {  get; set; }
        public int Sat_Fat {  get; set; }
        public int Fiber {  get; set; }
        public int Carbs {  get; set; }

        public string category {  get; set; }



        public override string ToString()
        {
            return Name + "" + measure+""+ grams +" " +calories+ "" + protein+ "" + fat + "" + Sat_Fat+ "" + Fiber + "" + Carbs+ "" +category+ "";
        }

        public int CompareTo(CollectionViewClass? other)
        {
           if ( other == null) return 1;

           if(this.Name.CompareTo(other.Name) == 0 )
            {
                return this.protein.CompareTo(other.protein);
            }

            return this.Name.CompareTo(other.Name);

        }

      

    }


    
}
