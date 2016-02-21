using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Compression;
using System.IO;

namespace FichiersZip
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelCheck.Visible = false;
            LabelFc1.Visible = false;
            LabelFc2.Visible = false;
        }

        protected void ButtonEnvoyer_Click1(object sender, EventArgs e)
        {
            //On créer un nom d'archive
            string nomArchive = NouveauNomArchive(TextBoxNom.Text, TextBoxPrenom.Text);

            //Si les deux fileupload sont remplis
            //1.0
            if (CombienDeFichier(FileUpload1, FileUpload2) == 2)
            {
                if (CheckBox1.Checked)
                {
                    LabelCheck.Text = "Erreur vous avez coché la case, 'je ne telecharge pas de fichier'";
                    LabelCheck.Visible = true;
                }
                else
                { 
                string NewNameFc2 = FileUpload2.FileName;
                if (FileUpload1.FileName == FileUpload2.FileName)
                {
                    NewNameFc2 = ChangerNomFichier();
                }
                
                if (ExtensionAutorise(FileUpload1))
                {
                    //Si le fichier fait moins de 3MO / ContentLength est en octet
                    if (FileUpload1.PostedFile.ContentLength < 3100000)
                    {
                        CreerUneArchiveFc(nomArchive, FileUpload1, FileUpload1.FileName);
                        SupprimerUnFichier(FileUpload1.FileName);
                        //SupprimerUnFichier(FileUpload1.FileName);

                    }
                    else
                    {
                        LabelFc1.Text = "La taille du fichier 1 dépasse la limite autorisé";
                        LabelFc1.Visible = true;
                    }
                }
                else
                {
                    LabelFc1.Text = "Le fichier 1 n'a pas une extension autorisé";
                    LabelFc1.Visible = true;
                }

                if (ExtensionAutorise(FileUpload2))
                {
                    //Si le fichier fait moins de 3MO / ContentLength est en octet
                    if (FileUpload2.PostedFile.ContentLength < 3100000)
                    {
                        CreerUneArchiveFc(nomArchive, FileUpload2, NewNameFc2);
                        SupprimerUnFichier(NewNameFc2);
                        SaveZipSql(nomArchive);
                    }
                    else
                    {
                        LabelFc2.Text = "La taille du fichier 2 dépasse la limite autorisé";
                        LabelFc2.Visible = true;
                    }
                }
                else
                {
                    LabelFc2.Text = "Le fichier 2 n'a pas une extension autorisé";
                    LabelFc2.Visible = true;
                }
                
                }

            }
            //Si le FileUpload1 contient un fichier
            else if (CombienDeFichier(FileUpload1, FileUpload2) == 1)
            {
                if (CheckBox1.Checked)
                {
                    LabelCheck.Text = "Erreur vous avez coché la case, 'je ne telecharge pas de fichier'";
                    LabelCheck.Visible = true;
                }
                else
                { 
                if (ExtensionAutorise(FileUpload1))
                    {
                        //Si le fichier fait moins de 3MO / ContentLength est en octet
                        if (FileUpload1.PostedFile.ContentLength < 3100000)
                        {
                            CreerUneArchiveFc(nomArchive, FileUpload1, FileUpload1.FileName);
                            SupprimerUnFichier(FileUpload1.FileName);

                            SaveZipSql(nomArchive);
                        }
                    else
                    {
                        LabelFc1.Text = "La taille du fichier 1 dépasse la limite autorisé";
                        LabelFc1.Visible = true;
                    }                 
                }
                else
                {
                    LabelFc1.Text = "Le fichier 1 n'a pas une extension autorisé";
                    LabelFc1.Visible = true;
                }
                }
 
            }
            else
            {
                if (CheckBox1.Checked && FileUpload2.HasFile)
                {
                    LabelCheck.Text = "Erreur Vous avez choisi de ne pas télécharger de fichier";
                    LabelCheck.Visible = true;
                }
                else if (CheckBox1.Checked)
                {
                    ;
                }
                else
                {
                    Response.Write("Erreur Le fichier 1 n'est pas rempli");
                }    
            }
        }

        //methode pour donner un nom unique à une archive
        private string NouveauNomArchive(string nom, string prenom)
        {
            string rechercheNom = nom.ToString().Substring(0, 3).ToLower();
            string recherchePrenom = prenom.ToString().Substring(0, 3).ToLower();
            //nom par défaut pour l'archive
            string nomArchive = "";
            while (nomArchive == "" || BL.BlZip.ExistZip(nomArchive))
            {
                Random nbrr = new Random(DateTime.Now.Millisecond);
                int nbr10 = nbrr.Next(1, 6000);
                nomArchive = 0 + "_" + nbr10 + "_" + rechercheNom + "_" + recherchePrenom + "_" + ".zip";


            }
            return nomArchive;
        }

        //methode pour savoir combien on a de fichier
        //1.0
        private int CombienDeFichier(FileUpload Fc1, FileUpload Fc2)
        {
            if (FileUpload1.HasFile && FileUpload2.HasFile)
            {
                return 2;
            }
            else if (FileUpload1.HasFile)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //methode pour supprimer un fichier
        private void SupprimerUnFichier(string fichier)
        {
            //Etape3: Supression du fichier
            //La variable path contient le chemin relatif du dossier dans lequel est enregistré le fichier
            string path = Server.MapPath("//fichiers/");

            //La varible fc1 contient le nom du fichier
            string fc1 = fichier.ToString();

            //On créer un tableau qui contient le nom de tous les fichiers présent dans notre dossier
            string[] tab = Directory.GetFiles(path);

            //On liste tous les fichiers
            foreach (string filename in tab)
            {
                //On recupere le nom sans l'URL
                string result = System.IO.Path.GetFileName(filename);

                //Si notre fichier existe
                if (fc1 == result)
                {
                    //On supprime le fichier
                    System.IO.File.Delete(path + fc1);
                }
            }
        }

        //methode pour creer une archive et mettre le fichier dedans FC1
        private void CreerUneArchiveFc(string nomArchive, FileUpload FileUploadActuel, string nom)
        {
            //Etape1: Depot du fichier
            //On Enregistre le fichier dans le dossier fichiers
            FileUploadActuel.SaveAs(MapPath("//fichiers/" + nom));

            //La variable zipPath contient l'emplacement de l'archive zip ainsi que le nom qu'on lui donne
            string zipPath = @"E:\___Projets - Visual Studios\En cours\Asp.net\FichiersZip\2016.01.15 - FichierZip\FichiersZip\fichiers\" + nomArchive;

            //La variable newFile contient le chemin absolu + le nom de notre fichier
            string newFile = @"E:\___Projets - Visual Studios\En cours\Asp.net\FichiersZip\2016.01.15 - FichierZip\FichiersZip\fichiers\" + nom;

            //On créer et on ouvre l'archive en mode "update"
            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
            {
                //On ajoute le fichier à notre archive
                archive.CreateEntryFromFile(newFile, nom);
                Response.Write("Fichier ajouté à l'archive");
            }
        }

        //methode pour changer le nom du fichier2
        private string ChangerNomFichier()
        {
            Response.Write("Les deux fichiers ont le même nom");
            //on  créer une variable qui contient le filename du FC2
            string NewNameFc2 = FileUpload2.FileName;
            //boucle pour changer le nom
            do
            {

                Random nbr = new Random(DateTime.Now.Millisecond);
                int nbr1 = nbr.Next(1, 6000);
                NewNameFc2 = nbr1 + NewNameFc2;
            } while (FileUpload1.FileName == NewNameFc2);
            Response.Write("Les deux fichiers n'ont plus le même nom");

            return NewNameFc2;
        }

        //methode pour savoir si l'extension est autorisé
        private bool ExtensionAutorise(FileUpload FC)
        {
            //Tableau des extensions qui ne sont pas autorisés
            string[] fichierPasAutorise = { ".mp3", ".mp4", ".mov", ".avi", ".fla", ".gif", ".exe", ".asp", ".bat", ".html", ".htm", ".aspx", ".js", ".css", ".bash", ".sh" };
            bool autorise = true;
            //Boucle qui permet de savoir si
            for (int i = 0; i < fichierPasAutorise.Length && autorise; i++)
            {
                if (Path.GetExtension(FC.FileName) == fichierPasAutorise[i])
                {
                    autorise = false;
                }
            }
            return autorise;
        }

        //méthode pour enregistrer le nom de l'archive zip dans la BDD SQL
        private void SaveZipSql(string nomArchive)
        {
            BO.FichiersZip boZip = new BO.FichiersZip();

            boZip.NomZip = nomArchive.ToString();
            BL.BlZip.InsertFichiersZip(boZip);
        }

    }
}


