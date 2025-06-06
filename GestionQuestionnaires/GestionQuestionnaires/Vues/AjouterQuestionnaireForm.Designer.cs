namespace GestionQuestionnaires
{
    partial class AjouterQuestionnaireForm
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
            labelnvQuestionnaire = new Label();
            labelTitre = new Label();
            labelTheme = new Label();
            txtboxQuestionnaire = new TextBox();
            btnSauvegarder = new Button();
            cbBoxTheme = new ComboBox();
            btnAnnuler = new Button();
            SuspendLayout();
            // 
            // labelnvQuestionnaire
            // 
            labelnvQuestionnaire.AutoSize = true;
            labelnvQuestionnaire.Font = new Font("Tahoma", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelnvQuestionnaire.ForeColor = SystemColors.ButtonHighlight;
            labelnvQuestionnaire.Location = new Point(169, 9);
            labelnvQuestionnaire.Name = "labelnvQuestionnaire";
            labelnvQuestionnaire.Size = new Size(467, 39);
            labelnvQuestionnaire.TabIndex = 0;
            labelnvQuestionnaire.Text = "NOUVEAU QUESTIONNAIRE";
            // 
            // labelTitre
            // 
            labelTitre.AutoSize = true;
            labelTitre.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitre.ForeColor = SystemColors.ButtonHighlight;
            labelTitre.Location = new Point(81, 119);
            labelTitre.Name = "labelTitre";
            labelTitre.Size = new Size(198, 22);
            labelTitre.TabIndex = 1;
            labelTitre.Text = "Titre du Questionnaire :";
            // 
            // labelTheme
            // 
            labelTheme.AutoSize = true;
            labelTheme.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelTheme.ForeColor = SystemColors.ButtonHighlight;
            labelTheme.Location = new Point(93, 156);
            labelTheme.Name = "labelTheme";
            labelTheme.Size = new Size(216, 22);
            labelTheme.TabIndex = 2;
            labelTheme.Text = "Thème du Questionnaire :";
            // 
            // txtboxQuestionnaire
            // 
            txtboxQuestionnaire.Location = new Point(285, 114);
            txtboxQuestionnaire.Name = "txtboxQuestionnaire";
            txtboxQuestionnaire.Size = new Size(351, 31);
            txtboxQuestionnaire.TabIndex = 5;
            // 
            // btnSauvegarder
            // 
            btnSauvegarder.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSauvegarder.Location = new Point(486, 288);
            btnSauvegarder.Name = "btnSauvegarder";
            btnSauvegarder.Size = new Size(150, 36);
            btnSauvegarder.TabIndex = 7;
            btnSauvegarder.Text = "Créer";
            btnSauvegarder.UseVisualStyleBackColor = true;
            btnSauvegarder.Click += btnSauvegarder_Click;
            // 
            // cbBoxTheme
            // 
            cbBoxTheme.FormattingEnabled = true;
            cbBoxTheme.Location = new Point(335, 151);
            cbBoxTheme.Name = "cbBoxTheme";
            cbBoxTheme.Size = new Size(301, 33);
            cbBoxTheme.TabIndex = 8;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnnuler.Location = new Point(144, 288);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(150, 36);
            btnAnnuler.TabIndex = 9;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // AjouterQuestionnaireForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAnnuler);
            Controls.Add(cbBoxTheme);
            Controls.Add(btnSauvegarder);
            Controls.Add(txtboxQuestionnaire);
            Controls.Add(labelTheme);
            Controls.Add(labelTitre);
            Controls.Add(labelnvQuestionnaire);
            Name = "AjouterQuestionnaireForm";
            Text = "Ajouter un questionnaire";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelnvQuestionnaire;
        private Label labelTitre;
        private Label labelTheme;
        private TextBox txtboxQuestionnaire;
        private Button btnSauvegarder;
        private ComboBox cbBoxTheme;
        private Button btnAnnuler;
    }
}