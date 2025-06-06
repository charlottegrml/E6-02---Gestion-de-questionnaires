namespace GestionQuestionnaires.Vues
{
    partial class AjouterQuestion
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
            cboxType = new ComboBox();
            txtboxLibelle = new TextBox();
            gboxQCS = new GroupBox();
            btnAjouterQCS = new Button();
            checkBoxCorrecte = new CheckBox();
            txtProposition = new TextBox();
            txtPoidsQCS = new TextBox();
            label5 = new Label();
            gboxVF = new GroupBox();
            checkBoxNeg = new CheckBox();
            txtPoidsVF = new TextBox();
            label4 = new Label();
            rbFaux = new RadioButton();
            rbVrai = new RadioButton();
            DGVReponses = new DataGridView();
            btnSauvegarder = new Button();
            btnAnnuler = new Button();
            btnAjouter = new Button();
            gboxQCS.SuspendLayout();
            gboxVF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVReponses).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(139, 23);
            label1.Name = "label1";
            label1.Size = new Size(534, 48);
            label1.TabIndex = 4;
            label1.Text = "AJOUTER UNE QUESTION";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(12, 108);
            label2.Name = "label2";
            label2.Size = new Size(239, 29);
            label2.TabIndex = 5;
            label2.Text = "Titre de la Question :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(12, 155);
            label3.Name = "label3";
            label3.Size = new Size(242, 29);
            label3.TabIndex = 6;
            label3.Text = "Type de la Question :";
            // 
            // cboxType
            // 
            cboxType.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboxType.FormattingEnabled = true;
            cboxType.Location = new Point(303, 164);
            cboxType.Name = "cboxType";
            cboxType.Size = new Size(182, 32);
            cboxType.TabIndex = 7;
            cboxType.SelectedIndexChanged += cboxType_SelectedIndexChanged;
            // 
            // txtboxLibelle
            // 
            txtboxLibelle.Location = new Point(260, 113);
            txtboxLibelle.Name = "txtboxLibelle";
            txtboxLibelle.Size = new Size(440, 31);
            txtboxLibelle.TabIndex = 8;
            // 
            // gboxQCS
            // 
            gboxQCS.BackColor = SystemColors.ActiveCaptionText;
            gboxQCS.Controls.Add(btnAjouterQCS);
            gboxQCS.Controls.Add(checkBoxCorrecte);
            gboxQCS.Controls.Add(txtProposition);
            gboxQCS.Controls.Add(txtPoidsQCS);
            gboxQCS.Controls.Add(label5);
            gboxQCS.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            gboxQCS.ForeColor = SystemColors.ButtonHighlight;
            gboxQCS.Location = new Point(74, 224);
            gboxQCS.Name = "gboxQCS";
            gboxQCS.Size = new Size(417, 150);
            gboxQCS.TabIndex = 9;
            gboxQCS.TabStop = false;
            gboxQCS.Text = "Réponses type QCS :";
            // 
            // btnAjouterQCS
            // 
            btnAjouterQCS.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnAjouterQCS.ForeColor = SystemColors.ActiveCaptionText;
            btnAjouterQCS.Location = new Point(308, 99);
            btnAjouterQCS.Name = "btnAjouterQCS";
            btnAjouterQCS.Size = new Size(91, 31);
            btnAjouterQCS.TabIndex = 25;
            btnAjouterQCS.Text = "Ajouter";
            btnAjouterQCS.UseVisualStyleBackColor = true;
            btnAjouterQCS.Click += btnAjouterQCS_Click;
            // 
            // checkBoxCorrecte
            // 
            checkBoxCorrecte.AutoSize = true;
            checkBoxCorrecte.Location = new Point(279, 45);
            checkBoxCorrecte.Name = "checkBoxCorrecte";
            checkBoxCorrecte.Size = new Size(120, 31);
            checkBoxCorrecte.TabIndex = 14;
            checkBoxCorrecte.Text = "Correcte";
            checkBoxCorrecte.UseVisualStyleBackColor = true;
            // 
            // txtProposition
            // 
            txtProposition.Location = new Point(25, 42);
            txtProposition.Name = "txtProposition";
            txtProposition.Size = new Size(237, 34);
            txtProposition.TabIndex = 13;
            // 
            // txtPoidsQCS
            // 
            txtPoidsQCS.Location = new Point(131, 101);
            txtPoidsQCS.Name = "txtPoidsQCS";
            txtPoidsQCS.Size = new Size(145, 34);
            txtPoidsQCS.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(25, 101);
            label5.Name = "label5";
            label5.Size = new Size(84, 29);
            label5.TabIndex = 12;
            label5.Text = "Poids :";
            // 
            // gboxVF
            // 
            gboxVF.BackColor = SystemColors.ActiveCaptionText;
            gboxVF.Controls.Add(checkBoxNeg);
            gboxVF.Controls.Add(txtPoidsVF);
            gboxVF.Controls.Add(label4);
            gboxVF.Controls.Add(rbFaux);
            gboxVF.Controls.Add(rbVrai);
            gboxVF.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            gboxVF.ForeColor = SystemColors.ButtonHighlight;
            gboxVF.Location = new Point(99, 391);
            gboxVF.Name = "gboxVF";
            gboxVF.Size = new Size(362, 150);
            gboxVF.TabIndex = 10;
            gboxVF.TabStop = false;
            gboxVF.Text = "Réponses type Vrai / Faux :";
            // 
            // checkBoxNeg
            // 
            checkBoxNeg.AutoSize = true;
            checkBoxNeg.Font = new Font("Tahoma", 8F, FontStyle.Italic, GraphicsUnit.Point);
            checkBoxNeg.Location = new Point(32, 111);
            checkBoxNeg.Name = "checkBoxNeg";
            checkBoxNeg.Size = new Size(282, 23);
            checkBoxNeg.TabIndex = 15;
            checkBoxNeg.Text = "mauvaise réponse à point négatif ?";
            checkBoxNeg.UseVisualStyleBackColor = true;
            // 
            // txtPoidsVF
            // 
            txtPoidsVF.Location = new Point(127, 76);
            txtPoidsVF.Name = "txtPoidsVF";
            txtPoidsVF.Size = new Size(153, 34);
            txtPoidsVF.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(37, 76);
            label4.Name = "label4";
            label4.Size = new Size(84, 29);
            label4.TabIndex = 11;
            label4.Text = "Poids :";
            // 
            // rbFaux
            // 
            rbFaux.AutoSize = true;
            rbFaux.Location = new Point(231, 42);
            rbFaux.Name = "rbFaux";
            rbFaux.Size = new Size(83, 31);
            rbFaux.TabIndex = 1;
            rbFaux.TabStop = true;
            rbFaux.Text = "Faux";
            rbFaux.UseVisualStyleBackColor = true;
            // 
            // rbVrai
            // 
            rbVrai.AutoSize = true;
            rbVrai.Location = new Point(32, 42);
            rbVrai.Name = "rbVrai";
            rbVrai.Size = new Size(75, 31);
            rbVrai.TabIndex = 0;
            rbVrai.TabStop = true;
            rbVrai.Text = "Vrai";
            rbVrai.UseVisualStyleBackColor = true;
            // 
            // DGVReponses
            // 
            DGVReponses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVReponses.Location = new Point(497, 204);
            DGVReponses.Name = "DGVReponses";
            DGVReponses.RowHeadersWidth = 62;
            DGVReponses.RowTemplate.Height = 33;
            DGVReponses.Size = new Size(305, 337);
            DGVReponses.TabIndex = 21;
            // 
            // btnSauvegarder
            // 
            btnSauvegarder.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSauvegarder.Location = new Point(642, 547);
            btnSauvegarder.Name = "btnSauvegarder";
            btnSauvegarder.Size = new Size(150, 36);
            btnSauvegarder.TabIndex = 22;
            btnSauvegarder.Text = "Terminer";
            btnSauvegarder.UseVisualStyleBackColor = true;
            btnSauvegarder.Click += btnSauvegarder_Click;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnnuler.Location = new Point(43, 547);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(150, 36);
            btnAnnuler.TabIndex = 23;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // btnAjouter
            // 
            btnAjouter.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAjouter.Location = new Point(362, 547);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(150, 36);
            btnAjouter.TabIndex = 24;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // AjouterQuestion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(870, 613);
            Controls.Add(btnAjouter);
            Controls.Add(gboxVF);
            Controls.Add(btnAnnuler);
            Controls.Add(btnSauvegarder);
            Controls.Add(DGVReponses);
            Controls.Add(gboxQCS);
            Controls.Add(txtboxLibelle);
            Controls.Add(cboxType);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AjouterQuestion";
            Text = "Ajouter une Question";
            gboxQCS.ResumeLayout(false);
            gboxQCS.PerformLayout();
            gboxVF.ResumeLayout(false);
            gboxVF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVReponses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cboxType;
        private TextBox txtboxLibelle;
        private GroupBox gboxQCS;
        private TextBox txtProposition;
        private TextBox txtPoidsQCS;
        private Label label5;
        private GroupBox gboxVF;
        private TextBox txtPoidsVF;
        private Label label4;
        private RadioButton rbFaux;
        private RadioButton rbVrai;
        private CheckBox checkBoxCorrecte;
        private DataGridView DGVReponses;
        private Button btnSauvegarder;
        private CheckBox checkBoxNeg;
        private Button btnAnnuler;
        private Button btnAjouter;
        private Button btnAjouterQCS;
    }
}