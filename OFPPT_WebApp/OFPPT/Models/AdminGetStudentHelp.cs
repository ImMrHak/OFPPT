using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OFPPT.Models
{
    public class AdminGetStudentHelp
    {
        public int id { get; set; }
        public string cin { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string typedemande { get; set; }
        public string commentaire { get; set; }
    }
}