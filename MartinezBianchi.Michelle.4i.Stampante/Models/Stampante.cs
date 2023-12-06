using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





//-4 serbatoi di colore: CMYB e un cassetto di fogli (tutte property int) V
//-un metodo bool Stampa( Pagina p ) (che torna false, se l'inchiostro non è sufficiente per stampare) V
//- un metodo int StatoInchiostro( Colore c ) che torna la quantità di inchiostro presente nei 4 serbatoi. V
//- un metodo int StatoCarta() che mi ritorna la quantità di fogli nel cassetto V
//- un metodo void SostituisciColore( Colore c ) che rimpiazza un serbatoio di inchiostro e lo riporta a 100 V
//- un metodo void AggiungiCarta( int qta ) che aggiunge fogli fino ad un max di 200 V



namespace MartinezBianchi.Michelle._4i.Stampante
{
    internal class Stampante
    {

        //-4 serbatoi di colore: CMYB e un cassetto di fogli (tutte property int)

        public int Carta { get; set; }
        public int Cyan { get; set; }
        public int Magenta { get; set; }
        public int Yellow { get; set; }
        public int Black { get; set; }

        public Stampante()
        {
            Cyan = Magenta = Yellow = Black = 100;
            Carta = 200;
        }

        //-un metodo bool Stampa( Pagina p ) (che torna false, se l'inchiostro non è sufficiente per stampare)
        public bool Stampa(Pagina p)
        {
            if (
                (Carta > 0) && 
                (this.Cyan >= p.Cyan) && 
                (this.Magenta >= p.Magenta) && 
                (this.Yellow >= p.Yellow) && 
                (this.Black >= p.Black) 
                ) {
                    this.Cyan -= p.Cyan;
                    this.Magenta -= p.Magenta;
                    this.Yellow -= p.Yellow;
                    this.Black -= p.Black;
                    Carta--;
                    return true;
            }
            return false;
        }


        //- un metodo int StatoInchiostro( Colore c ) che torna la quantità di inchiostro presente nei 4 serbatoi.
        public int StatoInchiostro(Colore c) 
        {
            switch (c)
            {
                case Colore.Cyan:
                    return this.Cyan;

                case Colore.Magenta:
                    return this.Magenta;

                case Colore.Yellow:
                    return this.Yellow;

                case Colore.Black:
                    return this.Black;

                default:
                    return -1;
            }
        }



        //- un metodo int StatoCarta() che mi ritorna la quantità di fogli nel cassetto
        public int StatoCarta()
        {
            return this.Carta;
        }



        //- un metodo void SostituisciColore( Colore c ) che rimpiazza un serbatoio di inchiostro e lo riporta a 100
        public void SostituisciColore(Colore c)
        {
            switch (c)
            {
                case Colore.Cyan:
                    this.Cyan=100;
                    break;

                case Colore.Magenta:
                    this.Magenta=100;
                    break;

                case Colore.Yellow:
                    this.Yellow=100;
                    break;

                case Colore.Black:
                    this.Black=100;
                    break;
            }
        }




        //- un metodo void AggiungiCarta( int qta ) che aggiunge fogli fino ad un max di 200
        public void AggiungiCarta(int qta)
        {
            Carta += qta;
            if (Carta > 200) { Carta = 200; }
        }

    }
}
