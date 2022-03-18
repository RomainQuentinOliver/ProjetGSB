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
    /// Logique d'interaction pour modifierReg.xaml
    /// </summary>
    public partial class modifierReg : Window
    {
        public modifierReg(GstBDD gst)
        {
            InitializeComponent();
        }
        GstBDD gst;

        private void Window_Loaded_Modifier_Reg(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            lstRegionModif.ItemsSource = gst.GetAllRegion();
            cboSecteur.ItemsSource = gst.GetAllSecteur(); 

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lstRegionModif_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstRegionModif.SelectedItem != null)
            {
                string nomRegionSelect = (lstRegionModif.SelectedItem as Region).NomReg;
                txt_nomReg.Text = nomRegionSelect;

                txt_SecReg.Text = ((lstRegionModif.SelectedItem as Region).CodeSec as Secteur).LibelleSecteur; 

            }
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {

            if(lstRegionModif.SelectedItem != null)
            {

                if(txt_nomReg.Text != "")
                {
                    string newNomReg = txt_nomReg.Text;
                    int regCode = (lstRegionModif.SelectedItem as Region).CodeReg;
                    int codeSec = ((lstRegionModif.SelectedItem as Region).CodeSec as Secteur).CodeSecteur;

                    if (cboSecteur.SelectedItem != null)
                    {
                        string newNomSec = (cboSecteur.SelectedItem as Secteur).LibelleSecteur;

                        if (newNomSec != txt_SecReg.Text)
                        {
                            int newCodeSec = (cboSecteur.SelectedItem as Secteur).CodeSecteur;
                            
                            gst.ModifierRegion(newCodeSec, newNomReg, regCode);
                            this.Close();
                            MessageBox.Show("Le nom de la région a bien été modifié !");
                        }
                        else
                        {
                            MessageBox.Show("Veuillez selectionner un nouveau secteur", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        if (cboSecteur.SelectedItem == null)
                        {
                            

                            gst.ModifierRegion(codeSec, newNomReg, regCode);
                            this.Close();
                            MessageBox.Show("Le nom de la région a bien été modifié !");
                        }
                        else
                        {
                            MessageBox.Show("Erreur", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez saisir un nom", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une région", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
