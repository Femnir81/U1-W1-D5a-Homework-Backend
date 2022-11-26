using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_W1_D5a_Homework_Backend
{
    internal class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public string Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public double RedditoAnnuale { get; set; }
        public Contribuente() { }
        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, string sesso, string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        public double GetImposta(double RedditoAnnuale)
        {
            if (RedditoAnnuale >= 0.00 && RedditoAnnuale <= 15000.00)
            {
                return RedditoAnnuale * 0.23;
            }
            else if (RedditoAnnuale >= 15001.00 && RedditoAnnuale <= 28000.00)
            {
                return 3450.00 + ((RedditoAnnuale - 15000.00) * 0.27);
            }
            else if (RedditoAnnuale >= 28001.00 && RedditoAnnuale <= 55000.00)
            {
                return 6960.00 + ((RedditoAnnuale - 28000.00) * 0.38);
            }
            else if (RedditoAnnuale >= 55001.00 && RedditoAnnuale <= 75000.00)
            {
                return 17220.00 + ((RedditoAnnuale - 55000.00) * 0.41);
            }
            else if (RedditoAnnuale >= 75001.00)
            {
                return 25420.00 + ((RedditoAnnuale - 75000.00) * 0.43);
            }
            else
            {
                return 0.00;
            }
        }


        
    }
}

