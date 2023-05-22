                                                      /*==============================================================*/
                                                      /*                      Nom de SGBD :  OFPPT                    */
                                                      /*             Date de création :  22/05/2022 19:55:30          */
                                                      /*==============================================================*/

                                                      /*==============================================================*/
                                                      /*             Suppression Des Tables Si Ils Existents          */
                                                      /*==============================================================*/

IF DB_ID('OFPPT') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS Roles;
	DROP TABLE IF EXISTS Genre;
	DROP TABLE IF EXISTS Nationalite;
	DROP TABLE IF EXISTS Scolarite;
	DROP TABLE IF EXISTS Categorie;
	DROP TABLE IF EXISTS Branche;
	DROP TABLE IF EXISTS Ville;
	DROP TABLE IF EXISTS Etablissement;
	DROP TABLE IF EXISTS TypeFormation;
	DROP TABLE IF EXISTS NvFormation;
	DROP TABLE IF EXISTS Choix;
	DROP TABLE IF EXISTS PlanEpreuve;
	DROP TABLE IF EXISTS TypeDemande;
	DROP TABLE IF EXISTS BesoinAide;
	DROP TABLE IF EXISTS Users;
	DROP TABLE IF EXISTS UserChoice;
	DROP TABLE IF EXISTS UserInformations;
	DROP TABLE IF EXISTS ReponseMessage;
END

                                                      /*==============================================================*/
                                                      /*                Création De La Base Des Données              */
                                                      /*==============================================================*/

CREATE DATABASE OFPPT
GO
USE OFPPT
GO

                                                      /*==============================================================*/
                                                      /*                      Création Des Tables                     */
                                                      /*==============================================================*/
CREATE TABLE Roles
(
r_ID INT PRIMARY KEY IDENTITY(1,1),
r_role VARCHAR(150) CHECK(r_role IN('STUDENT','ADMIN','DIRECTEUR'))
)
GO
CREATE TABLE Genre
(
g_ID INT PRIMARY KEY IDENTITY(1,1),
g_genre VARCHAR(150) CHECK(g_genre IN('Masculin','Féminin'))
)
GO
CREATE TABLE Nationalite
(
n_ID INT PRIMARY KEY IDENTITY(1,1),
n_nationalite VARCHAR(150) CHECK(n_nationalite IN('Marocain','Étranger'))
)
GO
CREATE TABLE Scolarite
(
s_ID INT PRIMARY KEY IDENTITY(1,1),
s_scolarite VARCHAR(MAX)
)
GO
CREATE TABLE Categorie
(
c_ID INT PRIMARY KEY IDENTITY(1,1),
c_categorie VARCHAR(MAX)
)
GO
CREATE TABLE Branche
(
b_ID INT PRIMARY KEY IDENTITY(1,1),
b_branche VARCHAR(MAX)
)
GO
CREATE TABLE Ville
(
v_ID INT PRIMARY KEY IDENTITY(1,1),
v_ville VARCHAR(MAX)
)
GO
CREATE TABLE Etablissement
(
e_ID INT PRIMARY KEY IDENTITY(1,1),
e_etablissement VARCHAR(MAX)
)
GO
CREATE TABLE TypeFormation
(
tf_ID INT PRIMARY KEY IDENTITY(1,1),
tf_typeformation VARCHAR(MAX)
)
GO
CREATE TABLE NvFormation
(
nvf_ID INT PRIMARY KEY IDENTITY(1,1),
nvf_nvformation VARCHAR(MAX)
)
GO
CREATE TABLE Choix
(
ch_ID INT PRIMARY KEY IDENTITY(1,1),
ch_choix VARCHAR(MAX)
)
GO
CREATE TABLE TypeDemande
(
td_id INT PRIMARY KEY IDENTITY(1,1),
td_typedemande VARCHAR(150),
)
GO
CREATE TABLE BesoinAide
(
ba_id INT PRIMARY KEY IDENTITY(1,1),
td_id INT FOREIGN KEY REFERENCES TypeDemande(td_id),
ba_cin VARCHAR(100),
ba_nom VARCHAR(150),
ba_prenom VARCHAR(150),
ba_commentaire TEXT,
ba_isDeleted BIT
)
GO
CREATE TABLE ReponseMessage
(
rm_id INT PRIMARY KEY IDENTITY(1,1),
rm_titre VARCHAR(150),
rm_reponsemessage TEXT,
ba_id INT FOREIGN KEY REFERENCES BesoinAide(ba_id),
)
GO
CREATE TABLE Users
(
u_cin VARCHAR(150) PRIMARY KEY,
u_pass VARCHAR(150),
u_cne VARCHAR(150),
u_dtnaiss DATE,
u_email VARCHAR(150),
u_nom VARCHAR(150),
u_prenom VARCHAR(150),
u_nomAr NVARCHAR(150),
u_prenomAr NVARCHAR(150),
u_adresse TEXT,
u_tel VARCHAR(150),
n_ID INT FOREIGN KEY REFERENCES Nationalite(n_ID),
g_ID INT FOREIGN KEY REFERENCES Genre(g_ID),
u_moyennegenbac FLOAT,
r_ID INT FOREIGN KEY REFERENCES Roles(r_ID),
IsCompleted VARCHAR(150),
IsDeleted BIT
)
GO
CREATE TABLE UserChoice(
uc_ID INT PRIMARY KEY IDENTITY(1,1),
u_cin VARCHAR(150) FOREIGN KEY REFERENCES Users(u_cin),
s_ID INT FOREIGN KEY REFERENCES Scolarite(s_ID),
c_ID INT FOREIGN KEY REFERENCES Categorie(c_ID),
b_ID INT FOREIGN KEY REFERENCES Branche(b_ID),
v_ID INT FOREIGN KEY REFERENCES Ville(v_ID),
e_ID INT FOREIGN KEY REFERENCES Etablissement(e_ID),
tf_ID INT FOREIGN KEY REFERENCES TypeFormation(tf_ID),
nvf_ID INT FOREIGN KEY REFERENCES NvFormation(nvf_ID),
FirstChoice INT FOREIGN KEY REFERENCES Choix(ch_ID),
SecondChoice INT FOREIGN KEY REFERENCES Choix(ch_ID),
ThirdChoice INT FOREIGN KEY REFERENCES Choix(ch_ID),
ChoixAccepter INT FOREIGN KEY REFERENCES Choix(ch_ID)
)
GO
CREATE TABLE UserInformations
(
ui_ID INT PRIMARY KEY IDENTITY(1,1),
u_cin VARCHAR(150) FOREIGN KEY REFERENCES Users(u_cin),
ui_nompere VARCHAR(150),
ui_prenompere VARCHAR(150),
ui_cinpere VARCHAR(150),
ui_nommere VARCHAR(150),
ui_prenommere VARCHAR(150),
ui_cinmere VARCHAR(150),
v_ID INT FOREIGN KEY REFERENCES Ville(v_ID)
)
GO
CREATE TABLE PlanEpreuve
(
pe_id INT PRIMARY KEY IDENTITY(1,1),
pe_epreuve VARCHAR(150),
pe_datedebut VARCHAR(150),
pe_datefin VARCHAR(150),
ch_ID INT FOREIGN KEY REFERENCES Choix(ch_ID) 
)

                                                      /*==============================================================*/
                                                      /*                    Remplissage Des Tables                    */
                                                      /*==============================================================*/

INSERT INTO Roles(r_role) VALUES('STUDENT')
INSERT INTO Roles(r_role) VALUES('ADMIN')
INSERT INTO Roles(r_role) VALUES('DIRECTEUR')


INSERT INTO Genre(g_genre) VALUES('Masculin')
INSERT INTO Genre(g_genre) VALUES('Féminin')


INSERT INTO Nationalite(n_nationalite) VALUES('Marocain')
INSERT INTO Nationalite(n_nationalite) VALUES('Étranger')


INSERT INTO TypeDemande(td_typedemande) VALUES('Demande d’information')
INSERT INTO TypeDemande(td_typedemande) VALUES('Réclamation')
INSERT INTO TypeDemande(td_typedemande) VALUES('Signalement de problème technique')


INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle De Lalla Aicha Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Formation Des Adultes Sidi Moumen Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Essafa Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ain Chock Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Al Massira Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Derb El Kabir Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Maarif Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Zone Industrielle Moulay Rachid Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Recherche Et D’engineering Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Agadir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Formation De Textile Ben M’sik Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Hay El Mohammadi Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Hay Hassani 1 Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Hay Hassani 2 Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Sidi Bernoussi Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée De Gestion Hay El Mohammadi Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Polo Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Assa')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Ain Chok-inara Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée El Hank Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Moulay Rachid Ben M’sik Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Des Techniques D’habillement Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Des Vêtements Derb Ghallef Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise Dans Les Métiers De Transport Agadir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise Dans Les Métiers De Transport Routier Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Gestion Et D’informatique Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De L’hôtellerie Et De La Restauration Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Arts Graphiques Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée De Confection Sidi Maarouf Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée De Gestion Sidi Moumen Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Génie Mécanique Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Inter-entreprise Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Ntic Route Aéroport Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Roches Noires Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Sidi Maarouf Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Sidi Moumen Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise Des Métiers Du Cuir Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise Du Bâtiment Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise En Fabrication Des Matières Plastiques Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise En Fabrication Des Produits Agroalimentaires Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise Génie Thermique Et Froid Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise Industriel Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialises Formation De L’industrie Meunière Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Ain Borja Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise En Tannerie Et Traitement Du Cuir Sidi Bernoussi Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Hay Nahda Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Hay Riad Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée NTIC Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie AppliquéeG Yacoub El Mansour Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Safi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Chmaou Salé')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Hay Salam Salé')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Lamkinsia Salé')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Multisectoriel Salé')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Sala Al Jadida')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Sefrou')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Sidi Ifni')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Sidi Kacem')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Sidi Slimane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Smara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée SoukSebt')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée TC Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Ibn Marhal Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée NTIC Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Route Aéroport Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Zone Libre Echange Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Al Oubour Tantan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Taounate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Tourirt')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Taroudant')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Tata')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Taza')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Ain Aouda Temara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Ain AtiQ Temara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Multisectoriel Temara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Temara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Route Aéroport Tetouan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Route Sebta Tetouan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Saniat R’mel Tetouan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Tetouan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Tinghir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Tiznit')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée NTIC Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée NTIC Sidi Maarouf')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée NTIC Route Aéroport Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Roches Noires Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Sidi Bernoussi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Sidi Moumen')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Mohamed El Fassi Errachidia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Nargiss Fès')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Route Imouzer Fès')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée NTIC Guelmime')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Tassila Inezgane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée TC Daoudiate Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée NTIC Sidi Youssef Ben Ali')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Route Agouray Meknès Institut Spécialise De Technologie Appliquée Midelt')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Mirleft')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Missour')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Mohammedia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Nador')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Ouarzazate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Ouazzane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Oued Zem')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialise De Technologie Appliquée Sidi Maafa Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De L’hôtellerie Et De La Restauration Agadir L’hôtellerie L’hôtellerie')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Agadir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée En Hôtellerie Et De Tourisme Founty Agadir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Ahfir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Biougra ait baha')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Al Hoceima')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie En Hôtellerie Et De Tourisme')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Al Hoceima')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Azemmour')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie En Hotellerie Et De Tourisme El Haouzia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Azilal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Azrou')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ouled Mrah')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ben Ahmed')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Bengrir')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Ben Slimane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Gestion Et D’informatique Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ntic Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie En Hotellerie Et De Tourisme Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Berkane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Berkane')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Des Metiers De Confection Berrechid')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Berrchid')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé En Techniques Informatiques commerce Et Gestion Berrchid')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Bouarfa')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Boujaad')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Boujdour')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Boujniba')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Bouznika')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Chafchaouen')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Chafchaouen')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Chichaoua')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Dakhla')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professsinnelle Demnate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée El Brouj')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De qualification Professionnelle El Jadida')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Al Massira El Jadida')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Cite De L’air El Jadida')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée El Karia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Mohamed El Fassi Errachidia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Erfoud')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Essaouira')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie En Hôtellerie Et De Tourisme Essaouira')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Al Adarissa Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Formation Et D’encadrement Des Enfants Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Perfectionnement Des Artisans Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Route Imouzer Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Formation Aux Métiers De L’action Sociale Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Bab Ftouh Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée De Confection Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée De Gestion Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Hay Al Adarissa Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Nargiss Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Route Imouzer Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé Des Métiers Traditionnels Du Bâtiment Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Figuig')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Fquih Ben Salah')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Goulmima')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Guelmim')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De L’hôtellerie Et De Tourisme Guelmim')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ntic Guelmim')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Guercif')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Had Soualem')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée El Hajeb')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Hattane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ifrane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Tassila')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Jerrada')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Saknia Kenitra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Sebou Kenitra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Batiment Et Travaux Publics Kenitra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Industriel Maamora Kenitra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Maamora Kenitra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Kalaa-sraghna')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Khemisset')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Khenifra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Khenifra')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Bd Driss 1 Er Khouribga')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Quartier Administratif Khouribga')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Gestion Et D’informatique Khouribga')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Khouribga')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ksbat Tadla')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ksar El Kebir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Gestion Et D’informatique Laayoune')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De L’hôtellerie Et De La Restauration Laayoune')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Laayoune')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Larache')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Mechraa Belksiri')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Al Massira Daoudiate Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Azli Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Gestion Et D’informatique Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De L’hôtellerie Et De La Restauration Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Bab Dokkala Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée De Textile Et De Confection Daoudiate Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Jbel Lakhdar Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Maintenance Hoteliere Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ntic Sidi Youssef Ben Ali Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé Industriel Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Mediouna Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Sidi Baba Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Avenue Des F.a.r Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée De Gestion Bab Tizimi Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Route Agouray Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie En Hotellerie Et De Tourisme Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Route Agouray Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Midelt')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Missour')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Port-Mohammedia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Yassmina Mohammedia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Mohammedia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé Industriel Mohammedia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Moulay Driss Zerhoune')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Mrirt')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Kissariat Nador')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Al Aaroui Nador')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Laarassi Nador')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Nador')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ouaouizerth')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Formation Des Metiers Du Cinema Ouarzazate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ouarzazate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ouazzane')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle 2 Oued Zem')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle 1 Oued Zem')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Oued Zem')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Annasr Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ennahda Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ennajd Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De L’hôtellerie Et De La Restauration Omar Ben Omar Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée El Aounia Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Koulouche Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Lazaret Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Hotellerie Restauration Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée De Gestion Yacoub El Mansour Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Confection Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée De Gestion Yacoub El Mansour Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Hay Nahda Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Hay Riad Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ntic Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualificatin Professionnelle Sidi Ouassel Safi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée 1 Safi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée 2 Safi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ntic Safi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Confection Sale')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Chmaou Sale')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Hay Salam Sale')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Lamkinsia Sale')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Sefrou')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Sefrou')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ain Chock Rhal Elmeskini Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Sidi Abdelkrim Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée 1 Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée 2 Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Route Sidi Bennour')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Sidi Kacem')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Sidi Slimane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Smara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Souk Sebt')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ain Aouda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ain Atique')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Temara')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Tahannaout')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre D’insertion Essabil Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Beni Makada Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Confection Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Ntic Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé Dans Les Metiers De Transport Routier Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Ibn Marhal Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Route Aeroport Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Zone Libre Echange Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée De Textile -confection Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De L’hôtellerie Et De La Restauration Tantan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Oubour Tantan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Taounate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Taourirt')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Taroudant')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Taroudant')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Tata')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Formation Des Arts Culinaires Taza')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée De Confection Taza')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Taza')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Taza')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Tetouan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie En Hotellerie Et De Tourisme Tamuda Bay Madiq')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Tiflet')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliquée Tinghir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Tiznit')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Spécialisé De Technologie Appliquée Youssoufia')


INSERT INTO Ville(v_ville) VALUES('Casablanca')
INSERT INTO Ville(v_ville) VALUES('Agadir')
INSERT INTO Ville(v_ville) VALUES('Rabat')
INSERT INTO Ville(v_ville) VALUES('Safi')
INSERT INTO Ville(v_ville) VALUES('Sala Aljadida')
INSERT INTO Ville(v_ville) VALUES('Sefrou')
INSERT INTO Ville(v_ville) VALUES('Settat')
INSERT INTO Ville(v_ville) VALUES('Ifni')
INSERT INTO Ville(v_ville) VALUES('Smara')
INSERT INTO Ville(v_ville) VALUES('Sidi Kacem')
INSERT INTO Ville(v_ville) VALUES('SoukSebt')
INSERT INTO Ville(v_ville) VALUES('Tanger')
INSERT INTO Ville(v_ville) VALUES('Tantan')
INSERT INTO Ville(v_ville) VALUES('Taounate')
INSERT INTO Ville(v_ville) VALUES('Tourirt')
INSERT INTO Ville(v_ville) VALUES('Taroudant')
INSERT INTO Ville(v_ville) VALUES('Tata')
INSERT INTO Ville(v_ville) VALUES('Taza')
INSERT INTO Ville(v_ville) VALUES('Ain Aouda')
INSERT INTO Ville(v_ville) VALUES('Ain AtiQ')
INSERT INTO Ville(v_ville) VALUES('Tinghir')
INSERT INTO Ville(v_ville) VALUES('Tiznit')
INSERT INTO Ville(v_ville) VALUES('Beni Mellal')
INSERT INTO Ville(v_ville) VALUES('Errachidia')
INSERT INTO Ville(v_ville) VALUES('Fès')
INSERT INTO Ville(v_ville) VALUES('Guelmime')
INSERT INTO Ville(v_ville) VALUES('Inezgane')
INSERT INTO Ville(v_ville) VALUES('Marrakech')
INSERT INTO Ville(v_ville) VALUES('Sidi Youssef Ben Ali')
INSERT INTO Ville(v_ville) VALUES('Meknès')
INSERT INTO Ville(v_ville) VALUES('Midelt')
INSERT INTO Ville(v_ville) VALUES('Mirleft')
INSERT INTO Ville(v_ville) VALUES('Missour')
INSERT INTO Ville(v_ville) VALUES('Mohammedia')
INSERT INTO Ville(v_ville) VALUES('Nador')
INSERT INTO Ville(v_ville) VALUES('Ouarzazate')
INSERT INTO Ville(v_ville) VALUES('Ouazzane')
INSERT INTO Ville(v_ville) VALUES('Oued Zem')
INSERT INTO Ville(v_ville) VALUES('Oujda')
INSERT INTO Ville(v_ville) VALUES('Ahfir')
INSERT INTO Ville(v_ville) VALUES('ait baha')
INSERT INTO Ville(v_ville) VALUES('Al Hoceima')
INSERT INTO Ville(v_ville) VALUES('Azemmour')
INSERT INTO Ville(v_ville) VALUES('Azilal')
INSERT INTO Ville(v_ville) VALUES('Azrou')
INSERT INTO Ville(v_ville) VALUES('ben hmed')
INSERT INTO Ville(v_ville) VALUES('Bengrir')
INSERT INTO Ville(v_ville) VALUES('Berkane')
INSERT INTO Ville(v_ville) VALUES('Berrechid')
INSERT INTO Ville(v_ville) VALUES('Bouarfa')
INSERT INTO Ville(v_ville) VALUES('Boujaad')
INSERT INTO Ville(v_ville) VALUES('Boujdour')
INSERT INTO Ville(v_ville) VALUES('Boujniba')
INSERT INTO Ville(v_ville) VALUES('Bouznika')
INSERT INTO Ville(v_ville) VALUES('Chafchaouen')
INSERT INTO Ville(v_ville) VALUES('Chichaoua')
INSERT INTO Ville(v_ville) VALUES('Dakhla')
INSERT INTO Ville(v_ville) VALUES('Demnate')
INSERT INTO Ville(v_ville) VALUES('El Brouj')
INSERT INTO Ville(v_ville) VALUES('El Jadida')
INSERT INTO Ville(v_ville) VALUES('Errachidia')
INSERT INTO Ville(v_ville) VALUES('Erfoud')
INSERT INTO Ville(v_ville) VALUES('Essaouira')
INSERT INTO Ville(v_ville) VALUES('Figuig')
INSERT INTO Ville(v_ville) VALUES('Ben Salah')
INSERT INTO Ville(v_ville) VALUES('Goulmima')
INSERT INTO Ville(v_ville) VALUES('Guercif')
INSERT INTO Ville(v_ville) VALUES('Had Soualem')
INSERT INTO Ville(v_ville) VALUES('El Hajeb')
INSERT INTO Ville(v_ville) VALUES('Hattane')
INSERT INTO Ville(v_ville) VALUES('Ifrane')
INSERT INTO Ville(v_ville) VALUES('Jerrada')
INSERT INTO Ville(v_ville) VALUES('Kenitra')
INSERT INTO Ville(v_ville) VALUES('Kalaa-sraghna')
INSERT INTO Ville(v_ville) VALUES('Khemisset')
INSERT INTO Ville(v_ville) VALUES('Khenifra')
INSERT INTO Ville(v_ville) VALUES('Khouribga')
INSERT INTO Ville(v_ville) VALUES('Ksbat Tadla')
INSERT INTO Ville(v_ville) VALUES('Laayoune')
INSERT INTO Ville(v_ville) VALUES('Larache')
INSERT INTO Ville(v_ville) VALUES('Mechraa Belksiri')
INSERT INTO Ville(v_ville) VALUES('Missour')
INSERT INTO Ville(v_ville) VALUES('Mohammedia')
INSERT INTO Ville(v_ville) VALUES('Moulay Driss Zerhoune')
INSERT INTO Ville(v_ville) VALUES('Mrirt')
INSERT INTO Ville(v_ville) VALUES('Nador')
INSERT INTO Ville(v_ville) VALUES('Ouaouizerth')
INSERT INTO Ville(v_ville) VALUES('Oued Zem')
INSERT INTO Ville(v_ville) VALUES('Sale')
INSERT INTO Ville(v_ville) VALUES('Sidi Bennour')
INSERT INTO Ville(v_ville) VALUES('Sidi Slimane')
INSERT INTO Ville(v_ville) VALUES('Smara')
INSERT INTO Ville(v_ville) VALUES('Tahannaout')
INSERT INTO Ville(v_ville) VALUES('Tantan')
INSERT INTO Ville(v_ville) VALUES('Tata')
INSERT INTO Ville(v_ville) VALUES('Taza')
INSERT INTO Ville(v_ville) VALUES('Tiflet')
INSERT INTO Ville(v_ville) VALUES('Youssoufia')


INSERT INTO Scolarite VALUES('6 ème année primaire')
INSERT INTO Scolarite VALUES('1 ére année de  l''Enseignement  Secondaire Collégial')
INSERT INTO Scolarite VALUES('2 ème année de  l''Enseignement  Secondaire Collégial')
INSERT INTO Scolarite VALUES('Spécialisation')
INSERT INTO Scolarite VALUES('3 ème année de  l''Enseignement  Secondaire Collégial')
INSERT INTO Scolarite VALUES('Tronc Commun Enseignement Secondaire Qualifiant')
INSERT INTO Scolarite VALUES('1 ère Année du Baccalauréat')
INSERT INTO Scolarite VALUES('Qualification')
INSERT INTO Scolarite VALUES('2 ème Année du Baccalauréat')
INSERT INTO Scolarite VALUES('Technicien')
INSERT INTO Scolarite VALUES('En cours de préparation du bac')
INSERT INTO Scolarite VALUES('Baccalauréat')
INSERT INTO Scolarite VALUES('Bac+2')
INSERT INTO Scolarite VALUES('Bac+3')
INSERT INTO Scolarite VALUES('Bac+4')
INSERT INTO Scolarite VALUES('Bac+5')


INSERT INTO Categorie VALUES('Littéraire')
INSERT INTO Categorie VALUES('Scientifique')
INSERT INTO Categorie VALUES('Technique Gestion')
INSERT INTO Categorie VALUES('Technique Scientifique')
INSERT INTO Categorie VALUES('Bac Pro (Scientifique)')
INSERT INTO Categorie VALUES('Bac Pro (Littéraire)')


INSERT INTO Branche VALUES('Lettre moderne')
INSERT INTO Branche VALUES('Sciences humaines')
INSERT INTO Branche VALUES('Sciences agronomiques')
INSERT INTO Branche VALUES('Sciences de la vie et de la terre')
INSERT INTO Branche VALUES('Sciences math (A ou B)')
INSERT INTO Branche VALUES('Sciences physiques et chimie')
INSERT INTO Branche VALUES('Sciences de gestion administrative')
INSERT INTO Branche VALUES('Sciences de gestion comptable')
INSERT INTO Branche VALUES('Sciences économiques')
INSERT INTO Branche VALUES('Arts appliqués')
INSERT INTO Branche VALUES('Arts graphiques')
INSERT INTO Branche VALUES('Chimie industrielle')
INSERT INTO Branche VALUES('Electronique')
INSERT INTO Branche VALUES('Sciences Agricoles')
INSERT INTO Branche VALUES('Sciences et technologies électriques')
INSERT INTO Branche VALUES('Sciences et technologies mécaniques')
INSERT INTO Branche VALUES('Agricole')
INSERT INTO Branche VALUES('Arts et Techniques du Bois')
INSERT INTO Branche VALUES('Construction Aéronautique')
INSERT INTO Branche VALUES('Construction Métallique')
INSERT INTO Branche VALUES('Dessin de Bâtiment')
INSERT INTO Branche VALUES('Electrotechnique, Equipements Communicants')
INSERT INTO Branche VALUES('Fabrication Mécanique')
INSERT INTO Branche VALUES('Froid et Conditionnement d’Air')
INSERT INTO Branche VALUES('Gros Œuvres du Bâtiment')
INSERT INTO Branche VALUES('Maintenance de Véhicules Automobiles Option : Voitures')
INSERT INTO Branche VALUES('Arts Culinaires & Service de Restauration')
INSERT INTO Branche VALUES('Commerce')
INSERT INTO Branche VALUES('Comptabilité')
INSERT INTO Branche VALUES('Logistique')
INSERT INTO Branche VALUES('Stylisme - Modélisme')


INSERT INTO TypeFormation VALUES('Diplômante')
INSERT INTO TypeFormation VALUES('Qualifiante')


INSERT INTO NvFormation VALUES('Technicien spécialisé')
INSERT INTO NvFormation VALUES('Qualification')
INSERT INTO NvFormation VALUES('Spécialisation')
INSERT INTO NvFormation VALUES('Technicien')


INSERT INTO Choix VALUES('Gestion des Entreprises ')
INSERT INTO Choix VALUES('Développement Digital ')
INSERT INTO Choix VALUES('Infrastructure Digitale ')
INSERT INTO Choix VALUES('Technicien Spécialisé Bureau Etude en Construction Métallique')
INSERT INTO Choix VALUES('Techniques Habillement Industrialisation ')
INSERT INTO Choix VALUES('Educateur Spécialisé dans la Petite Enfance ')
INSERT INTO Choix VALUES('Menuiserie ')
INSERT INTO Choix VALUES('Electricité Entretien Industriel')
INSERT INTO Choix VALUES('Réparateur de Véhicules Automobiles')
INSERT INTO Choix VALUES('Opérateur Qualifié en Coupe et Couture industrielle')
INSERT INTO Choix VALUES('Menuiserie Aluminium')
INSERT INTO Choix VALUES('Assistant Administratif')
INSERT INTO Choix VALUES('MenuiTechnicien en Réparation des Engins à Moteur (Option: Automobile) serie')
INSERT INTO Choix VALUES('Technicien en Electricité de Maintenance Industrielle')