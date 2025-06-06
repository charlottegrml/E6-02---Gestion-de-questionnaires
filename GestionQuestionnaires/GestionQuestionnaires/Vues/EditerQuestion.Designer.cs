namespace GestionQuestionnaires.Vues
{
    partial class EditerQuestion
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
            label2 = new Label();
            label3 = new Label();
            txtLibelle = new TextBox();
            cmbType = new ComboBox();
            dgvPropositions = new DataGridView();
            groupBoxVraiFaux = new GroupBox();
            label4 = new Label();
            txtPoidsVF = new TextBox();
            radioFaux = new RadioButton();
            radioVrai = new RadioButton();
            btnSauvegarder = new Button();
            btnAnnuler = new Button();
            btnAjouterProposition = new Button();
            btnSupprimerProposition = new Button();
            gpboxQCS = new GroupBox();
            txtboxReponse = new TextBox();
            label6 = new Label();
            txtboxPoidsQCS = new TextBox();
            checkBoxNeg = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvPropositions).BeginInit();
            groupBoxVraiFaux.SuspendLayout();
            gpboxQCS.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(177, 9);
            label1.Name = "label1";
            label1.Size = new Size(503, 43);
            label1.TabIndex = 0;
            label1.Text = "MODIFIER UNE QUESTION";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(53, 89);
            label2.Name = "label2";
            label2.Size = new Size(197, 24);
            label2.TabIndex = 1;
            label2.Text = "Titre de la question :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(53, 130);
            label3.Name = "label3";
            label3.Size = new Size(199, 24);
            label3.TabIndex = 2;
            label3.Text = "Type de la question :";
            // 
            // txtLibelle
            // 
            txtLibelle.Location = new Point(256, 89);
            txtLibelle.Name = "txtLibelle";
            txtLibelle.Size = new Size(293, 31);
            txtLibelle.TabIndex = 3;
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(258, 127);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(182, 33);
            cmbType.TabIndex = 4;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            // 
            // dgvPropositions
            // 
            dgvPropositions.BackgroundColor = SystemColors.ActiveCaptionText;
            dgvPropositions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPropositions.GridColor = SystemColors.ActiveCaptionText;
            dgvPropositions.Location = new Point(379, 25);
            dgvPropositions.Name = "dgvPropositions";
            dgvPropositions.RowHeadersWidth = 62;
            dgvPropositions.RowTemplate.Height = 33;
            dgvPropositions.Size = new Size(360, 191);
            dgvPropositions.TabIndex = 5;
            dgvPropositions.CellContentClick += dgvPropositions_CellContentClick;
            // 
            // groupBoxVraiFaux
            // 
            groupBoxVraiFaux.Controls.Add(checkBoxNeg);
            groupBoxVraiFaux.Controls.Add(label4);
            groupBoxVraiFaux.Controls.Add(txtPoidsVF);
            groupBoxVraiFaux.Controls.Add(radioFaux);
            groupBoxVraiFaux.Controls.Add(radioVrai);
            groupBoxVraiFaux.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBoxVraiFaux.ForeColor = SystemColors.ControlLightLight;
            groupBoxVraiFaux.Location = new Point(155, 444);
            groupBoxVraiFaux.Name = "groupBoxVraiFaux";
            groupBoxVraiFaux.Size = new Size(418, 185);
            groupBoxVraiFaux.TabIndex = 6;
            groupBoxVraiFaux.TabStop = false;
            groupBoxVraiFaux.Text = "Modifier la réponse :";
            groupBoxVraiFaux.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(50, 96);
            label4.Name = "label4";
            label4.Size = new Size(70, 24);
            label4.TabIndex = 9;
            label4.Text = "Poids :";
            // 
            // txtPoidsVF
            // 
            txtPoidsVF.Location = new Point(138, 93);
            txtPoidsVF.Name = "txtPoidsVF";
            txtPoidsVF.Size = new Size(130, 32);
            txtPoidsVF.TabIndex = 9;
            // 
            // radioFaux
            // 
            radioFaux.AutoSize = true;
            radioFaux.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            radioFaux.Location = new Point(220, 37);
            radioFaux.Name = "radioFaux";
            radioFaux.Size = new Size(83, 31);
            radioFaux.TabIndex = 1;
            radioFaux.TabStop = true;
            radioFaux.Text = "Faux";
            radioFaux.UseVisualStyleBackColor = true;
            // 
            // radioVrai
            // 
            radioVrai.AutoSize = true;
            radioVrai.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            radioVrai.Location = new Point(72, 37);
            radioVrai.Name = "radioVrai";
            radioVrai.Size = new Size(75, 31);
            radioVrai.TabIndex = 0;
            radioVrai.TabStop = true;
            radioVrai.Text = "Vrai";
            radioVrai.UseVisualStyleBackColor = true;
            // 
            // btnSauvegarder
            // 
            btnSauvegarder.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSauvegarder.ForeColor = SystemColors.ActiveCaptionText;
            btnSauvegarder.Location = new Point(604, 151);
            btnSauvegarder.Name = "btnSauvegarder";
            btnSauvegarder.Size = new Size(159, 34);
            btnSauvegarder.TabIndex = 7;
            btnSauvegarder.Text = "Sauvegarder";
            btnSauvegarder.UseVisualStyleBackColor = true;
            btnSauvegarder.Click += btnSauvegarder_Click;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnnuler.ForeColor = SystemColors.ActiveCaptionText;
            btnAnnuler.Location = new Point(464, 151);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(109, 34);
            btnAnnuler.TabIndex = 8;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // btnAjouterProposition
            // 
            btnAjouterProposition.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAjouterProposition.ForeColor = SystemColors.ActiveCaptionText;
            btnAjouterProposition.Location = new Point(105, 130);
            btnAjouterProposition.Name = "btnAjouterProposition";
            btnAjouterProposition.Size = new Size(199, 34);
            btnAjouterProposition.TabIndex = 11;
            btnAjouterProposition.Text = "Ajouter une réponse";
            btnAjouterProposition.UseVisualStyleBackColor = true;
            btnAjouterProposition.Click += btnAjouterProposition_Click;
            // 
            // btnSupprimerProposition
            // 
            btnSupprimerProposition.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSupprimerProposition.ForeColor = SystemColors.ActiveCaptionText;
            btnSupprimerProposition.Location = new Point(23, 182);
            btnSupprimerProposition.Name = "btnSupprimerProposition";
            btnSupprimerProposition.Size = new Size(159, 34);
            btnSupprimerProposition.TabIndex = 12;
            btnSupprimerProposition.Text = "Supprimer";
            btnSupprimerProposition.UseVisualStyleBackColor = true;
            btnSupprimerProposition.Click += btnSupprimerProposition_Click;
            // 
            // gpboxQCS
            // 
            gpboxQCS.Controls.Add(txtboxReponse);
            gpboxQCS.Controls.Add(btnSupprimerProposition);
            gpboxQCS.Controls.Add(label6);
            gpboxQCS.Controls.Add(txtboxPoidsQCS);
            gpboxQCS.Controls.Add(dgvPropositions);
            gpboxQCS.Controls.Add(btnAjouterProposition);
            gpboxQCS.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            gpboxQCS.ForeColor = SystemColors.ButtonHighlight;
            gpboxQCS.Location = new Point(30, 203);
            gpboxQCS.Name = "gpboxQCS";
            gpboxQCS.Size = new Size(745, 235);
            gpboxQCS.TabIndex = 10;
            gpboxQCS.TabStop = false;
            gpboxQCS.Text = "Ajouter une réponse :";
            gpboxQCS.Visible = false;
            // 
            // txtboxReponse
            // 
            txtboxReponse.Location = new Point(23, 42);
            txtboxReponse.Name = "txtboxReponse";
            txtboxReponse.Size = new Size(298, 32);
            txtboxReponse.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(6, 92);
            label6.Name = "label6";
            label6.Size = new Size(70, 24);
            label6.TabIndex = 9;
            label6.Text = "Poids :";
            // 
            // txtboxPoidsQCS
            // 
            txtboxPoidsQCS.Location = new Point(82, 92);
            txtboxPoidsQCS.Name = "txtboxPoidsQCS";
            txtboxPoidsQCS.Size = new Size(130, 32);
            txtboxPoidsQCS.TabIndex = 9;
            // 
            // checkBoxNeg
            // 
            checkBoxNeg.AutoSize = true;
            checkBoxNeg.Font = new Font("Tahoma", 8F, FontStyle.Italic, GraphicsUnit.Point);
            checkBoxNeg.Location = new Point(33, 131);
            checkBoxNeg.Name = "checkBoxNeg";
            checkBoxNeg.Size = new Size(282, 23);
            checkBoxNeg.TabIndex = 16;
            checkBoxNeg.Text = "mauvaise réponse à point négatif ?";
            checkBoxNeg.UseVisualStyleBackColor = true;
            // 
            // EditerQuestion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 649);
            Controls.Add(gpboxQCS);
            Controls.Add(btnAnnuler);
            Controls.Add(btnSauvegarder);
            Controls.Add(groupBoxVraiFaux);
            Controls.Add(cmbType);
            Controls.Add(txtLibelle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlLightLight;
            Name = "EditerQuestion";
            Text = "Modifier une Question";
            ((System.ComponentModel.ISupportInitialize)dgvPropositions).EndInit();
            groupBoxVraiFaux.ResumeLayout(false);
            groupBoxVraiFaux.PerformLayout();
            gpboxQCS.ResumeLayout(false);
            gpboxQCS.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtLibelle;
        private ComboBox cmbType;
        private DataGridView dgvPropositions;
        private GroupBox groupBoxVraiFaux;
        private RadioButton radioFaux;
        private RadioButton radioVrai;
        private Button btnSauvegarder;
        private Button btnAnnuler;
        private Label label4;
        private TextBox txtPoidsVF;
        private Button btnAjouterProposition;
        private Button btnSupprimerProposition;
        private GroupBox gpboxQCS;
        private TextBox txtboxReponse;
        private Label label6;
        private TextBox txtboxPoidsQCS;
        private CheckBox checkBoxNeg;
        private CheckBox checkBoxCorrecte;

    }
}