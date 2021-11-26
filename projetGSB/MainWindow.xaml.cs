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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bibliothèque;
using GstBdd;

namespace projetGSB
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        GstBDD gst;

        private void Window_Loaded_accueil(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
        }
        private void btnAjouTin_Click(object sender, RoutedEventArgs e)
        {
            AjouterTin ajtTin = new AjouterTin(gst);
            ajtTin.Show();
        }

        private void btnModifierTin_Click(object sender, RoutedEventArgs e)
        {
            ModifierTin modifTin = new ModifierTin(gst);
            modifTin.Show();
        }

        private void btnAjoutMed_Click(object sender, RoutedEventArgs e)
        {
            AjouterMed ajtMed = new AjouterMed(gst);
            ajtMed.Show();
        }

        private void btnModifierMed_Click(object sender, RoutedEventArgs e)
        {
            ModifierMed modifMed = new ModifierMed(gst);
            modifMed.Show();
        }

        private void btnAjoutPre_Click(object sender, RoutedEventArgs e)
        {
            AjouterPre ajtPre = new AjouterPre(gst);
            ajtPre.Show();
        }

        private void btnAjtPerturbateur_Click(object sender, RoutedEventArgs e)
        {
            AjoutPertubateur  ajtPerturb = new AjoutPertubateur(gst);
            ajtPerturb.Show();
        }
    }
}
