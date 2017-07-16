using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Drawing;//Outils pour utiliser GDI
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;

namespace Tron
{    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
            ResizeCanvas();
        }             
        int MouvementXJ1;//variables pour le mouvement vertical et horizontal
        int MouvementYJ1;      
        bool gauche = false; //variable pour verifier dans quelle direction le joueur vas
        bool droite = false; //utilité: si le joueur va vers la droite, il ne peut par se retourner a la gauche
        bool haut = false; 
        bool bas = false;

        int MouvementXJ2;//variables pour le mouvement vertical et horizontal
        int MouvementYJ2;
        bool haut2 = false;//variable pour verifier dans quelle direction le joueur vas
        bool bas2 = false;  //utilité: si le joueur va vers la droite, il ne peut par se retourner a la gauche
        bool gauche2 = false; 
        bool droite2 = false;
                   
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
      
            switch (e.KeyCode)
            {
                case (Keys.Up):
                    //quand la touche Haut, le joueur bouge en haut
                    if (bas == true)//si le joueur essaie de changer sa direction a bas, lorsque la direction est vers le haut,rien faire
                    {
                    }
                else
                    {
                        MouvementYJ1 = -5;//bouge le joueur 
                        MouvementXJ1 = 0;
                        haut = true;//actualise la direction
                        bas = false;
                        gauche = false;
                        droite = false;
                    }
                   
                    
                    break;                   
                case (Keys.Down):
                    //quand la touche bas est appuye, le joueur bouge en bas
                    if (haut == true)
                    {
                    }
                    else
                    {
                    MouvementYJ1 = 5;
                    MouvementXJ1 = 0;
                    bas = true;
                    haut = false;
                    gauche = false;
                    droite = false;
                    }
                  
                    break;
                case (Keys.Left):
                    //quand la touche droite est appuye, le joueur bouge a droite
                    if (droite == true)
                    {
                    }
                    else
                    {
                    MouvementYJ1 = 0;
                    MouvementXJ1 = -5;
                    bas = false;
                    haut = false;
                    gauche = true;
                    droite = false;
                    }
                    
                    
                    break;
                case (Keys.Right):
                    //quand la touche gauche est appuye, le joueur bouge a gauche
                    if (gauche == true)
                    {
                    }
                    else
                    {
                    MouvementXJ1 = 5;
                    MouvementYJ1 = 0;
                    bas = false;
                    haut = false;
                    gauche = false;
                    droite = true;  
                    } 
                    break;

                    //Joueur 2

                    //Meme princique qu'avec le joueur 1 sauf que les touches sont WASD 
                case Keys.W:
                    {
                        if (bas2 == true)
                        {
                        }
                        else
                        {
                    MouvementYJ2 = -5;
                    MouvementXJ2 = 0;
                    haut2 = true;
                    bas2 = false;
                    gauche2 = false;
                    droite2 = false;
                        }
                    }
                    break;
                case Keys.A:
                    {
                        if (droite2 == true)
                        {
                        }
                        else
                        {
                    MouvementYJ2 = 0;
                    MouvementXJ2 = -5;
                    haut2 = false;
                    bas2 = false;
                    gauche2 = true;
                    droite2 = false;
                        }
                    }
                    break;
                case Keys.S:
                    {
                        if (haut2 == true)
                        {
                        }
                        else
                        {
                    MouvementYJ2 = 5;
                    MouvementXJ2 = 0;
                    haut2 = false;
                    bas2 = true;
                    gauche2 = false;
                    droite2 = false;
                        }
                    }
                    break;
                case Keys.D:
                    {
                        if (gauche2 == true)
                        {
                        }
                        else
                        {
                    MouvementYJ2 = 0;
                    MouvementXJ2= 5;
                    haut2 = false;
                    bas2 = false;
                    gauche2 = false;
                    droite2 = true;
                        }
                    }
                    break;
            }
        }       
       
        public GraphicsPath chemin; //le graphics path pour le chemin derriere les joueurs

        

        List<PointF> pts = new  List<PointF>();//liste de points ou on vas tracer le chemin (liste de centres)
        List<PointF> pts2 = new List<PointF>();
        
            
        
        private void timer1_Tick(object sender, EventArgs e)
        {        
            //PointF PosInit = J1.centre;//la position initiale du joueur        
            pts.Add(J1.centre);//ajoute le point centre du joueur a la liste         
            J1.Bouge(MouvementXJ1, MouvementYJ1);//bouge le joueur
            pts.Add(J1.centre);//apres que le joueur bouge, son centre bouge aussi alors je le rajoute encore a la liste

            //Meme principe pour le joueur 2
            pts2.Add(J2.centre);
            J2.Bouge(MouvementXJ2, MouvementYJ2);
            pts2.Add(J2.centre);     
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {   //Detection de colision
            Variables.temps = Variables.temps + 1;
            //temps = temps + 1;
            this.Text = "Temps: " + Variables.temps.ToString();//temps écoulé depuis le début du jeu
            for (int i = 0; i < pts.Count; i++)
            {
                //Si la tete du joueur bleu entre en collision avec une partie du joueur rouge 
                if (pts[pts.Count - 1].X > pts2[i].X - 7 && pts[pts.Count - 1].X < pts2[i].X + 7 &&
                    pts[pts.Count - 1].Y > pts2[i].Y - 7 && pts[pts.Count - 1].Y < pts2[i].Y + 7)
                {
                    //arrete le mouvement
                    timer2.Enabled = false;
                    timer1.Enabled = false;
                    MessageBox.Show("Joueur 2 (Rouge) a gagné(e)");

                    //ferme la form et ouvre la form qui affiche le score
                    this.Visible = false;
                    Score form3 = new Score();
                    form3.Visible = true;
                    i = pts.Count - 1;
                    Variables.bleu = false;
                    Variables.rouge = true;    
                }     
             }
           
            ////Si la tete du joueur bleu entre en collision avec une partie de soi meme (bleu entre en collision avec le chemin bleu)
            for (int i = 0; i < pts.Count - 25; i++)
            {
                
                if (pts[pts.Count - 1].X > pts[i].X - 7 && pts[pts.Count - 1].X < pts[i].X + 7 &&
                    pts[pts.Count - 1].Y > pts[i].Y - 7 && pts[pts.Count - 1].Y < pts[i].Y + 7)
                {
                    //arrete le mouvement
                    timer2.Enabled = false;
                    timer1.Enabled = false;
                    MessageBox.Show("Joueur 2 (Rouge) a gagné(e)");

                    //ferme la form et ouvre la forme qui affiche le score
                    this.Visible = false;
                    Score form3 = new Score();
                    form3.Visible = true;
                    i = pts.Count - 1;
                    Variables.bleu = false;
                    Variables.rouge = true;
                    //i = pts.Count;
                }
            }
            for (int i = 0; i < pts.Count; i++)
            {
                //Si la tete du joueur rouge entre en collision avec le joueur bleu
                if (pts2[pts.Count - 1].X > pts[i].X - 7 && pts2[pts.Count - 1].X < pts[i].X + 7 &&
                    pts2[pts.Count - 1].Y > pts[i].Y - 7 && pts2[pts.Count - 1].Y < pts[i].Y + 7)
                {  //arrete le mouvement
                    timer2.Enabled = false;
                    timer1.Enabled = false;
                    MessageBox.Show("Joueur 1 (Bleu) a gagné(e)");
                    //ferme la form et ouvre la forme qui affiche le score
                    this.Visible = false;
                    Score form3 = new Score();
                    form3.Visible = true;
                    i = pts.Count - 1;

                    Variables.rouge = false;
                    Variables.bleu = true;
                }                
            }
            for (int i = 0; i < pts.Count - 25; i++)
            {
                //si rouge entre en collision avec soi-meme (collision avec son chemin)
                if (pts2[pts.Count - 1].X > pts2[i].X - 7 && pts2[pts.Count - 1].X < pts2[i].X + 7 &&
                    pts2[pts.Count - 1].Y > pts2[i].Y - 7 && pts2[pts.Count - 1].Y < pts2[i].Y + 7)
                {//arrete le mouvement
                    timer2.Enabled = false;
                    timer1.Enabled = false;
                    MessageBox.Show("Joueur 1 (Bleu) a gagné(e)");
                    //ferme la form et ouvre la forme qui affiche le score
                    this.Visible = false;
                    Score form3 = new Score();
                    form3.Visible = true;
                    i = pts.Count - 1;
                    Variables.bleu = true;                    
                    Variables.rouge = false;


                }
            }
            if (J1.centre.X > this.Width || J1.centre.Y > this.Height || J1.centre.X < 0 ||J1.centre.Y < 0)
            {//collision avec les limites de la form
                timer2.Enabled = false;
                timer1.Enabled = false;
                MessageBox.Show("Joueur 2 (Rouge) a gagné(e)");

                this.Visible = false;
                Score form3 = new Score();
                form3.Visible = true;
                Variables.bleu = false;

            }
            if (J2.centre.X > this.Width || J2.centre.Y > this.Height || J2.centre.X < 0 || J2.centre.Y < 0)
            {//collision avec les limites de la form
                timer2.Enabled = false;
                timer1.Enabled = false;
                MessageBox.Show("Joueur 1 (Bleu) a gagné(e)");
                //ferme et crée la form du score
                this.Visible = false;
                Score form3 = new Score();
                form3.Visible = true;

                Variables.bleu = true;
            }
        }
        
        private void Init()
        {
            //Améliore la qualité des graphiques            
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //crée un graphics path
             GraphicsPath gp = new GraphicsPath();
            //crée le joueur 1
             //la direction initiale est la droite
             J1 = new JoueurInit(new PointF(50, this.Height / 2), 30);
            
             MouvementXJ1 = 5;
             MouvementYJ1 = 0;
             gauche2 = true;
             //crée le joueur 2
            //la direction initiale est la droite
             droite = true;
            //initialise le joueur a l'emplacement
             J2 = new JoueurInit(new PointF(this.Width - 110, this.Height / 2), 30);
             MouvementXJ2 = -5;
             MouvementYJ2 = 0;

        }
        JoueurInit J1;//initialise les joueurs
        JoueurInit J2;
        
        private Bitmap _canvas;
        private void ResizeCanvas()
        {
            Bitmap tmp = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppRgb);
            //j'utilise un bitmap parceque lorsque je dessinais sur form_paint,
            //le dessin disparait a chaque fois que le dessin se renouvelle
            //donc avec un bitmap, le dessin peut rester sur la feuille
            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.Clear(Color.White);
                if (_canvas != null)
                {
                    g.DrawImage(_canvas, 0, 0);
                    _canvas.Dispose();
                }
            }
            _canvas = tmp;
        }  
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //déssine les joueurs sur la form en utilisant GDI
           Graphics g = e.Graphics;
            using (Bitmap tmp = new Bitmap(_canvas))//j'utilise un bitmap pour creer le chemin derriere les joueurs
            {
                using (Graphics f = Graphics.FromImage(tmp))
                {
                    for (int i = 0; i < pts.Count - 1; i++)
                    {
                        Pen bluepen = new Pen(Color.FromArgb(255, 0, 0, 255), 15);
                        Pen redpen = new Pen(Color.FromArgb(255, 255, 0, 0), 15);
                        //dessinne le chemin derriere le joueur en utilisant le point du centre
                        //je dessine une ligne (dont j'ai change l'epaisseur) en utilisant une liste des point du centre du joueur
                        //pour le centre: a chaque position du joueur, j'ajoute son point centre a la listepts/pts
                        //et je dessine des lignes entre les points dans la liste
                        g.DrawLine(bluepen, pts[i], pts[i+1]);
                        g.DrawLine(redpen, pts2[i], pts2[i + 1]);
                        
                    }
                }
                }
            //
            SolidBrush Joueur1Couleur = new SolidBrush(Color.Blue);
            SolidBrush Joueur2Couleur = new SolidBrush(Color.Red);
            g.SmoothingMode = SmoothingMode.HighQuality;
            //déssine le joueur et la couleur
            g.DrawPath(Pens.Black, J1.gp);
            //remplis le carre du joueur
            g.FillPath(Joueur1Couleur, J1.gp);
            //dessine le Joueur 2 et sa couleur
            g.DrawPath(Pens.Black, J2.gp);
            g.FillPath(Joueur2Couleur, J2.gp);
           
            Application.DoEvents();
            Thread.Sleep(16);
            this.Invalidate();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }  
    }
}
//classe globale de variables pour utiliser dans plusieures forms
class Variables
{
    public static int temps = 1;
    public static bool bleu = false;
    public static bool rouge = false;
    public static int numelementsliste = 0;
}



