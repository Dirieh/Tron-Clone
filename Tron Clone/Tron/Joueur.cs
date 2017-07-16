using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Tron
{
public partial class Joueur : Form
    {
        public Joueur()
        {
            InitializeComponent();
        }

        private void Mouvement_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {   //ferme la form pour la page d'acceuil et ouvre celle pour le jeu
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            //ouvre la form pour le score et ferme l'Actuelle
            this.Visible = false;
            Score score = new Score();
            score.Show();
        }
       
         
    }
    
    class JoueurInit
    {  
        //initialise les points
        PointF A, B, C, D;
        public PointF centre;
        public GraphicsPath gp;
 

        //public float Direction;//Mesurée en degré

        public JoueurInit(PointF pos, int cote)
        {
            //initialise les points
            A = new PointF(pos.X, pos.Y);
            B = new PointF(pos.X + cote, pos.Y);
            C = new PointF(pos.X, pos.Y + cote);
            D = new PointF(pos.X + cote, pos.Y + cote);
            centre = new PointF(pos.X + (cote / 2), pos.Y + (cote / 2));
          
            gp = new GraphicsPath();
            gp.AddLine(A, B);
            gp.AddLine(B, D);
            gp.AddLine(D, C);
            gp.AddLine(C, A);
            //déssine le joueur
        }


        public void Bouge(int MouvementX, int MouvementY)
        {
            
            Matrix Mt = new Matrix(); // Initialise la matrice Mt            
            // Convertis Direction en radian          
            // Définis Mt comme une matrice de translation de (x, y)
            Mt.Translate(MouvementX, MouvementY);
            //deplace le joueur
            gp.Transform(Mt); // Applique M à gp
            //dessine le deplacement
            // Translate le centre entre aussi
            // Mets le centre dans un tableau de points
            
            PointF[] pts = new PointF[] { centre };
            
            Mt.TransformPoints(pts); //Transforme le tableau de points
            centre = pts[0];   // Centre translaé
        }

    }

    
}
