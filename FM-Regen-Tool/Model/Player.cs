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

        private string _currentAbility;
        public string CurrentAbility 
        {
            get
            {
                return _currentAbility;
            }
            set
            {
                int ca;
                bool result = int.TryParse(value, out ca);

                if (result)
                {
                    if (ca < 0)
                    {
                        ca = 0;
                    }
                    else if (ca > 200)
                    {
                        ca = 200;
                    }

                    _currentAbility = ca.ToString();
                }
            }
        }

        private string _potentialAbility;
        public string PotentialAbility 
        { 
            get
            {
                return _potentialAbility;
            }
            set
            {
                int pa;
                bool result = int.TryParse(value, out pa);

                if (result)
                {
                    if (pa < 0)
                    {
                        pa = 0;
                    }
                    else if (pa > 200)
                    {
                        pa = 200;
                    }

                    _potentialAbility = pa.ToString();
                }
            }
        }

        private string _startString = "\"DETAILED_FUTURE_REGEN\"";

        private void SetPosition()
        {
            switch (PreferredPosition)
            {
                case "Goalkeeper":
                    PreferredPosition = "GOALKEEPER";
                    break;
                case "Left Defender":
                    PreferredPosition = "DEFENDER_LEFT_SIDE";
                    break;
                case "Right Defender":
                    PreferredPosition = "DEFENDER_RIGHT_SIDE";
                    break;
                case "Central Defender":
                    PreferredPosition = "DEFENDER_CENTRAL";
                    break;
                case "Left Midfielder":
                    PreferredPosition = "MIDFIELDER_LEFT_SIDE";
                    break;
                case "Right Midfielder":
                    PreferredPosition = "MIDFIELDER_RIGHT_SIDE";
                    break;
                case "Central Midfielder":
                    PreferredPosition = "MIDFIELDER_CENTRAL";
                    break;
                case "Attacking Left Midfielder":
                    PreferredPosition = "ATTACKING_MIDFIELDER_LEFT_SIDE";
                    break;
                case "Attacking Right Midfielder":
                    PreferredPosition = "ATTACKING_MIDFIELDER_RIGHT_SIDE";
                    break;
                case "Attacking Central Midfielder":
                    PreferredPosition = "ATTACKING_MIDFIELDER_CENTRAL";
                    break;
                case "Attacker Central":
                    PreferredPosition = "ATTACKER_CENTRAL";
                    break;
                default:
                    break;
            }
        }

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

            SetPosition();
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

            return sb.ToString();
        }
    }
}
