using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OFPPT.Models
{
    public class AdminAdd
    {
        // Ajouter Un Directeur
        public string cin { set; get; }
        public string pass { set; get; }
        public string nom { set; get; }
        public string prenom { set; get; }
        public string email { set; get; }
        public int etablissement { set; get; }

        //Ajouter Une Epreuve
        public string epreuvenom { set; get; }
        public string datedebutepreuve { set; get; }
        public string datefinepreuve { set; get; }
        public int choixbranche { set; get; }

        //Ajouter Une Ville
        public string villee { set; get; }

        //Ajouter Un Etablissement
        public string etab { set; get; }

        //Ajouter Un Nv De Formation
        public string nvforma { set; get; }

        //Ajouter Une Categorie
        public string categoriee { set; get; }

        //Ajouter Une Branche
        public string branchee { set; get; }

        //Ajouter Un Type De Formation
        public string tyformation { set; get; }

        //Ajouter Une Scolarite
        public string scolarite { set; get; }

        //Ajouter Un Choix
        public string choix { set; get; }
    }
}