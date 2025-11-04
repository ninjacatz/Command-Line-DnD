namespace DnDProject;

// Contains miscellaneous properties and methods which define various data for use elsewhere
internal class Data
{
    // Dictionary linking Races and the languages they can speak/write
    public static Dictionary<string, string[]> RaceLanguageDictionary = new Dictionary<string, string[]>
    {
        {"Dragonborn", new[] {"Common", "Draconic"}},
        {"Dwarf", new[] {"Common", "Dwarvish"}},
        {"Elf", new[] {"Common", "Elvish"}},
        {"Gnome", new[] {"Common", "Gnomish"}},
        {"Half-Elf", new[] {"Common", "Elvish"}},
        {"Halfling", new[] {"Common", "Halfling"}},
        {"Half-Orc", new[] {"Common", "Orcish"}},
        {"Human", new[] {"Common"}},
        {"Tiefling", new[] {"Common", "Infernal"}}
    };

    // Array of Races that can have an additional language
    public static string[] RacesWithAdditionalLanguage = new string[]
    {
        "Elf", // technically only high elves
        "Half-Elf",
        "Human"
    };

    // Dictionary Linking Classes with Number of Skill Proficiencies they can learn
    public static Dictionary<int, string[]> ClassSkillProficiencyCountDictionary = new Dictionary<int, string[]>
    {
        {6, new[] {"Bard"}}, // with college of lore at lvl 3, bards can have 6 skill proficiencies
        {4, new[] {"Rogue"}},
        {3, new[] {"Bard", "Ranger"}},
        {2, new[] {"Barbarian", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Sorcerer", "Warlock", "Wizard"}}
    };

    // Dictionary linking Classes with the skills they can possibly be proficient with
    public static Dictionary<string, string[]> ClassSkillProficiencyDictionary = new Dictionary<string, string[]>
    {
        {"Barbarian", new[] {"Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival"}},
        {"Bard", new[] {"Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation", "Investigaton", "Medicine", "Nature", "Perception", "Performance", "Persuasion", "Religion", "Sleight of Hand", "Stealth", "Survival"}},
        {"Cleric", new[] {"History", "Insight", "Medicine", "Persuasion", "Religion"}},
        {"Druid", new[] {"Arcana", "Animal Handling", "Insight", "Medicine", "Nature", "Perception", "Religion", "Survival"}},
        {"Fighter", new[] {"Acrobatics", "Animal Handling", "Athletics", "History", "Insight", "Intimidation", "Perception", "Survival"}},
        {"Monk", new[] {"Acrobatics", "Athletics", "History", "Insight", "Religion", "Stealth"}},
        {"Paladin", new[] {"Athletics", "Insight", "Intimidation", "Medicine", "Persuasion", "Religion"}},
        {"Ranger", new[] {"Animal Handling", "Athletics", "Insight", "Investigation", "Nature", "Perception", "Stealth", "Survival"}},
        {"Rogue", new[] {"Acrobatics", "Athletics", "Deception", "Insight", "Intimidation", "Investigation", "Perception", "Performance", "Persuasion", "Sleight of Hand", "Stealth"}},
        {"Sorcerer", new[] {"Arcana", "Deception", "Insight", "Intimidation", "Persuasion", "Religion"}},
        {"Warlock", new[] {"Arcana", "Deception", "History", "Intimidation", "Investigation", "Nature", "Religion"}},
        {"Wizard", new[] {"Arcana", "History", "Insight", "Investigation", "Medicine", "Religion"}}
    };

    // Dictionary linking Backgrounds with Number of Languages available to learn
    public static Dictionary<int, string[]> BackgroundLanguageCountDictionary = new Dictionary<int, string[]>()
    {
        {2, new[] {"Acolyte", "Sage"}},
        {1, new[] {"Guild Artisan", "Guild Merchant", "Hermit", "Noble", "Knight", "Outlander"}},
        {0, new[] {"Charlatan", "Criminal", "Spy", "Entertainer", "Gladiator", "Folk Hero", "Sailor", "Pirate", "Soldier", "Urchin"}}
    };

    // Dictionary linking Backgrounds with Skill Proficiencies
    public static Dictionary<string, string[]> BackgroundSkillProficiencyDictionary = new Dictionary<string, string[]>()
    {
        {"Acolyte", new[] {"Insight", "Religion"}},
        {"Charlatan", new[] {"Deception", "Sleight of Hand"}},
        {"Criminal", new[] {"Deception", "Stealth"}},
        {"Spy", new[] {"Deception", "Stealth"}},
        {"Entertainer", new[] {"Acrobatics", "Performance"}},
        {"Gladiator", new[] {"Acrobatics", "Performance"}},
        {"Folk Hero", new[] {"Animal Handling", "Survival"}},
        {"Guild Artisan", new[] {"Insight", "Persuasion"}},
        {"Guild Merchant", new[] {"Insight", "Persuasion"}},
        {"Hermit", new[] {"Medicine", "Religion"}},
        {"Noble", new[] {"History", "Persuasion"}},
        {"Knight", new[] {"History", "Persuasion"}},
        {"Outlander", new[] {"Athletics", "Survival"}},
        {"Sage", new[] {"Arcana", "History"}},
        {"Sailor", new[] {"Athletics", "Perception"}},
        {"Pirate", new[] {"Athletics", "Perception"}},
        {"Soldier", new[] {"Athletics", "Intimidation"}},
        {"Urchin", new[] {"Sleight of Hand", "Stealth"}}
    };

    // Dictionary linking Background Features to Backgrounds
    public static Dictionary<string, string[]> BackgroundFeaturesDictionary = new Dictionary<string, string[]>()
    {
        {"Acolyte", new[] {"Shelter of the Faithful"}},
        {"Charlatan", new[] {"False Identity"}},
        {"Criminal", new[] {"Criminal Contact"}},
        {"Spy", new[] {"Criminal Contact"}},
        {"Entertainer", new[] {"By Popular Demand"}},
        {"Gladiator", new[] {"By Popular Demand"}},
        {"Folk Hero", new[] {"Rustic Hospitality"}},
        {"Guild Artisan", new[] {"Guild Membership"}},
        {"Guild Merchant", new[] {"Guild Membership"}},
        {"Hermit", new[] {"Discovery"}},
        {"Noble", new[] {"Position of Privilege", "Retainers"}},
        {"Knight", new[] {"Retainers"}},
        {"Outlander", new[] {"Wanderer"}},
        {"Sage", new[] {"Researcher"}},
        {"Sailor", new[] {"Ship's Passage", "Bad Reputation"}},
        {"Pirate", new[] {"Ship's Passage", "Bad Reputation"}},
        {"Soldier", new[] {"Military Rank"}},
        {"Urchin", new[] {"City Secrets"}}
    };

    // Array of Backgrounds pulled from BackgroundSkillProficiencyDictionary
    public static string[] BackgroundsArray
    {
        get
        {
            List<string> backgrounds = new List<string>();
            foreach (string background in BackgroundSkillProficiencyDictionary.Keys)
            {
                backgrounds.Add(background);
            }
            return backgrounds.ToArray();
        }
    }

    // Array of Languages
    public static string[] LanguagesArray = new string[]
    {
        "Common", 
        "Dwarvish",
        "Elvish",
        "Giant",
        "Gnomish",
        "Goblin",
        "Halfling",
        "Orc",
        "Abyssal",
        "Celestial",
        "Draconic",
        "Deep Speech",
        "Infernal",
        "Primordial",
        "Sylvan",
        "Undercommon"
    };

    // Array of Creature Sizes
    public static string[] CreatureSizesArray = new string[]
    {
        "Tiny",
        "Small",
        "Medium",
        "Large",
        "Huge",
        "Gargantuan"
    };

    // Array of Alignment Types
    public static string[] AlignmentTypesArray = new string[]
    {
        "Lawful Good",
        "Neutral Good",
        "Chaotic Good",
        "Lawful Neutral",
        "True Neutral",
        "Chaotic Neutral",
        "Lawful Evil",
        "Neutral Evil",
        "Chaotic Evil"
    };

    // Array of Classes
    public static string[] ClassArray = new string[]
    {
        "Barbarian",
        "Bard",
        "Cleric",
        "Druid",
        "Fighter",
        "Monk",
        "Paladin",
        "Ranger",
        "Rogue",
        "Sorcerer",
        "Warlock",
        "Wizard"
    };

    // Array of Races
    public static string[] RaceArray = new string[]
    {
        "Dragonborn",
        "Dwarf",
        "Elf",
        "Gnome",
        "Half-Elf",
        "Halfling",
        "Half-Orc",
        "Human",
        "Tiefling"
    };

    // Dictionary linking Classes with Save Proficiencies
    public static Dictionary<string, string[]> ClassSaveProficienciesDictionary = new Dictionary<string, string[]>()
    {
        {"Barbarian", new[] {"Strength", "Consitution"}},
        {"Bard", new[] {"Dexterity", "Charisma"}},
        {"Cleric", new[] {"Wisdom", "Charisma"}},
        {"Druid", new[] {"Intelligence", "Wisdom"}},
        {"Fighter", new[] {"Strength", "Consitution"}},
        {"Monk", new[] {"Strength", "Dexterity"}},
        {"Paladin", new[] {"Wisdom", "Charisma"}},
        {"Ranger", new[] {"Strength", "Dexterity"}},
        {"Rogue", new[] {"Dexterity", "Intelligence"}},
        {"Sorcerer", new[] {"Constitution", "Charisma"}},
        {"Warlock", new[] {"Wisdom", "Charisma"}},
        {"Wizard", new[] {"Intelligence", "Wisdom"}}
    };

    // Dictionary linking skills by ability it is bound with
    public static Dictionary<string, string> SkillsByAbilityDictionary = new Dictionary<string, string>()
    {
        {"Acrobatics", "Dexterity"},
        {"Animal Handling", "Wisdom"},
        {"Arcana", "Intelligence"},
        {"Athletics", "Strength"},
        {"Deception", "Charisma"},
        {"History", "Intelligence"},
        {"Insight", "Wisdom"},
        {"Intimidation", "Charisma"},
        {"Investigaton", "Intelligence"},
        {"Medicine", "Wisdom"},
        {"Nature", "Intelligence"},
        {"Perception", "Wisdom"},
        {"Performance", "Charisma"},
        {"Persuasion", "Charisma"},
        {"Religion", "Intelligence"},
        {"Sleight of Hand", "Dexterity"},
        {"Stealth", "Dexterity"},
        {"Survival", "Wisdom"}
    };

    // Array of Abilities
    public static string[] AbilityArray = new string[]
    {
        "Strength",
        "Dexterity",
        "Intelligence",
        "Constitution",
        "Wisdom",
        "Charisma"
    };

    // Array of Skills
    public static string[] SkillArray = new string[]
    {
        "Acrobatics",
        "Animal Handling",
        "Arcana",
        "Athletics",
        "Deception",
        "History",
        "Insight",
        "Intimidation",
        "Investigaton",
        "Medicine",
        "Nature",
        "Perception",
        "Performance",
        "Persuasion",
        "Religion",
        "Sleight of Hand",
        "Stealth",
        "Survival"
    };

    // Converts string array into string for use in exception messages
    // Ex: {"A, "B", "C"} becomes "A, B, or C"
    public static string CreateExceptionMessageListFor(string[] array)
    {
        string exceptionMessage = "";
        for (int i = 0; i < array.Length; i++)
        {
            if (i == 0)
            {
                exceptionMessage += array[i];
            }
            else if (i == array.Length - 1)
            {
                exceptionMessage += ", or " + array[i];
            }
            else
            {
                exceptionMessage += ", " + array[i];
            }
        }
        return exceptionMessage;
    }

    // Converts short-form or long-form abilities to correctly capitalized ability name
    public static string ConvertAbilityStringToCompleteFormFor(string ability)
    {
        string localAbility = ability.ToLower() ;

        if (localAbility == "str" || localAbility == "strength")
        {
            return "Strength";
        }
        if (localAbility == "dex" || localAbility == "dexterity")
        {
            return "Dexterity";
        }
        if (localAbility == "con" || localAbility == "constitution")
        {
            return "Constitution";
        }
        if (localAbility == "int" || localAbility == "intelligence")
        {
            return "Intelligence";
        }
        if (localAbility == "wis" || localAbility == "wisdom")
        {
            return "Wisdom";
        }
        if (localAbility == "cha" || localAbility == "char" || localAbility == "charisma")
        {
            return "Charisma";
        }
        return null;
    }

    // Converts single-word representation of a skill into the full correctly capitalized skill name
    public static string ConvertSkillStringToCompleteFormFor(string skill)
    {
        string localSkill = skill.ToLower();

        if (localSkill == "acrobatics")
        {
            return "Acrobatics";
        }
        if (localSkill == "animal")
        {
            return "Animal Handling";
        }
        if (localSkill == "arcana")
        {
            return "Arcana";
        }
        if (localSkill == "athletics")
        {
            return "Athletics";
        }
        if (localSkill == "deception")
        {
            return "Deception";
        }
        if (localSkill == "history")
        {
           return "History";
        }
        if (localSkill == "insight")
        {
            return "Insight";
        }
        if (localSkill == "intimidation")
        {
            return "Indimidation";
        }
        if (localSkill == "investigation")
        {
            return "Investigation";
        }
        if (localSkill == "medicine")
        {
            return "Medicine";
        }
        if (localSkill == "nature")
        {
            return "Nature";
        }
        if (localSkill == "perception")
        {
            return "Perception";
        }
        if (localSkill == "performance")
        {
            return "Performance";
        }
        if (localSkill == "persuasion")
        {
            return "Persuasion";
        }
        if (localSkill == "religion")
        {
            return "Religion";
        }
        if (localSkill == "sleight")
        {
            return "Sleight of Hand";
        }
        if (localSkill == "stealth")
        {
            return "Stealth";
        }
        if (localSkill == "survival")
        {
            return "Survival";
        }
        return null;
    }

    // Determines ability modifier based on given ability string
    public static int DetermineModifierForAbility(string ability)
    {
        if (ability == "Strength")
        {
            return Program.Character.StrengthModifier;
        }
        if (ability == "Dexterity")
        {
            return Program.Character.DexterityModifier;
        }
        if (ability == "Constitution")
        {
            return Program.Character.ConstitutionModifier;
        }
        if (ability == "Intelligence")
        {
            return Program.Character.IntelligenceModifier;
        }
        if (ability == "Wisdom")
        {
            return Program.Character.WisdomModifier;
        }
        if (ability == "Charisma")
        {
            return Program.Character.CharismaModifier;
        }
        // -100 being an impossible ability modifier
        return -100;
    }
}
