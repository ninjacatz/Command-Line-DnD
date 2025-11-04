namespace Command_Line_DnD;

internal class DescribeCharacter
{
    public static void Describe()
    {
        Console.Write(Program.Character.FirstName);
        if (Program.Character.LastName != null)
        {
            Console.Write(" " + Program.Character.LastName);
        }
        Console.WriteLine();
        Console.WriteLine("Languages Known:");
        foreach (string language in Program.Character.AllLanguagesKnown)
        {
            Console.WriteLine(language);
        }
        Console.WriteLine("Not quite finished with this yet...");
    }
}
