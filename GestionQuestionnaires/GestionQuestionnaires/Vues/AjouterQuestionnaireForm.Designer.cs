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
            labelQuestion = new Label();
            DGVQuestion = new DataGridView();
            txtboxQuestionnaire = new TextBox();
            btnSauvegarder = new Button();
            cbBoxTheme = new ComboBox();
            btnAnnuler = new Button();
            label1 = new Label();
            txtQuestion = new TextBox();
            btnAjouterQuestion = new Button();
            cbBoxType = new ComboBox();
            label2 = new Label();
            textBox1 = new TextBox();
            btnAjouterReponse = new Button();
            chkReponseCorrecte = new CheckBox();
            GBvraiFaux = new GroupBox();
            rbfaux = new RadioButton();
            rbVrai = new RadioButton();
            button1 = new Button();
            GBListeValeur = new GroupBox();
            panelQCM = new Panel();
            chkbrep4 = new CheckBox();
            chkbrep2 = new CheckBox();
            chkbrep3 = new CheckBox();
            chkbrep1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)DGVQuestion).BeginInit();
            GBvraiFaux.SuspendLayout();
            GBListeValeur.SuspendLayout();
            panelQCM.SuspendLayout();
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
            labelTitre.Location = new Point(12, 64);
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
            labelTheme.Location = new Point(12, 93);
            labelTheme.Name = "labelTheme";
            labelTheme.Size = new Size(216, 22);
            labelTheme.TabIndex = 2;
            labelTheme.Text = "Thème du Questionnaire :";
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelQuestion.ForeColor = SystemColors.ButtonHighlight;
            labelQuestion.Location = new Point(12, 160);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(100, 22);
            labelQuestion.TabIndex = 3;
            labelQuestion.Text = "Questions :";
            // 
            // DGVQuestion
            // 
            DGVQuestion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVQuestion.Location = new Point(27, 248);
            DGVQuestion.Name = "DGVQuestion";
            DGVQuestion.RowHeadersWidth = 62;
            DGVQuestion.RowTemplate.Height = 33;
            DGVQuestion.Size = new Size(364, 190);
            DGVQuestion.TabIndex = 4;
            // 
            // txtboxQuestionnaire
            // 
            txtboxQuestionnaire.Location = new Point(216, 59);
            txtboxQuestionnaire.Name = "txtboxQuestionnaire";
            txtboxQuestionnaire.Size = new Size(259, 31);
            txtboxQuestionnaire.TabIndex = 5;
            // 
            // btnSauvegarder
            // 
            btnSauvegarder.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSauvegarder.Location = new Point(617, 402);
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
            cbBoxTheme.Location = new Point(272, 96);
            cbBoxTheme.Name = "cbBoxTheme";
            cbBoxTheme.Size = new Size(203, 33);
            cbBoxTheme.TabIndex = 8;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnnuler.Location = new Point(461, 402);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(150, 36);
            btnAnnuler.TabIndex = 9;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 207);
            label1.Name = "label1";
            label1.Size = new Size(159, 22);
            label1.TabIndex = 10;
            label1.Text = "Type de question :";
            // 
            // txtQuestion
            // 
            txtQuestion.Location = new Point(118, 155);
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(273, 31);
            txtQuestion.TabIndex = 11;
            // 
            // btnAjouterQuestion
            // 
            btnAjouterQuestion.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAjouterQuestion.Location = new Point(406, 152);
            btnAjouterQuestion.Name = "btnAjouterQuestion";
            btnAjouterQuestion.Size = new Size(85, 36);
            btnAjouterQuestion.TabIndex = 12;
            btnAjouterQuestion.Text = "Ajouter";
            btnAjouterQuestion.UseVisualStyleBackColor = true;
            // 
            // cbBoxType
            // 
            cbBoxType.FormattingEnabled = true;
            cbBoxType.Location = new Point(188, 196);
            cbBoxType.Name = "cbBoxType";
            cbBoxType.Size = new Size(203, 33);
            cbBoxType.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(567, 201);
            label2.Name = "label2";
            label2.Size = new Size(89, 22);
            label2.TabIndex = 14;
            label2.Text = "Réponse :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(239, 32);
            textBox1.TabIndex = 15;
            // 
            // btnAjouterReponse
            // 
            btnAjouterReponse.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAjouterReponse.Location = new Point(251, 27);
            btnAjouterReponse.Name = "btnAjouterReponse";
            btnAjouterReponse.Size = new Size(85, 36);
            btnAjouterReponse.TabIndex = 16;
            btnAjouterReponse.Text = "Ajouter";
            btnAjouterReponse.UseVisualStyleBackColor = true;
            // 
            // chkReponseCorrecte
            // 
            chkReponseCorrecte.AutoSize = true;
            chkReponseCorrecte.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            chkReponseCorrecte.ForeColor = SystemColors.ButtonHighlight;
            chkReponseCorrecte.Location = new Point(6, 67);
            chkReponseCorrecte.Name = "chkReponseCorrecte";
            chkReponseCorrecte.Size = new Size(228, 25);
            chkReponseCorrecte.TabIndex = 17;
            chkReponseCorrecte.Text = "à cocher si réponse correcte";
            chkReponseCorrecte.UseVisualStyleBackColor = true;
            // 
            // GBvraiFaux
            // 
            GBvraiFaux.Controls.Add(rbfaux);
            GBvraiFaux.Controls.Add(rbVrai);
            GBvraiFaux.Controls.Add(button1);
            GBvraiFaux.Location = new Point(542, 238);
            GBvraiFaux.Name = "GBvraiFaux";
            GBvraiFaux.Size = new Size(136, 158);
            GBvraiFaux.TabIndex = 18;
            GBvraiFaux.TabStop = false;
            GBvraiFaux.Visible = false;
            // 
            // rbfaux
            // 
            rbfaux.AutoSize = true;
            rbfaux.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rbfaux.ForeColor = SystemColors.ButtonHighlight;
            rbfaux.Location = new Point(30, 74);
            rbfaux.Name = "rbfaux";
            rbfaux.Size = new Size(77, 28);
            rbfaux.TabIndex = 2;
            rbfaux.TabStop = true;
            rbfaux.Text = "Faux";
            rbfaux.UseVisualStyleBackColor = true;
            // 
            // rbVrai
            // 
            rbVrai.AutoSize = true;
            rbVrai.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rbVrai.ForeColor = SystemColors.ButtonHighlight;
            rbVrai.Location = new Point(30, 40);
            rbVrai.Name = "rbVrai";
            rbVrai.Size = new Size(70, 28);
            rbVrai.TabIndex = 1;
            rbVrai.TabStop = true;
            rbVrai.Text = "Vrai";
            rbVrai.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(13, 118);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // GBListeValeur
            // 
            GBListeValeur.Controls.Add(panelQCM);
            GBListeValeur.Controls.Add(textBox1);
            GBListeValeur.Controls.Add(btnAjouterReponse);
            GBListeValeur.Controls.Add(chkReponseCorrecte);
            GBListeValeur.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            GBListeValeur.Location = new Point(433, 238);
            GBListeValeur.Name = "GBListeValeur";
            GBListeValeur.Size = new Size(345, 148);
            GBListeValeur.TabIndex = 19;
            GBListeValeur.TabStop = false;
            GBListeValeur.Visible = false;
            // 
            // panelQCM
            // 
            panelQCM.Controls.Add(chkbrep4);
            panelQCM.Controls.Add(chkbrep2);
            panelQCM.Controls.Add(chkbrep3);
            panelQCM.Controls.Add(chkbrep1);
            panelQCM.Location = new Point(16, 10);
            panelQCM.Name = "panelQCM";
            panelQCM.Size = new Size(300, 111);
            panelQCM.TabIndex = 20;
            panelQCM.Visible = false;
            // 
            // chkbrep4
            // 
            chkbrep4.AutoSize = true;
            chkbrep4.ForeColor = SystemColors.ButtonHighlight;
            chkbrep4.Location = new Point(166, 55);
            chkbrep4.Name = "chkbrep4";
            chkbrep4.Size = new Size(129, 28);
            chkbrep4.TabIndex = 3;
            chkbrep4.Text = "Réponse 4";
            chkbrep4.UseVisualStyleBackColor = true;
            // 
            // chkbrep2
            // 
            chkbrep2.AutoSize = true;
            chkbrep2.ForeColor = SystemColors.ButtonHighlight;
            chkbrep2.Location = new Point(166, 16);
            chkbrep2.Name = "chkbrep2";
            chkbrep2.Size = new Size(129, 28);
            chkbrep2.TabIndex = 2;
            chkbrep2.Text = "Réponse 2";
            chkbrep2.UseVisualStyleBackColor = true;
            // 
            // chkbrep3
            // 
            chkbrep3.AutoSize = true;
            chkbrep3.ForeColor = SystemColors.ButtonHighlight;
            chkbrep3.Location = new Point(28, 55);
            chkbrep3.Name = "chkbrep3";
            chkbrep3.Size = new Size(123, 28);
            chkbrep3.TabIndex = 1;
            chkbrep3.Text = "Réponse3";
            chkbrep3.UseVisualStyleBackColor = true;
            // 
            // chkbrep1
            // 
            chkbrep1.AutoSize = true;
            chkbrep1.ForeColor = SystemColors.ButtonHighlight;
            chkbrep1.Location = new Point(28, 16);
            chkbrep1.Name = "chkbrep1";
            chkbrep1.Size = new Size(129, 28);
            chkbrep1.TabIndex = 0;
            chkbrep1.Text = "Réponse 1";
            chkbrep1.UseVisualStyleBackColor = true;
            // 
            // AjouterQuestionnaireForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(GBListeValeur);
            Controls.Add(GBvraiFaux);
            Controls.Add(label2);
            Controls.Add(cbBoxType);
            Controls.Add(btnAjouterQuestion);
            Controls.Add(txtQuestion);
            Controls.Add(label1);
            Controls.Add(btnAnnuler);
            Controls.Add(cbBoxTheme);
            Controls.Add(btnSauvegarder);
            Controls.Add(txtboxQuestionnaire);
            Controls.Add(DGVQuestion);
            Controls.Add(labelQuestion);
            Controls.Add(labelTheme);
            Controls.Add(labelTitre);
            Controls.Add(labelnvQuestionnaire);
            Name = "AjouterQuestionnaireForm";
            Text = "Ajouter un questionnaire";
            ((System.ComponentModel.ISupportInitialize)DGVQuestion).EndInit();
            GBvraiFaux.ResumeLayout(false);
            GBvraiFaux.PerformLayout();
            GBListeValeur.ResumeLayout(false);
            GBListeValeur.PerformLayout();
            panelQCM.ResumeLayout(false);
            panelQCM.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelnvQuestionnaire;
        private Label labelTitre;
        private Label labelTheme;
        private Label labelQuestion;
        private DataGridView DGVQuestion;
        private TextBox txtboxQuestionnaire;
        private Button btnSauvegarder;
        private ComboBox cbBoxTheme;
        private Button btnAnnuler;
        private Label label1;
        private TextBox txtQuestion;
        private Button btnAjouterQuestion;
        private ComboBox cbBoxType;
        private Label label2;
        private TextBox textBox1;
        private Button btnAjouterReponse;
        private CheckBox chkReponseCorrecte;
        private GroupBox GBvraiFaux;
        private Button button1;
        private RadioButton rbVrai;
        private RadioButton rbfaux;
        private GroupBox GBListeValeur;
        private Panel panelQCM;
        private CheckBox chkbrep1;
        private CheckBox chkbrep4;
        private CheckBox chkbrep2;
        private CheckBox chkbrep3;
    }
}