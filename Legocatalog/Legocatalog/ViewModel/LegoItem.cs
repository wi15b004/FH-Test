using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Legocatalog.ViewModel
{
    public class LegoItem
    {
        public string Description { get; set; }
        public int NoOfParts { get; set; }
        public int Id { get; set; }
        public BitmapImage Image { get; set; }
        public string AgeRecommendation { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public LegoItem(string description, int noOfParts, int id, BitmapImage image, string age)
        {
            Description = description;
            NoOfParts = noOfParts;
            Id = id;
            Image = image;
            AgeRecommendation = age;
        }

    }
}
