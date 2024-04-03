using CommunityToolkit.Mvvm.ComponentModel;
using FM_Regen_Tool.Model;

namespace FM_Regen_Tool.ViewModel
{
    public class OptionalVM : ObservableObject
    {
        private string _nickName;
        public string NickName
        {
            get { return _nickName; }
            set
            {
                if (_nickName != value)
                {
                    _nickName = value;
                    OnPropertyChanged(nameof(NickName));
                }
            }
        }

        private string _nation;
        public string Nation
        {
            get { return _nation; }
            set
            {
                if (_nation != value)
                {
                    _nation = value;
                    OnPropertyChanged(nameof(Nation));
                }
            }
        }

        private string _favouriteClub;
        public string FavouriteClub
        {
            get { return _favouriteClub; }
            set
            {
                if (_favouriteClub != value)
                {
                    _favouriteClub = value;
                    OnPropertyChanged(nameof(FavouriteClub));
                }
            }
        }

        private List<string> _ethnicityList = new List<string>
        {
            "Random", "Northern Europe", "Mediterrean/Hispanic", "North African/Middle Eastern", "African/Caribbean",
            "Asian", "South East Asian", "Pacific Islander", "Native American", "Native Australian", "Mixed race white/black", "East Asian"
        };
        public List<string> EthnicityList
        {
            get { return _ethnicityList; }
        }

        private string _ethnicity;
        public string Ethnicity
        {
            get { return _ethnicity; }
            set
            {
                if (_ethnicity != value)
                {
                    _ethnicity = value;
                    OnPropertyChanged(nameof(Ethnicity));
                }
            }
        }

        private string _height;
        public string Height
        {
            get { return _height; }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged(nameof(Height));
                }
            }
        }

        private string _weight;
        public string Weight
        {
            get { return _weight; }
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        private List<string> _footList = new List<string>
        {
            "Right only", "Left only", "Right preferred", "Left preferred", "Both"
        };
        public List<string> FootList
        {
            get { return _footList; }
        }

        private string _foot;
        public string Foot
        {
            get { return _foot; }
            set
            {
                if (_foot != value)
                {
                    _foot = value;
                    OnPropertyChanged(nameof(Foot));
                }
            }
        }

        private List<string> _positionList = new List<string>
        {
            "Goalkeeper", "Left Defender", "Right Defender", "Central Defender",
            "Left Midfielder", "Right Midfielder", "Central Midfielder",
            "Attacking Left Midfielder", "Attacking Right Midfielder", "Attacking Central Midfielder",
            "Attacker Central"
        };
        public List<string> PositionList
        {
            get { return _positionList; }
        }

        private string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPropertyChanged(nameof(Position));
                }
            }
        }

        private string _preferredNumber;
        public string PreferredNumber
        {
            get { return _preferredNumber; }
            set
            {
                if (_preferredNumber != value)
                {
                    _preferredNumber = value;
                    OnPropertyChanged(nameof(PreferredNumber));
                }
            }
        }

        private string _birthCity;
        public string BirthCity
        {
            get { return _birthCity; }
            set
            {
                if (_birthCity != value)
                {
                    _birthCity = value;
                    OnPropertyChanged(nameof(BirthCity));
                }
            }
        }

        private string _currentAbility;
        public string CurrentAbility
        {
            get { return _currentAbility; }
            set
            {
                if (_currentAbility != value)
                {
                    _currentAbility = value;
                    OnPropertyChanged(nameof(CurrentAbility));
                }
            }
        }

        private string _potentialAbility;
        public string PotentialAbility
        {
            get { return _potentialAbility; }
            set
            {
                if (_potentialAbility != value)
                {
                    _potentialAbility = value;
                    OnPropertyChanged(nameof(PotentialAbility));
                }
            }
        }

        public OptionalVM()
        {
            _ethnicity = _ethnicityList[0];
            _foot = _footList[0];
            _position = _positionList[0];
        }

        public void NewPlayer()
        {
            NickName = string.Empty;
            Nation = string.Empty;
            FavouriteClub = string.Empty;

            _ethnicity = _ethnicityList[0];

            Height = string.Empty;
            Weight = string.Empty;

            _foot = _footList[0];
            _position = _positionList[0];

            PreferredNumber = string.Empty;
            BirthCity = string.Empty;
            CurrentAbility = string.Empty;
            PotentialAbility = string.Empty;
        }

        public Player SavePlayer(Player player)
        {
            player.NickName = _nickName;
            player.Nationality = _nation;
            player.FavouriteClub = _favouriteClub;

            int index = _ethnicityList.IndexOf(_ethnicity);
            --index;
            player.Ethnicity = index.ToString();

            player.Height = _height;
            player.Weight = _weight;

            index = _footList.IndexOf(_foot);
            player.PreferredFoot = index.ToString();
            player.PreferredPosition = _position;

            player.FavouriteNumber = _preferredNumber;
            player.BirthCity = _birthCity;
            player.CurrentAbility = _currentAbility;
            player.PotentialAbility = _potentialAbility;

            return player;
        }
    }
}
