//Mattia Cincotta 3H 2024-02-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppCalcolatriceBitWise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        #region variabili
        static int num1;//num per la prima tabella
        static int num2;//num per la seconda tabella
        #endregion


        #region conversioni

        #region conversione a int
        static int ConversioneToInt(string stringa)
        {
            char[] caratteri = stringa.ToCharArray();
            Array.Reverse(caratteri);
            int result = 0;
            for (int i = 0; i < caratteri.Length; i++)
            {
                if (caratteri[i] == '1')
                {
                    if (i == 0)
                    {
                        result++;
                    }
                    else
                    {
                        result += (int)Math.Pow(2, i);
                    }
                }
            }

            return result;
        }
        #endregion

        #region conversione a binario
        private string ConversioneToBin(int dec)
        {
            int res;
            string result = "";

            if (dec < 0)
            {
                int b = 1 << 9 - 1;

                dec = (dec & b);
            }
            while (dec > 0)
            {
                res = dec % 2;
                if (res == 0)
                    result = "0" + result;
                else
                    result = "1" + result;
                dec /= 2;
            }


            return result;
        }
        #endregion

        #endregion

        #region reset result
        private void btnReset_Result_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Content = string.Empty;
        }
        #endregion


        #region tabella 1

        #region controllo input
        private void txtNumBit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNumBit.Text == "")
            {
                btnShiftLeft.IsEnabled = false;
                btnShiftRight.IsEnabled = false;
            }
            else if (!int.TryParse(txtNumBit.Text, out num1) || num1 > 8)
            {
                MessageBox.Show($"Il valore inserito non è corretto", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                btnShiftLeft.IsEnabled = false;
                btnShiftRight.IsEnabled = false;            }
            else
            {
                btnShiftLeft.IsEnabled = true;
                btnShiftRight.IsEnabled = true;
            }
        }
        #endregion

        #region reset_1   
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //faccio tornare tutto vuoto
            txtStringBit.Content = "";
            txtNumBit.Text = "";
            //abilito nuovamente i tasti
            btnZero.IsEnabled = true;
            btnUno.IsEnabled = true;
            btnNot.IsEnabled= true;
        }
        #endregion

        #region bottone zero_1
        private void btnZero_Click(object sender, RoutedEventArgs e)    //aggiunge zero
        {
            if(txtStringBit.Content.ToString().Length < 8) 
            {
                txtStringBit.Content += "0";
            }
            else
            {
                MessageBox.Show($"ha già inserito 8 bit", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                btnZero.IsEnabled = false;
                btnUno.IsEnabled = false;
            }
            
        }
        #endregion

        #region bottone uno_1
        private void btnUno_Click(object sender, RoutedEventArgs e) //aggiunge uno 
        {
            if (txtStringBit.Content.ToString().Length < 8)
            {
                txtStringBit.Content += "1";
            }
            else
            {
                MessageBox.Show($"ha già inserito 8 bit", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                btnUno.IsEnabled = false;
                btnZero.IsEnabled = false;
            }
        }
        #endregion


        #region shiftLeft
        private void btnShiftLeft_Click(object sender, RoutedEventArgs e)//divide per il numero inserito in txtNumBit
        {
            int temp = (ConversioneToInt(txtStringBit.Content.ToString()) << num1);

            if (temp == 0)
            {
                txtStringBit.Content = "0";

            }
            else txtStringBit.Content = ConversioneToBin(temp);

        }
        #endregion

        #region shiftRight
        private void btnShiftRight_Click(object sender, RoutedEventArgs e)//moltipliica per il numero inserito in txtNumBit
        {
            int temp = (ConversioneToInt(txtStringBit.Content.ToString()) >> num1);

            if(temp == 0)
            {
                txtStringBit.Content = "0";

            }else txtStringBit.Content = ConversioneToBin(temp);
        }
        #endregion


        #region NOT
        private void btnNot_Click(object sender, RoutedEventArgs e)
        {

            string input = txtStringBit.Content.ToString();
            int valore = ConversioneToInt(input);
            valore = ~valore;
            int bitmask = (1 << 9) - 1; //1111 1111
            string result = ConversioneToBin(valore & bitmask); //il risultato corrisponde gli ultimi 8 bit del risultato del not e non viene generato un problema derivante dal segno del numero da convertire in 2
            txtStringBit.Content = result.Substring(result.Length - 8, 8);

        }
        #endregion

        #endregion


        #region tabella 2

        #region controllo input
        private void txtNumBit_2_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txtNumBit_2.Text == "")
            {
                btnShiftLeft_2.IsEnabled = false;
                btnShiftRight_2.IsEnabled = false;
            }
            else if (!int.TryParse(txtNumBit_2.Text, out num2) || num2 > 8)
            {
                MessageBox.Show($"Il valore inserito non è corretto", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                btnShiftLeft_2.IsEnabled = false;
                btnShiftRight_2.IsEnabled = false;
            }
            else
            {

                btnShiftLeft_2.IsEnabled = true;
                btnShiftRight_2.IsEnabled = true;

            }
        }
        #endregion

        #region reset_2
        private void btnReset_2_Click(object sender, RoutedEventArgs e)
        {
            txtStringBit_2.Content = "";
            btnZero_2.IsEnabled = true;
            btnUno_2.IsEnabled = true;
            btnShiftLeft_2.IsEnabled = true;
            btnShiftRight_2.IsEnabled = true;
            btnNot_2.IsEnabled = true;
            txtNumBit_2.Text = "";

        }
        #endregion

        #region bottoneZero_2
        private void btnZero_2_Click(object sender, RoutedEventArgs e)
        {
            if (txtStringBit_2.Content.ToString().Length < 8)
            {
                txtStringBit_2.Content += "0";
            }
            else
            {
                MessageBox.Show($"ha già inserito 8 bit", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                btnZero_2.IsEnabled = false;
                btnUno_2.IsEnabled = false;
            }
        }

        #endregion

        #region bottoneUno_2
        private void btnUno_2_Click(object sender, RoutedEventArgs e)
        {
            if (txtStringBit_2.Content.ToString().Length < 8)
            {
                txtStringBit_2.Content += "1";
            }
            else
            {
                MessageBox.Show($"ha già inserito 8 bit", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                btnUno_2.IsEnabled = false;
                btnZero_2.IsEnabled = false;
            }
        }
        #endregion


        #region shiftLeft2
        private void btnShiftLeft_2_Click(object sender, RoutedEventArgs e)
        {
            int temp = (ConversioneToInt(txtStringBit_2.Content.ToString()) << num2);

            if (temp == 0)
            {
                txtStringBit_2.Content = "0";

            }
            else txtStringBit_2.Content = ConversioneToBin(temp);
        }
        #endregion

        #region shiftRight2
        private void btnShiftRight_2_Click(object sender, RoutedEventArgs e)
        {
            int temp = (ConversioneToInt(txtStringBit_2.Content.ToString()) >> num2);

            if (temp == 0)
            {
                txtStringBit.Content = "0";

            }
            else txtStringBit_2.Content = ConversioneToBin(temp);
        }
        #endregion

        #region NOT
        private void btnNot_2_Click(object sender, RoutedEventArgs e)
        {
            string input = txtStringBit_2.Content.ToString();
            int valore = ConversioneToInt(input);
            valore = ~valore;
            int bitmask = (1 << 9) - 1; //1111 1111
            string result = ConversioneToBin(valore & bitmask); //il risultato dell'and sono gli ultimi 8 bit del risultato del not e non viene generato un problema derivante dal segno del numero da convertire in 2
            txtStringBit_2.Content = result.Substring(result.Length - 8, 8);
        }
        #endregion

        #endregion

        #region operatori logici

        #region AND
        private void btnAnd_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Content = "";//viene svuotato ogni volta che viene richiamata

            #region variabili
            string temp1 = txtStringBit.Content.ToString();     //variabile che contiene la stringa dela prima tabella
            string temp2 = txtStringBit_2.Content.ToString();   //variabile che contiene la stringa della seconda tabella
            string result = "";                                 //risultato finale
            #endregion

            #region operazione and
            result = ConversioneToBin((ConversioneToInt(temp1) & ConversioneToInt(temp2)));
            #endregion


            txtResult.Content = result; //output

        }
        #endregion
        

        #region OR
        private void btnOr_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Content = "";//viene svuotato ogni volta che viene richiamata

            #region variabili
            string temp1 = txtStringBit.Content.ToString();     //variabile che contiene la stringa dela prima tabella
            string temp2 = txtStringBit_2.Content.ToString();   //variabile che contiene la stringa della seconda tabella
            string result;                                 //risultato finale
            #endregion

            #region operazione or
            int a = ConversioneToInt(temp1);
            int b = ConversioneToInt(temp2);
            if (a == 0 && b == 0)
            {
                result = "0";
            }
            else result = ConversioneToBin(a | b);
            #endregion


            txtResult.Content = result; //output
        }
        #endregion


        #region XOR
        private void btnXor_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Content = "";//viene svuotato ogni volta che viene richiamata

            #region variabili
            string temp1 = txtStringBit.Content.ToString();     //variabile che contiene la stringa dela prima tabella
            string temp2 = txtStringBit_2.Content.ToString();   //variabile che contiene la stringa della seconda tabella
            string result;                                 //risultato finale
            #endregion

            #region operazione xor
            int a = ConversioneToInt(temp1);
            int b = ConversioneToInt(temp2);

            if(a == b)
            {
                result = "0";
            }
            else result = ConversioneToBin(a ^ b);

            #endregion


            txtResult.Content = result; //output


        }



        #endregion

        #endregion


    }
}
