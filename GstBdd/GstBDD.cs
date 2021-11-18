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
    }
}
