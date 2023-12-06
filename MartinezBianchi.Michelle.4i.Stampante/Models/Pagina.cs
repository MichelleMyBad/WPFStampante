using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



//-4 attributi CMYB che, se usata per stampare, consuma i serbatoi della stampante. V
//- un costruttore che accetta colori specifici al massimo di valore 3 V
//- un costruttore che crea una Pagina con colori random V


namespace MartinezBianchi.Michelle._4i.Stampante
{
    internal class Pagina
    {
        //-4 attributi CMYB che, se usata per stampare, consuma i serbatoi della stampante.
        public int Cyan { get; set; }
        public int Magenta { get; set; }
        public int Yellow { get; set; }
        public int Black { get; set; }


        //- un costruttore che accetta colori specifici al massimo di valore 3
        public Pagina(int cyan, int magenta, int yellow, int black)
        {
            if (
                cyan >= 0 && cyan < 4 && 
                magenta >= 0 && magenta < 4 && 
                yellow >= 0 && yellow < 4 && 
                black >= 0 && black < 4
                )
            { 
                this.Cyan = cyan;
                this.Magenta = magenta;
                this.Yellow = yellow;
                this.Black = black;
            }
        }

        //- un costruttore che crea una Pagina con colori random
        public Pagina() 
        { 
            Random c = new Random();
            this.Cyan = c.Next(1, 4);
            this.Magenta = c.Next(1, 4);
            this.Yellow = c.Next(1, 4);
            this.Black = c.Next(1, 4);
        } 
    }
}
