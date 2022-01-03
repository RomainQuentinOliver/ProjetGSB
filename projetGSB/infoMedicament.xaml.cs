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
    /// Logique d'interaction pour infoMedicament.xaml
    /// </summary>
    public partial class infoMedicament : Window
    {
        public infoMedicament(GstBDD gst)
        {
            InitializeComponent();
        }
        GstBDD gst; 

        private void Window_Loaded_InfoMed(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            lst_Medicament.ItemsSource = gst.GetAllMedicaments();
        }

        private void lst_Medicament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lst_Medicament.SelectedItem != null)
            {
                txt_nomCommercial.Text = (lst_Medicament.SelectedItem as Medicament).NomCommercialMed;
                int depotLegal = (lst_Medicament.SelectedItem as Medicament).DepotLegalMed;
                txt_famille.Text = gst.GetNomFamilleByIdMed(depotLegal); 
                txt_composition.Text = (lst_Medicament.SelectedItem as Medicament).CompositionMed;
                txt_effets.Text = (lst_Medicament.SelectedItem as Medicament).EffetsMed;
                txt_contreIndic.Text = (lst_Medicament.SelectedItem as Medicament).ContreIndicMed;
                txt_prix.Text = (lst_Medicament.SelectedItem as Medicament).PrixEchantillonMed.ToString();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
