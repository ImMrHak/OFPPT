using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OFPPT.Models
{
    public class FillChoice_Admin
    {
        public int id_choix { set; get; }
        public string choix { set; get; }
        public int e_ID { set; get; }
        public string e_etablissement { set; get; }
    }
}