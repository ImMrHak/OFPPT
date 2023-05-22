                                                      /*==============================================================*/
                                                      /*                      Nom de SGBD :  OFPPT                    */
                                                      /*             Date de cr�ation :  22/05/2022 19:55:30          */
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
                                                      /*                Cr�ation De La Base Des Donn�es              */
                                                      /*==============================================================*/

CREATE DATABASE OFPPT
GO
USE OFPPT
GO

                                                      /*==============================================================*/
                                                      /*                      Cr�ation Des Tables                     */
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
g_genre VARCHAR(150) CHECK(g_genre IN('Masculin','F�minin'))
)
GO
CREATE TABLE Nationalite
(
n_ID INT PRIMARY KEY IDENTITY(1,1),
n_nationalite VARCHAR(150) CHECK(n_nationalite IN('Marocain','�tranger'))
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
INSERT INTO Genre(g_genre) VALUES('F�minin')


INSERT INTO Nationalite(n_nationalite) VALUES('Marocain')
INSERT INTO Nationalite(n_nationalite) VALUES('�tranger')


INSERT INTO TypeDemande(td_typedemande) VALUES('Demande d�information')
INSERT INTO TypeDemande(td_typedemande) VALUES('R�clamation')
INSERT INTO TypeDemande(td_typedemande) VALUES('Signalement de probl�me technique')


INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle De Lalla Aicha Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Formation Des Adultes Sidi Moumen Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Essafa Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ain Chock Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Al Massira Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Derb El Kabir Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Maarif Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Zone Industrielle Moulay Rachid Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Recherche Et D�engineering Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Agadir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Formation De Textile Ben M�sik Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Hay El Mohammadi Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Hay Hassani 1 Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Hay Hassani 2 Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Sidi Bernoussi Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e De Gestion Hay El Mohammadi Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Polo Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Assa')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Ain Chok-inara Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e El Hank Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Moulay Rachid Ben M�sik Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Des Techniques D�habillement Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Des V�tements Derb Ghallef Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise Dans Les M�tiers De Transport Agadir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise Dans Les M�tiers De Transport Routier Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Gestion Et D�informatique Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De L�h�tellerie Et De La Restauration Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Arts Graphiques Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e De Confection Sidi Maarouf Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e De Gestion Sidi Moumen Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e G�nie M�canique Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Inter-entreprise Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Ntic Route A�roport Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Roches Noires Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Sidi Maarouf Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Sidi Moumen Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise Des M�tiers Du Cuir Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise Du B�timent Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise En Fabrication Des Mati�res Plastiques Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise En Fabrication Des Produits Agroalimentaires Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise G�nie Thermique Et Froid Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise Industriel Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialises Formation De L�industrie Meuni�re Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Ain Borja Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise En Tannerie Et Traitement Du Cuir Sidi Bernoussi Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Hay Nahda Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Hay Riad Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e NTIC Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�eG Yacoub El Mansour Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Safi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Chmaou Sal�')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Hay Salam Sal�')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Lamkinsia Sal�')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Multisectoriel Sal�')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Sala Al Jadida')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Sefrou')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Sidi Ifni')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Sidi Kacem')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Sidi Slimane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Smara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e SoukSebt')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e TC Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Ibn Marhal Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e NTIC Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Route A�roport Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Zone Libre Echange Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Al Oubour Tantan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Taounate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Tourirt')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Taroudant')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Tata')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Taza')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Ain Aouda Temara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Ain AtiQ Temara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Multisectoriel Temara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Temara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Route A�roport Tetouan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Route Sebta Tetouan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Saniat R�mel Tetouan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Tetouan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Tinghir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Tiznit')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e NTIC Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e NTIC Sidi Maarouf')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e NTIC Route A�roport Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Roches Noires Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Sidi Bernoussi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Sidi Moumen')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Mohamed El Fassi Errachidia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Nargiss F�s')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Route Imouzer F�s')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e NTIC Guelmime')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Tassila Inezgane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e TC Daoudiate Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e NTIC Sidi Youssef Ben Ali')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Route Agouray Mekn�s Institut Sp�cialise De Technologie Appliqu�e Midelt')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Mirleft')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Missour')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Mohammedia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Nador')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Ouarzazate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Ouazzane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Oued Zem')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialise De Technologie Appliqu�e Sidi Maafa Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De L�h�tellerie Et De La Restauration Agadir L�h�tellerie L�h�tellerie')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Agadir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e En H�tellerie Et De Tourisme Founty Agadir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Ahfir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Biougra ait baha')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Al Hoceima')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie En H�tellerie Et De Tourisme')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Al Hoceima')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Azemmour')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie En Hotellerie Et De Tourisme El Haouzia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Azilal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Azrou')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ouled Mrah')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ben Ahmed')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Bengrir')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Ben Slimane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Gestion Et D�informatique Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ntic Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie En Hotellerie Et De Tourisme Beni Mellal')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Berkane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Berkane')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Des Metiers De Confection Berrechid')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Berrchid')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� En Techniques Informatiques commerce Et Gestion Berrchid')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Bouarfa')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Boujaad')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Boujdour')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Boujniba')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Bouznika')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Chafchaouen')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Chafchaouen')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Chichaoua')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Dakhla')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professsinnelle Demnate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e El Brouj')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De qualification Professionnelle El Jadida')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Al Massira El Jadida')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Cite De L�air El Jadida')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e El Karia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Mohamed El Fassi Errachidia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Erfoud')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Essaouira')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie En H�tellerie Et De Tourisme Essaouira')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Al Adarissa Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Formation Et D�encadrement Des Enfants Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Perfectionnement Des Artisans Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Route Imouzer Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Formation Aux M�tiers De L�action Sociale Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Bab Ftouh Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e De Confection Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e De Gestion Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Hay Al Adarissa Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Nargiss Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Route Imouzer Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� Des M�tiers Traditionnels Du B�timent Fes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Figuig')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Fquih Ben Salah')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Goulmima')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Guelmim')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De L�h�tellerie Et De Tourisme Guelmim')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ntic Guelmim')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Guercif')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Had Soualem')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e El Hajeb')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Hattane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ifrane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Tassila')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Jerrada')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Saknia Kenitra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Sebou Kenitra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Batiment Et Travaux Publics Kenitra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Industriel Maamora Kenitra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Maamora Kenitra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Kalaa-sraghna')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Khemisset')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Khenifra')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Khenifra')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Bd Driss 1 Er Khouribga')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Quartier Administratif Khouribga')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Gestion Et D�informatique Khouribga')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Khouribga')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ksbat Tadla')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ksar El Kebir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Gestion Et D�informatique Laayoune')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De L�h�tellerie Et De La Restauration Laayoune')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Laayoune')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Larache')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Mechraa Belksiri')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Al Massira Daoudiate Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Azli Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Gestion Et D�informatique Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De L�h�tellerie Et De La Restauration Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Bab Dokkala Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e De Textile Et De Confection Daoudiate Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Jbel Lakhdar Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Maintenance Hoteliere Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ntic Sidi Youssef Ben Ali Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� Industriel Marrakech')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Mediouna Casablanca')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Sidi Baba Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Avenue Des F.a.r Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e De Gestion Bab Tizimi Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Route Agouray Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie En Hotellerie Et De Tourisme Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Route Agouray Meknes')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Midelt')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Missour')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Port-Mohammedia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Yassmina Mohammedia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Mohammedia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� Industriel Mohammedia')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Moulay Driss Zerhoune')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Mrirt')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Kissariat Nador')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Al Aaroui Nador')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Laarassi Nador')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Nador')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ouaouizerth')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Formation Des Metiers Du Cinema Ouarzazate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ouarzazate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ouazzane')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle 2 Oued Zem')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle 1 Oued Zem')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Oued Zem')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Annasr Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ennahda Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ennajd Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De L�h�tellerie Et De La Restauration Omar Ben Omar Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e El Aounia Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Koulouche Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Lazaret Oujda')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Hotellerie Restauration Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e De Gestion Yacoub El Mansour Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Confection Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e De Gestion Yacoub El Mansour Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Hay Nahda Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Hay Riad Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ntic Rabat')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualificatin Professionnelle Sidi Ouassel Safi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e 1 Safi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e 2 Safi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ntic Safi')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Confection Sale')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Chmaou Sale')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Hay Salam Sale')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Lamkinsia Sale')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Sefrou')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Sefrou')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Ain Chock Rhal Elmeskini Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Sidi Abdelkrim Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e 1 Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e 2 Settat')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Route Sidi Bennour')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Sidi Kacem')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Sidi Slimane')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Smara')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Souk Sebt')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ain Aouda')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ain Atique')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Temara')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Tahannaout')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre D�insertion Essabil Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Beni Makada Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Confection Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre Mixte De Formation Professionnelle Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Ntic Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� Dans Les Metiers De Transport Routier Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Ibn Marhal Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Route Aeroport Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Zone Libre Echange Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e De Textile -confection Tanger')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De L�h�tellerie Et De La Restauration Tantan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Oubour Tantan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Taounate')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Taourirt')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Taroudant')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Taroudant')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Tata')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Formation Des Arts Culinaires Taza')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e De Confection Taza')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Taza')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Taza')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Tetouan')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie En Hotellerie Et De Tourisme Tamuda Bay Madiq')
INSERT INTO Etablissement(e_etablissement) VALUES('Centre De Qualification Professionnelle Tiflet')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut De Technologie Appliqu�e Tinghir')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Tiznit')
INSERT INTO Etablissement(e_etablissement) VALUES('Institut Sp�cialis� De Technologie Appliqu�e Youssoufia')


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
INSERT INTO Ville(v_ville) VALUES('F�s')
INSERT INTO Ville(v_ville) VALUES('Guelmime')
INSERT INTO Ville(v_ville) VALUES('Inezgane')
INSERT INTO Ville(v_ville) VALUES('Marrakech')
INSERT INTO Ville(v_ville) VALUES('Sidi Youssef Ben Ali')
INSERT INTO Ville(v_ville) VALUES('Mekn�s')
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


INSERT INTO Scolarite VALUES('6 �me ann�e primaire')
INSERT INTO Scolarite VALUES('1 �re ann�e de  l''Enseignement  Secondaire Coll�gial')
INSERT INTO Scolarite VALUES('2 �me ann�e de  l''Enseignement  Secondaire Coll�gial')
INSERT INTO Scolarite VALUES('Sp�cialisation')
INSERT INTO Scolarite VALUES('3 �me ann�e de  l''Enseignement  Secondaire Coll�gial')
INSERT INTO Scolarite VALUES('Tronc Commun Enseignement Secondaire Qualifiant')
INSERT INTO Scolarite VALUES('1 �re Ann�e du Baccalaur�at')
INSERT INTO Scolarite VALUES('Qualification')
INSERT INTO Scolarite VALUES('2 �me Ann�e du Baccalaur�at')
INSERT INTO Scolarite VALUES('Technicien')
INSERT INTO Scolarite VALUES('En cours de pr�paration du bac')
INSERT INTO Scolarite VALUES('Baccalaur�at')
INSERT INTO Scolarite VALUES('Bac+2')
INSERT INTO Scolarite VALUES('Bac+3')
INSERT INTO Scolarite VALUES('Bac+4')
INSERT INTO Scolarite VALUES('Bac+5')


INSERT INTO Categorie VALUES('Litt�raire')
INSERT INTO Categorie VALUES('Scientifique')
INSERT INTO Categorie VALUES('Technique Gestion')
INSERT INTO Categorie VALUES('Technique Scientifique')
INSERT INTO Categorie VALUES('Bac Pro (Scientifique)')
INSERT INTO Categorie VALUES('Bac Pro (Litt�raire)')


INSERT INTO Branche VALUES('Lettre moderne')
INSERT INTO Branche VALUES('Sciences humaines')
INSERT INTO Branche VALUES('Sciences agronomiques')
INSERT INTO Branche VALUES('Sciences de la vie et de la terre')
INSERT INTO Branche VALUES('Sciences math (A ou B)')
INSERT INTO Branche VALUES('Sciences physiques et chimie')
INSERT INTO Branche VALUES('Sciences de gestion administrative')
INSERT INTO Branche VALUES('Sciences de gestion comptable')
INSERT INTO Branche VALUES('Sciences �conomiques')
INSERT INTO Branche VALUES('Arts appliqu�s')
INSERT INTO Branche VALUES('Arts graphiques')
INSERT INTO Branche VALUES('Chimie industrielle')
INSERT INTO Branche VALUES('Electronique')
INSERT INTO Branche VALUES('Sciences Agricoles')
INSERT INTO Branche VALUES('Sciences et technologies �lectriques')
INSERT INTO Branche VALUES('Sciences et technologies m�caniques')
INSERT INTO Branche VALUES('Agricole')
INSERT INTO Branche VALUES('Arts et Techniques du Bois')
INSERT INTO Branche VALUES('Construction A�ronautique')
INSERT INTO Branche VALUES('Construction M�tallique')
INSERT INTO Branche VALUES('Dessin de B�timent')
INSERT INTO Branche VALUES('Electrotechnique, Equipements Communicants')
INSERT INTO Branche VALUES('Fabrication M�canique')
INSERT INTO Branche VALUES('Froid et Conditionnement d�Air')
INSERT INTO Branche VALUES('Gros �uvres du B�timent')
INSERT INTO Branche VALUES('Maintenance de V�hicules Automobiles Option : Voitures')
INSERT INTO Branche VALUES('Arts Culinaires & Service de Restauration')
INSERT INTO Branche VALUES('Commerce')
INSERT INTO Branche VALUES('Comptabilit�')
INSERT INTO Branche VALUES('Logistique')
INSERT INTO Branche VALUES('Stylisme - Mod�lisme')


INSERT INTO TypeFormation VALUES('Dipl�mante')
INSERT INTO TypeFormation VALUES('Qualifiante')


INSERT INTO NvFormation VALUES('Technicien sp�cialis�')
INSERT INTO NvFormation VALUES('Qualification')
INSERT INTO NvFormation VALUES('Sp�cialisation')
INSERT INTO NvFormation VALUES('Technicien')


INSERT INTO Choix VALUES('Gestion des Entreprises ')
INSERT INTO Choix VALUES('D�veloppement Digital ')
INSERT INTO Choix VALUES('Infrastructure Digitale ')
INSERT INTO Choix VALUES('Technicien Sp�cialis� Bureau Etude en Construction M�tallique')
INSERT INTO Choix VALUES('Techniques Habillement Industrialisation ')
INSERT INTO Choix VALUES('Educateur Sp�cialis� dans la Petite Enfance ')
INSERT INTO Choix VALUES('Menuiserie ')
INSERT INTO Choix VALUES('Electricit� Entretien Industriel')
INSERT INTO Choix VALUES('R�parateur de V�hicules Automobiles')
INSERT INTO Choix VALUES('Op�rateur Qualifi� en Coupe et Couture industrielle')
INSERT INTO Choix VALUES('Menuiserie Aluminium')
INSERT INTO Choix VALUES('Assistant Administratif')
INSERT INTO Choix VALUES('MenuiTechnicien en R�paration des Engins � Moteur (Option: Automobile) serie')
INSERT INTO Choix VALUES('Technicien en Electricit� de Maintenance Industrielle')