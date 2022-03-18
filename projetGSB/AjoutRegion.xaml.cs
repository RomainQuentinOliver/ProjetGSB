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
using Bibliothèque;

namespace projetGSB
{
    /// <summary>
    /// Logique d'interaction pour AjoutRegion.xaml
    /// </summary>
    public partial class AjoutRegion : Window
    {
        public AjoutRegion(GstBDD gst)
        {
            InitializeComponent();
        }
        GstBDD gst;
        private void Window_Loaded_Ajout_Region(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            lst_secteur.ItemsSource = gst.GetAllSecteur();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if(lst_secteur.SelectedItem != null)
            {
                if(nomRegion.Text != "")
                {
                    int SecCode = (lst_secteur.SelectedItem as Secteur).CodeSecteur;
                    string nomReg = nomRegion.Text;  
                    gst.AjoutRegion(SecCode,nomReg);
                    this.Close(); 
                    MessageBox.Show("Région ajouté", "Nouvelle région", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Veuillez saisir un nom de region", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un secteur", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
