namespace GestionQuestionnaires
{
    partial class EditerQuestionnaireForm
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
            components = new System.ComponentModel.Container();
            txtboxQuestionnaire = new TextBox();
            labelTitre = new Label();
            labelnvQuestionnaire = new Label();
            labelTheme = new Label();
            cbBoxTheme = new ComboBox();
            DGVQuestion = new DataGridView();
            cmsQuestion = new ContextMenuStrip(components);
            toolStripMenuItem1ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3ToolStripMenuItem = new ToolStripMenuItem();
            btnAnnuler = new Button();
            btnSauvegarder = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVQuestion).BeginInit();
            cmsQuestion.SuspendLayout();
            SuspendLayout();
            // 
            // txtboxQuestionnaire
            // 
            txtboxQuestionnaire.BackColor = SystemColors.ControlLightLight;
            txtboxQuestionnaire.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxQuestionnaire.ForeColor = Color.Black;
            txtboxQuestionnaire.Location = new Point(280, 121);
            txtboxQuestionnaire.Name = "txtboxQuestionnaire";
            txtboxQuestionnaire.Size = new Size(352, 32);
            txtboxQuestionnaire.TabIndex = 0;
            // 
            // labelTitre
            // 
            labelTitre.AutoSize = true;
            labelTitre.Font = new Font("Tahoma", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelTitre.ForeColor = SystemColors.HighlightText;
            labelTitre.Location = new Point(149, 30);
            labelTitre.Name = "labelTitre";
            labelTitre.Size = new Size(515, 39);
            labelTitre.TabIndex = 1;
            labelTitre.Text = "EDITER MON QUESTIONNAIRE";
            labelTitre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelnvQuestionnaire
            // 
            labelnvQuestionnaire.AutoSize = true;
            labelnvQuestionnaire.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelnvQuestionnaire.ForeColor = SystemColors.HighlightText;
            labelnvQuestionnaire.Location = new Point(195, 124);
            labelnvQuestionnaire.Name = "labelnvQuestionnaire";
            labelnvQuestionnaire.Size = new Size(65, 24);
            labelnvQuestionnaire.TabIndex = 2;
            labelnvQuestionnaire.Text = "Titre :";
            labelnvQuestionnaire.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTheme
            // 
            labelTheme.AutoSize = true;
            labelTheme.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTheme.ForeColor = SystemColors.HighlightText;
            labelTheme.Location = new Point(175, 183);
            labelTheme.Name = "labelTheme";
            labelTheme.Size = new Size(85, 24);
            labelTheme.TabIndex = 3;
            labelTheme.Text = "Thème :";
            labelTheme.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbBoxTheme
            // 
            cbBoxTheme.FormattingEnabled = true;
            cbBoxTheme.Location = new Point(280, 180);
            cbBoxTheme.Name = "cbBoxTheme";
            cbBoxTheme.Size = new Size(208, 33);
            cbBoxTheme.TabIndex = 5;
            // 
            // DGVQuestion
            // 
            DGVQuestion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVQuestion.Location = new Point(149, 239);
            DGVQuestion.Name = "DGVQuestion";
            DGVQuestion.ReadOnly = true;
            DGVQuestion.RowHeadersWidth = 62;
            DGVQuestion.RowTemplate.Height = 33;
            DGVQuestion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVQuestion.Size = new Size(515, 191);
            DGVQuestion.TabIndex = 6;
            DGVQuestion.CellMouseClick += DGVQuestion_CellMouseClick;
            // 
            // cmsQuestion
            // 
            cmsQuestion.ImageScalingSize = new Size(24, 24);
            cmsQuestion.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1ToolStripMenuItem, toolStripMenuItem2ToolStripMenuItem, toolStripMenuItem3ToolStripMenuItem });
            cmsQuestion.Name = "cmsQuestion";
            cmsQuestion.Size = new Size(244, 100);
            // 
            // toolStripMenuItem1ToolStripMenuItem
            // 
            toolStripMenuItem1ToolStripMenuItem.Name = "toolStripMenuItem1ToolStripMenuItem";
            toolStripMenuItem1ToolStripMenuItem.Size = new Size(243, 32);
            toolStripMenuItem1ToolStripMenuItem.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2ToolStripMenuItem
            // 
            toolStripMenuItem2ToolStripMenuItem.Name = "toolStripMenuItem2ToolStripMenuItem";
            toolStripMenuItem2ToolStripMenuItem.Size = new Size(243, 32);
            toolStripMenuItem2ToolStripMenuItem.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3ToolStripMenuItem
            // 
            toolStripMenuItem3ToolStripMenuItem.Name = "toolStripMenuItem3ToolStripMenuItem";
            toolStripMenuItem3ToolStripMenuItem.Size = new Size(243, 32);
            toolStripMenuItem3ToolStripMenuItem.Text = "toolStripMenuItem3";
            // 
            // btnAnnuler
            // 
            btnAnnuler.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAnnuler.Location = new Point(465, 447);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(167, 34);
            btnAnnuler.TabIndex = 7;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click_1;
            // 
            // btnSauvegarder
            // 
            btnSauvegarder.BackColor = SystemColors.ButtonHighlight;
            btnSauvegarder.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSauvegarder.ForeColor = SystemColors.ActiveCaptionText;
            btnSauvegarder.Location = new Point(646, 447);
            btnSauvegarder.Name = "btnSauvegarder";
            btnSauvegarder.Size = new Size(167, 34);
            btnSauvegarder.TabIndex = 8;
            btnSauvegarder.Text = "Sauvegarder";
            btnSauvegarder.UseVisualStyleBackColor = false;
            btnSauvegarder.Click += btnSauvegarder_Click_1;
            // 
            // EditerQuestionnaireForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(825, 502);
            Controls.Add(btnSauvegarder);
            Controls.Add(btnAnnuler);
            Controls.Add(DGVQuestion);
            Controls.Add(cbBoxTheme);
            Controls.Add(labelTheme);
            Controls.Add(labelnvQuestionnaire);
            Controls.Add(labelTitre);
            Controls.Add(txtboxQuestionnaire);
            Name = "EditerQuestionnaireForm";
            Text = "Editer un questionnaire";
            ((System.ComponentModel.ISupportInitialize)DGVQuestion).EndInit();
            cmsQuestion.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtboxQuestionnaire;
        private Label labelTitre;
        private Label labelnvQuestionnaire;
        private Label labelTheme;
        private ComboBox cbBoxTheme;
        private DataGridView DGVQuestion;
        private ContextMenuStrip cmsQuestion;
        private ToolStripMenuItem toolStripMenuItem1ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3ToolStripMenuItem;
        private Button btnAnnuler;
        private Button btnSauvegarder;
    }
}