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
            this.btnDeleteBlock = new System.Windows.Forms.Button();
            this.showCenter = new System.Windows.Forms.CheckBox();
            this.panelCanvas = new BlockDiagramEditor.Controls.BufferedPanel();
            this.labelScale = new System.Windows.Forms.Label();
            this.btnSelectHexagon = new System.Windows.Forms.Button();
            this.btnSelectDiamond = new System.Windows.Forms.Button();
            this.btnSelectTerminator = new System.Windows.Forms.Button();
            this.btnSelectParalelogram = new System.Windows.Forms.Button();
            this.btnSelectEllipse = new System.Windows.Forms.Button();
            this.btnSelectRectangle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCanvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeleteBlock
            // 
            this.btnDeleteBlock.BackColor = System.Drawing.Color.White;
            this.btnDeleteBlock.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnDeleteBlock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDeleteBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDeleteBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBlock.Location = new System.Drawing.Point(12, 516);
            this.btnDeleteBlock.Name = "btnDeleteBlock";
            this.btnDeleteBlock.Size = new System.Drawing.Size(130, 65);
            this.btnDeleteBlock.TabIndex = 6;
            this.btnDeleteBlock.TabStop = false;
            this.btnDeleteBlock.Text = "Видалити блок";
            this.btnDeleteBlock.UseVisualStyleBackColor = false;
            this.btnDeleteBlock.Click += new System.EventHandler(this.btnDeleteBlock_Click);
            // 
            // showCenter
            // 
            this.showCenter.AutoSize = true;
            this.showCenter.Checked = true;
            this.showCenter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCenter.Location = new System.Drawing.Point(12, 490);
            this.showCenter.Name = "showCenter";
            this.showCenter.Size = new System.Drawing.Size(135, 20);
            this.showCenter.TabIndex = 7;
            this.showCenter.Text = "Показати центр";
            this.showCenter.UseVisualStyleBackColor = true;
            this.showCenter.CheckedChanged += new System.EventHandler(this.showCenter_CheckedChanged);
            // 
            // panelCanvas
            // 
            this.panelCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCanvas.BackColor = System.Drawing.Color.Silver;
            this.panelCanvas.Controls.Add(this.labelScale);
            this.panelCanvas.Location = new System.Drawing.Point(151, 12);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(860, 572);
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
            this.labelScale.Location = new System.Drawing.Point(3, 553);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(104, 16);
            this.labelScale.TabIndex = 0;
            this.labelScale.Text = "Масштаб: 100%";
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
            this.btnSelectHexagon.Location = new System.Drawing.Point(12, 296);
            this.btnSelectHexagon.Name = "btnSelectHexagon";
            this.btnSelectHexagon.Size = new System.Drawing.Size(130, 65);
            this.btnSelectHexagon.TabIndex = 5;
            this.btnSelectHexagon.TabStop = false;
            this.btnSelectHexagon.UseVisualStyleBackColor = false;
            this.btnSelectHexagon.Click += new System.EventHandler(this.btnSelectHexagon_Click);
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
            this.btnSelectDiamond.Location = new System.Drawing.Point(12, 225);
            this.btnSelectDiamond.Name = "btnSelectDiamond";
            this.btnSelectDiamond.Size = new System.Drawing.Size(130, 65);
            this.btnSelectDiamond.TabIndex = 4;
            this.btnSelectDiamond.TabStop = false;
            this.btnSelectDiamond.UseVisualStyleBackColor = false;
            this.btnSelectDiamond.Click += new System.EventHandler(this.btnSelectDiamond_Click);
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
            this.btnSelectTerminator.Location = new System.Drawing.Point(12, 12);
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
            this.btnSelectParalelogram.Location = new System.Drawing.Point(12, 83);
            this.btnSelectParalelogram.Name = "btnSelectParalelogram";
            this.btnSelectParalelogram.Size = new System.Drawing.Size(130, 65);
            this.btnSelectParalelogram.TabIndex = 3;
            this.btnSelectParalelogram.TabStop = false;
            this.btnSelectParalelogram.UseVisualStyleBackColor = false;
            this.btnSelectParalelogram.Click += new System.EventHandler(this.btnSelectParalelogram_Click);
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
            this.btnSelectEllipse.Location = new System.Drawing.Point(12, 367);
            this.btnSelectEllipse.Name = "btnSelectEllipse";
            this.btnSelectEllipse.Size = new System.Drawing.Size(130, 65);
            this.btnSelectEllipse.TabIndex = 1;
            this.btnSelectEllipse.TabStop = false;
            this.btnSelectEllipse.UseVisualStyleBackColor = false;
            this.btnSelectEllipse.Click += new System.EventHandler(this.btnSelectEllipse_Click);
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
            this.btnSelectRectangle.Location = new System.Drawing.Point(12, 154);
            this.btnSelectRectangle.Name = "btnSelectRectangle";
            this.btnSelectRectangle.Size = new System.Drawing.Size(130, 65);
            this.btnSelectRectangle.TabIndex = 0;
            this.btnSelectRectangle.TabStop = false;
            this.btnSelectRectangle.UseVisualStyleBackColor = false;
            this.btnSelectRectangle.Click += new System.EventHandler(this.btnSelectRectangle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1023, 596);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showCenter);
            this.Controls.Add(this.btnDeleteBlock);
            this.Controls.Add(this.btnSelectHexagon);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.btnSelectDiamond);
            this.Controls.Add(this.btnSelectTerminator);
            this.Controls.Add(this.btnSelectParalelogram);
            this.Controls.Add(this.btnSelectEllipse);
            this.Controls.Add(this.btnSelectRectangle);
            this.Name = "Form1";
            this.Text = "Block Diagram Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
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
        private System.Windows.Forms.Button btnDeleteBlock;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.CheckBox showCenter;
        private System.Windows.Forms.Label label1;
    }
}

