using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace El_meu_IMC
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void boto_Click(object sender, RoutedEventArgs e)
        {
            string u = pes.Text;
            u = u.Replace(".", ",");
            string dos = alcada.Text;
            dos = dos.Replace(".", ",");

            double pes2 = -1;
            double alcada2 = -1;
            try
            {
                pes2 = Convert.ToDouble(u);
                alcada2 = Convert.ToDouble(dos);
                
            }catch (FormatException i){
                IMC2.Text="Sisplau, introdueix només números";
            }catch (OverflowException i){
                IMC2.Text="Error. Números massa alts.";
            }
            if (alcada2 == 0 || pes2 == 0)
                IMC2.Text = "Ni alçada ni pes poden ser 0";
            else
            {
                if (alcada2 > 10)
                {
                    alcada2 = alcada2 / 100;
                }

                double IMCN = pes2 / (alcada2 * alcada2);

                int calcul = Convert.ToInt32(IMCN);

                if (IMCN != -1)
                {

                    IMC.Text = "El seu índex de massa corporal és " + calcul;
                    if (IMCN < 16)
                    {
                        IMC2.Text = "Té infra pes sever";
                        IMC2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                    if (IMCN >= 16 && IMCN < 17)
                    {
                        IMC2.Text = "Té un infrapes moderat";
                        IMC2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                    if (IMCN >= 17 && IMCN < 19)
                    {
                        IMC2.Text = "Té un infrapes accpetable";
                        IMC2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                    if (IMCN >= 19 && IMCN < 25)
                    {
                        if (IMCN >= 22 && IMCN < 23)
                            IMC2.Text = "El seu pes és l'ideal";
                        else
                            IMC2.Text = "El seu pes és normal";

                        IMC2.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                    }
                    if (IMCN >= 25 && IMCN < 30)
                    {
                        IMC2.Text = "Té una obesitat tipus I";
                        IMC2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                    if (IMCN >= 35 && IMCN < 40)
                    {
                        IMC2.Text = "Té una obesitat tipus II";
                        IMC2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                    if (IMCN >= 40)
                    {
                        IMC2.Text = "Té una obesitat tipus III";
                        IMC2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                }
                else
                {
                    IMC2.Text = "Error al llegir les dades. Comproveu que heu ficat números i separat els decimals amb coma (,) o punt (.)";
                }
            }


        }
    }
}