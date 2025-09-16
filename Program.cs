using System.Collections.Generic;

namespace BioBokaren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menuChoice = 0;
            const string valuta = "SEK"; //Valuta
            const double moms = 0.06; //6% moms
            const double studentRabatt = 0.15; //15% rabatt för studenter
            bool harStudentRabatt = false; //Håller reda på om kunden har studentrabatt eller inte

            double totalPris = 0; //Totalpris för alla biljetter
            int antalBiljetter = 0; //Antal biljetter kunden vill köpa
            int valdFilm = 0; //Index för vald film
            int valdTid = 0; //Index för vald tid

            string[] filmer = { "Braveheart", "Gladiatorn", "Top Gun", "Avatar", "Inception" };
            string[] tider = { "15:00", "18:00", "21:00" };
            double[] priser = { 120, 100, 130, 140, 110 }; //Priserna motsvarar filmernas index i arrayen

            List<string> dinaFilmer = new List<string>();  //Här skapar jag listor som jag matar in valda filmer, tider och priser i för att sedan kunna skriva ut dem på kvittot
            List<string> dinaTider = new List<string>();
            List<double> dinaPriser = new List<double>();

            Console.WriteLine("Välkommen till BioBokaren!");

            while (true)
            {
                if (menuChoice == 5) //Avsluta
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tack för att du använde BioBokaren. Välkommen åter!");
                    Console.ResetColor();
                    break;
                }

                VisaMeny();
                Console.Write("Skriv in ditt val: ");
                menuChoice = GetInt();

                switch (menuChoice)  
                {

                    case 1:     //Lista filmer
                        Console.Clear();
                        ListaFilmer(filmer, tider, priser, valuta);

                        Console.WriteLine();

                        break;

                    case 2:     //Välj film & tid, ange biljetter

                        Console.Clear(); // Rensa konsolen för att göra det mer överskådligt

                        ListaFilmer(filmer, tider, priser, valuta); //Visar filmer och tider igen för att underlätta valet
                        Console.WriteLine();

                        Console.Write("Ange filmens nummer: "); //-1 för att matcha arrayens index
                        valdFilm = GetInt() - 1;    

                        if (valdFilm < 0 || valdFilm >= filmer.Length)  //Kontrollerar att användaren anger ett giltigt filmnummer
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du har angett ett ogiltigt filmnummer. Försök igen.");
                            Console.ResetColor();
                            break;
                        }

                        dinaFilmer.Add(filmer[valdFilm]); //Lägger till vald film i listan för kvittot

                        Console.Write("Ange tidens nummer: ");
                        valdTid = GetInt() - 1;
                        if (valdTid < 0 || valdTid >= tider.Length)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du har angett ett ogiltigt tidnummer. Försök igen.");
                            Console.ResetColor();
                            break;
                        }

                        dinaTider.Add(tider[valdTid]); //Lägger till vald tid i listan för kvittot

                        Console.Write("Ange antal biljetter: ");
                        antalBiljetter = GetInt();
                        if (antalBiljetter <= 0)
                        {
                            Console.WriteLine("Du måste ange minst en biljett. Försök igen.");
                            break;
                        }

                        dinaPriser.Add((priser[valdFilm] * antalBiljetter)); //Lägger till priset för valda biljetter i listan för kvittot
                        
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Din order har genomförts. Detaljer kan du se under Skriv ut kvitto");
                        Console.ResetColor();

                        break;

                    case 3:     //Lägg på eller ta bort studentrabatt
                        if (harStudentRabatt == false)
                        {
                            Console.Clear();
                            harStudentRabatt = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Studentrabatt aktiverad.");
                            Console.ResetColor();
                            
                        }
                        else
                        {
                            Console.Clear();
                            harStudentRabatt = false;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Studentrabatt avaktiverad.");
                            Console.ResetColor();
                            
                        }

                        break;

                    case 4:     //Skriv ut kvitto
                        Console.Clear();
                        if (antalBiljetter == 0)  //Kontrollerar att kunden har valt biljetter innan kvitto skrivs ut
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du har inte valt några biljetter än. Välj biljetter först.");
                            Console.ResetColor();
                            break;
                        }

                        CalculateTotal(dinaFilmer, dinaPriser, dinaTider, harStudentRabatt, studentRabatt, moms);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine("Tack för ditt köp!");
                        Console.ResetColor();

                        break;

                    case 5:
                        break;

                    default:
                        Console.WriteLine("Du har angett felaktigt val. Försök igen");
                        break;
                }
            }

        }



        static void VisaMeny() //Metod för att visa menyn
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("1. Lista filmer");
            Console.WriteLine("2. Välj film & tid, ange biljetter");
            Console.WriteLine("3. Lägg på/ta bort studentrabatt");
            Console.WriteLine("4. Skriv ut kvitto");
            Console.WriteLine("5. Avsluta");
            Console.WriteLine();
            Console.ResetColor();

        }


        // Metod för att lista filmer och tider
        static void ListaFilmer(string[] filmer, string[] tider, double[] priser, string valuta) 
        {
            
            Console.WriteLine("Tillgängliga filmer:");
            Console.WriteLine();


            for (int i = 0; i < filmer.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {filmer[i]}: Pris: {priser[i]} {valuta}");
            }
            Console.WriteLine();
            
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tillgängliga tider:");
            for (int j = 0; j < tider.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {tider[j]}");
            }
            Console.ResetColor();

        }

        static int GetInt() //Hjälpmetod för att hantera felaktig inmatning av heltal
        {
            int helTal;

            while (int.TryParse(Console.ReadLine(), out helTal) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du har inte angett ett heltal. Försök igen.");
                Console.ResetColor();
            }

            return helTal;

        }

        static double GetDouble() //Används inte i nuläget men kan vara bra att ha för framtida ändamål ;)
        {
            double decimalTal;

            while (double.TryParse(Console.ReadLine(), out decimalTal) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du har inte angett ett tal. Försök igen.");
                Console.ResetColor();
            }

            return decimalTal;
        }

        static void CalculateTotal(List<string> filmer, List<double> priser, List<string> Tider, bool studenRabatt = false, double rabatt = 0.15, double moms = 0.06)
        {
           
            double totalPris = 0;
            Console.Clear();
            Console.WriteLine("Kvitto:");
            for (int i = 0; i < filmer.Count; i++)
            {
                
                if (studenRabatt)  // Pris per rad om kunden har studentrabatt
                {
                    Console.WriteLine($"{filmer[i]} - Kl. {Tider[i]} - Pris: {Math.Round(priser[i] * (1 - rabatt) * (1 + moms), 2)} SEK (inkl 6% moms samt 15% studentrabatt avdragen)");

                }
                else      //    Pris per rad om kunden inte har studentrabatt
                {
                    Console.WriteLine($"{filmer[i]} - Kl. {Tider[i]} - Pris: {Math.Round((priser[i] * (1+ moms)), 2)} SEK inkl 6% moms");

                }
                totalPris += priser[i];
            }

            Console.ForegroundColor = ConsoleColor.Yellow;  
            Console.WriteLine();
            if (studenRabatt)   // Totalpris om kunden har studentrabatt
            {
                totalPris = totalPris * (1 - rabatt) * (1 + moms);
                Console.WriteLine($"Totala priset landar på {Math.Round(totalPris, 2)} SEK (inkl 6% moms samt 15% studentrabatt avdragen)");
            }
            else //     Totalpris om kunden inte har studentrabatt
            {
                totalPris = totalPris * (1 + moms);
                Console.WriteLine($"Totala priset landar på {Math.Round(totalPris, 2)} SEK inkl 6% moms");
            }
            Console.ResetColor();


        }
    }
}
