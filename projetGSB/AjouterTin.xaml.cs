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
using System.Windows.Shapes;
using GstBdd;

namespace projetGSB
{
    /// <summary>
    /// Logique d'interaction pour AjouterTin.xaml
    /// </summary>
    public partial class AjouterTin : Window
    {
        public AjouterTin(GstBDD unGst)
        {
            InitializeComponent();
        }
        GstBDD gst;

        private void Button_Click(object sender,  RoutedEventArgs e)
        {
            string a = libelleTin.Text;
            int b = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += 1;
            }

            if (libelleTin.Text == "")
            {
                MessageBox.Show("Veuillez rentrer un nouveau type d'individu ", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (b != 0)
            {
                MessageBox.Show("Veillez ne pas rentrer de chiffres", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                gst = new GstBDD();
                gst.AjouterTypeIndividu(libelleTin.Text);
                this.Close();
                MessageBox.Show("Individu ajouté", "Nouveau type d'individu", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
