/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }
        static Double Polonaise(String Entrée)
        {
            try
            {
                string[] entrée = Entrée.Split(' ');
                int Cases = entrée.Length;

                while (Cases > 1)
                {
                    int k = Cases - 1;
                    while (k > 0 && entrée[k] != "+" && entrée[k] != "-" && entrée[k] != "/" && entrée[k] != "*")
                    {
                        k--;
                    }
                    float a = float.Parse(entrée[k + 1]);
                    float b = float.Parse(entrée[k + 2]);

                    float Réponse = 0;
                    switch (entrée[k])
                    {
                        case "+": Réponse = a + b; break;
                        case "-": Réponse = a - b; break;
                        case "*": Réponse = a * b; break;
                        case "/":
                            if (b == 0)
                            {
                                return float.NaN;
                            }
                            Réponse = a / b; break;
                    }
                    entrée[k] = Réponse.ToString();

                    for (int j = k + 1; j < Cases - 2; j++)
                    {
                        entrée[j] = entrée[j + 2];
                    }
                    for (int j = Cases + 2; j < Cases ; j++)
                    {
                        entrée[j] =" ";
                    }
                    Cases = Cases - 2;
                }
                return Double.Parse(entrée[0]);
            }
            catch
            {
                return Double.NaN;
            }
        }
        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
