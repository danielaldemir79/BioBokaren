namespace BioBokaren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menuChoice = 0;

            VisaMeny();

            switch (menuChoice)
            {

                case 1:     //Lista filmer
                    break;

                case 2:     //Välj film & tid, ange biljetter
                    break;

                case 3:     //Lägg på/ta bort studentrabatt
                    break;

                case 4:     //Skriv ut kvitto
                    break;

                case 5:     //Avsluta
                    break;

                default:
                    Console.WriteLine("Du har angett felaktigt val.");
                    break;
            }

        }



        static void VisaMeny()
        {
            Console.WriteLine();
            Console.WriteLine("Välkommen till BioBokaren!");
            Console.WriteLine("1. Lista filmer");
            Console.WriteLine("2. Välj film & tid, ange biljetter");
            Console.WriteLine("3. Lägg på/ta bort studentrabatt");
            Console.WriteLine("4. Skriv ut kvitto");
            Console.WriteLine("5. Avsluta");
            Console.WriteLine();
        }


        static int GetInt()
        {
            int helTal;

            while (int.TryParse(Console.ReadLine(), out helTal) == false)
            {
                Console.WriteLine("Du har inte angett ett heltal. Försök igen.");
            }
        
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
