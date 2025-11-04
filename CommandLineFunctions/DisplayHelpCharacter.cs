namespace Command_Line_DnD;

internal class DisplayHelpCharacter
{
    public static void Display()
    {
        Console.WriteLine("--- List of Character Commands ---");
        Console.WriteLine("save [ability]\n\tPerforms an saving throw of the given ability\n\tAbilities can be written long-form or short-form (Ex. dexterity or dex)");
        Console.WriteLine("skill [skill]\n\tPerforms a skill check of the given skill");
        Console.WriteLine("damage [amount]\n\tDamages your character by the given amount");
        Console.WriteLine("heal [amount]\n\tHeals your character by the given amount");
    }
}
