using CommunityToolkit.Mvvm.ComponentModel;
using FM_Regen_Tool.Model;

namespace FM_Regen_Tool.ViewModel
{
    public class RequiredVM : ObservableObject
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        private string _birthDate;
        public string BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged(nameof(BirthDate));
                }
            }
        }

        private List<string> _skinToneList = new List<string> { "1 - Lightest", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20 - Darkest" };
        public List<string> SkinToneList
        {
            get { return _skinToneList; }
        }

        private string _skinTone;
        public string SkinTone
        {
            get { return _skinTone; }
            set
            {
                if (_skinTone != value)
                {
                    _skinTone = value;
                    OnPropertyChanged(nameof(SkinTone));
                }
            }
        }

        private List<string> _hairColourList = new List<string> { "Random", "Blond", "Light Brown", "Dark Brown", "Red", "Black", "Grey", "Bald" };
        public List<string> HairColourList
        {
            get { return _hairColourList; }
        }

        private string _hairColour;
        public string HairColour
        {
            get { return _hairColour; }
            set
            {
                if (_hairColour != value)
                {
                    _hairColour = value;
                    OnPropertyChanged(nameof(HairColour));
                }
            }
        }

        private string _clubId;
        public string ClubId
        {
            get { return _clubId; }
            set
            {
                if (_clubId != value)
                {
                    _clubId = value;
                    OnPropertyChanged(nameof(ClubId));
                }
            }
        }

        public RequiredVM()
        {
            _skinTone = _skinToneList[0];
            _hairColour = _hairColourList[0];
        }

        public void NewPlayer()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthDate = string.Empty;

            SkinTone = _skinToneList[0];
            HairColour = _hairColourList[0];

            ClubId = string.Empty;
        }

        public Player SavePlayer(Player player)
        {
            player.FirstName = _firstName;
            player.LastName = _lastName;
            player.BirthDate = _birthDate;

            int index = _skinToneList.IndexOf(_skinTone);
            player.SkinTone = index.ToString();

            index = _hairColourList.IndexOf(_hairColour);
            player.HairColor = index.ToString();

            player.ClubId = _clubId;

            return player;
        }
    }
}
