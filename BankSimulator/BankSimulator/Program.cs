using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("BankSimulator");
        Console.WriteLine();

        string userChoice = string.Empty, rsatsInput;
        bool exit = false;
        double insättning, uttag, saldo = 0, antalÅr, rsats, insättningsbelopÅrlig, räntesatsDecimal, framtidaVärde = 0;

        Console.WriteLine("Välkommen till denna bank simulator");
        


        while (exit != true)
        {
            Console.WriteLine("Vad vill du göra?:  ");
            Console.WriteLine("[I] Insättning, [U] Uttag, [S] Saldo, [R] Räntebetalning, [A] Avsluta");
            userChoice = Console.ReadLine();



            switch (userChoice)
            {
                case "I":
                    Console.WriteLine("Insättning");
                    Console.WriteLine("Hur mycket vill du sätta in?: ");
                    insättning = Convert.ToDouble(Console.ReadLine());
                    saldo = saldo + insättning;
                    break;
                case "U":
                    Console.WriteLine("Uttag");
                    Console.WriteLine("Hur mycket vill du ta ut?: ");
                    uttag = Convert.ToDouble(Console.ReadLine());
                    saldo = saldo - uttag;
                    break;
                case "S":
                    Console.WriteLine("Saldo");
                    Console.WriteLine($"{saldo}kr");
                    break;
                case "R":
                    Console.WriteLine("Räntebetalning");
                    Console.WriteLine("Hur mycket vill du betala in detta året: ");
                    insättningsbelopÅrlig = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Vilken ränte sats i %? t ex 5% = 0.05: ");
                    rsatsInput = Console.ReadLine();
                    if(double.TryParse(rsatsInput, NumberStyles.Float, CultureInfo.InvariantCulture, out double prasedRsats))
                    {
                        rsats = prasedRsats * 100;
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig inmatning. Ange ett giltigt nummer.");
                        rsats = 0;
                    }
                    Console.WriteLine("Hur många år?: ");
                    antalÅr = Convert.ToDouble(Console.ReadLine());
                    
                    räntesatsDecimal = rsats / 100;

                    for(int år = 1; år <= antalÅr; år++)
                    {
                        framtidaVärde = (framtidaVärde * (1 + räntesatsDecimal)) + insättningsbelopÅrlig;

                        Console.WriteLine($"FramtidaVärde: {framtidaVärde}");
                        Console.WriteLine($"insättningsbelopÅrlig: {insättningsbelopÅrlig}");
                        Console.WriteLine($"räntesatsDecimal: {räntesatsDecimal}");

                    }

                    Console.WriteLine($"Du kommer få {framtidaVärde}kr efter {antalÅr}år");
                    break;
                case "A":
                    Console.WriteLine("Avsluta");
                    exit = true;
                    break;
            }
        }

    }

}