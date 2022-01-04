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
    /// Logique d'interaction pour ModifierMed.xaml
    /// </summary>
    public partial class ModifierMed : Window
    {
        public ModifierMed(GstBDD gst)
        {
            InitializeComponent();
        }
        GstBDD gst;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            lstMedicamentModif.ItemsSource = gst.GetAllMedicaments();
            cboFamille.ItemsSource = gst.GetAllFamilles();
        }

        private void lstMedicamentModif_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gst = new GstBDD();
            cboFamille.ItemsSource = gst.GetAllFamilles();
            txtnomMed.Text = (lstMedicamentModif.SelectedItem as Medicament).NomCommercialMed;
            txtprixMed.Text = (lstMedicamentModif.SelectedItem as Medicament).PrixEchantillonMed.ToString();
            txtcomposition.Text = (lstMedicamentModif.SelectedItem as Medicament).CompositionMed;
            txteffet.Text = (lstMedicamentModif.SelectedItem as Medicament).EffetsMed;
            txtcontreindic.Text = (lstMedicamentModif.SelectedItem as Medicament).ContreIndicMed;

        }

        private void QuitterModif_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show((cboFamille.SelectedItem as Famille).LibelleFamille);

            this.Close();
        }

        private void EnregistrerModif_Click(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();

            if (cboFamille.SelectedItem != null)
            {
                if (txtnomMed.Text != "")
                {
                    if (txtprixMed.Text != "")
                    {
                        if (txtcomposition.Text != "")
                        {
                            if (txteffet.Text != "")
                            {
                                if (txtcontreindic.Text != "")
                                {
                                    int id = (lstMedicamentModif.SelectedItem as Medicament).DepotLegalMed;
                                    string nom = txtnomMed.Text;

                                    int famille = gst.GetIdFamille((cboFamille.SelectedItem as Famille).LibelleFamille);

                                    string composition = txtcomposition.Text;
                                    string effets = txteffet.Text;
                                    string contreindic = txtcontreindic.Text;
                                    double prix = (lstMedicamentModif.SelectedItem as Medicament).PrixEchantillonMed;

                                    gst.ModifierMedicament(id, nom, famille, composition, effets, contreindic, prix);
                                    this.Close();
                                    MessageBox.Show("Les informations du médicament ont bien été misent à jour !");
                                }
                                else
                                {
                                    MessageBox.Show("Veuillez saisir une contreindication", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Veuillez saisir un effet", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Veuillez saisir une composition", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez saisir un prix", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez saisir un nom", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir une famille", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
