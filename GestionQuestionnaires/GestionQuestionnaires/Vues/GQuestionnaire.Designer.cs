namespace GestionQuestionnaires
{
    partial class GQuestionnaire
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DGV1 = new DataGridView();
            cMS1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            txtbox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGV1).BeginInit();
            cMS1.SuspendLayout();
            SuspendLayout();
            // 
            // DGV1
            // 
            DGV1.BackgroundColor = SystemColors.ActiveCaptionText;
            DGV1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV1.Location = new Point(86, 77);
            DGV1.Margin = new Padding(3, 4, 3, 4);
            DGV1.MultiSelect = false;
            DGV1.Name = "DGV1";
            DGV1.ReadOnly = true;
            DGV1.RowHeadersWidth = 62;
            DGV1.RowTemplate.Height = 33;
            DGV1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV1.Size = new Size(754, 346);
            DGV1.TabIndex = 1;
            DGV1.CellMouseClick += DGV1_CellMouseClick;
            // 
            // cMS1
            // 
            cMS1.ImageScalingSize = new Size(24, 24);
            cMS1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3 });
            cMS1.Name = "contextMenuStrip1";
            cMS1.Size = new Size(244, 100);
            cMS1.ItemClicked += cMS1_ItemClicked;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(243, 32);
            toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(243, 32);
            toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(243, 32);
            toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // txtbox1
            // 
            txtbox1.BackColor = SystemColors.InfoText;
            txtbox1.BorderStyle = BorderStyle.None;
            txtbox1.Font = new Font("Tahoma", 16F, FontStyle.Bold, GraphicsUnit.Point);
            txtbox1.ForeColor = SystemColors.Window;
            txtbox1.Location = new Point(86, 23);
            txtbox1.Margin = new Padding(3, 4, 3, 4);
            txtbox1.Name = "txtbox1";
            txtbox1.ReadOnly = true;
            txtbox1.Size = new Size(754, 39);
            txtbox1.TabIndex = 2;
            txtbox1.Text = "QUESTIONNAIRES";
            txtbox1.TextAlign = HorizontalAlignment.Center;
            // 
            // GQuestionnaire
            // 
            AutoScaleDimensions = new SizeF(12F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(960, 486);
            Controls.Add(txtbox1);
            Controls.Add(DGV1);
            Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GQuestionnaire";
            Text = "Liste des questionnaires";
            ((System.ComponentModel.ISupportInitialize)DGV1).EndInit();
            cMS1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView DGV1;
        private ContextMenuStrip cMS1;
        private ToolStripMenuItem ajouterToolStripMenuItem;
        private ToolStripMenuItem annulerToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem1;
        private TextBox txtbox1;
    }
}