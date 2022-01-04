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
using Bibliothèque; 
using GstBdd;

namespace projetGSB
{
    /// <summary>
    /// Logique d'interaction pour ModifierTin.xaml
    /// </summary>
    public partial class ModifierTin : Window
    {
        public ModifierTin(GstBDD gst)
        {
            InitializeComponent();
        }
        GstBDD gst; 
        private void Window_Loaded_Modifier_Tin(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            lstTin.ItemsSource = gst.GetAllTypesIndividu();

        }

        private void lstTin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstTin.SelectedItem != null)
            {
                string LibelleTin = (lstTin.SelectedItem as TypeIndividu).LibelleTypeInd;
                txtLibelle.Text = LibelleTin;
            }
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (lstTin.SelectedItem != null)
            {
                string LibelleTin = (lstTin.SelectedItem as TypeIndividu).LibelleTypeInd;

                if (txtLibelle.Text != LibelleTin)
                {

                
                    if (txtLibelle.Text != "")
                    {

                        int codeTin = (lstTin.SelectedItem as TypeIndividu).CodeTypeInd;
                        string libelle = txtLibelle.Text;
                        gst.UpdateTypeIndividu(libelle, codeTin);
                        this.Close();
                        MessageBox.Show("Le type d'individu à bien été mis à jour !");

                    }
                    else
                    {
                        MessageBox.Show("Veuillez saisir un type d'individu.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Le type d'individu n'a pas été modifié.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Veuillez choisir un type d'individu.", "Erreur de choix", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
