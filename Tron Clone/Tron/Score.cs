using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//pour sauvegarder et ouvrir des fichiers

namespace Tron
{

    public partial class Score : Form
    {

        public Score()
        {
            InitializeComponent();
        }

        public struct listeinit
        {


            public string Nom;//variables pour la liste
            public float Score;
            // remarque : void n'est pas utlisé dans le constructeur
            public listeinit(string Nom, int Score)
            {                
                this.Nom = Nom;
                this.Score = Score;

            }
        }
        //Score ScoreInit;
        //Cree une variable pour la longueur de la liste

        const int NMBRTOT = 100;
        //Déclare un tableau pour heberger les scores
        listeinit[] ListeScore = new listeinit[NMBRTOT];
        //initialise le nombre d'elements.
        int NmbrÉlements = 0;

        //bool ordre = false;
        private void Affiche()
        {//affiche les éléments 
            lstv1.Items.Clear();//efface la liste

            lstv1.View = View.Details;
            lstv1.Columns[0].Text = "Nom/Initiales";
            lstv1.Columns[1].Text = "Score";
           

            for (int i = 0; i < NmbrÉlements; i++)
            {
                ListViewItem Rang = new ListViewItem(ListeScore[i].Nom);
                Rang.SubItems.Add(ListeScore[i].Score.ToString());
                lstv1.Items.Add(Rang);
                //ajoute les valeurs a la liste
            }
        }
        int scoreinitial = 1;//le score initial est de 1

        private void btnVas_Click(object sender, EventArgs e)
        { //Ajoute un nom dans la liste
            int tempsx = Variables.temps;
            bool stringValide = true;
            foreach (char c in txtNom.Text)//Validation des données entrées (accepte un string)
            {
                if (!char.IsLetter(c) || txtNom.Text == "")
                {
                    stringValide = false;
                    return;
                }
            }
            bool NomPreexistant = false;
            if (stringValide == true && txtNom.Text != "")//si l'élement est valide et le texte est pas vide, ajoute a la liste
            {
                if (lstv1.Items.Count >= 1)//si il y a des elements dans la liste,
                {
                    for (int i = 0; i < lstv1.Items.Count; i++)
                    {
                        if (txtNom.Text == lstv1.Items[i].SubItems[0].Text)//verifie si le joueur est deja dans la liste
                        {
                            int scoreCompte = Convert.ToInt32(lstv1.Items[i].SubItems[1].Text);
                            lstv1.Items[i].SubItems[1].Text = (scoreCompte + 1).ToString();
                            NmbrÉlements = NmbrÉlements + 1;

                            NomPreexistant = true;

                        }
                    }
                    if (NomPreexistant == false)//Si l'element n'est pas déja dans la liste, on l'ajoute a la liste
                    {
                        string[] row = { txtNom.Text, scoreinitial.ToString() };
                        var listViewItem = new ListViewItem(row);
                        lstv1.Items.Add(listViewItem);
                        NmbrÉlements = NmbrÉlements + 1;

                        //btnVas.Visible = false;
                        //txtNom.Visible = false;
                        //label1.Visible = false;
                        //btnRecommence.Visible = true;
                        //btnVasAcceuil.Visible = true;
                    }
                }
                else //si il y a pas d'elements dans la liste,
                {
                    //cree un nouveau joueur

                    string[] row = { txtNom.Text, scoreinitial.ToString() };
                    var listViewItem = new ListViewItem(row);
                    lstv1.Items.Add(listViewItem);
                    NmbrÉlements = NmbrÉlements + 1;

                    //btnVas.Visible = false;
                    //txtNom.Visible = false;
                    //label1.Visible = false;
                    //btnRecommence.Visible = true;
                    //btnVasAcceuil.Visible = true;
                }
            }
        }
        private void btnRecommence_Click(object sender, EventArgs e)
        {
            //ferme le form du score et reouvre la form du jeu
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btnVasAcceuil_Click(object sender, EventArgs e)
        { // quand l'utilisateur veut recommencer, efface la form du score et recrée celle de l'écran d'Acceuil
            this.Visible = false;
            Joueur form2 = new Joueur();
            form2.Visible = true;
            Enregistre();
        }

        private void Score_Load(object sender, EventArgs e)
        {
            //Ouvre();
        }

        private void Enregistre()
        {
            //Enregiste la liste automatiquement dans un document text "EnregistreTest.txt"
            string fsl = Environment.CurrentDirectory;
            //File.WriteAllText(fsl + @"\EnregistreTest.txt", String.Empty);
            //declare le chemin pour acceder au fichier txt
            FileStream fls = new FileStream(fsl + "\\EnregistreTest.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            //Déclare l'objet qui fera l'écriture des données dans le fichier
            BinaryWriter bw1 = new BinaryWriter(fls);
            NmbrÉlements = lstv1.Items.Count;
            for (int i = 0; i < lstv1.Items.Count; i++)
            {      //ecris les donnees de la liste dans le fichier          
                bw1.Write(lstv1.Items[i].SubItems[0].Text);
                bw1.Write(lstv1.Items[i].SubItems[1].Text);
            }
            //ferme les outils pour acceder et ouvrir le fichier
            bw1.Close();
            fls.Close();


        }



        private void Ouvre()
        {

            //codes pour ouvrir les données de score que j'ai enregistrés (fonctionne pas) 
            //l'enregistrement marche mais j'ai un probleme lorsque j'essaie d'ouvrir
            //Notes: le probleme que j'ai eu avec cette partie de mon code était que la ligne  
            //"while (fstream.Position < fstream.Length)" Cette ligne de code s'execute malgré le fait que la condition est fausse
            //Apres un recherche, je pense que c'est un problème ou le programme ignore la condition 
            //(http://stackoverflow.com/questions/27551032/debugger-stepping-into-if-block-where-condition-is-false/27552124#27552124)
            //si vous voulez voir l'erreure, enlever le commentaire dans "Score_Load" ,démarrer le debogage et appuyer sur score
            
            ofd1.InitialDirectory = Application.StartupPath;
            //Le nom de fichier est vide 
            //ofd1.FileName = "";
            ofd1.FileName = "EnregistreTest";
            //ofd1.Filter = "Fichier Texte(*.txt)|*.txt";
            ////Affiche la fenêtre de dialogue
            //ofd1.ShowDialog();

            string fsl = Application.StartupPath;
            //Déclare le canal de communication avec le fichier
            FileStream fstream = new FileStream(fsl + "\\EnregistreTest.txt", FileMode.Open, FileAccess.Read);
            //Déclare l'objet qui fera la lecture des données dans le fichier
            BinaryReader binreader = new BinaryReader(fstream);

            int i = 0; // C'est mon compteur    
            //Déclare l'objet qui fera la lecture des données dans le fichier              
            while (fstream.Position < fstream.Length)
            {//cette boucle while execute le code malgré le fait que la condition est fausse
                if (!(Convert.ToInt16(fstream.Position) == Convert.ToInt16(fstream.Length)))
                {
                    ListViewItem temp = new ListViewItem(binreader.ReadString());
                    temp.SubItems.Add(binreader.ReadString());
                    //lire une chaîne de caractères du fichier et 
                    // assigne-la à la cellule correspondante du tableau registre
                    lstv1.Items.Add(temp);
                }
                //incrémente le compteur 
                i = i + 1;
            }   
            //mettre à jour le nombre d'éléments lus
            NmbrÉlements = i;
            //Affiche le contenu du tableau
            Affiche();
            //Fermer le canal et le fichier
            fstream.Close();
            binreader.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {


        }
        private void btnEnregistre_Click(object sender, EventArgs e)
        {

        }
        //bool completed = false;
        private void btnouvre_Click(object sender, EventArgs e)
        {
        


        }
    }
}       
    

