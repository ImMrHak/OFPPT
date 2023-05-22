using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OFPPT.Models;

namespace OFPPT.Controllers
{
    public class StudentController : Controller
    {
        ConnectDB CDB = new ConnectDB();
        string nom, prenom, cin;
        public void GetFullName()
        {
            cin = Session ["CIN"].ToString();
            nom = Session ["Nom"].ToString();
            prenom = Session ["Prenom"].ToString();
            ViewBag.CIN = cin;
            ViewBag.Nom = nom;
            ViewBag.Prenom = prenom;
            ViewBag.NomPrenom = prenom + " " + nom;
            CDB.Connection("SELECT COUNT(RM.rm_id) FROM ReponseMessage RM, BesoinAide BA WHERE BA.ba_id=RM.ba_id AND BA.ba_cin='" + Session["CIN"] + "'");
            ViewBag.Reponse = CDB.Cmd.ExecuteScalar().ToString();
            CDB.Deconnection();
        }

        // Button se deconnecter
        [HttpGet]
        public ActionResult Disconnect()
        {
            Session.Abandon();
            Session.Clear();
            return Redirect("~/Account/SignIn");
        }

        // Page d'accueil
        [HttpGet]
        public ActionResult Home()
        {
            try
            {
                GetFullName();
                CDB.Connection("SELECT COUNT(ba_id) FROM BesoinAide WHERE ba_cin='" + Session["CIN"] + "' AND ba_isDeleted='FALSE'");
                @ViewBag.NbAide = CDB.Cmd.ExecuteScalar().ToString();

                CDB.Connection("SELECT COUNT(PE.pe_id) FROM UserChoice UC, Choix C, PlanEpreuve PE WHERE PE.ch_ID=C.ch_ID AND C.ch_ID=UC.ChoixAccepter AND UC.u_cin='" + Session["CIN"] + "'");
                @ViewBag.NbEpreuve = CDB.Cmd.ExecuteScalar().ToString();

                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Demande d'aide
        [HttpGet]
        public ActionResult Help()
        {
            try
            {
                GetFullName();
                return View("Help");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Envoi de la demande d'aide
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Help(Help_User HU)
        {
            try
            {
                CDB.Connection("INSERT INTO BesoinAide(td_id, ba_cin, ba_nom, ba_prenom, ba_commentaire, ba_isDeleted) VALUES('" + HU.typedemande + "','" + Session["CIN"] + "','" + Session["Nom"] + "','" + Session["Prenom"] + "','" + HU.comment + "','FALSE')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Page mes dossiers nationnaux
        int FirstChoice, SecondChoice, ThirdChoice, ChoixAccepter1;
        [HttpGet]
        public ActionResult MyNationalFile()
        {
            try
            {
                GetFullName();
                CDB.Connection("SELECT S.s_scolarite, C.c_categorie, B.b_branche, E.e_etablissement, TF.tf_typeformation, NF.nvf_nvformation, UC.FirstChoice, UC.SecondChoice, UC.ThirdChoice, U.IsCompleted, UC.ChoixAccepter FROM Users U, UserChoice UC, Scolarite S, Categorie C, Branche B, Etablissement E, TypeFormation TF, NvFormation NF, Choix CH WHERE UC.u_cin='" + Session["CIN"] + "' AND UC.u_cin=U.u_cin AND UC.s_ID=S.s_ID AND UC.c_ID=C.c_ID AND UC.b_ID=B.b_ID AND UC.e_ID=E.e_ID AND UC.tf_ID=TF.tf_ID AND UC.nvf_ID=NF.nvf_ID AND CH.ch_ID=UC.FirstChoice");
                CDB.Dr = CDB.Cmd.ExecuteReader();
                while (CDB.Dr.Read())
                {
                    ViewBag.scolarite = CDB.Dr[0].ToString();
                    ViewBag.categorie = CDB.Dr[1].ToString();
                    ViewBag.branche = CDB.Dr[2].ToString();
                    ViewBag.etablissement = CDB.Dr[3].ToString();
                    ViewBag.typeformation = CDB.Dr[4].ToString();
                    ViewBag.nvformation = CDB.Dr[5].ToString();
                    FirstChoice = Convert.ToInt32(CDB.Dr[6].ToString());
                    SecondChoice = Convert.ToInt32(CDB.Dr[7].ToString());
                    ThirdChoice = Convert.ToInt32(CDB.Dr[8].ToString());
                    ViewBag.Completed = CDB.Dr[9].ToString();
                    ViewBag.ChoixAccepter1 = CDB.Dr[10].ToString();
                }
                CDB.Deconnection();

                //1er Choix
                CDB.Connection("SELECT ch_choix FROM Choix WHERE ch_ID='" + FirstChoice + "'");
                CDB.Dr = CDB.Cmd.ExecuteReader();
                while (CDB.Dr.Read())
                {
                    ViewBag.FirstChoiceName = CDB.Dr[0].ToString();
                }
                CDB.Deconnection();

                //2eme Choix
                CDB.Connection("SELECT ch_choix FROM Choix WHERE ch_ID='" + SecondChoice + "'");
                CDB.Dr = CDB.Cmd.ExecuteReader();
                while (CDB.Dr.Read())
                {
                    ViewBag.SecondChoiceName = CDB.Dr[0].ToString();
                }
                CDB.Deconnection();

                //3eme Choix
                CDB.Connection("SELECT ch_choix FROM Choix WHERE ch_ID='" + ThirdChoice + "'");
                CDB.Dr = CDB.Cmd.ExecuteReader();
                while (CDB.Dr.Read())
                {
                    ViewBag.ThirdChoiceName = CDB.Dr[0].ToString();
                }
                CDB.Deconnection();

                //Choix Accepter
                CDB.Connection("SELECT ch_choix FROM Choix WHERE ch_ID='" + ViewBag.ChoixAccepter1 + "'");
                CDB.Dr = CDB.Cmd.ExecuteReader();
                while (CDB.Dr.Read())
                {
                    ViewBag.AcceptedChoice = CDB.Dr[0].ToString();
                }
                CDB.Deconnection();
                return View("MyNationalFile");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Page a propos d'utilisateur
        [HttpGet]
        public ActionResult AboutMe()
        {
            try
            {
                GetFullName();
                CDB.Connection("SELECT G.g_genre ,U.u_nom, U.u_prenom, U.u_nomAr, U.u_prenomAr, UI.ui_nompere, UI.ui_prenompere, UI.ui_nommere, UI.ui_prenommere, U.u_dtnaiss, N.n_nationalite, U.u_cne, U.u_tel, u_adresse, u_email, S.s_scolarite, C.c_categorie, B.b_branche FROM Users U, UserInformations UI, UserChoice UC,Scolarite S, Categorie C, Nationalite N, Branche B, Genre G WHERE U.u_cin='" + Session["CIN"] + "' AND UC.u_cin=U.u_cin AND UC.s_ID=S.s_ID AND UC.c_ID=C.c_ID AND UC.b_ID=B.b_ID AND U.n_ID=N.n_ID AND U.g_ID=G.g_ID");
                CDB.Dr = CDB.Cmd.ExecuteReader();
                while (CDB.Dr.Read())
                {
                    ViewBag.Genre = CDB.Dr[0].ToString();
                    ViewBag.Nom = CDB.Dr[1].ToString();
                    ViewBag.Prenom = CDB.Dr[2].ToString();
                    ViewBag.NomAr = CDB.Dr[3].ToString();
                    ViewBag.PrenomAr = CDB.Dr[4].ToString();
                    ViewBag.NomPere = CDB.Dr[5].ToString();
                    ViewBag.PrenomPere = CDB.Dr[6].ToString();
                    ViewBag.NomMere = CDB.Dr[7].ToString();
                    ViewBag.PrenomMere = CDB.Dr[8].ToString();
                    ViewBag.DateNaissance = CDB.Dr[9].ToString();
                    ViewBag.Nationalite = CDB.Dr[10].ToString();
                    ViewBag.CNE = CDB.Dr[11].ToString();
                    ViewBag.Tel = CDB.Dr[12].ToString();
                    ViewBag.Adresse = CDB.Dr[13].ToString();
                    ViewBag.Email = CDB.Dr[14].ToString();
                    ViewBag.Scolarite = CDB.Dr[15].ToString();
                    ViewBag.Categorie = CDB.Dr[16].ToString();
                    ViewBag.Branche = CDB.Dr[17].ToString();

                }
                CDB.Deconnection();

                //Lieu De Naissance
                CDB.Connection("SELECT V.v_ville FROM UserInformations UF, Ville V WHERE UF.u_cin='" + Session["CIN"] + "' AND UF.v_ID=V.v_ID");
                CDB.Dr = CDB.Cmd.ExecuteReader();
                while (CDB.Dr.Read())
                {
                    ViewBag.VilleNaissance = CDB.Dr[0].ToString();
                }
                CDB.Deconnection();

                //Ville OU L'Utilisateur Vas Etudier
                CDB.Connection("SELECT V.v_ville FROM UserChoice UC, Ville V WHERE UC.u_cin='" + Session["CIN"] + "' AND UC.v_ID=V.v_ID");
                CDB.Dr = CDB.Cmd.ExecuteReader();
                while (CDB.Dr.Read())
                {
                    ViewBag.VilleEtude = CDB.Dr[0].ToString();
                }
                CDB.Deconnection();
                return View("AboutMe");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Modifier les informations d'un utilisateur
        [HttpPost]
        [AllowAnonymous]
        public ActionResult UpdateUser(Update_User UU)
        {
            try
            {
                CDB.Connection("UPDATE Users SET u_nom='" + UU.nom + "', u_prenom='" + UU.prenom + "', u_nomAr=N'" + UU.nomar + "', u_prenomAr=N'" + UU.prenomar + "', u_adresse='" + UU.adresse + "', u_tel='" + UU.tel + "', u_email='" + UU.email + "' WHERE u_cin='" + Session["CIN"] + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();

                CDB.Connection("UPDATE UserInformations SET ui_nompere='" + UU.nompere + "', ui_prenompere='" + UU.prenompere + "', ui_nommere='" + UU.nommere + "', ui_prenommere='" + UU.prenommere + "' WHERE u_cin='" + Session["CIN"] + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("AboutMe");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        
        //----------------------------------------------------------------------//
        // Page des epreuves d'une branche d'un utilisateur                     //
        [HttpGet]                                                               //
        public ActionResult Planning()
        {
            try
            {
                GetFullName();
                List<Planning_User> AllData = new List<Planning_User>();
                AllData.Clear();
                AllData = GetEpreuve();
                ViewData.Model = AllData;
                return View("Planning");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                                       //

        //Methode qui permet d'obtenir les epreuves d'un utilisateur            //
        public List<Planning_User> GetEpreuve()
        {
            List<Planning_User> returnList = new List<Planning_User>();
            CDB.Connection("SELECT PE.pe_epreuve, PE.pe_datedebut, PE.pe_datefin, C.ch_choix FROM UserChoice UC, Choix C, PlanEpreuve PE WHERE PE.ch_ID=C.ch_ID AND C.ch_ID=UC.ChoixAccepter AND UC.u_cin='" + Session["CIN"] + "'");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                Planning_User PA = new Planning_User();
                PA.epreuve = CDB.Dr[0].ToString();
                PA.datedebut = CDB.Dr[1].ToString();
                PA.datefin = CDB.Dr[2].ToString();
                PA.branche = CDB.Dr[3].ToString();
                returnList.Add(PA);
            }
            CDB.Deconnection();
            return returnList;
        }                              //
        //----------------------------------------------------------------------//

        // Page de re-inscription
        [HttpGet]
        public ActionResult Register()
        {
            try
            {
                GetFullName();
                return View("Register");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Methode qui permet la re-inscription d'un etudiant
        string s_ID, c_ID, b_ID, tf_ID;
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(StudentModif_Add_Del SMAD)
        {
            try
            {
                CDB.Connection("SELECT s_ID, c_ID, b_ID, tf_ID FROM UserChoice WHERE u_cin='" + Session["CIN"] + "'");
                CDB.Dr = CDB.Cmd.ExecuteReader();
                while (CDB.Dr.Read())
                {
                    s_ID = CDB.Dr[0].ToString();
                    c_ID = CDB.Dr[1].ToString();
                    b_ID = CDB.Dr[2].ToString();
                    tf_ID = CDB.Dr[3].ToString();
                }
                CDB.Deconnection();
                CDB.Connection("INSERT INTO UserChoice(u_cin, s_ID, c_ID, b_ID, v_ID, tf_ID, e_ID, nvf_ID, FirstChoice, SecondChoice, ThirdChoice) VALUES('" + Session["CIN"] + "','" + s_ID + "','" + c_ID + "','" + b_ID + "','" + SMAD.ville + "','" + tf_ID + "','" + SMAD.etablissement + "','" + SMAD.typeformation + "','" + SMAD.firstchoice + "','" + SMAD.secondchoice + "','" + SMAD.thirdchoice + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Recuperer tout les villes de la BDD
        public List<StudentModif_Add_Del> GetAllVille()
        {
            List<StudentModif_Add_Del> returnList = new List<StudentModif_Add_Del>();
            CDB.Connection("SELECT v_ID, v_ville FROM Ville");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                StudentModif_Add_Del SMAD = new StudentModif_Add_Del();
                SMAD.v_ID = Convert.ToInt32(CDB.Dr[0].ToString());
                SMAD.v_ville = CDB.Dr[1].ToString();
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

        // Recuperer tout les niveaux de formations de la BDD
        public List<StudentModif_Add_Del> GetAllNvFormation()
        {
            List<StudentModif_Add_Del> returnList = new List<StudentModif_Add_Del>();
            CDB.Connection("SELECT nvf_ID, nvf_nvformation FROM NvFormation");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                StudentModif_Add_Del SMAD = new StudentModif_Add_Del();
                SMAD.nvf_ID = Convert.ToInt32(CDB.Dr[0].ToString());
                SMAD.nvf_nvformation = CDB.Dr[1].ToString();
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

        //----------------------------------------------------------------------//
        // Page des messages envoie/recue                                       //
        [HttpGet]                                                               //
        public ActionResult ViewAllResponse()
        {
            try
            {
                GetFullName();
                List<Message_User> AllData = new List<Message_User>();
                AllData.Clear();
                AllData = GetMessageHelp();
                ViewData.Model = AllData;
                return View("ViewAllResponse");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                               //
        public List<Message_User> GetMessageHelp()
        {
            List<Message_User> returnList = new List<Message_User>();
            CDB.Connection("SELECT BA.ba_id, BA.ba_nom, BA.ba_prenom, TD.td_typedemande, BA.ba_commentaire FROM BesoinAide BA, TypeDemande TD  WHERE ba_cin = '" + Session["CIN"] + "' AND ba_isDeleted = 'TRUE' AND TD.td_id=BA.td_id");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                Message_User MU = new Message_User();
                MU.id = Convert.ToInt32(CDB.Dr[0].ToString());
                MU.nom = CDB.Dr[1].ToString();
                MU.prenom = CDB.Dr[2].ToString();
                MU.typedemande = CDB.Dr[3].ToString();
                MU.commentaire = CDB.Dr[4].ToString();
                returnList.Add(MU);
            }
            CDB.Deconnection();
            return returnList;
        }                          //
        [HttpGet]
        public ActionResult AdminResponse(int ID)
        {
            try
            {
                GetFullName();
                CDB.Connection("SELECT RM.rm_titre, RM.rm_reponsemessage FROM ReponseMessage RM, BesoinAide BA WHERE BA.ba_id=RM.ba_id AND BA.ba_cin='" + Session["CIN"] + "' AND BA.ba_id='" + ID + "'");
                CDB.Dr = CDB.Cmd.ExecuteReader();
                while (CDB.Dr.Read())
                {
                    AdminMessage_User AMU = new AdminMessage_User();
                    ViewBag.titre = CDB.Dr[0].ToString();
                    ViewBag.reponsemessage = CDB.Dr[1].ToString();
                }
                return View("AdminResponse");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                           //
        //---------------------------------------------------------------------//
    }
}