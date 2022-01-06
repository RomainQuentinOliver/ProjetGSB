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
    /// Logique d'interaction pour AjoutPertubateur.xaml
    /// </summary>
    public partial class AjoutPertubateur : Window
    {
        public AjoutPertubateur(GstBDD gst)
        {
            InitializeComponent();
        }
        GstBDD gst;

        private void Window_Loaded_Ajout_Med_Perturbateur(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            lst_Medicament.ItemsSource = gst.GetAllMedicaments();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lst_Medicament_Selection(object sender, SelectionChangedEventArgs e)
        {
            if (lst_Medicament.SelectedItem != null)
            {
                lst_perturbateur.ItemsSource = gst.GetAllPertubateur((lst_Medicament.SelectedItem as Medicament).DepotLegalMed);
                lst_non_perturbateur.ItemsSource = gst.GetAllNonPertubateur((lst_Medicament.SelectedItem as Medicament).DepotLegalMed);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (lst_Medicament.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir un médicament.", "Erreur de choix", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (lst_non_perturbateur.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez choisir un nouveaux pertubateur.", "Erreur de choix", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int pertubateur = (lst_non_perturbateur.SelectedItem as Medicament).DepotLegalMed;
                    int pertube = (lst_Medicament.SelectedItem as Medicament).DepotLegalMed;
                    if (pertube == pertubateur)
                    {
                        MessageBox.Show("Veuillez choisir un nouveaux pertubateur.", "Erreur de choix", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        gst.AjoutPertubateur(pertubateur, pertube);
                        MessageBox.Show("Le pertubateur a bien été créé.");
                        
                    }

                }
            }
        }

        private void lst_non_perturbateur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lst_perturbateur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Retirer(object sender, RoutedEventArgs e)
        {
            int pertubateur = (lst_perturbateur.SelectedItem as Medicament).DepotLegalMed;
            int pertube = (lst_Medicament.SelectedItem as Medicament).DepotLegalMed;
            gst.DeletePertubateur(pertubateur, pertube);
            lst_perturbateur.ItemsSource = gst.GetAllPertubateur((lst_Medicament.SelectedItem as Medicament).DepotLegalMed);
            lst_non_perturbateur.ItemsSource = gst.GetAllNonPertubateur((lst_Medicament.SelectedItem as Medicament).DepotLegalMed);
        }
    }
}
