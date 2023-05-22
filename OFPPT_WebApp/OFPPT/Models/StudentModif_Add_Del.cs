using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OFPPT.Models
{
    public class StudentModif_Add_Del
    {
        public string cin { set; get; }
        public string cne { set; get; }
        public string dtnaiss { set; get; }
        public string email { set; get; }
        public string nom { set; get; }
        public string prenom { set; get; }
        public string nomar { set; get; }
        public string prenomar { set; get; }
        public string adresse { set; get; }
        public string numtel { set; get; }
        public string natio { set; get; }
        public string genre { set; get; }
        public float mgbac { set; get; }
        public string nompere { set; get; }
        public string prenompere { set; get; }
        public string cinpere { set; get; }
        public string nommere { set; get; }
        public string prenommere { set; get; }
        public string cinmere { set; get; }
        public string ville { set; get; }
        public string nvscolarite { set; get; }
        public string categorie { set; get; }
        public string branche { set; get; }
        public string ville1 { set; get; }
        public string etablissement { set; get; }
        public string typeformation { set; get; }
        public string nvformation { set; get; }
        public string firstchoice { set; get; }
        public string secondchoice { set; get; }
        public string thirdchoice { set; get; }

        public int ch_ID { set; get; }
        public string ch_choix { set; get; }


        public int s_ID { set; get; }
        public string s_scolarite { set; get; }

        public int b_ID { set; get; }
        public string b_branche { set; get; }


        public int c_ID { set; get; }
        public string c_categorie { set; get; }

        public int e_ID { set; get; }
        public string e_etablissement { set; get; }

        public int v_ID { set; get; }
        public string v_ville { set; get; }

        public int nvf_ID { set; get; }
        public string nvf_nvformation { set; get; }

        public int tf_ID { set; get; }
        public string tf_typeformation { set; get; }
    }
}