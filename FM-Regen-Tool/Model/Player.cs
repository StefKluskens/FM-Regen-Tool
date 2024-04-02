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
        public string FavouriteClub { get; set; }
        public string Ethnicity { get; set; }        
        public string Height { get; set; }
        public string Weight { get; set; }
        public string PreferredFoot { get; set; }
        public string PreferredPosition { get; set; }
        public string FavouriteNumber { get; set; }
        public string BirthCity { get; set; }
        public string CurrentAbility { get; set; }
        public string PotentialAbility { get; set; }

        private string _startString = "\"DETAILED_FUTURE_REGEN\"";
        

        public string GetPlayerString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_startString);

            sb.Append(" \"");
            sb.Append(FirstName);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(NickName);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(LastName);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(BirthDate);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(Nationality);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(FavouriteClub);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(Ethnicity);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(SkinTone);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(HairColor);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(Height);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(Weight);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(PreferredFoot);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(PreferredPosition);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(FavouriteNumber);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(BirthCity);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(CurrentAbility);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(PotentialAbility);
            sb.Append("\"");

            sb.Append(" \"");
            sb.Append(ClubId);
            sb.Append("\"");

            sb.Append('\n');

            return sb.ToString();
        }
    }
}
