using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OFPPT.Models
{
    public class GetDirecteurInfos
    {
        public string cin { set; get; }
        public string pass { set; get; }
        public string email { set; get; }
        public string nom { set; get; }
        public string prenom { set; get; }
        public string etablissement { set; get; }

        public int e_id { set; get; }
        public string fulletab { set; get; }

        public int id_choix { set; get; }
        public string choix { set; get; }
    }
}