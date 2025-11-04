namespace Command_Line_DnD;

internal class LoadCharacter
{
    public static void Load(string filename)
    {
        try
        {
            string currentDir = Directory.GetCurrentDirectory();
			string projectRoot = currentDir;
			if (currentDir.Contains(Path.Combine("bin", "Debug")) || currentDir.Contains(Path.Combine("bin", "Release")))
			{
				projectRoot = Path.GetFullPath(Path.Combine(currentDir, @"..\..\.."));
			}
            string[] lines = System.IO.File.ReadAllLines(projectRoot + "/CharacterSheets/" + filename + ".txt");

            // Set properties of PlayerCharacter
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("_.~ First Name* ~._"))
                {
                    Program.Character.FirstName = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Last Name ~._") && lines[i + 1] != "")
                {
                    Program.Character.LastName = lines[i+ 1].Trim();
                }
                if (lines[i].Contains("_.~ Race* ~._"))
                {
                    Program.Character.Race = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Race Additional Language ~._") && lines[i + 1] != "")
                {
                    Program.Character.RaceAdditionalLanguage = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Class* ~._"))
                {
                    Program.Character.CharacterClass = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Class Skill Proficiencies* ~._"))
                {
                    Program.Character.CharacterClassProficiencies = lines[i + 1].Trim().Split(",");
                }
                if (lines[i].Contains("_.~ Gender ~._") && lines[i + 1] != "")
                {
                    Program.Character.Gender = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Eye Color ~._") && lines[i + 1] != "")
                {
                    Program.Character.EyeColor = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Height ~._") && lines[i + 1] != "")
                {
                    try {Program.Character.Height = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("Height must be an integer.");}
                }
                if (lines[i].Contains("_.~ Weight ~._") && lines[i + 1] != "")
                {
                    try {Program.Character.Weight = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("Weight must be an integer.");}
                }
                if (lines[i].Contains("_.~ Age ~._") && lines[i + 1] != "")
                {
                    try {Program.Character.Age = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("Age must be an integer.");}
                }
                if (lines[i].Contains("_.~ Alignment ~._") && lines[i + 1] != "")
                {
                    Program.Character.Alignment = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Faith ~._") && lines[i + 1] != "")
                {
                    Program.Character.Faith = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Ideals ~._") && lines[i + 1] != "")
                {
                    Program.Character.Ideals = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Bonds ~._") && lines[i + 1]  != "")
                {
                    Program.Character.Bonds = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Flaws ~._") && lines[i + 1] != "")
                {
                    Program.Character.Flaws = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Backstory ~._") && lines[i + 1] != "")
                {
                    Program.Character.Backstory = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Background* ~._"))
                {
                    Program.Character.Background = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Background Additional Languages ~._") && lines[i + 1] != "")
                {
                    Program.Character.BackgroundAdditionalLanguages = lines[i + 1].Trim().Split(",");
                }
                if (lines[i].Contains("_.~ Background Feature ~._") && lines[i + 1] != "")
                {
                    Program.Character.BackgroundFeature = lines[i + 1].Trim();
                }
                if (lines[i].Contains("_.~ Total Hit Points* ~._"))
                {
                    try {Program.Character.TotalHitpoints = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("TotalHitPoints must be an integer.");}
                }
                if (lines[i].Contains("_.~ Current Hit Points* ~._"))
                {
                    try {Program.Character.CurrentHitPoints = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("CurrentHitPoints must be an integer.");}
                }
                if (lines[i].Contains("_.~ Level* ~._"))
                {
                    try {Program.Character.Level = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("Level must be an integer.");}
                }
                if (lines[i].Contains("_.~ Strength* ~._"))
                {
                    try {Program.Character.Strength = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("Strength must be an integer.");}
                }
                if (lines[i].Contains("_.~ Dexterity* ~._"))
                {
                    try {Program.Character.Dexterity = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("Dexterity must be an integer.");}
                }
                if (lines[i].Contains("_.~ Constitution* ~._"))
                {
                    try {Program.Character.Constitution = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("Constitution must be an integer.");}
                }
                if (lines[i].Contains("_.~ Intelligence* ~._"))
                {
                    try {Program.Character.Intelligence = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("Intelligence must be an integer.");}
                }
                if (lines[i].Contains("_.~ Wisdom* ~._"))
                {
                    try {Program.Character.Wisdom = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("Wisdom must be an integer.");}
                }
                if (lines[i].Contains("_.~ Charisma* ~._"))
                {
                    try {Program.Character.Charisma = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("Charisma must be an integer.");}
                }
                if (lines[i].Contains("_.~ Armor Class* ~._"))
                {
                    try {Program.Character.ArmorClass = Convert.ToInt32(lines[i + 1].Trim());}
                    catch{throw new Exception("ArmorClass must be an integer.");}
                }
                if (lines[i].Contains("_.~ Size ~._") && lines[i + 1] != "")
                {
                    Program.Character.Size = lines[i + 1];
                }
                if (lines[i].Contains("_.~ Equipment ~._") && lines[i + 1] != "")
                {
                    Program.Character.Equipment = lines[i + 1].Split(", ");
                }
                
            }

            Console.WriteLine($"Character {Program.Character.FirstName} successfully loaded.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No such file \"" + filename + ".txt\" found in CharacterSheets folder.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + " Failed to load " + filename + ".txt.");
        }
    }
}
