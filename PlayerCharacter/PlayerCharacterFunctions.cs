namespace DnDProject;

internal class PlayerCharacterFunctions
{
    public static void AbilitySave(string ability)
    {
        ability = Data.ConvertAbilityStringToCompleteFormFor(ability);

        if (!Data.AbilityArray.Contains(ability))
        {
            Console.WriteLine("Ability does not exist.");
            return;
        }

        int rollValue = Roll.d(20);

        if (Data.ClassSaveProficienciesDictionary[Program.Character.CharacterClass].Contains(ability))
        {
            Console.WriteLine($"{rollValue} + {ability} Modifier({Data.DetermineModifierForAbility(ability)}) + Proficiency Bonus({Program.Character.ProficiencyBonus}) = {rollValue + Data.DetermineModifierForAbility(ability) + Program.Character.ProficiencyBonus}");
        }
        else
        {
            Console.WriteLine($"{rollValue} + {ability} Modifier({Data.DetermineModifierForAbility(ability)}) = {rollValue + Data.DetermineModifierForAbility(ability)}");
        }
    }

    public static void SkillCheck(string skill)
    {
        skill = Data.ConvertSkillStringToCompleteFormFor(skill);

        if (!Data.SkillArray.Contains(skill))
        {
            Console.WriteLine("Skill does not exist.");
            return;
        }

        string abilityForSkill = Data.SkillsByAbilityDictionary[skill];

        int rollValue = Roll.d(20);

        if (Data.BackgroundSkillProficiencyDictionary[Program.Character.Background].Contains(skill) || Data.ClassSkillProficiencyDictionary[Program.Character.CharacterClass].Contains(skill))
        {
            // Character is proficient in skill based on background OR class proficiency
            Console.WriteLine($"{rollValue} + {abilityForSkill} Modifier({Data.DetermineModifierForAbility(abilityForSkill)}) + Proficiency Bonus({Program.Character.ProficiencyBonus}) = {(rollValue + Data.DetermineModifierForAbility(abilityForSkill) + Program.Character.ProficiencyBonus)}");
        }
        else
        {
            Console.WriteLine($"{rollValue} + {abilityForSkill} Modifier({Data.DetermineModifierForAbility(abilityForSkill)}) = {rollValue + Data.DetermineModifierForAbility(abilityForSkill)}");
        }
    }

    public static void ChangeHitPoints(string amount)
    {
        try
        {
            int amountInt = Convert.ToInt32(amount);
            int extra = 0;
            
            Console.WriteLine($"Old Hit Points: ({Program.Character.CurrentHitPoints}/{Program.Character.TotalHitpoints})");

            if (amountInt < 0 && Math.Abs(amountInt) <= Program.Character.CurrentHitPoints)
            {
                Program.Character.CurrentHitPoints += amountInt;
            }
            if (amountInt < 0 && Math.Abs(amountInt) > Program.Character.CurrentHitPoints)
            {
                extra = Program.Character.CurrentHitPoints + amountInt;
                Program.Character.CurrentHitPoints = 0;
            }
            if (amountInt > 0 && amountInt <= (Program.Character.TotalHitpoints - Program.Character.CurrentHitPoints))
            {
                Program.Character.CurrentHitPoints += amountInt;
            }
            if (amountInt > 0 && amountInt > (Program.Character.TotalHitpoints - Program.Character.CurrentHitPoints))
            {
                extra = (Program.Character.CurrentHitPoints + amountInt) - Program.Character.TotalHitpoints;
                Program.Character.CurrentHitPoints = Program.Character.TotalHitpoints;
            }

            Console.Write($"New Hit Points: ({Program.Character.CurrentHitPoints}/{Program.Character.TotalHitpoints})");

            if (extra > 0)
            {
                Console.WriteLine($" +{extra}");
            }
            else if (extra < 0)
            {
                Console.WriteLine($" {extra}");
            }
            else
            {
                Console.WriteLine();
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Hit Point amount was not an integer.");
        }
    } 
}

