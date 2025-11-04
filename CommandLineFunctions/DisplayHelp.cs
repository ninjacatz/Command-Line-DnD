namespace Command_Line_DnD;

internal class DisplayHelp
{
    public static void Display()
    {
        Console.WriteLine("--- List of Commands ---");
        Console.WriteLine("help\n\tDisplays commands and describes their usage");
        Console.WriteLine("help-character\n\tDisplays commands related to a player character and describes their usage");
        Console.WriteLine("load [file_name_to_load]\n\tFile must be located in CharacterSheets folder of program\n\tIf file is name.txt type \"load name\"\n\tUse blank character sheet provided in CharacterSheets folder for new characters");
        Console.WriteLine("roll [number of die and die type]\n\tSimulates die rolls with random numbers\n\tExamples: \"roll d20\" rolls a d20, \"roll 4d12\" rolls 4 d12s,\n\t\"roll 4d20 + 5\" rolls 4 d20s and adds 5 to all of the rolls,\n\t\"roll 4d7 * 3\" rolls 4 d7s and multiplies 3 to all of the rolls");
        Console.WriteLine("describe\n\tGives a list of descriptive attributes of currently loaded character");
        Console.WriteLine("describe-stats\n\tGives a list of statistical attributes of currently loaded character");
        Console.WriteLine("quit\n\tExits program");
    }
}
