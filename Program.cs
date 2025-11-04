namespace DnDProject;

class Program
{
    public static PlayerCharacter Character = new PlayerCharacter();

    static void Main(string[] args)
    {
        // setting FirstName to "No Character Loaded", used to determine if character is loaded
        Character.FirstName = "No Character Loaded";

        Console.WriteLine("ninjacats' DnD Project. Type \"help\" for a list of commands.");

        CommandLine.MainLoop();
    }
}
