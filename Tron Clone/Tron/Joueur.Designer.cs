namespace Tron
{
    partial class Joueur
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btndemarre = new System.Windows.Forms.Button();
            this.picacceuil = new System.Windows.Forms.PictureBox();
            this.btnScore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picacceuil)).BeginInit();
            this.SuspendLayout();
            // 
            // btndemarre
            // 
            this.btndemarre.BackColor = System.Drawing.SystemColors.InfoText;
            this.btndemarre.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btndemarre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndemarre.Font = new System.Drawing.Font("Broadway", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndemarre.ForeColor = System.Drawing.Color.Aqua;
            this.btndemarre.Location = new System.Drawing.Point(348, 299);
            this.btndemarre.Name = "btndemarre";
            this.btndemarre.Size = new System.Drawing.Size(148, 67);
            this.btndemarre.TabIndex = 0;
            this.btndemarre.Text = "Start";
            this.btndemarre.UseVisualStyleBackColor = false;
            this.btndemarre.Click += new System.EventHandler(this.button1_Click);
            // 
            // picacceuil
            // 
            this.picacceuil.Image = global::Tron.Properties.Resources.tron_welcome;
            this.picacceuil.Location = new System.Drawing.Point(83, -30);
            this.picacceuil.Name = "picacceuil";
            this.picacceuil.Size = new System.Drawing.Size(680, 309);
            this.picacceuil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picacceuil.TabIndex = 1;
            this.picacceuil.TabStop = false;
            // 
            // btnScore
            // 
            this.btnScore.BackColor = System.Drawing.SystemColors.InfoText;
            this.btnScore.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btnScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScore.Font = new System.Drawing.Font("Broadway", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScore.ForeColor = System.Drawing.Color.Aqua;
            this.btnScore.Location = new System.Drawing.Point(470, 157);
            this.btnScore.Name = "btnScore";
            this.btnScore.Size = new System.Drawing.Size(148, 67);
            this.btnScore.TabIndex = 2;
            this.btnScore.Text = "Score";
            this.btnScore.UseVisualStyleBackColor = false;
            this.btnScore.Visible = false;
            this.btnScore.Click += new System.EventHandler(this.btnScore_Click);
            // 
            // Joueur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(845, 378);
            this.Controls.Add(this.picacceuil);
            this.Controls.Add(this.btndemarre);
            this.Controls.Add(this.btnScore);
            this.Name = "Joueur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tron";
            this.Load += new System.EventHandler(this.Mouvement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picacceuil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndemarre;
        private System.Windows.Forms.PictureBox picacceuil;
        private System.Windows.Forms.Button btnScore;
    }
}