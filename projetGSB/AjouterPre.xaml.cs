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
    /// Logique d'interaction pour AjouterPre.xaml
    /// </summary>
    /// 

    // Oliver
    public partial class AjouterPre : Window
    {
        public AjouterPre(GstBDD gst)
        {
            InitializeComponent();
        }
        GstBDD gst; 

        private void Window_Loaded_New_Prescription(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            cboMed.ItemsSource = gst.GetAllMedicaments();
            cboTin.ItemsSource = gst.GetAllTypesIndividu();
            cboDosage.ItemsSource = gst.GetAllDosage(); 
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (cboMed.SelectedItem != null)
            {
                if (cboTin.SelectedItem != null)
                {
                    if (cboDosage.SelectedItem != null)
                    {
                        if (txtPosologie.Text != "")
                        {
                            
                            int medicament = (cboMed.SelectedItem as Medicament).DepotLegalMed;
                            int typeIndividu = (cboTin.SelectedItem as TypeIndividu).CodeTypeInd;
                            int Codedose = (cboDosage.SelectedItem as Dosage).CodeDose; 
                            string posologie = txtPosologie.Text;

                            gst.AjoutPre(medicament, typeIndividu, Codedose, posologie);
                            this.Close();
                            MessageBox.Show("La prescription a bien été créé.");
                          
                        }
                        else
                        {
                            MessageBox.Show("Veuillez saisir une posologie.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez sélectionner un dosage.", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un type d'individu.", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un médicament.", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
