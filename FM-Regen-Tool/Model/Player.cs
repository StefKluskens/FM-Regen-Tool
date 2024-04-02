using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Regen_Tool.Model
{
    public class Player
    {
        //Required Fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string SkinTone { get; set; }
        public string HairColor { get; set; }
        public string ClubId { get; set; }

        //Optional Fields
        public string NickName { get; set; }
        public string Nationality { get; set; }
        public string FavoriteClub { get; set; }
        public string Ethnicity { get; set; }        
        public string Height { get; set; }
        public string Weight { get; set; }
        public string PreferredFoot { get; set; }
        public string PreferredPosition { get; set; }
        public string FavoriteNumber { get; set; }
        public string BirthCity { get; set; }
        public string CurrentAbility { get; set; }
        public string PotentialAbility { get; set; }

        private string _combinedString = "\"DETAILED_FUTURE_REGEN\"";
        
    }
}
