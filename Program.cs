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

            string[] filmer = { "Braveheart", "Gldiatorn", "Top Gun", "Avatar", "Inception" };
            string[] tider = { "15:00", "18:00", "21:00" }; 
            double[] priser = { 120, 100, 130, 140, 110 }; //Priserna motsvarar filmernas index i arrayen

            List<string> dinaFilmer = new List<string>();  //Här matar vi in valda filmer, tider och priser för att sedan skriva ut på kvittot
            List<string> dinaTider = new List<string>();
            List<double> dinaPriser = new List<double>();

            Console.WriteLine("Välkommen till BioBokaren!");

            while (true)
            {
                if (menuChoice == 5) //Avsluta
                {
                    Console.WriteLine("Tack för att du använde BioBokaren. Välkommen åter!");
                    break;
                }

                VisaMeny();
                menuChoice = GetInt();

                switch (menuChoice)
                {

                    case 1:     //Lista filmer
                        Console.Clear();
                        ListaFilmer(filmer, tider, priser, valuta);

                        Console.WriteLine();

                        break;

                    case 2:     //Välj film & tid, ange biljetter
                       
                        Console.Clear();
                        
                        ListaFilmer(filmer, tider, priser, valuta);
                        Console.WriteLine();
                        
                        Console.WriteLine("Ange filmens nummer:");
                        valdFilm = GetInt() - 1;

                        if (valdFilm < 0 || valdFilm >= filmer.Length)
                        {
                            Console.WriteLine("Du har angett ett ogiltigt filmnummer. Försök igen.");
                            break;
                        }
                        
                        dinaFilmer.Add(filmer[valdFilm]); //Lägger till vald film i listan för kvittot

                        Console.WriteLine("Ange tidens nummer:");
                        valdTid = GetInt() - 1;
                        if (valdTid < 0 || valdTid >= tider.Length)
                        {
                            Console.WriteLine("Du har angett ett ogiltigt tidnummer. Försök igen.");
                            break;
                        }

                        dinaTider.Add(tider[valdTid]); //Lägger till vald tid i listan för kvittot

                        Console.WriteLine("Ange antal biljetter:");
                        antalBiljetter = GetInt();
                        if (antalBiljetter <= 0)
                        {
                            Console.WriteLine("Du måste ange minst en biljett. Försök igen.");
                            break;
                        }

                        dinaPriser.Add((priser[valdFilm] * antalBiljetter)); //Lägger till priset för valda biljetter i listan för kvittot

                        break;

                    case 3:     //Lägg på/ta bort studentrabatt
                        if (harStudentRabatt == false)
                        {
                            harStudentRabatt = true;
                            Console.WriteLine("Studentrabatt aktiverad.");
                        }
                        else
                        {
                            harStudentRabatt = false;
                            Console.WriteLine("Studentrabatt avaktiverad.");
                        }

                        break;

                    case 4:     //Skriv ut kvitto
                        Console.Clear();
                        if (antalBiljetter == 0)
                        {
                            Console.WriteLine("Du har inte valt några biljetter än. Välj biljetter först.");
                            break;
                        }
                        
                        totalPris = CalculateTotal(dinaFilmer, dinaPriser, dinaTider, harStudentRabatt);

                        break;
                   
                    case 5:
                        break;
                    
                    default:
                        Console.WriteLine("Du har angett felaktigt val. Försök igen");
                        break;
                }
            }

        }



        static void VisaMeny()
        {
            Console.WriteLine();
            Console.WriteLine("1. Lista filmer");
            Console.WriteLine("2. Välj film & tid, ange biljetter");
            Console.WriteLine("3. Lägg på/ta bort studentrabatt");
            Console.WriteLine("4. Skriv ut kvitto");
            Console.WriteLine("5. Avsluta");
            Console.WriteLine();
        }


        // Metod för att lista filmer och tider
        static void ListaFilmer(string[] filmer, string[] tider, double[] priser, string valuta)
        {
            Console.WriteLine("Tillgängliga filmer:");
            for (int i = 0; i < filmer.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {filmer[i]}: Pris: {priser[i]} {valuta}");
            }
            Console.WriteLine();
            Console.WriteLine("Tillgängliga tider:");
            for (int j = 0; j < tider.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {tider[j]}");
            }
        }
        
        static int GetInt()
        {
            int helTal;

            while (int.TryParse(Console.ReadLine(), out helTal) == false)
            {
                Console.WriteLine("Du har inte angett ett heltal. Försök igen.");
            }

            return helTal;

        }

        static double GetDouble()
        {
            double decimalTal;

            while (double.TryParse(Console.ReadLine(), out decimalTal) == false)
            {
                Console.WriteLine("Du har inte angett ett tal. Försök igen.");
            }

            return decimalTal;
        }

        static double CalculateTotal(List<string> filmer, List<double> priser, List<string> Tider, bool studenRabatt = false)
        {
            double summa = 0;

           
           
            return summa;
        }
}
