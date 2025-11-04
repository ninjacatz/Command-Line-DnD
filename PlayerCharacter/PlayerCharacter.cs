namespace Command_Line_DnD
{
    internal class PlayerCharacter 
    {
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value == String.Empty) throw new ArgumentException($"{nameof(FirstName)} cannot be empty.");
                _firstName = value;
            }
        }
        public string LastName { get; set; }

        private string _characterClass;
        public string CharacterClass
        {
            get => _characterClass;
            set
            {
                if (!Data.ClassArray.Contains(value)) throw new ArgumentException($"{nameof(CharacterClass)} must be {Data.CreateExceptionMessageListFor(Data.ClassArray)}.");
                _characterClass = value;
            }
        }

        private string[] _characterClassProficiencies;
        public string[] CharacterClassProficiencies
        {
            get => _characterClassProficiencies;
            set
            {
                if (!Data.ClassSkillProficiencyCountDictionary[value.Length].Contains(_characterClass))
                {
                    throw new ArgumentException($"{_characterClass} class does not allow {value.Length} skill proficiencies.");
                }

                foreach (string proficiency in value)
                {
                    if (!Data.ClassSkillProficiencyDictionary[_characterClass].Contains(proficiency))
                    {
                        throw new ArgumentException($"{proficiency} proficiency is not allowed for {_characterClass} class. Use {Data.CreateExceptionMessageListFor(Data.ClassSkillProficiencyDictionary[_characterClass])}.");
                    }
                }
                _characterClassProficiencies = value;
            }
        }

        private string _race;
        public string Race
        {
            get => _race;
            set
            {
                if (!Data.RaceArray.Contains(value)) throw new ArgumentException($"{nameof(Race)} must be {Data.CreateExceptionMessageListFor(Data.RaceArray)}.");
                _race = value;
            }
        }

        private string _raceAdditionalLanguage;
        public string RaceAdditionalLanguage
        {
            get => _raceAdditionalLanguage;
            set
            {
                if (!Data.RacesWithAdditionalLanguage.Contains(value))
                {
                    throw new ArgumentException($"{_race} cannot have an additional language.");
                }
                if (!Data.LanguagesArray.Contains(value))
                {
                    throw new ArgumentException($"{nameof(RaceAdditionalLanguage)} contains a non-existant language.");
                }
                _raceAdditionalLanguage = value;
            }
        }

        public string Gender { get; set; }
        public string EyeColor { get; set; }

        private int _height;
        public int Height
        {
            get => _height;
            set 
            {
                if (value <= 0) throw new ArgumentOutOfRangeException($"{nameof(Height)} must be a positive integer.");
                _height = value;
            }
        }

        private int _weight;
        public int Weight
        {
            get => _weight;
            set 
            {
                if (value <= 0) throw new ArgumentOutOfRangeException($"{nameof(Weight)} must be a positive integer.");
                _weight = value;
            }
        }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (value <= 0) throw new ArgumentException($"{nameof(Age)} must be a positive integer.");
                _age = value;
            }
        }

        private string _alignment;
        public string Alignment 
        { 
            get => _alignment; 
            set 
            {
                if (!Data.AlignmentTypesArray.Contains(value))
                {
                    throw new ArgumentException($"{nameof(Alignment)} must be {Data.CreateExceptionMessageListFor(Data.AlignmentTypesArray)}.");
                }
                _alignment = value;
            }
        }

        public string Faith { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public string Backstory { get; set; }

        private string _background;
        public string Background
        { 
            get => _background;
            set
            {
                if (!Data.BackgroundsArray.Contains(value))
                {
                    throw new ArgumentException($"{nameof(Background)} must be {Data.CreateExceptionMessageListFor(Data.BackgroundsArray)}.");
                }
                _background = value;
            }
        }

        public string[] BackgroundSkillProficiencies => Data.BackgroundSkillProficiencyDictionary[_background];

        private string[] _backgroundAdditionalLanguages;
        public string[] BackgroundAdditionalLanguages
        {
            get => _backgroundAdditionalLanguages;
            set
            {
                if (Data.BackgroundLanguageCountDictionary[2].Contains(_background) && value.Length != 2)
                {
                    throw new ArgumentException($"{nameof(BackgroundAdditionalLanguages)} must have two language choices for the given background ({_background}).");
                }
                else if (Data.BackgroundLanguageCountDictionary[1].Contains(_background) && value.Length != 1)
                {
                    throw new ArgumentException($"{nameof(BackgroundAdditionalLanguages)} must only have one language choice for the given background ({_background}).");
                }
                else if (Data.BackgroundLanguageCountDictionary[0].Contains(_background) && value.Length != 0)
                {
                    throw new ArgumentException($"{nameof(BackgroundAdditionalLanguages)} cannot have any language choices for the given background ({_background}).");
                }
                foreach (string language in value)
                {
                    if (!Data.LanguagesArray.Contains(language))
                    {
                        throw new ArgumentException($"{nameof(BackgroundAdditionalLanguages)} contains a non-existing langauge. Choose from {Data.CreateExceptionMessageListFor(Data.LanguagesArray)}.");
                    }
                }
                _backgroundAdditionalLanguages = value;
            }
        }

        private string _backgroundFeature;
        public string BackgroundFeature
        {
            get => _backgroundFeature;
            set
            {
                if (!Data.BackgroundFeaturesDictionary[_background].Contains(value))
                {
                    throw new ArgumentException($"{nameof(BackgroundFeature)} must be a valid feature for the given background ({_background}). Valid features include {Data.CreateExceptionMessageListFor(Data.BackgroundFeaturesDictionary[_background])}.");
                }
                _backgroundFeature = value;
            }
        }

        public string[] AllLanguagesKnown
        {
            get
            {
                // default languages of race
                List<string> allLanguagesList = Data.RaceLanguageDictionary[_race].ToList();
                // any additional languages based on race
                if (_raceAdditionalLanguage != null)
                {
                    allLanguagesList.Add(_raceAdditionalLanguage);
                }
                // any additional languages from background
                if (_backgroundAdditionalLanguages.Length != 0)
                {
                    foreach (string language in _backgroundAdditionalLanguages)
                    {
                        allLanguagesList.Add(language);
                    }
                }
                return allLanguagesList.ToArray();
            }
        }

        private int _totalHitpoints;
        public int TotalHitpoints
        {
            get => _totalHitpoints;
            set 
            {
                if (value < 1) throw new ArgumentOutOfRangeException($"{nameof(TotalHitpoints)} must be a positive integer.");
                _totalHitpoints = value;
            }
        }

        private int _currentHitPoints;
        public int CurrentHitPoints
        {
            get => _currentHitPoints;
            set
            {
                if (value < 0 || value > _totalHitpoints) throw new ArgumentOutOfRangeException($"{nameof(CurrentHitPoints)} must not be below 0 or above your total hit points at {_totalHitpoints}.");
                _currentHitPoints = value;
            }
        }

        // Setting a level also sets the Proficiency Bonus
        private int _level;
        public int Level
        {
            get => _level;
            set
            {
                if (value < 1 || value > 20) throw new ArgumentOutOfRangeException($"{nameof(Level)} must be from 1 to 20.");
                _level = value;
                if (value > 1 && value <= 4) _proficiencyBonus = 2;
                if (value > 4 && value <= 8) _proficiencyBonus = 3;
                if (value > 8 && value <= 12) _proficiencyBonus = 4;
                if (value > 12 && value <= 16) _proficiencyBonus = 5;
                if (value > 16 && value <= 20) _proficiencyBonus = 6;
            }
        }

        private int _proficiencyBonus;
        public int ProficiencyBonus => _proficiencyBonus;

        private int _strength;
        public int Strength
        {
            get => _strength;
            set 
            {
                if (value < 3 || value > 30) throw new ArgumentOutOfRangeException($"{nameof(Strength)} must be from 3 to 30.");
                _strength = value;
            }
        }
        private int _dexterity;
        public int Dexterity
        {
            get => _dexterity;
            set 
            {
                if (value < 3 || value > 30) throw new ArgumentOutOfRangeException($"{nameof(Dexterity)} must be from 3 to 30.");
                _dexterity = value;
            }
        }
        private int _constitution;
        public int Constitution
        {
            get => _constitution;
            set 
            {
                if (value < 3 || value > 30) throw new ArgumentOutOfRangeException($"{nameof(Constitution)} must be from 3 to 30.");
                _constitution = value;
            }
        }
        private int _intelligence;
        public int Intelligence
        {
            get => _intelligence;
            set 
            {
                if (value < 3 || value > 30) throw new ArgumentOutOfRangeException($"{nameof(Intelligence)} must be from 3 to 30.");
                _intelligence = value;
            }
        }
        private int _wisdom;
        public int Wisdom
        {
            get => _wisdom;
            set 
            {
                if (value < 3 || value > 30) throw new ArgumentOutOfRangeException($"{nameof(Wisdom)} must be from 3 to 30.");
                _wisdom = value;
            }
        }
        private int _charisma;
        public int Charisma
        {
            get => _charisma;
            set 
            {
                if (value < 3 || value > 30) throw new ArgumentOutOfRangeException($"{nameof(Charisma)} must be from 3 to 30.");
                _charisma = value;
            }
        }

        public int StrengthModifier => (_strength - 10) / 2;
        public int DexterityModifier => (_dexterity - 10) / 2;
        public int ConstitutionModifier => (_constitution - 10) / 2;
        public int IntelligenceModifier => (_intelligence - 10) / 2;
        public int WisdomModifier => (_wisdom - 10) / 2;
        public int CharismaModifier => (_charisma - 10) / 2; 

        public int ArmorClass { get; set; }

        private string _size;
        public string Size
        {
            get => _size;
            set 
            {
                if (!Data.CreatureSizesArray.Contains(value))
                {
                    throw new ArgumentException($"{nameof(Size)} must be {Data.CreateExceptionMessageListFor(Data.CreatureSizesArray)}.");
                }
                _size = value;
            }
        }

        public int InitiativeBonus => DexterityModifier;

        // Equipment:
        // NOTE: strength score determines weight you can carry (strength*15)
        public string[] Equipment;
    }
}
