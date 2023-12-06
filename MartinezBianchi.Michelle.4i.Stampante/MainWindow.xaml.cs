using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MartinezBianchi.Michelle._4i.Stampante
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stampante stampante = new Stampante();

        public MainWindow()
        {
            InitializeComponent();
            fogliNum.Text = stampante.Carta.ToString();
            srbC.Text = stampante.Cyan.ToString();
            srbM.Text = stampante.Magenta.ToString();
            srbY.Text = stampante.Yellow.ToString();
            srbB.Text = stampante.Black.ToString();
        }


        //generazione pagina randomica 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pagina rndPagina = new Pagina();
            rndmC.Text = rndPagina.Cyan.ToString();
            rndmM.Text = rndPagina.Magenta.ToString();
            rndmY.Text = rndPagina.Yellow.ToString();
            rndmB.Text = rndPagina.Black.ToString();
        }


        //generazione pagina personalizzata

        //aggiungi Cyan
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsC.Text)<3) { 
                prsC.Text= (Convert.ToInt16(prsC.Text)+1).ToString();
            }
        }

        //rimuovi Cyan
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsC.Text) > 0)
            {
                prsC.Text = (Convert.ToInt16(prsC.Text) - 1).ToString();
            }
        }


        //aggiungi Magenta
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsM.Text) < 3)
            {
                prsM.Text = (Convert.ToInt16(prsM.Text) + 1).ToString();
            }
        }

        //rimuovi Magenta
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsM.Text) > 0)
            {
                prsM.Text = (Convert.ToInt16(prsM.Text) - 1).ToString();
            }
        }

        //aggiungi Yellow
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsY.Text) < 3)
            {
                prsY.Text = (Convert.ToInt16(prsY.Text) + 1).ToString();
            }
        }

        //rimuovi Yellow
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsY.Text) > 0)
            {
                prsY.Text = (Convert.ToInt16(prsY.Text) - 1).ToString();
            }
        }

        //aggiungi Black
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsB.Text) < 3)
            {
                prsB.Text = (Convert.ToInt16(prsB.Text) + 1).ToString();
            }
        }

        //rimuovi Black
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsB.Text) > 0)
            {
                prsB.Text = (Convert.ToInt16(prsB.Text) - 1).ToString();
            }
        }

        //Aggiunta fogli
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (fogliAdd.Text == "0")
            {
                MessageBox.Show("Impossibile aggiungere 0 fogli");
            }
            else if (fogliNum.Text == "200")
            {
                MessageBox.Show("È già stato raggiunto il numero massimo di fogli");
            }
            stampante.AggiungiCarta(Convert.ToInt32(fogliAdd.Text));
            int fogliPreRiempimento = Convert.ToInt16(fogliNum.Text);
            fogliNum.Text = stampante.Carta.ToString();
            if (Convert.ToInt16(fogliNum.Text) == 200)
            {
                fogliAdd.Text = (fogliPreRiempimento + (Convert.ToInt16(fogliAdd.Text)) -200).ToString();
            }else
            { fogliAdd.Text = "0"; }
        }


        //ricarica Cyan
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if(srbC.Text == "100") {
                MessageBox.Show("Il serbatoio è pieno");
                return;
            }
            stampante.SostituisciColore(Colore.Cyan);
            srbC.Text = stampante.Cyan.ToString();
        }


        //ricarica Magenta
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (srbM.Text == "100")
            {
                MessageBox.Show("Il serbatoio è pieno");
                return;
            }
            stampante.SostituisciColore(Colore.Magenta);
            srbM.Text = stampante.Magenta.ToString();
        }

        //ricarica Yellow
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            if (srbY.Text == "100")
            {
                MessageBox.Show("Il serbatoio è pieno");
                return;
            }
            stampante.SostituisciColore(Colore.Yellow);
            srbY.Text = stampante.Yellow.ToString();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            if (srbB.Text == "100")
            {
                MessageBox.Show("Il serbatoio è pieno");
                return;
            }
            stampante.SostituisciColore(Colore.Black);
            srbB.Text = stampante.Black.ToString();
        }


        //stampa pagina randomica
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            if (
                rndmC.Text != "0" ||
                rndmM.Text != "0" ||
                rndmY.Text != "0" ||
                rndmB.Text != "0"
                )
            {
                Pagina rndPag = new Pagina(
                Convert.ToInt32(rndmC.Text),
                Convert.ToInt32(rndmM.Text),
                Convert.ToInt32(rndmY.Text),
                Convert.ToInt32(rndmB.Text)
                );
                if (stampante.Stampa(rndPag))
                {
                    srbC.Text = stampante.Cyan.ToString();
                    srbM.Text = stampante.Magenta.ToString();
                    srbY.Text = stampante.Yellow.ToString();
                    srbB.Text = stampante.Black.ToString();
                    fogliNum.Text = stampante.Carta.ToString();
                }
                else
                {
                    MessageBox.Show("Errore : carta o inchiostro insufficienti, controllare i rispettivi serbatoi");
                }
            }
            else
            {
                MessageBox.Show("Errore : impossibile stampare una pagina vuota");
            }
        }

        //stampa pagina personalizzata
        private void Button_Click_15(object sender, RoutedEventArgs e)
        {

            if (
                prsC.Text != "0" ||
                prsM.Text != "0" ||
                prsY.Text != "0" ||
                prsB.Text != "0"
                )
            {
                Pagina prsPag = new Pagina(
                Convert.ToInt32(prsC.Text),
                Convert.ToInt32(prsM.Text),
                Convert.ToInt32(prsY.Text),
                Convert.ToInt32(prsB.Text)
                );
                if (stampante.Stampa(prsPag)) { 
                    srbC.Text = stampante.Cyan.ToString();
                    srbM.Text = stampante.Magenta.ToString();
                    srbY.Text = stampante.Yellow.ToString();
                    srbB.Text = stampante.Black.ToString();
                    fogliNum.Text = stampante.Carta.ToString();
                }
                else
                {
                    MessageBox.Show("Errore : carta o inchiostro insufficienti, controllare i rispettivi serbatoi");
                }
            }
            else
            {
                MessageBox.Show("Errore : impossibile stampare una pagina vuota");
            }
        }
    }
}
