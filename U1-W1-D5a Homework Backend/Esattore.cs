using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_W1_D5a_Homework_Backend
{
    internal class Esattore
    {
        private string User { get; set; } = "marco";
        private string Password { get; set; } = "puccio";
        private bool Logged { get; set; } = false;
        private List<Contribuente> ListaContribuenti { get; set; } = new List<Contribuente>();

        public void Menu()
        {
            if (Logged == false)
            {
                Console.WriteLine("==========================");
                Console.WriteLine("1) Effettua il login");
                Console.WriteLine("2) Esci");
                Console.WriteLine("==========================");
                string sceltaNonLoggato = Console.ReadLine();
                if (sceltaNonLoggato == "1")
                {
                    Login();
                }
                else if(sceltaNonLoggato == "2") 
                {
                    Environment.Exit(0);    
                }
                else
                {
                    Console.WriteLine("Hai digitato un numero inesistente, riprova.");
                    Console.WriteLine("");
                    Menu();
                }
            }
            else
            {
                Console.WriteLine("==========================");
                Console.WriteLine("1) Crea contribuente");
                Console.WriteLine("2) Elenco dei contribuenti");
                Console.WriteLine("3) Scheda dettagliata dei Contribuente");
                Console.WriteLine("4) Logout");
                Console.WriteLine("5) Esci");
                Console.WriteLine("==========================");
                string sceltaLoggato = Console.ReadLine();

                if (sceltaLoggato == "1")
                {
                    CreaContribuente();
                }
                else if (sceltaLoggato == "2")
                {
                    ElencoContribuenti();
                }
                else if (sceltaLoggato == "3")
                {
                    SchedaContribuenti();
                }
                else if (sceltaLoggato == "4")
                {
                    Logout();
                }
                else if (sceltaLoggato == "5")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Hai digitato un numero inesistente, riprova.");
                    Console.WriteLine("");
                    Menu();
                }
            }
        }

        private void Login()
        {
            Console.WriteLine("Digita il tuo nome utente:");
            string nomeUser = Console.ReadLine();
            if (User != nomeUser)
            {
                Console.WriteLine("Hai digitato il nome sbagliato.");
                Login();
            }
            Console.WriteLine("Digita la tua password:");
            string nomePassword = Console.ReadLine();
            if (Password != nomePassword)
            {
                Console.WriteLine("Hai digitato la password sbagliata.");
                Login();
            }
            Logged = true;
            Menu();
        }                

        private void Logout()
        {
            Logged= false;
            Menu();
        }

        private void CreaContribuente()
        {
            try
            {
                Contribuente contribuente = new Contribuente();
                Console.WriteLine("Digita il tuo nome:");
                contribuente.Nome = Console.ReadLine();
                Console.WriteLine("Digita il tuo cognome:");
                contribuente.Cognome = Console.ReadLine();
                Console.WriteLine("Digita la tua data di nascita nel formato dd/MM/YYYY:");
                contribuente.DataNascita = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci il tuo codice fiscale:");
                contribuente.CodiceFiscale = Console.ReadLine();
                Console.WriteLine("Digita M se sei un maschio o F se sei una femmina:");
                string sesso = Console.ReadLine();
                if (sesso == "M")
                {
                    contribuente.Sesso = "M";
                }
                else if (sesso == "F")
                {
                    contribuente.Sesso = "F";
                }
                else
                {
                    Console.WriteLine("Non hai digitato correttamente.");
                    Console.WriteLine("");
                    CreaContribuente();
                }
                Console.WriteLine("Digita il tuo Comune di residenza:");
                contribuente.ComuneResidenza = Console.ReadLine();
                Console.WriteLine("Digita il tuo reddito annuale");
                contribuente.RedditoAnnuale = double.Parse(Console.ReadLine());
                ListaContribuenti.Add(contribuente);
                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                CreaContribuente();
            }

        }

        private void ElencoContribuenti()
        {
            int n = 1;
            Console.WriteLine("===============================");
            Console.WriteLine("ELENCO DEI CONTRIBUENTI");
            foreach (Contribuente contribuente in ListaContribuenti)
            {
                Console.WriteLine($"{n}) {contribuente.Nome} {contribuente.Cognome}.");
                n++;
            }
            Console.WriteLine("===============================");
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        private void SchedaContribuenti()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            foreach (Contribuente contribuente in ListaContribuenti)
            {           
            Console.WriteLine("===============================");
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome},");
            Console.WriteLine($"nato il {contribuente.DataNascita.ToString("d")} {contribuente.Sesso}");
            Console.WriteLine($"residente in {contribuente.ComuneResidenza}");
            Console.WriteLine($"codice fiscale: {contribuente.CodiceFiscale.ToUpper()}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"Reddito dichiarato: {contribuente.RedditoAnnuale} €");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"IMPOSTA DA VERSARE: € {contribuente.GetImposta(contribuente.RedditoAnnuale)}");
            Console.WriteLine("===============================");
            }
            Console.ReadLine();
            Menu();
        }
    }
}
