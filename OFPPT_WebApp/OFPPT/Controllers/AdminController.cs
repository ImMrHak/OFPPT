using System;
using System.Collections.Generic;
using System.Web.Mvc;

using OFPPT.Models;

namespace OFPPT.Controllers
{
    public class AdminController : Controller
    {
        ConnectDB CDB = new ConnectDB();
        // Page des epreuves d'une branche d'un utilisateur
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
            CDB.Connection("SELECT COUNT(*) FROM BesoinAide WHERE ba_isDeleted='FALSE'");
            ViewBag.TotalHelp = CDB.Cmd.ExecuteScalar().ToString();
            CDB.Deconnection();
        }

        //----------------------------------------------------------------------------------------------------//
        // Page d'accueil administrateur                                                                      //
        [HttpGet]                                                                                             //
        public ActionResult Home()
        {
            try
            {
                GetInfo();
                CDB.Connection("SELECT COUNT(*) FROM Users WHERE IsDeleted='FALSE' AND r_ID='3'");
                ViewBag.TotalDirecteur = CDB.Cmd.ExecuteScalar().ToString();
                CDB.Deconnection();

                List<FillChoice_Admin> AllData = new List<FillChoice_Admin>();
                AllData.Clear();
                AllData = GetAllChoice();
                ViewData.Model = AllData;
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                                                                        //

        //Methode qui permet d'obtenir des choix et des etablissements pour ajouter une epreuve a une class   //
        public List<FillChoice_Admin> GetAllChoice()
        {
            List<FillChoice_Admin> returnList = new List<FillChoice_Admin>();
            CDB.Connection("SELECT DISTINCT ch_ID, ch_choix, e_ID, e_etablissement FROM Choix, Etablissement");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                FillChoice_Admin FCA = new FillChoice_Admin();
                FCA.id_choix = Convert.ToInt32(CDB.Dr[0].ToString());
                FCA.choix = CDB.Dr[1].ToString();
                FCA.e_ID = Convert.ToInt32(CDB.Dr[2].ToString());
                FCA.e_etablissement = CDB.Dr[3].ToString();
                returnList.Add(FCA);
            }

            CDB.Deconnection();
            return returnList;
        }                                                      //
        //---------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------//
        //                      Ajout des elements dans la BDD                          //
        // Ajout Administrateur                                                         //
        [HttpPost]                                                                      //
        [AllowAnonymous]                                                                //
        public ActionResult AddDirect(AdminAdd AA)
        {
            try
            {
                CDB.Connection("INSERT INTO Users(u_cin, u_pass, u_email, u_nom, u_prenom, r_ID, IsDeleted) VALUES('" + AA.cin + "','" + AA.pass + "','" + AA.email + "','" + AA.nom + "','" + AA.prenom + "','3','FALSE')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();

                CDB.Connection("INSERT INTO UserChoice(u_cin, e_ID) VALUES('" + AA.cin + "','" + AA.etablissement + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                                   //
                                                                                        //
        // Ajout Epreuve                                                                //
        [HttpPost]                                                                      //                                       
        [AllowAnonymous]                                                                //
        public ActionResult AddEpreuve(AdminAdd AA)
        {
            try
            {
                CDB.Connection("INSERT INTO PlanEpreuve(pe_epreuve,pe_datedebut,pe_datefin,ch_ID) VALUES('" + AA.epreuvenom + "','" + AA.datedebutepreuve + "','" + AA.datefinepreuve + "', '" + AA.choixbranche + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                                  //
                                                                                        //
        // Ajout Ville                                                                  //
        [HttpPost]                                                                      //
        [AllowAnonymous]                                                                //
        public ActionResult AddVille(AdminAdd AA)
        {
            try
            {
                CDB.Connection("INSERT INTO Ville(v_ville) VALUES('" + AA.villee + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                                   //
                                                                                       //
        // Ajout Etablissement                                                         //
        [HttpPost]                                                                     //
        [AllowAnonymous]                                                               //
        public ActionResult AddEtablissement(AdminAdd AA)
        {
            try
            {
                CDB.Connection("INSERT INTO Etablissement(e_etablissement) VALUES('" + AA.etab + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                          //
                                                                                      //
        // Ajout AddNvFormation                                                       //
        [HttpPost]                                                                    //
        [AllowAnonymous]                                                              //
        public ActionResult AddNvFormation(AdminAdd AA)
        {
            try
            {
                CDB.Connection("INSERT INTO NvFormation(nvf_nvformation) VALUES('" + AA.nvforma + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                           //
                                                                                     //
        // Ajout Categorie                                                           //
        [HttpPost]                                                                   //
        [AllowAnonymous]                                                             //
        public ActionResult AddCategorie(AdminAdd AA)
        {
            try
            {
                CDB.Connection("INSERT INTO Categorie(c_categorie) VALUES('" + AA.categoriee + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                             //
                                                                                     //
        // Ajout Branche                                                             //
        [HttpPost]                                                                   //
        [AllowAnonymous]                                                             //
        public ActionResult AddBranche(AdminAdd AA)
        {
            try
            {
                CDB.Connection("INSERT INTO Branche(b_branche) VALUES('" + AA.branchee + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                               //
                                                                                     //
        // Ajout Type Formation                                                      //
        [HttpPost]                                                                   //
        [AllowAnonymous]                                                             //
        public ActionResult AddTypeFormation(AdminAdd AA)
        {
            try
            {
                CDB.Connection("INSERT INTO TypeFormation(tf_typeformation) VALUES('" + AA.tyformation + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                         //
                                                                                     //
        // Ajout Scolarite                                                           //
        [HttpPost]                                                                   //
        [AllowAnonymous]                                                             //
        public ActionResult AddScolarite(AdminAdd AA)
        {
            try
            {
                CDB.Connection("INSERT INTO Scolarite(s_scolarite) VALUES('" + AA.scolarite + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                             //
                                                                                     //
        // Ajout Choix                                                               //
        [HttpPost]                                                                   //
        [AllowAnonymous]                                                             //
        public ActionResult AddChoix(AdminAdd AA)
        {
            try
            {
                CDB.Connection("INSERT INTO Choix(ch_choix) VALUES('" + AA.choix + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                                 //
        //---------------------------------------------------------------------------//

        //----------------------------------------------------------------------------------------------------//
        // Page de reception des messages                                                                     //
        [HttpGet]                                                                                             //
        public ActionResult ViewAllReports()
        {
            try
            {
                GetInfo();
                List<AdminGetStudentHelp> AllReports = new List<AdminGetStudentHelp>();
                AllReports.Clear();
                AllReports = GetReports();
                ViewData.Model = AllReports;
                return View("ViewAllReports");
            }
            catch (Exception ex)
            {
                return View();
            }
        }                                                               //
                                                                                                              //
        // Obtenir tout les reports depuis la BDD                                                             //                                                                                            
        public List<AdminGetStudentHelp> GetReports()
        {
            List<AdminGetStudentHelp> returnList = new List<AdminGetStudentHelp>();
            CDB.Connection("SELECT BA.ba_id, TD.td_typedemande, BA.ba_cin, BA.ba_nom, BA.ba_prenom, BA.ba_commentaire FROM BesoinAide BA, TypeDemande TD WHERE BA.td_id=TD.td_id AND BA.ba_isDeleted='FALSE'");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                AdminGetStudentHelp GASH = new AdminGetStudentHelp();
                GASH.id = Convert.ToInt32(CDB.Dr[0].ToString());
                GASH.typedemande = CDB.Dr[1].ToString();
                GASH.cin = CDB.Dr[2].ToString();
                GASH.nom = CDB.Dr[3].ToString();
                GASH.prenom = CDB.Dr[4].ToString();
                GASH.commentaire = CDB.Dr[5].ToString();
                returnList.Add(GASH);
            }
            CDB.Deconnection();
            return returnList;
        }                                                      //
        //----------------------------------------------------------------------------------------------------//

        // Envoie de reponse a utilisateur selectionner
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SendResponse(AdminSendResponse ASR)
        {
            try
            {
                CDB.Connection("INSERT INTO ReponseMessage(rm_titre, rm_reponsemessage,ba_id) VALUES('" + ASR.sujet + "','" + ASR.reponse + "','" + ASR.idedemande + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();

                CDB.Connection("UPDATE BesoinAide SET ba_isDeleted='TRUE' WHERE ba_id='" + ASR.idedemande + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("ViewAllReports");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewAllDirecteur()
        {
            try
            {
                GetInfo();
                List<GetDirecteurInfos> AllReports = new List<GetDirecteurInfos>();
                AllReports.Clear();
                AllReports = GettAllDirector();
                ViewData.Model = AllReports;

                return View("ViewAllDirecteur");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //Methode qui permet d'obtenir les directeurs, des etablissements, les epreuves   //
        public List<GetDirecteurInfos> GetAllEtabl()
        {
            List<GetDirecteurInfos> returnList = new List<GetDirecteurInfos>();
            CDB.Connection("SELECT e_ID, e_etablissement FROM Etablissement");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                GetDirecteurInfos GDI = new GetDirecteurInfos();
                GDI.e_id = Convert.ToInt32(CDB.Dr[0].ToString());
                GDI.fulletab = CDB.Dr[1].ToString();
                returnList.Add(GDI);
            }
            CDB.Deconnection();
            return returnList;
        }
        public List<GetDirecteurInfos> GetAllEpreuve()
        {
            List<GetDirecteurInfos> returnList = new List<GetDirecteurInfos>();
            CDB.Connection("SELECT ch_ID, ch_choix FROM Choix");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                GetDirecteurInfos GDI = new GetDirecteurInfos();
                GDI.id_choix = Convert.ToInt32(CDB.Dr[0].ToString());
                GDI.choix = CDB.Dr[1].ToString();
                returnList.Add(GDI);
            }
            CDB.Deconnection();
            return returnList;
        }
        public List<GetDirecteurInfos> GettAllDirector()
        {
            List<GetDirecteurInfos> returnList = new List<GetDirecteurInfos>();
            CDB.Connection("SELECT U.u_cin, U.u_pass, U.u_email, U.u_nom, U.u_prenom, E.e_etablissement FROM Users U, UserChoice UC, Etablissement E WHERE U.u_cin=UC.u_cin AND UC.e_ID=e.e_ID AND U.r_ID='3' AND U.IsDeleted='FALSE'");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                GetDirecteurInfos GDI = new GetDirecteurInfos();
                GDI.cin = CDB.Dr[0].ToString();
                GDI.pass = CDB.Dr[1].ToString();
                GDI.email = CDB.Dr[2].ToString();
                GDI.nom = CDB.Dr[3].ToString();
                GDI.prenom = CDB.Dr[4].ToString();
                GDI.etablissement = CDB.Dr[5].ToString();
                returnList.Add(GDI);
            }
            CDB.Deconnection();
            return returnList;
        }

        // Modifier un directeur
        [HttpPost]
        [AllowAnonymous]
        public ActionResult EditDirect(GetDirecteurInfos GDI)
        {
            try
            {
                CDB.Connection("UPDATE Users SET u_pass='" + GDI.pass + "', u_email='" + GDI.email + "', u_nom='" + GDI.nom + "', u_prenom='" + GDI.prenom + "' WHERE u_cin='" + GDI.cin + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();

                CDB.Connection("UPDATE UserChoice SET e_ID='" + GDI.e_id + "' WHERE u_cin='" + GDI.cin + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("ViewAllDirecteur");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Supprimer un directeur
        [HttpPost]
        [AllowAnonymous]
        public ActionResult DelDirect(GetDirecteurInfos GDI)
        {
            try
            {
                CDB.Connection("UPDATE Users SET IsDeleted='TRUE' WHERE u_cin='" + GDI.cin + "'");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("ViewAllDirecteur");
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