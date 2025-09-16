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

            string[] filmer = { "Braveheart", "Gldiatorn", "Top Gun", "Avatar", "Inception" };
            string[] tider = { "15:00", "18:00", "21:00" }; 
            double[] priser = { 120, 100, 130, 140, 110 }; //Priserna motsvarar filmernas index i arrayen

            
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
                        break;

                    case 3:     //Lägg på/ta bort studentrabatt
                        break;

                    case 4:     //Skriv ut kvitto
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


    }
}
