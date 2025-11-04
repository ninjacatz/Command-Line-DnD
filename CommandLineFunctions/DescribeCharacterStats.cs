namespace Command_Line_DnD;

internal class DescribeCharacterStats
{
    public static void Describe()
    {
        Console.WriteLine("Hit Points: (" + Program.Character.CurrentHitPoints + "/" + Program.Character.TotalHitpoints + ")");
        Console.WriteLine("Not quite finished with this yet...");
    }
}
