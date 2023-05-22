using System;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using OFPPT.Models;
using System.Collections.Generic;

namespace OFPPT.Controllers
{
    public class AccountController : Controller
    {
        ConnectDB CDB = new ConnectDB();

        // Page de connexion
        [HttpGet]
        public ActionResult SignIn()
        {
            return View("SignIn");
        }

        // Connexion de l'utilisateur
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignIn(Connect_User CU)
        {
            try
            {
                CDB.Connection("SELECT COUNT(*) FROM Users U WHERE U.u_cin = '" + CU.cin + "' AND U.u_pass = '" + CU.pass + "' AND U.IsDeleted = 'FALSE'");
                string Output = CDB.Cmd.ExecuteScalar().ToString();
                CDB.Deconnection();
                if (Output == "1")
                {
                    CDB.Connection("SELECT U.u_nom, U.u_prenom, R.r_role FROM Users U,Roles R WHERE U.u_cin ='" + CU.cin + "' AND U.r_ID = R.r_ID AND U.IsDeleted = 'FALSE'");
                    CDB.Dr = CDB.Cmd.ExecuteReader();
                    while (CDB.Dr.Read())
                    {
                        Session["CIN"] = CU.cin.ToString();
                        Session["Nom"] = CDB.Dr[0].ToString();
                        Session["Prenom"] = CDB.Dr[1].ToString();
                        Session["Role"] = CDB.Dr[2].ToString();
                    }
                    CDB.Deconnection();
                    if (Session["Role"].ToString() == "STUDENT")
                    {
                        return RedirectToAction("Home", "Student");
                    }
                    else if (Session["Role"].ToString() == "ADMIN")
                    {
                        return RedirectToAction("Home", "Admin");
                    }
                    else if(Session["Role"].ToString() == "DIRECTEUR")
                    {
                        return RedirectToAction("Home", "Directeur");
                    }
                    else
                    {
                        Response.Write("<script>window.addEventListener('load', function () {Message('error','Une erreur est survenue veuillez contacter l'administrateur !');})</script>");
                        return View();
                    }
                }
                else
                {
                    Response.Write("<script>window.addEventListener('load', function () {Message('error','Votre cin ou mot de passe est incorrecte !');})</script>");
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Page de recuperation du mot de passe
        [HttpGet]
        public ActionResult Recover()
        {
            return View("Recover");
        }

        // Reception du mot de passe dans la boite de reception de l'utilisateur
        string mail, pass;
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Recover(Recover_User RU)
        {
            try
            {
                CDB.Connection("SELECT COUNT(*) FROM Users U WHERE U.u_cin = '" + RU.cin + "' AND U.IsDeleted = 'FALSE'");
                string Output = CDB.Cmd.ExecuteScalar().ToString();
                CDB.Deconnection();
                if (Output == "1")
                {
                    CDB.Connection("SELECT U.u_email1, U.u_pass FROM Users U WHERE u_cin ='" + RU.cin + "' AND U.IsDeleted = 'FALSE'");
                    CDB.Dr = CDB.Cmd.ExecuteReader();
                    while (CDB.Dr.Read())
                    {
                        mail = CDB.Dr[0].ToString();
                        pass = CDB.Dr[1].ToString();
                    }
                    CDB.Deconnection();

                    MailMessage MM = new MailMessage();
                    MM.From = new MailAddress("ofppt.test1@gmail.com");
                    MM.To.Add("ofppt.test1@gmail.com");
                    MM.Subject = "Récuperation de votre mot de passe ";
                    MM.Body = "Voice votre mot de passe : " + pass;
                    MM.IsBodyHtml = false;

                    SmtpClient SC = new SmtpClient();
                    SC.Host = "smtp.gmail.com";
                    SC.Port = 587;
                    SC.EnableSsl = false;

                    NetworkCredential NC = new NetworkCredential("ofppt.test1@gmail.com", "ofppt123456");
                    SC.UseDefaultCredentials = true;
                    SC.Credentials = NC;
                    SC.Send(MM);
                    SC.Dispose();

                    return View();
                }
                else
                {
                    Response.Write("<script>window.addEventListener('load', function () {Message('error','Une erreur est survenue veuillez contacter l'administrateur !');})</script>");
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Page d'inscription d'utilisateur
        [HttpGet]
        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        // Creation du compte de l'utilisateur
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp(StudentModif_Add_Del RU)
        {
            try
            {
                CDB.Connection("INSERT INTO Users VALUES('" + RU.cin + "','" + RU.cin + "','" + RU.cne + "','" + RU.dtnaiss + "','" + RU.email + "','" + RU.nom + "','" + RU.prenom + "',N'" + RU.nomar + "',N'" + RU.prenomar + "','" + RU.adresse + "','" + RU.numtel + "','" + RU.natio + "','" + RU.genre + "','" + RU.mgbac + "','1','Non','FALSE')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();

                CDB.Connection("INSERT INTO UserInformations(u_cin, ui_nompere, ui_prenompere, ui_cinpere, ui_nommere, ui_prenommere, ui_cinmere, v_ID) VALUES('" + RU.cin + "','" + RU.nompere + "','" + RU.prenompere + "','" + RU.cinpere + "','" + RU.nommere + "','" + RU.prenommere + "','" + RU.cinmere + "','" + RU.ville + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();

                CDB.Connection("INSERT INTO UserChoice(u_cin, s_ID, c_ID, b_ID, v_ID, e_ID, tf_ID, nvf_ID, FirstChoice, SecondChoice, ThirdChoice) VALUES('" + RU.cin + "','" + RU.nvscolarite + "','" + RU.categorie + "','" + RU.branche + "','" + RU.ville1 + "','" + RU.etablissement + "','" + RU.typeformation + "','" + RU.nvformation + "','" + RU.firstchoice + "','" + RU.secondchoice + "','" + RU.thirdchoice + "')");
                CDB.Cmd.ExecuteNonQuery();
                CDB.Deconnection();
                return View("SignUp");
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

        // Recuperer tout les types de formations de la BDD
        public List<StudentModif_Add_Del> GetAllTypeFormations()
        {
            List<StudentModif_Add_Del> returnList = new List<StudentModif_Add_Del>();
            CDB.Connection("SELECT tf_ID, tf_typeformation FROM TypeFormation");
            CDB.Dr = CDB.Cmd.ExecuteReader();
            while (CDB.Dr.Read())
            {
                StudentModif_Add_Del SMAD = new StudentModif_Add_Del();
                SMAD.tf_ID = Convert.ToInt32(CDB.Dr[0].ToString());
                SMAD.tf_typeformation = CDB.Dr[1].ToString();
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
    }
}