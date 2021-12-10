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
            cmd = new MySqlCommand("SELECT MED_DEPOTLEGAL, MED_NOMCOMMERCIAL, FAM_COD, MED_COMPOSITION, MED_EFFETS, MED_CONTREINDIC, MED_PRIXECHANTILLON FROM medicament", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Famille codeF = new Famille(Convert.ToInt16(dr[2].ToString()), "test");
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
    }
}
