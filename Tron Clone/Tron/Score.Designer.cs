namespace Tron
{
    partial class Score
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstv1 = new System.Windows.Forms.ListView();
            this.Nom = new System.Windows.Forms.ColumnHeader();
            this.Scores = new System.Windows.Forms.ColumnHeader();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVas = new System.Windows.Forms.Button();
            this.btnVasAcceuil = new System.Windows.Forms.Button();
            this.btnRecommence = new System.Windows.Forms.Button();
            this.btnEnregistre = new System.Windows.Forms.Button();
            this.btnouvre = new System.Windows.Forms.Button();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.sfd1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // lstv1
            // 
            this.lstv1.AutoArrange = false;
            this.lstv1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nom,
            this.Scores});
            this.lstv1.Location = new System.Drawing.Point(12, 334);
            this.lstv1.Name = "lstv1";
            this.lstv1.Size = new System.Drawing.Size(190, 304);
            this.lstv1.TabIndex = 0;
            this.lstv1.UseCompatibleStateImageBehavior = false;
            this.lstv1.View = System.Windows.Forms.View.Details;
            this.lstv1.Visible = false;
            // 
            // Nom
            // 
            this.Nom.Text = "Nom";
            this.Nom.Width = 69;
            // 
            // Scores
            // 
            this.Scores.Text = "Score";
            this.Scores.Width = 69;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(83, 370);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 1;
            this.txtNom.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(5, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nom/Initiales:";
            this.label1.Visible = false;
            // 
            // btnVas
            // 
            this.btnVas.Location = new System.Drawing.Point(93, 396);
            this.btnVas.Name = "btnVas";
            this.btnVas.Size = new System.Drawing.Size(75, 23);
            this.btnVas.TabIndex = 3;
            this.btnVas.Text = "Vas";
            this.btnVas.UseVisualStyleBackColor = true;
            this.btnVas.Visible = false;
            this.btnVas.Click += new System.EventHandler(this.btnVas_Click);
            // 
            // btnVasAcceuil
            // 
            this.btnVasAcceuil.Location = new System.Drawing.Point(42, 61);
            this.btnVasAcceuil.Name = "btnVasAcceuil";
            this.btnVasAcceuil.Size = new System.Drawing.Size(94, 23);
            this.btnVasAcceuil.TabIndex = 4;
            this.btnVasAcceuil.Text = "Welcome page";
            this.btnVasAcceuil.UseVisualStyleBackColor = true;
            this.btnVasAcceuil.Click += new System.EventHandler(this.btnVasAcceuil_Click);
            // 
            // btnRecommence
            // 
            this.btnRecommence.Location = new System.Drawing.Point(52, 32);
            this.btnRecommence.Name = "btnRecommence";
            this.btnRecommence.Size = new System.Drawing.Size(75, 23);
            this.btnRecommence.TabIndex = 5;
            this.btnRecommence.Text = "Play Again";
            this.btnRecommence.UseVisualStyleBackColor = true;
            this.btnRecommence.Click += new System.EventHandler(this.btnRecommence_Click);
            // 
            // btnEnregistre
            // 
            this.btnEnregistre.Location = new System.Drawing.Point(93, 425);
            this.btnEnregistre.Name = "btnEnregistre";
            this.btnEnregistre.Size = new System.Drawing.Size(75, 22);
            this.btnEnregistre.TabIndex = 6;
            this.btnEnregistre.Text = "Enregistre";
            this.btnEnregistre.UseVisualStyleBackColor = true;
            this.btnEnregistre.Visible = false;
            this.btnEnregistre.Click += new System.EventHandler(this.btnEnregistre_Click);
            // 
            // btnouvre
            // 
            this.btnouvre.Location = new System.Drawing.Point(93, 453);
            this.btnouvre.Name = "btnouvre";
            this.btnouvre.Size = new System.Drawing.Size(75, 22);
            this.btnouvre.TabIndex = 7;
            this.btnouvre.Text = "Ouvre";
            this.btnouvre.UseVisualStyleBackColor = true;
            this.btnouvre.Visible = false;
            this.btnouvre.Click += new System.EventHandler(this.btnouvre_Click);
            // 
            // ofd1
            // 
            this.ofd1.FileName = "openFileDialog1";
            // 
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(180, 114);
            this.Controls.Add(this.btnouvre);
            this.Controls.Add(this.btnEnregistre);
            this.Controls.Add(this.btnRecommence);
            this.Controls.Add(this.btnVasAcceuil);
            this.Controls.Add(this.btnVas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lstv1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Score";
            this.Text = "Score";
            this.Load += new System.EventHandler(this.Score_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstv1;
        private System.Windows.Forms.ColumnHeader Nom;
        private System.Windows.Forms.ColumnHeader Scores;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVas;
        private System.Windows.Forms.Button btnVasAcceuil;
        private System.Windows.Forms.Button btnRecommence;
        private System.Windows.Forms.Button btnEnregistre;
        private System.Windows.Forms.Button btnouvre;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.SaveFileDialog sfd1;
    }
}