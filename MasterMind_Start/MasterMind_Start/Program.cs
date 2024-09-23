using System;

namespace MasterMind_Start
{
    class Program
    {
        /*
         * NAAM:.......................
        */

        static void Main(string[] args)
        {
            // Consolekleuren instellen
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            const int beurten = 10;
            bool gewonnen = false;
            string[] invoerCijfers;
            string invoer;

            int[] aOpgave = new int[4];
            int[,] aVeld = new int[beurten, 4];
            int[,] aControle = new int[beurten, 2];

            // We starten een nieuw spel.
            NieuwSpel(ref aOpgave);

            // Het spel heeft maximaal x (10) beurten.
            for (int i = 0; i <= aVeld.GetUpperBound(0); i++)
            {
                // We tonen de cijfers en de controle
                ToonSpel(i, aOpgave, aVeld);

                // Invoer cijfers beurt.
                Console.Write("Geef je cijfers in gescheiden met een komma: ");
                invoer = Console.ReadLine();

                // Splitsen van invoer naar array.
                invoerCijfers = invoer.Split(',');

                // Elk cijfer van de invoer in de array aVeld bewaren.
                for (int teller = 0; teller < invoerCijfers.Length; teller++)
                {
                    aVeld[i, teller] = Convert.ToInt32(invoerCijfers[teller]);
                }

                // ******** CONTROLE INGAVE CIJFERS *********

                // ******** CONTROLE INGAVE CIJFERS *********

                // Indien gewonnen tonen we het veld met de laatste beurt + gevonden in...
                if (gewonnen)
                {
                    ToonSpel(i + 1, aOpgave, aVeld);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Gevonden in " + (i + 1) + " beurt(en)!");
                    Console.ReadLine();
                    return;
                }
            }

            // Tonen het veld met de laatste beurt.
            // Indien het niet gevonden is in x (10) beurten, melding volgende keer beter...
            ToonSpel(aVeld.GetUpperBound(0) + 1, aOpgave, aVeld);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Ai, volgende keer beter!");
            Console.ReadLine();
        }

       

        private static void ToonSpel(int index, int[] aOpgave, int[,] aVeld)
        {
            string res = "";

            Console.Clear();
            Console.WriteLine("MasterMind");
            Console.WriteLine("***********");
            Console.WriteLine("");
            // Toon de opgave in debug mode.
            Console.WriteLine(aOpgave[0] + " " + aOpgave[1] + " " + aOpgave[2] + " " + aOpgave[3]);
            Console.WriteLine("******** \tJP JC");


            // We tonen alle gespeelde beurten, dus afhankelijk van de parameter index.
            for (int i = 0; i < index; i++)
            {
                // We tonen welke beurt het is 1# 2#...
                res += (i + 1) + "# ";
                for (int j = 0; j <= aVeld.GetUpperBound(1); j++)
                {
                    res += (aVeld[i, j] + " ");
                }

                res += "\t";

                // Volgende beurt nieuwe lijn.
                res += Environment.NewLine;
            }

            Console.WriteLine(res);
        }

        private static void NieuwSpel(ref int[] aOpgave)
        {
            Random willekeurig = new Random();
            int cijfer;

            // We genereren 4 willekeurige cijfers.
            for (int i = 0; i <= aOpgave.GetUpperBound(0); i++)
            {                                    
                // ******** CONTROLE CIJFER AL GEBRUIKT *********
                    
                cijfer = willekeurig.Next(1, 7);

                  
                aOpgave[i] = cijfer;

                // ******** CONTROLE CIJFER AL GEBRUIKT *********
            }
        }
        


    }
}
