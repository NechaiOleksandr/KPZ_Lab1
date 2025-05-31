namespace BlockDiagramEditor.WF
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDelete = new System.Windows.Forms.Button();
            this.showCenter = new System.Windows.Forms.CheckBox();
            this.BlocksPanel = new System.Windows.Forms.Panel();
            this.labelArrows = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelBlocks = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.panelCanvas = new BlockDiagramEditor.Controls.BufferedPanel();
            this.labelScale = new System.Windows.Forms.Label();
            this.unsetSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSelectArrow = new System.Windows.Forms.Button();
            this.btnSelectTerminator = new System.Windows.Forms.Button();
            this.btnSelectParalelogram = new System.Windows.Forms.Button();
            this.btnSelectRectangle = new System.Windows.Forms.Button();
            this.btnSelectEllipse = new System.Windows.Forms.Button();
            this.btnSelectDiamond = new System.Windows.Forms.Button();
            this.btnSelectHexagon = new System.Windows.Forms.Button();
            this.BlocksPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelCanvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.Location = new System.Drawing.Point(12, 526);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(157, 65);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // showCenter
            // 
            this.showCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showCenter.AutoSize = true;
            this.showCenter.Checked = true;
            this.showCenter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCenter.Location = new System.Drawing.Point(12, 594);
            this.showCenter.Name = "showCenter";
            this.showCenter.Size = new System.Drawing.Size(135, 20);
            this.showCenter.TabIndex = 7;
            this.showCenter.Text = "Показати центр";
            this.showCenter.UseVisualStyleBackColor = true;
            this.showCenter.CheckedChanged += new System.EventHandler(this.showCenter_CheckedChanged);
            // 
            // BlocksPanel
            // 
            this.BlocksPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BlocksPanel.AutoScroll = true;
            this.BlocksPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.BlocksPanel.Controls.Add(this.btnSelectTerminator);
            this.BlocksPanel.Controls.Add(this.btnSelectParalelogram);
            this.BlocksPanel.Controls.Add(this.btnSelectRectangle);
            this.BlocksPanel.Controls.Add(this.btnSelectEllipse);
            this.BlocksPanel.Controls.Add(this.btnSelectDiamond);
            this.BlocksPanel.Controls.Add(this.btnSelectHexagon);
            this.BlocksPanel.Location = new System.Drawing.Point(12, 34);
            this.BlocksPanel.Name = "BlocksPanel";
            this.BlocksPanel.Size = new System.Drawing.Size(157, 352);
            this.BlocksPanel.TabIndex = 9;
            // 
            // labelArrows
            // 
            this.labelArrows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelArrows.AutoSize = true;
            this.labelArrows.Location = new System.Drawing.Point(12, 389);
            this.labelArrows.Name = "labelArrows";
            this.labelArrows.Size = new System.Drawing.Size(50, 16);
            this.labelArrows.TabIndex = 11;
            this.labelArrows.Text = "Cрілки";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnSelectArrow);
            this.panel1.Location = new System.Drawing.Point(12, 408);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 112);
            this.panel1.TabIndex = 10;
            // 
            // labelBlocks
            // 
            this.labelBlocks.AutoSize = true;
            this.labelBlocks.Location = new System.Drawing.Point(9, 15);
            this.labelBlocks.Name = "labelBlocks";
            this.labelBlocks.Size = new System.Drawing.Size(47, 16);
            this.labelBlocks.TabIndex = 10;
            this.labelBlocks.Text = "Блоки";
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(172, 12);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(52, 16);
            this.labelSearch.TabIndex = 12;
            this.labelSearch.Text = "Пошук:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Location = new System.Drawing.Point(230, 9);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(144, 22);
            this.textBoxSearch.TabIndex = 13;
            // 
            // panelCanvas
            // 
            this.panelCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCanvas.BackColor = System.Drawing.Color.DarkGray;
            this.panelCanvas.Controls.Add(this.labelScale);
            this.panelCanvas.Location = new System.Drawing.Point(175, 34);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(896, 580);
            this.panelCanvas.TabIndex = 2;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            this.panelCanvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseDoubleClick);
            this.panelCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseDown);
            this.panelCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseMove);
            this.panelCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseUp);
            // 
            // labelScale
            // 
            this.labelScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(3, 561);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(104, 16);
            this.labelScale.TabIndex = 0;
            this.labelScale.Text = "Масштаб: 100%";
            // 
            // unsetSearch
            // 
            this.unsetSearch.BackColor = System.Drawing.Color.White;
            this.unsetSearch.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.UnsetSearch;
            this.unsetSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.unsetSearch.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.unsetSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.unsetSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.unsetSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unsetSearch.Location = new System.Drawing.Point(408, 9);
            this.unsetSearch.Name = "unsetSearch";
            this.unsetSearch.Size = new System.Drawing.Size(22, 22);
            this.unsetSearch.TabIndex = 14;
            this.unsetSearch.TabStop = false;
            this.unsetSearch.UseVisualStyleBackColor = false;
            this.unsetSearch.Click += new System.EventHandler(this.unsetSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(380, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(22, 22);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.TabStop = false;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSelectArrow
            // 
            this.btnSelectArrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectArrow.BackColor = System.Drawing.Color.White;
            this.btnSelectArrow.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.Arrow;
            this.btnSelectArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectArrow.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectArrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectArrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectArrow.Location = new System.Drawing.Point(3, 3);
            this.btnSelectArrow.Name = "btnSelectArrow";
            this.btnSelectArrow.Size = new System.Drawing.Size(130, 65);
            this.btnSelectArrow.TabIndex = 8;
            this.btnSelectArrow.TabStop = false;
            this.btnSelectArrow.UseVisualStyleBackColor = false;
            this.btnSelectArrow.Click += new System.EventHandler(this.btnSelectArrow_Click);
            // 
            // btnSelectTerminator
            // 
            this.btnSelectTerminator.BackColor = System.Drawing.Color.White;
            this.btnSelectTerminator.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.Terminator;
            this.btnSelectTerminator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectTerminator.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectTerminator.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectTerminator.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectTerminator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectTerminator.Location = new System.Drawing.Point(3, 3);
            this.btnSelectTerminator.Name = "btnSelectTerminator";
            this.btnSelectTerminator.Size = new System.Drawing.Size(130, 65);
            this.btnSelectTerminator.TabIndex = 2;
            this.btnSelectTerminator.TabStop = false;
            this.btnSelectTerminator.UseVisualStyleBackColor = false;
            this.btnSelectTerminator.Click += new System.EventHandler(this.btnSelectTerminator_Click);
            // 
            // btnSelectParalelogram
            // 
            this.btnSelectParalelogram.BackColor = System.Drawing.Color.White;
            this.btnSelectParalelogram.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.Paralelogram;
            this.btnSelectParalelogram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectParalelogram.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectParalelogram.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectParalelogram.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectParalelogram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectParalelogram.Location = new System.Drawing.Point(3, 74);
            this.btnSelectParalelogram.Name = "btnSelectParalelogram";
            this.btnSelectParalelogram.Size = new System.Drawing.Size(130, 65);
            this.btnSelectParalelogram.TabIndex = 3;
            this.btnSelectParalelogram.TabStop = false;
            this.btnSelectParalelogram.UseVisualStyleBackColor = false;
            this.btnSelectParalelogram.Click += new System.EventHandler(this.btnSelectParalelogram_Click);
            // 
            // btnSelectRectangle
            // 
            this.btnSelectRectangle.BackColor = System.Drawing.Color.White;
            this.btnSelectRectangle.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.Rectangle;
            this.btnSelectRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectRectangle.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectRectangle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectRectangle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectRectangle.Location = new System.Drawing.Point(3, 145);
            this.btnSelectRectangle.Name = "btnSelectRectangle";
            this.btnSelectRectangle.Size = new System.Drawing.Size(130, 65);
            this.btnSelectRectangle.TabIndex = 0;
            this.btnSelectRectangle.TabStop = false;
            this.btnSelectRectangle.UseVisualStyleBackColor = false;
            this.btnSelectRectangle.Click += new System.EventHandler(this.btnSelectRectangle_Click);
            // 
            // btnSelectEllipse
            // 
            this.btnSelectEllipse.BackColor = System.Drawing.Color.White;
            this.btnSelectEllipse.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.Ellipse;
            this.btnSelectEllipse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectEllipse.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectEllipse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectEllipse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectEllipse.Location = new System.Drawing.Point(3, 358);
            this.btnSelectEllipse.Name = "btnSelectEllipse";
            this.btnSelectEllipse.Size = new System.Drawing.Size(130, 65);
            this.btnSelectEllipse.TabIndex = 1;
            this.btnSelectEllipse.TabStop = false;
            this.btnSelectEllipse.UseVisualStyleBackColor = false;
            this.btnSelectEllipse.Click += new System.EventHandler(this.btnSelectEllipse_Click);
            // 
            // btnSelectDiamond
            // 
            this.btnSelectDiamond.BackColor = System.Drawing.Color.White;
            this.btnSelectDiamond.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.Diamond;
            this.btnSelectDiamond.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectDiamond.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectDiamond.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectDiamond.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectDiamond.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectDiamond.Location = new System.Drawing.Point(3, 216);
            this.btnSelectDiamond.Name = "btnSelectDiamond";
            this.btnSelectDiamond.Size = new System.Drawing.Size(130, 65);
            this.btnSelectDiamond.TabIndex = 4;
            this.btnSelectDiamond.TabStop = false;
            this.btnSelectDiamond.UseVisualStyleBackColor = false;
            this.btnSelectDiamond.Click += new System.EventHandler(this.btnSelectDiamond_Click);
            // 
            // btnSelectHexagon
            // 
            this.btnSelectHexagon.BackColor = System.Drawing.Color.White;
            this.btnSelectHexagon.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.Hexagon;
            this.btnSelectHexagon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectHexagon.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectHexagon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectHexagon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectHexagon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectHexagon.Location = new System.Drawing.Point(3, 287);
            this.btnSelectHexagon.Name = "btnSelectHexagon";
            this.btnSelectHexagon.Size = new System.Drawing.Size(130, 65);
            this.btnSelectHexagon.TabIndex = 5;
            this.btnSelectHexagon.TabStop = false;
            this.btnSelectHexagon.UseVisualStyleBackColor = false;
            this.btnSelectHexagon.Click += new System.EventHandler(this.btnSelectHexagon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1083, 626);
            this.Controls.Add(this.unsetSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.showCenter);
            this.Controls.Add(this.labelArrows);
            this.Controls.Add(this.labelBlocks);
            this.Controls.Add(this.BlocksPanel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.panelCanvas);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Block Diagram Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.BlocksPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelCanvas.ResumeLayout(false);
            this.panelCanvas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectRectangle;
        private System.Windows.Forms.Button btnSelectEllipse;
        private Controls.BufferedPanel panelCanvas;
        private System.Windows.Forms.Button btnSelectTerminator;
        private System.Windows.Forms.Button btnSelectHexagon;
        private System.Windows.Forms.Button btnSelectDiamond;
        private System.Windows.Forms.Button btnSelectParalelogram;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.CheckBox showCenter;
        private System.Windows.Forms.Button btnSelectArrow;
        private System.Windows.Forms.Panel BlocksPanel;
        private System.Windows.Forms.Label labelArrows;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelBlocks;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button unsetSearch;
    }
}

