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
    /// Logique d'interaction pour modifierVisiteur.xaml
    /// </summary>
    public partial class modifierVisiteur : Window
    {
        public modifierVisiteur(GstBDD gst)
        {
            InitializeComponent();
        }
        GstBDD gst;

        private void Window_Loaded_Modifier_Visiteur(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            lstVisiteur.ItemsSource = gst.GetAllVisiteur();
            cboSecteur.ItemsSource = gst.GetAllSecteur();
            cboLabo.ItemsSource = gst.GetAllLabo(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            if(lstVisiteur.SelectedItem != null)
            {
                if(nomVis.Text != "")
                {
                    if(prenomVis.Text != "")
                    {
                        if (adresseVis.Text != "")
                        {
                            if (codePostalVis.Text != "")
                            {       
                                if(villeVis.Text != "")
                                {
                                    int matricule = (lstVisiteur.SelectedItem as Visiteur).Matricule;
                                    string nom = nomVis.Text;
                                    string prenom = prenomVis.Text;
                                    string adresse = adresseVis.Text;
                                    int codePostal = Convert.ToInt32(codePostalVis.Text);
                                    string ville = villeVis.Text;

                                    if (dateEmbaucheVis2.SelectedDate != null)
                                    {
                                        string dateEmbauche = dateEmbaucheVis2.SelectedDate.ToString(); 

                                        if(cboSecteur.SelectedItem != null)
                                        {
                                            int codeSec = (cboSecteur.SelectedItem as Secteur).CodeSecteur; 

                                            if(cboLabo.SelectedItem != null)
                                            {
                                                int codeLab = (cboLabo.SelectedItem as Labo).CodeLab;
                                                gst.ModifierVisiteur(matricule,nom,prenom,adresse,codePostal,ville,dateEmbauche,codeSec,codeLab);
                                                this.Close(); 
                                                MessageBox.Show("Les informations du visiteur ont bien été misent à jour !");

                                            }
                                            else /* date embauche et secteur modifié mais pas labo*/
                                            {
                                                int codeLab = gst.GetLaboByNom(txtlabo.Text).CodeLab;
                                                gst.ModifierVisiteur(matricule, nom, prenom, adresse, codePostal, ville, dateEmbauche, codeSec, codeLab);
                                                this.Close();
                                                MessageBox.Show("Les informations du visiteur ont bien été mises à jour !");
                                            }
                                        }
                                        else /* date embauche modifié mais pas le code secteur*/
                                        {
                                            int codeSec = gst.GetSecteurByNom(txtsecteur.Text).CodeSecteur; // code secteur inital

                                            if (cboLabo.SelectedItem != null)
                                            {
                                                int codeLab = (cboLabo.SelectedItem as Labo).CodeLab;
                                                gst.ModifierVisiteur(matricule, nom, prenom, adresse, codePostal, ville, dateEmbauche, codeSec, codeLab);
                                                this.Close();
                                                MessageBox.Show("Les informations du visiteur ont bien été misent à jour !");

                                            }
                                            else /* date embauche modifié  mais pas secteur et labo*/
                                            {
                                                int codeLab = gst.GetLaboByNom(txtlabo.Text).CodeLab; // code labo inital 
                                                gst.ModifierVisiteur(matricule, nom, prenom, adresse, codePostal, ville, dateEmbauche, codeSec, codeLab);
                                                this.Close();
                                                MessageBox.Show("Les informations du visiteur ont bien été mises à jour !");
                                            }

                                        }
                                    }
                                    else  /* Date embauche non modifié */
                                    {
                                        string dateEmbauche = dateEmbaucheVis.Text;

                                        if (cboSecteur.SelectedItem != null)
                                        {
                                            int codeSec = (cboSecteur.SelectedItem as Secteur).CodeSecteur;

                                            if (cboLabo.SelectedItem != null)
                                            {
                                                int codeLab = (cboLabo.SelectedItem as Labo).CodeLab;
                                                gst.ModifierVisiteur(matricule, nom, prenom, adresse, codePostal, ville, dateEmbauche, codeSec, codeLab);
                                                this.Close();
                                                MessageBox.Show("Les informations du visiteur ont bien été misent à jour !");

                                            }
                                            else /* date embauche et secteur modifié mais pas labo*/
                                            {
                                                int codeLab = gst.GetLaboByNom(txtlabo.Text).CodeLab;
                                                gst.ModifierVisiteur(matricule, nom, prenom, adresse, codePostal, ville, dateEmbauche, codeSec, codeLab);
                                                this.Close();
                                                MessageBox.Show("Les informations du visiteur ont bien été mises à jour !");
                                            }
                                        }
                                        else /* date embauche modifié mais pas le code secteur*/
                                        {
                                            int codeSec = gst.GetSecteurByNom(txtsecteur.Text).CodeSecteur; // code secteur inital

                                            if (cboLabo.SelectedItem != null)
                                            {
                                                int codeLab = (cboLabo.SelectedItem as Labo).CodeLab;
                                                gst.ModifierVisiteur(matricule, nom, prenom, adresse, codePostal, ville, dateEmbauche, codeSec, codeLab);
                                                this.Close();
                                                MessageBox.Show("Les informations du visiteur ont bien été misent à jour !");

                                            }
                                            else /* date embauche modifié  mais pas secteur et labo*/
                                            {
                                                int codeLab = gst.GetLaboByNom(txtlabo.Text).CodeLab; // code labo inital 
                                                gst.ModifierVisiteur(matricule, nom, prenom, adresse, codePostal, ville, dateEmbauche, codeSec, codeLab);
                                                this.Close();
                                                MessageBox.Show("Les informations du visiteur ont bien été mises à jour !");
                                            }

                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un utilisateur"); 
            }
        }

        private void lstVisiteur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstVisiteur.SelectedItem != null)
            {
                nomVis.Text = (lstVisiteur.SelectedItem as Visiteur).NomVis;
                prenomVis.Text = (lstVisiteur.SelectedItem as Visiteur).PrenomVis;
                adresseVis.Text = (lstVisiteur.SelectedItem as Visiteur).AdresseVis;
                codePostalVis.Text = (lstVisiteur.SelectedItem as Visiteur).CodePostal.ToString();
                villeVis.Text = (lstVisiteur.SelectedItem as Visiteur).Ville;
                dateEmbaucheVis.Text = (lstVisiteur.SelectedItem as Visiteur).DateEmbaucheVis;
                txtlabo.Text = ((lstVisiteur.SelectedItem as Visiteur).CodeLaboVis as Labo).NomLab; 
                txtsecteur.Text = ((lstVisiteur.SelectedItem as Visiteur).CodeSecteurVis as Secteur).LibelleSecteur;

            }
        }
    }
    
}
