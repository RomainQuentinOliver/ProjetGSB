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
    /// Logique d'interaction pour AjouterMed.xaml
    /// </summary>
    public partial class AjouterMed : Window
    {
        public AjouterMed(GstBDD gst)
        {
            InitializeComponent();
        }
        GstBDD gst;
        private void Window_Loaded_Ajout_Med(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            cboFamille.ItemsSource = gst.GetAllFamille();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cboFamille.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir une famille.", "Erreur de choix", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (nomMed.Text == "")
                {
                    MessageBox.Show("Veuillez écrire un nom médicament.", "Erreur de choix", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (prixMed.Text == "")
                    {
                        MessageBox.Show("Veuillez écrire un prix médicament.", "Erreur de choix", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (composition.Text == "")
                        {
                            MessageBox.Show("Veuillez écrire une composition.", "Erreur de choix", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            if (effet.Text == "")
                            {
                                MessageBox.Show("Veuillez écrire un effect.", "Erreur de choix", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                if (contreindic.Text == "")
                                {
                                    MessageBox.Show("Veuillez écrire une contre indication.", "Erreur de choix", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                else
                                {
                                    string nom = nomMed.Text;
                                    int famCode = (cboFamille.SelectedItem as Famille).CodeFamille;
                                    //string prixOK = prixMed.Text.Replace(',', '.');
                                    decimal prix = Convert.ToDecimal(prixMed.Text);
                                    string comp = composition.Text;
                                    string effet_med = effet.Text;
                                    string contre = contreindic.Text;

                                    gst.AjoutMed(nom, famCode, prix, comp, effet_med, contre);

                                    MessageBox.Show("Le médicament a bien été créé.");
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
