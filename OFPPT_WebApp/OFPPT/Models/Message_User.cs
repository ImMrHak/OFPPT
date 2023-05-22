using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OFPPT.Models
{
    public class Message_User
    {
        public int id { set; get; }
        public string nom { set; get; }
        public string prenom { set; get; }
        public string typedemande { set; get; }
        public string commentaire { set; get; }
    }
}