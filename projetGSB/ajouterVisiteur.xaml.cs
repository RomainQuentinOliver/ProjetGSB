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
    /// Logique d'interaction pour ajouterVisiteur.xaml
    /// </summary>
    public partial class ajouterVisiteur : Window
    {
        public ajouterVisiteur(GstBDD gst)
        {
            InitializeComponent();
        }
        GstBDD gst;

        private void Window_Loaded_Ajout_Vis(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            cboSecteur.ItemsSource = gst.GetAllSecteur();
            cboLabo.ItemsSource = gst.GetAllLabo();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (nomVis.Text != "")
            {
                if (prenomVis.Text != "")
                {
                    if (adresseVis.Text != "")
                    {
                        if (codePostalVis.Text != "")
                        {
                            if (villeVis.Text != "")
                            {
                                if (dateEmbaucheVis2.SelectedDate != null)
                                {
                                    if (cboSecteur.SelectedItem != null)
                                    {
                                        if (cboLabo.SelectedItem != null)
                                        {
                                            string nom = nomVis.Text;
                                            string prenom = prenomVis.Text;
                                            string adresse = adresseVis.Text;
                                            string ville = villeVis.Text; 
                                            int codePostal = Convert.ToInt32(codePostalVis.Text);
                                            string dateEmbauche = dateEmbaucheVis2.SelectedDate.ToString();
                                            int codeSecteur = (cboSecteur.SelectedItem as Secteur).CodeSecteur; 
                                            int codeLabo = (cboLabo.SelectedItem as Labo).CodeLab;

                                            gst.AjoutVis(nom, prenom, adresse, codePostal, ville, dateEmbauche, codeSecteur, codeLabo);
                                            this.Close();
                                            MessageBox.Show("Le visiteur a bien été ajouté.");
                                            
                                        }
                                        else
                                        {
                                            MessageBox.Show("Veuillez choisir un laboratoire.", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Veuillez choisir un secteur.", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Veuillez entrer une date d'embauche.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Veuillez entrer une ville.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Veuillez entrer un code postal.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez entrer une adresse.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer un prénom.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
