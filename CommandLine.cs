namespace Command_Line_DnD;

internal class CommandLine
{
    public static void MainLoop()
    {
        for (;;)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            // Program.character.FirstName will be set at "No Character Loaded"
            // if no character has been loaded yet
            Console.Write(Program.Character.FirstName);
            Console.ResetColor();
            Console.Write(" >");

            string command = Console.ReadLine();

            DetermineCommand(command);
        }
    }

    static void DetermineCommand(string command)
    {
        // Where string is not null or whitespace: Allows user to enter extra spaces in command
        // Ex. "  roll    4d20" = {"roll, "4d20"}
        List<string> commandList = command.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

        // To lower: Allows user to enter capitalized commands
        // Ex. {"RoLL", "4D20"} = {"roll", "4d20"}
        for (int i = 0; i < commandList.Count; i++)
        {
            commandList[i] = commandList[i].ToLower();
        }

        // If no character is loaded there are only four commands available to use: load, help, quit, and roll
        // NOTE: still does not account for random entries. ex. "notacommand 4"
        if (Program.Character.FirstName == "No Character Loaded" && 
            commandList[0] != "load" && 
            commandList[0] != "help" && 
            commandList[0] != "roll" && 
            commandList[0] != "quit")
        {
            Console.WriteLine("Please load a character first. Enter \"help\' for more information.");
        }
        else
        {
            DetermineCommandArray(commandList.ToArray());
        }
    }
    
    static void DetermineCommandArray(string[] commandArray)
    {
        switch (commandArray[0])
        {
            case "":
                // do nothing
                break;
            case "help":
                if (CheckNumberOfCommands(new int[] {1}, commandArray))
                {
                    DisplayHelp.Display();
                }
                break;
            case "help-character":
                if (CheckNumberOfCommands(new int[] {1}, commandArray))
                {
                    DisplayHelpCharacter.Display();
                }
                break;
            case "describe":
                if (CheckNumberOfCommands(new int[] {1}, commandArray))
                {
                    DescribeCharacter.Describe();
                }
                break;
            case "describe-stats":
                if (CheckNumberOfCommands(new int[] {1}, commandArray))
                {
                    DescribeCharacterStats.Describe();
                }
                break;
            case "load":
                if (CheckNumberOfCommands(new int[] {2}, commandArray))
                {
                    if (Program.Character.FirstName != "No Character Loaded")
                    {
                        Console.WriteLine("Cannot load another character. Please quit and try again.");
                    }
                    else
                    {
                        LoadCharacter.Load(commandArray[1]);
                    }
                }
                break;
            case "save":
                if (CheckNumberOfCommands(new int[] {2}, commandArray))
                {
                    PlayerCharacterFunctions.AbilitySave(commandArray[1]);
                }
                break;
            case "skill":
                if (CheckNumberOfCommands(new int[] {2}, commandArray))
                {
                    PlayerCharacterFunctions.SkillCheck(commandArray[1]);
                }
                break;
            case "damage":
                if (CheckNumberOfCommands(new int[] {2}, commandArray))
                {
                    PlayerCharacterFunctions.ChangeHitPoints("-" + commandArray[1]);
                }
                break;
            case "heal":
                if (CheckNumberOfCommands(new int[] {2}, commandArray))
                {
                    PlayerCharacterFunctions.ChangeHitPoints(commandArray[1]);
                }
                break;
            case "roll":
                if (CheckNumberOfCommands(new int[] {2, 4}, commandArray))
                {
                    Roll.DetermineDieCommand(commandArray);
                }
                break;
            case "quit":
                if (CheckNumberOfCommands(new int[] {1}, commandArray))
                {
                    Environment.Exit(0);
                }
                break;
            default:
                Console.WriteLine("Unknown command: " + commandArray[0]);
                break;
        }
    }

    static bool CheckNumberOfCommands(int[] possibleCommands, string[] commandArray)
    {
        for (int i = 0; i < possibleCommands.Length; i++)
        {
            if (commandArray.Length == possibleCommands[i])
            {
                return true;
            }
        }

        Console.Write($"Command {commandArray[0]} does not accept {commandArray.Length - 1} argument");

        if (commandArray.Length - 1 != 1)
        {
            Console.WriteLine("s");
        }
        else
        {
            Console.WriteLine();
        }

        return false;
    }
}
