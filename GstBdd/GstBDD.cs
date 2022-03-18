using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliothèque;

namespace GstBdd
{
    public class GstBDD
    {
        private MySqlConnection cnx;
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        public GstBDD()
        {
            string chaine = "Server=127.0.0.1;Database=gsb;Uid=root;Pwd=;SslMode=none";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }

        public List<Medicament> GetAllMedicaments() // Oliver
        {
            List<Medicament> LesMedicaments = new List<Medicament>();
            cmd = new MySqlCommand("SELECT MED_DEPOTLEGAL, MED_NOMCOMMERCIAL, FAM_COD, MED_COMPOSITION, MED_EFFETS, MED_CONTREINDIC, MED_PRIXECHANTILLON,FAM_LIBELLE  FROM medicament INNER JOIN Famille ON FAM_CODE = FAM_COD", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Famille codeF = new Famille(Convert.ToInt16(dr[2].ToString()), dr[7].ToString());
                Medicament uneNouveauMedicament = new Medicament(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), codeF, dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToDouble(dr[6].ToString()));
                LesMedicaments.Add(uneNouveauMedicament);
            }
            dr.Close();
            return LesMedicaments;
        }

        public List<TypeIndividu> GetAllTypesIndividu() // Oliver
        {
            List<TypeIndividu> lesTypesIndividu = new List<TypeIndividu>();
            cmd = new MySqlCommand("SELECT TIN_CODE, TIN_LIBELLE FROM type_individu", cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TypeIndividu unNouveauType = new TypeIndividu(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                lesTypesIndividu.Add(unNouveauType);
            }
            dr.Close();
            return lesTypesIndividu;
        }

        public void AjoutPre(int unDepotLegal, int unCode, int doseCode, string unePosologie) // Oliver
        {
            cmd = new MySqlCommand("INSERT INTO prescrire (MED_DEPOTLEGAL, DOS_CODE, TIN_CODE, PRE_POSOLOGIE) VALUES (" + unDepotLegal + "," + unCode + "," + doseCode + ",'" + unePosologie + "'" + ")", cnx);
            cmd.ExecuteNonQuery();
        }

        public List<Dosage> GetAllDosage() // Oliver
        {
            List<Dosage> lesDoses = new List<Dosage>();
            cmd = new MySqlCommand("SELECT DOS_CODE, DOS_QUANTITE, DOS_UNITE FROM `dosage` ", cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Dosage uneNouvelleDose = new Dosage(Convert.ToInt16(dr[0].ToString()), Convert.ToInt16(dr[1].ToString()), dr[2].ToString());
                lesDoses.Add(uneNouvelleDose);
            }
            dr.Close();
            return lesDoses;
        }

        public void UpdateTypeIndividu(string Libelle, int codeTin) // Oliver
        {
            cmd = new MySqlCommand("UPDATE type_individu SET TIN_LIBELLE = " + "'" + Libelle + "' WHERE TIN_CODE = " + codeTin, cnx);
            cmd.ExecuteNonQuery();
        }

        public void AjouterTypeIndividu(string Libelle) // Oliver
        {
            cmd = new MySqlCommand("INSERT INTO type_individu VALUES (null,'" + Libelle + "')", cnx);
            cmd.ExecuteNonQuery();
        }

        public string GetNomFamilleByIdMed(int id) // Oliver
        {
            cmd = new MySqlCommand("SELECT FAM_LIBELLE FROM famille WHERE FAM_CODE = (SELECT FAM_COD FROM medicament WHERE MED_DEPOTLEGAL = " + id + ")", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            string codeFamille = dr[0].ToString();
            dr.Close(); 

            return codeFamille; 
        }

        public void ModifierMedicament(int id, string nom, int famille, string composition, string effets, string contreindic, double prix) // Romain
        {
            cmd = new MySqlCommand("UPDATE medicament SET MED_NOMCOMMERCIAL = '" + nom + "', FAM_COD =" + famille + ", MED_COMPOSITION = '" + composition.Replace("'", "''") + "', MED_EFFETS = '" + effets.Replace("'", "''") + "', MED_CONTREINDIC = '" + contreindic.Replace("'", "''") + "', MED_PRIXECHANTILLON = " + prix + "  WHERE MED_DEPOTLEGAL = " + id, cnx);
            cmd.ExecuteNonQuery();
        }

        public List<Famille> GetAllFamilles() // Romain
        {
            List<Famille> lesFamilles = new List<Famille>();
            cmd = new MySqlCommand("SELECT FAM_CODE, FAM_LIBELLE FROM famille", cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Famille uneFamille = new Famille(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                lesFamilles.Add(uneFamille);
            }
            dr.Close();
            return lesFamilles;
        }

        public int GetIdFamille(string famille) // Romain
        {
            cmd = new MySqlCommand("SELECT FAM_CODE FROM famille WHERE FAM_LIBELLE ='" + famille + "'", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            int idFamille = Convert.ToInt16(dr[0].ToString());
            dr.Close();
            return idFamille;
        }
        public List<Famille> GetAllFamille() // Quentin
        {
            List<Famille> LesFamille = new List<Famille>();
            cmd = new MySqlCommand("SELECT FAM_CODE ,FAM_LIBELLE FROM famille", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Famille codeF = new Famille(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                LesFamille.Add(codeF);
            }
            dr.Close();
            return LesFamille;
        }
        public void AjoutMed(string nom, int famCode, decimal prix, string comp, string effet_med, string contre) // Quentin
        {

            double p = Convert.ToDouble(prix.ToString().Replace('.', '.'));

            cmd = new MySqlCommand("INSERT INTO medicament VALUES(null,'" + nom + "'," + famCode + ",'" + comp.Replace("'", "''") + "','" + effet_med.Replace("'", "''") + "','" + contre.Replace("'", "''") + "'," + p + ")", cnx);
            cmd.ExecuteNonQuery();
        }

        public List<Medicament> GetAllPertubateur(int num) // Quentin
        {
            List<Medicament> LesPertubateur = new List<Medicament>();
            cmd = new MySqlCommand("SELECT MED_PERTURBATEUR, MED_NOMCOMMERCIAL, FAM_COD, MED_COMPOSITION, MED_EFFETS, MED_CONTREINDIC, MED_CONTREINDIC FROM medicament INNER JOIN interagir ON MED_DEPOTLEGAL = MED_PERTURBATEUR WHERE MED_MED_PERTURBE =" + num + " GROUP BY MED_PERTURBATEUR ", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Famille codeF = new Famille(Convert.ToInt16(dr[2].ToString()), "test");
                /*  Medicament inter = new Medicament(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), codeF, dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToDouble(dr[6].ToString())); */
                Medicament inter = new Medicament(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), null, null, null, null, 0);
                LesPertubateur.Add(inter);
            }
            dr.Close();
            return LesPertubateur;
        }

        public List<Medicament> GetAllNonPertubateur(int num) // Quentin
        {
            List<Medicament> LesPertubateur = new List<Medicament>();
            cmd = new MySqlCommand("SELECT MED_DEPOTLEGAL, MED_NOMCOMMERCIAL FROM medicament INNER JOIN interagir ON MED_DEPOTLEGAL = MED_PERTURBATEUR WHERE MED_PERTURBATEUR  NOT IN(SELECT MED_PERTURBATEUR FROM medicament INNER JOIN interagir ON MED_DEPOTLEGAL = MED_PERTURBATEUR WHERE MED_MED_PERTURBE = " + num + ") GROUP BY MED_DEPOTLEGAL", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Medicament inter = new Medicament(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), null, null, null, null, 0);
                LesPertubateur.Add(inter);
            }
            dr.Close();
            return LesPertubateur;
        }

        public void AjoutPertubateur(int pertubateur, int pertube) // Quentin
        {
            cmd = new MySqlCommand("INSERT INTO interagir VALUES(" + pertubateur + "," + pertube + ")", cnx);
            cmd.ExecuteNonQuery();
        }
        public void DeletePertubateur(int pertubateur, int pertube) // Quentin
        {
            cmd = new MySqlCommand("DELETE FROM interagir WHERE MED_PERTURBATEUR=" + pertubateur + " AND MED_MED_PERTURBE=" + pertube + ";", cnx);
            cmd.ExecuteNonQuery();
        }


        // Fonctionnalité 2 

        public List<Secteur> GetAllSecteur()
        {
            List<Secteur> LesSecteurs = new List<Secteur>();

            cmd = new MySqlCommand("SELECT SEC_CODE, SEC_LIBELLE FROM secteur", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Secteur unNouveauSecteur = new Secteur(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                LesSecteurs.Add(unNouveauSecteur); 
            }
            dr.Close(); 
            return LesSecteurs;
        }
        public List<Labo> GetAllLabo()
        {
            List<Labo> LesLabos = new List<Labo>();

            cmd = new MySqlCommand("SELECT LAB_CODE, LAB_NOM, LAB_CHEFVENTE FROM labo", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Labo unNouveauLabo = new Labo(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), dr[2].ToString()) ;
                LesLabos.Add(unNouveauLabo);
            }
            dr.Close();
            return LesLabos;
        }

        public List<Region> GetAllRegion()
        {
            List<Region> LesRegions = new List<Region>();

            cmd = new MySqlCommand("SELECT REG_CODE, SEC_CODE, REG_NOM FROM region", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Secteur codeSec = new Secteur(Convert.ToInt16(dr[1].ToString()), "test");
                Region uneNouvelleRegion = new Region(Convert.ToInt16(dr[0].ToString()), codeSec, dr[2].ToString());
                LesRegions.Add(uneNouvelleRegion);
            }
            dr.Close();
            return LesRegions;
        }

        public List<Visiteur> GetAllVisiteur()
        {
            List<Visiteur> LesVisiteurs = new List<Visiteur>();

            cmd = new MySqlCommand("SELECT VIS_MATRICULE,VIS_NOM,VIS_PRENOM,VIS_ADRESSE,VIS_CP,VIS_VILLE,VIS_DATEEMBAUCHE,secteur.SEC_CODE,labo.LAB_CODE,SEC_LIBELLE,LAB_NOM,LAB_CHEFVENTE FROM visiteur INNER JOIN secteur ON visiteur.SEC_CODE = secteur.SEC_CODE INNER JOIN labo ON labo.LAB_CODE = visiteur.LAB_CODE", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Secteur codeSec = new Secteur(Convert.ToInt16(dr[7].ToString()),dr[9].ToString());
                Labo codeLabo = new Labo(Convert.ToInt16(dr[8].ToString()),dr[10].ToString(),dr[11].ToString());
                Visiteur unNouveauVisiteur = new Visiteur(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToInt32(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(), codeSec, codeLabo);
                LesVisiteurs.Add(unNouveauVisiteur);
            }
            dr.Close();
            return LesVisiteurs;
        }

     /*   public Labo GetLaboById(int codeLabo)
        {

            cmd = new MySqlCommand("SELECT LAB_CODE, LAB_NOM, LAB_CHEFVENTE FROM labo WHERE LAB_CODE = " + codeLabo, cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            Labo unLabo = new Labo(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), dr[2].ToString());
            dr.Close();
            return unLabo;
        }*/

        /*public Secteur GetSecteurById(int codeSec)
        {

            cmd = new MySqlCommand("SELECT SEC_CODE, SEC_LIBELLE FROM secteur WHERE SEC_CODE = " + codeSec, cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            Secteur unSecteur = new Secteur(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
            dr.Close();
            return unSecteur;
        }*/

        public Labo GetLaboByNom(string nomLab)
        {
            cmd = new MySqlCommand("SELECT LAB_CODE, LAB_NOM, LAB_CHEFVENTE FROM labo WHERE LAB_NOM = '" + nomLab + "'", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            Labo unLabo = new Labo(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), dr[2].ToString()) ;
            dr.Close();
            return unLabo;
        }

        public Secteur GetSecteurByNom(string nomSec)
        {
            cmd = new MySqlCommand("SELECT SEC_CODE, SEC_LIBELLE FROM secteur WHERE SEC_LIBELLE = '" + nomSec + "'", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            Secteur unSecteur = new Secteur(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
            dr.Close();
            return unSecteur;
        }


        public void AjoutRegion(int SecCode, string RegNom)
        {
            cmd = new MySqlCommand("INSERT INTO region (REG_CODE,SEC_CODE,REG_NOM) VALUES (null," + SecCode + ", '" + RegNom + "')", cnx );
            cmd.ExecuteNonQuery();
        }

        public void AjoutVis(string visNom, string visPrenom, string visAdresse, int visCp, string visVille, string dateEmbauche, int secCode, int labCode)
        {
            cmd = new MySqlCommand("INSERT INTO visiteur (VIS_NOM,VIS_PRENOM,VIS_ADRESSE,VIS_CP,VIS_VILLE,VIS_DATEEMBAUCHE,SEC_CODE,LAB_CODE) VALUES ('" + visNom + "', '" + visPrenom + "', '" + visAdresse  + "', " + visCp + ", '" + visVille + "', '" + dateEmbauche + "', " + secCode + ", " + labCode + ")", cnx);
            cmd.ExecuteNonQuery();
        }
        public void ModifierRegion(int codeSec, string newNomReg, int RegCode) 
        {
            cmd = new MySqlCommand("UPDATE region SET SEC_CODE = '" + codeSec + "', REG_NOM = '" + newNomReg + "' WHERE REG_CODE = " + RegCode, cnx);
            cmd.ExecuteNonQuery();
        }

        public void ModifierVisiteur(int matricule, string nom, string prenom, string adresse, int codePostal, string ville, string dateEmbauche, int secCode, int labCode)
        {
            cmd = new MySqlCommand("UPDATE visiteur SET VIS_NOM = '" + nom + "', VIS_PRENOM = '" + prenom + "', VIS_ADRESSE = '" + adresse + "', VIS_CP = " + codePostal + ", VIS_VILLE = '" + ville + "', VIS_DATEEMBAUCHE = '" + dateEmbauche + "', SEC_CODE = " + secCode + ", LAB_CODE = " + labCode + "  WHERE VIS_MATRICULE = " + matricule, cnx);
            cmd.ExecuteNonQuery();
        }
    }
}

