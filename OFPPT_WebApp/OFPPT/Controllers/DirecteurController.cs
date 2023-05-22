using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OFPPT.Models;

namespace OFPPT.Controllers
{
    public class DirecteurController : Controller
    {
        ConnectDB CDB = new ConnectDB();
        string nom, prenom, cin;
        public void GetInfo()
        {
            cin = Session["CIN"].ToString();
            nom = Session["Nom"].ToString();
            prenom = Session["Prenom"].ToString();
            ViewBag.CIN = cin;
            ViewBag.Nom = nom;
            ViewBag.Prenom = prenom;
            ViewBag.NomPrenom = prenom + " " + nom;
        }
        // Page d'accueil
        [HttpGet]
        public ActionResult Home()
        {
            try
            {
                GetInfo();
                CDB.Connection("SELECT COUNT(UC.u_cin) FROM UserChoice UC, Users U WHERE U.r_ID='1' AND UC.u_cin=U.u_cin AND UC.e_ID=(SELECT e_ID FROM UserChoice WHERE u_cin='" + Session["CIN"] + "') AND U.IsDeleted='FALSE'");
                ViewBag.NbEtudiants = CDB.Cmd.ExecuteScalar().ToString();
                CDB.Deconnection();
                return View("Home");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // Page pour voir tous les etudiants d'un etablissement
        [HttpGet]
        public ActionResult ViewAllStudent()
        {
            try
            {
                GetInfo();
                List<StudentModif_Add_Del> AllData = new List<StudentModif_Add_Del>();
                AllData.Clear();
                AllData = GettAllStudents();
                ViewData.Model = AllData;
                return View("ViewAllStudent");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        //Methode qui permet d'obtenir les information des etudiant d'un etablissement   //
        public List<StudentModif_Add_Del> GettAllStudents()
        {
            List<StudentModif_Add_Del> returnList = new List<StudentModif_Add_Del>();
            CDB.Connection("SELECT DISTINCT U.u_cin, U.u_nom, U.u_prenom, U.u_cne, U.u_email, U.u_tel, E.e_etablissement, ch_Choix FROM Genre G, Nationalite N, Scolarite S, Categorie C, Branche B, Etablissement E, Choix CH, Users U, UserInformations UI, UserChoice UC WHERE U.r_ID='1' AND UC.u_cin=U.u_cin AND UC.e_ID=(SELECT e_ID FROM UserChoice WHERE u_cin='" + Session["CIN"] + "') AND U.g_ID=G.g_ID AND U.n_ID=N.n_ID AND UC.s_ID=S.s_ID AND UC.c_ID=C.c_ID AND UC.b_ID=B.b_ID AND UC.e_ID=E.e_ID AND UC.FirstChoice=CH.ch_ID AND U.IsDeleted='FALSE'");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                StudentModif_Add_Del SMAD = new StudentModif_Add_Del();
                SMAD.cin = CDB.Dr[0].ToString();
                SMAD.nom = CDB.Dr[1].ToString();
                SMAD.prenom = CDB.Dr[2].ToString();
                SMAD.cne = CDB.Dr[3].ToString();
                SMAD.email = CDB.Dr[4].ToString();
                SMAD.numtel = CDB.Dr[5].ToString();
                SMAD.etablissement = CDB.Dr[6].ToString();
                SMAD.ch_choix = CDB.Dr[7].ToString();
                returnList.Add(SMAD);
            }
            CDB.Deconnection();
            return returnList;
        }

        // Recuperer tout les choix de la BDD
        public List<StudentModif_Add_Del> GetAllChoix()
        {
            List<StudentModif_Add_Del> returnList = new List<StudentModif_Add_Del>();
            CDB.Connection("SELECT ch_ID, ch_choix FROM Choix");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                StudentModif_Add_Del SMAD = new StudentModif_Add_Del();
                SMAD.ch_ID = Convert.ToInt32(CDB.Dr[0].ToString());
                SMAD.ch_choix = CDB.Dr[1].ToString();
                returnList.Add(SMAD);
            }
            CDB.Deconnection();
            return returnList;
        }

        // Recuperer tout les scolarite de la BDD
        public List<StudentModif_Add_Del> GetAllScolarite()
        {
            List<StudentModif_Add_Del> returnList = new List<StudentModif_Add_Del>();
            CDB.Connection("SELECT s_ID, s_scolarite FROM Scolarite");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                StudentModif_Add_Del SMAD = new StudentModif_Add_Del();
                SMAD.s_ID = Convert.ToInt32(CDB.Dr[0].ToString());
                SMAD.s_scolarite = CDB.Dr[1].ToString();
                returnList.Add(SMAD);
            }
            CDB.Deconnection();
            return returnList;
        }

        // Recuperer tout les branche de la BDD
        public List<StudentModif_Add_Del> GetAllBranche()
        {
            List<StudentModif_Add_Del> returnList = new List<StudentModif_Add_Del>();
            CDB.Connection("SELECT b_ID, b_branche FROM Branche");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                StudentModif_Add_Del SMAD = new StudentModif_Add_Del();
                SMAD.b_ID = Convert.ToInt32(CDB.Dr[0].ToString());
                SMAD.b_branche = CDB.Dr[1].ToString();
                returnList.Add(SMAD);
            }
            CDB.Deconnection();
            return returnList;
        }

        // Recuperer tout les categoris de la BDD
        public List<StudentModif_Add_Del> GetAllCategorie()
        {
            List<StudentModif_Add_Del> returnList = new List<StudentModif_Add_Del>();
            CDB.Connection("SELECT c_ID, c_categorie FROM Categorie");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                StudentModif_Add_Del SMAD = new StudentModif_Add_Del();
                SMAD.c_ID = Convert.ToInt32(CDB.Dr[0].ToString());
                SMAD.c_categorie = CDB.Dr[1].ToString();
                returnList.Add(SMAD);
            }
            CDB.Deconnection();
            return returnList;
        }

        // Recuperer tout les etablissements de la BDD
        public List<StudentModif_Add_Del> GetAllEtabl()
        {
            List<StudentModif_Add_Del> returnList = new List<StudentModif_Add_Del>();
            CDB.Connection("SELECT e_ID, e_etablissement FROM Etablissement");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                StudentModif_Add_Del SMAD = new StudentModif_Add_Del();
                SMAD.e_ID = Convert.ToInt32(CDB.Dr[0].ToString());
                SMAD.e_etablissement = CDB.Dr[1].ToString();
                returnList.Add(SMAD);
            }
            CDB.Deconnection();
            return returnList;
        }

        // Supprimmer un etudiant
        [HttpPost]
        [AllowAnonymous]
        public ActionResult DelStudent(StudentModif_Add_Del SMAD)
        {
            try
            {
                CDB.Connection("UPDATE Users SET IsDeleted='TRUE' WHERE u_cin='" + SMAD.cin + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("ViewAllStudent");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Valider un etudiant
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ValidateStudent(StudentModif_Add_Del SMAD)
        {
            try
            {
                CDB.Connection("UPDATE Users SET IsCompleted='Oui' WHERE u_cin='" + SMAD.cin + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();

                CDB.Connection("UPDATE UserChoice SET ChoixAccepter='" + SMAD.ch_ID + "' WHERE u_cin='" + SMAD.cin + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("ViewAllStudent");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Modifier l'utilisateur
        [HttpPost]
        [AllowAnonymous]
        public ActionResult DirecteurEditStudent(StudentModif_Add_Del SMAD)
        {
            try
            {
                CDB.Connection("UPDATE Users SET g_ID='" + SMAD.genre + "', n_ID='" + SMAD.natio + "', u_cne='" + SMAD.cne + "', u_dtnaiss='" + SMAD.dtnaiss + "' WHERE u_cin='" + SMAD.cin + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();

                CDB.Connection("UPDATE UserChoice SET c_ID='" + SMAD.c_ID + "', s_ID='" + SMAD.s_ID + "', b_ID='" + SMAD.b_ID + "', e_ID='" + SMAD.e_ID + "' WHERE u_cin='" + SMAD.cin + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("ViewAllStudent");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Modification du mot de passe de l'utilisateur
        public ActionResult ChangePassword(Password_User PU)
        {
            try
            {
                CDB.Connection("UPDATE Users SET u_pass='" + PU.pass + "' WHERE u_cin='" + Session["CIN"] + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("AccountSettings");
            }
            catch (Exception ex)
            {
                return View("AccountSettings");
            }
        }
    }
}