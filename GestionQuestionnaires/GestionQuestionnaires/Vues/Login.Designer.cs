namespace GestionQuestionnaires
{
    partial class Login
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
            label1 = new Label();
            labelUsername = new Label();
            labelPassword = new Label();
            txtboxUsername = new TextBox();
            txtboxPassword = new TextBox();
            star2 = new Label();
            star1 = new Label();
            btnConnexion = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(235, 9);
            label1.Name = "label1";
            label1.Size = new Size(361, 72);
            label1.TabIndex = 0;
            label1.Text = "CONNEXION";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            labelUsername.Location = new Point(40, 119);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(277, 39);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Nom d'utilisateur :";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            labelPassword.Location = new Point(91, 167);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(226, 39);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Mot de passe :";
            // 
            // txtboxUsername
            // 
            txtboxUsername.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxUsername.Location = new Point(323, 116);
            txtboxUsername.Name = "txtboxUsername";
            txtboxUsername.Size = new Size(389, 46);
            txtboxUsername.TabIndex = 3;
            // 
            // txtboxPassword
            // 
            txtboxPassword.Font = new Font("TINspireKeys", 15.999999F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxPassword.Location = new Point(323, 168);
            txtboxPassword.Name = "txtboxPassword";
            txtboxPassword.Size = new Size(389, 40);
            txtboxPassword.TabIndex = 4;
            // 
            // star2
            // 
            star2.AutoSize = true;
            star2.ForeColor = Color.Red;
            star2.Location = new Point(718, 167);
            star2.Name = "star2";
            star2.Size = new Size(20, 25);
            star2.TabIndex = 5;
            star2.Text = "*";
            star2.Visible = false;
            // 
            // star1
            // 
            star1.AutoSize = true;
            star1.ForeColor = Color.Red;
            star1.Location = new Point(718, 116);
            star1.Name = "star1";
            star1.Size = new Size(20, 25);
            star1.TabIndex = 6;
            star1.Text = "*";
            star1.Visible = false;
            // 
            // btnConnexion
            // 
            btnConnexion.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnConnexion.Location = new Point(277, 272);
            btnConnexion.Name = "btnConnexion";
            btnConnexion.Size = new Size(275, 57);
            btnConnexion.TabIndex = 7;
            btnConnexion.Text = "SE CONNECTER";
            btnConnexion.UseVisualStyleBackColor = true;
            btnConnexion.Click += btnConnexion_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConnexion);
            Controls.Add(star1);
            Controls.Add(star2);
            Controls.Add(txtboxPassword);
            Controls.Add(txtboxUsername);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Controls.Add(label1);
            Name = "Login";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelUsername;
        private Label labelPassword;
        private TextBox txtboxUsername;
        private TextBox txtboxPassword;
        private Label star2;
        private Label star1;
        private Button btnConnexion;
    }
}