using System;
using System.Collections.Generic;
using System.IO;
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
            if (!File.Exists("SaveFile.csv"))
            {
                File.Create("SaveFile.csv").Close();
                StreamWriter saveFileW = new StreamWriter("SaveFile.csv",false);
                saveFileW.WriteLine("SerbatoioC; SerbatoioM; SerbatoioY; SerbatoioK; Fogli Rimanenti; Fogli da inserire; pagC; pagM; pagY; pagB");
                saveFileW.Flush();
                saveFileW.Write("100; 100; 100; 100; 200; 0; 0; 0; 0; 0");
                saveFileW.Flush();
                saveFileW.Close();
            }
            StreamReader saveFileR = new StreamReader("SaveFile.csv");
            int i;
            string storage="";
            for(i = 0; saveFileR.EndOfStream==false; i++)
            {
                if (i == 1)
                {
                    storage = saveFileR.ReadLine();
                }
                else
                {
                    saveFileR.ReadLine();
                }
            }
            saveFileR.Close();
            if (i != 2)
            {
                throw new Exception("File .csv errato");
            }
            else
            {
                string[] vet = storage.Split(";"); 
                if(vet.Length == 10) 
                {
                    int srbC, srbM, srbY, srbK, fogliNumInt, fogliAddInt, ciano, magenta, giallo, nero;
                    int.TryParse(vet[0], out srbC);
                    int.TryParse(vet[1], out srbM);
                    int.TryParse(vet[2], out srbY);
                    int.TryParse(vet[3], out srbK);
                    int.TryParse(vet[4], out fogliNumInt);
                    int.TryParse(vet[5], out fogliAddInt);
                    int.TryParse(vet[6], out ciano);
                    int.TryParse(vet[7], out magenta);
                    int.TryParse(vet[8], out giallo);
                    int.TryParse(vet[9], out nero);
                    stampante.Cyan = srbC;
                    stampante.Magenta = srbM;
                    stampante.Yellow = srbY;
                    stampante.Black = srbK;
                    fogliNum.Text = fogliNumInt.ToString();
                    fogliAdd.Text = fogliAddInt.ToString();
                    prsC.Text = ciano.ToString();
                    prsM.Text = magenta.ToString();
                    prsY.Text = giallo.ToString();
                    prsK.Text = nero.ToString();
                }
                else {throw new Exception("File .csv errato");}
                fogliNum.Text = stampante.Carta.ToString();
                srbC.Text = stampante.Cyan.ToString();
                srbM.Text = stampante.Magenta.ToString();
                srbY.Text = stampante.Yellow.ToString();
                srbK.Text = stampante.Black.ToString();
            }

        }


        public void Riscrittura()
        {
            StreamReader saveFileR = new StreamReader("SaveFile.csv");
            saveFileR.ReadLine();
            saveFileR.Close();
            System.IO.File.WriteAllText("SaveFile.csv", string.Empty);
            StreamWriter saveFileW = new StreamWriter("SaveFile.csv");
            saveFileW.WriteLine("SerbatoioC; SerbatoioM; SerbatoioY; SerbatoioK; Fogli Rimanenti; Fogli da inserire; pagC; pagM; pagY; pagB");
            saveFileW.Flush();
            saveFileW.WriteLine($"{srbC.Text}; {srbM.Text}; {srbY.Text}; {srbK.Text}; {fogliNum.Text}; {fogliAdd.Text}; {prsC.Text}; {prsM.Text}; {prsY.Text}; {prsK.Text}");
            saveFileW.Flush();
            saveFileW.Close();
        }


        //generazione pagina randomica 
        //random all
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            Pagina rndPagina = new Pagina();
            prsC.Text = rndPagina.Cyan.ToString();
            prsM.Text = rndPagina.Magenta.ToString();
            prsY.Text = rndPagina.Yellow.ToString();
            prsK.Text = rndPagina.Black.ToString();
            Riscrittura();

        }

        //random cyan
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random cyan = new Random();
            prsC.Text = cyan.Next(1,4).ToString();
            Riscrittura();
        }

        //random magenta
        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            Random cyan = new Random();
            prsM.Text = cyan.Next(1, 4).ToString();
            Riscrittura();
        }
        //random yellow
        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            Random cyan = new Random();
            prsY.Text = cyan.Next(1, 4).ToString();
            Riscrittura();
        }
        //random black
        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            Random cyan = new Random();
            prsK.Text = cyan.Next(1, 4).ToString();
            Riscrittura();
        }





        //generazione pagina personalizzata

        //aggiungi Cyan
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsC.Text)<3) { 
                prsC.Text= (Convert.ToInt16(prsC.Text)+1).ToString();
                Riscrittura();
            }
        }

        //rimuovi Cyan
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsC.Text) > 0)
            {
                prsC.Text = (Convert.ToInt16(prsC.Text) - 1).ToString();
                Riscrittura();
            }
        }


        //aggiungi Magenta
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsM.Text) < 3)
            {
                prsM.Text = (Convert.ToInt16(prsM.Text) + 1).ToString();
                Riscrittura();
            }
        }

        //rimuovi Magenta
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsM.Text) > 0)
            {
                prsM.Text = (Convert.ToInt16(prsM.Text) - 1).ToString();
                Riscrittura();
            }
        }

        //aggiungi Yellow
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsY.Text) < 3)
            {
                prsY.Text = (Convert.ToInt16(prsY.Text) + 1).ToString();
                Riscrittura();
            }
        }

        //rimuovi Yellow
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsY.Text) > 0)
            {
                prsY.Text = (Convert.ToInt16(prsY.Text) - 1).ToString();
                Riscrittura();
            }
        }

        //aggiungi Black
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsK.Text) < 3)
            {
                prsK.Text = (Convert.ToInt16(prsK.Text) + 1).ToString();
                Riscrittura();
            }
        }

        //rimuovi Black
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(prsK.Text) > 0)
            {
                prsK.Text = (Convert.ToInt16(prsK.Text) - 1).ToString();
                Riscrittura();
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
            int fogliDaAggiungere = 0;
            int.TryParse(fogliAdd.Text, out fogliDaAggiungere);
            stampante.AggiungiCarta(fogliDaAggiungere);
            int fogliPreRiempimento = Convert.ToInt16(fogliNum.Text);
            fogliNum.Text = stampante.Carta.ToString();
            if (Convert.ToInt16(fogliNum.Text) == 200)
            {
                fogliAdd.Text = (fogliPreRiempimento + fogliDaAggiungere -200).ToString();
            }else
            { fogliAdd.Text = "0"; }
            Riscrittura();
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
            Riscrittura();
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
            Riscrittura();
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
            Riscrittura();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            if (srbK.Text == "100")
            {
                MessageBox.Show("Il serbatoio è pieno");
                return;
            }
            stampante.SostituisciColore(Colore.Black);
            srbK.Text = stampante.Black.ToString();
            Riscrittura();
        }

        //stampa pagina
        private void Button_Click_15(object sender, RoutedEventArgs e)
        {

            if (
                prsC.Text != "0" ||
                prsM.Text != "0" ||
                prsY.Text != "0" ||
                prsK.Text != "0"
                )
            {
                Pagina prsPag = new Pagina(
                Convert.ToInt32(prsC.Text),
                Convert.ToInt32(prsM.Text),
                Convert.ToInt32(prsY.Text),
                Convert.ToInt32(prsK.Text)
                );
                if (stampante.Stampa(prsPag)) { 
                    srbC.Text = stampante.Cyan.ToString();
                    srbM.Text = stampante.Magenta.ToString();
                    srbY.Text = stampante.Yellow.ToString();
                    srbK.Text = stampante.Black.ToString();
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
            string testo = $"{srbC.Text}; {srbM.Text}; {srbY.Text}; {srbK.Text}; {fogliNum.Text}; {fogliAdd.Text}; {prsC.Text}; {prsM.Text}; {prsY.Text}; {prsK.Text};";
            Riscrittura();
        }
    }
}
