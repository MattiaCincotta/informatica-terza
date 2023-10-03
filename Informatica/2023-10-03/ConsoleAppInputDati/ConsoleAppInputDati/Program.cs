//Mattia Cincotta 3H 2023/10/03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppInputDati
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mattia Cincotta 3H");


            int numeroAlunni;
            bool inputOk;
            string stInput;
            int varInt;
            double varDouble;
            double altezza;

           
            #region validazione dell'altezza di una persona

            const double ALTEZZAMINIMA = 0.24;
            const double ALTEZZAMASSIMA = 2.72;

            do
            {
                Console.Write("Inserisci la tua altezza in metri -> ");
                stInput = Console.ReadLine();
                inputOk = Double.TryParse(stInput, out altezza);
                if (!inputOk || altezza < ALTEZZAMINIMA || altezza > ALTEZZAMASSIMA)
                {
                    Console.WriteLine("il valore inserito non è coretto, riprova -> ");
                }
                else Console.WriteLine("Bravo la tua altezza è " + stInput + "m");



            } while (!inputOk || altezza < ALTEZZAMINIMA || altezza > ALTEZZAMASSIMA);

            #endregion
                                                              













            /*
           #region Programma che verifica se il numero di studenti di una classe è corretto

           const int NUMEROMINIMOALUNNI = 10; //Numero minimo degli alunni che possono essere presenti in una classe
           const int NUMEROMASSIMOALUNNI = 35; //Numero massimo degli alunni che possono essere presenti in una classe

           do
           {
               Console.Write("Inserisci il numero di alunni presenti nella classe -> ");
               stInput = Console.ReadLine();
               inputOk = int.TryParse(stInput, out numeroAlunni);
               if (!inputOk || numeroAlunni > NUMEROMASSIMOALUNNI || numeroAlunni < NUMEROMINIMOALUNNI)
               {
                   Console.WriteLine("il valore inserito non è coretto, riprova ->");
               }
               else Console.WriteLine("Bravo il numero degli alunni presenti è " + stInput);



           } while (!inputOk || numeroAlunni > NUMEROMASSIMOALUNNI || numeroAlunni < NUMEROMINIMOALUNNI);

           #endregion
           /*
           #region Lettura a stampo di una stringa
           Console.Write("Input stringa -> ");
           stInput = Console.ReadLine();

           //Visualizza la stringa letta
           Console.WriteLine("Stringa letta = " + stInput);
           #endregion

           #region Conversione da stringa a double
           do
           {
               Console.Write("Input valore con la virgola -> ");
               stInput = Console.ReadLine();
               //Conversione stringa in intero
               inputOk = Double.TryParse(stInput, out varDouble);
               if (!inputOk) Console.WriteLine("input non valido! Riprova");

           } while (!inputOk); //Ricicla se non valido

           Console.WriteLine(varDouble);
           #endregion

           #region Conversione da stringa ad intero
           do
           {
               Console.Write("Input valore intero -> ");
               stInput = Console.ReadLine();
               //Conversione stringa in intero
               inputOk = int.TryParse(stInput, out varInt);
               if (!inputOk) Console.WriteLine("input non valido! Riprova");

           } while (!inputOk); //Ricicla se non valido
           Console.WriteLine(varInt);
           #endregion
           */
            #region termine programma
            Console.WriteLine("premi un tasto per terminare il programma");
            Console.ReadKey();
            #endregion






        }
    }
}
