namespace Command_Line_DnD;

internal class Roll
{
    public static int d(int dieSides)
    {
        Random rnd = new Random();
        return rnd.Next(1, dieSides + 1);
    }

    public static void DetermineDieCommand(string[] commandArray)
    {
        try
        {
            // initalized to arbitrary values because if/else statements require me to
            int numberOfRolls = 1;
            int dieType = 20;
            string operatorSymbol = null;
            int numberToOperate = 0;

            // check if index 1 is valid (ex. "d20", "4d12")
            if (commandArray[1].StartsWith("d"))
            {
                commandArray[1] = "1" + commandArray[1];
            }
            if (commandArray[1].Contains("d"))
            {
                string[] dieCommandArray = commandArray[1].Split('d');
                numberOfRolls = Convert.ToInt32(dieCommandArray[0]);
                dieType = Convert.ToInt32(dieCommandArray[1]);
            }
            else
            {
                throw new Exception("Incorrect die argument.");
            }

            // if using operator in addition to rolls
            if (commandArray.Length > 2)
            {
                // check if operator is correct (+ or *)
                if (commandArray[2] != "+" && commandArray[2] != "*")
                {
                    throw new Exception("Incorrect operator type. Must be \"+\" or \"*\".");
                }
                else
                {
                    operatorSymbol = commandArray[2];
                }
                // check if number for use in operation is integer
                numberToOperate = Convert.ToInt32(commandArray[3]);
            }

            for (int i = 0; i < numberOfRolls; i++)
            {
                RollWithDie(dieType, operatorSymbol, numberToOperate);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Found a non-integer where an integer was required.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void RollWithDie(int die, string operatorSymbol, int numberToOperate)
    {
        if (operatorSymbol == null)
        {
            Console.WriteLine(Roll.d(die));
        }
        else if (operatorSymbol == "+")
        {
            int rollValue = Roll.d(die);
            Console.WriteLine($"{rollValue} + {numberToOperate} = {rollValue + numberToOperate}");
        }
        else if (operatorSymbol == "*")
        {
            int rollValue = Roll.d(die);
            Console.WriteLine($"{rollValue} + {numberToOperate} = {rollValue * numberToOperate}");

        }
    }
}
