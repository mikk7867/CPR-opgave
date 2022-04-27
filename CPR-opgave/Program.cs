using CPR_opgave;

namespace CPRopgave
{
    public class Program
    {
        public static void Main (string[] args)
        {
            bool looper = true;
            while (looper)
            {
                Console.WriteLine("Indtast CPR i formatet DDMMYY-XXXX:");
                string? input = Console.ReadLine();
                if (input != null)
                {
                    string gender = Maths.Test(input);
                    if (gender == "mand" || gender == "kvinde")
                    {
                        Console.WriteLine($"Det indtastede CPR-nr tilhører en {gender}.");
                        looper = false;
                    }
                    else
                    {
                        Console.WriteLine($"{gender}. Prøv igen.");
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
