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
            this.showGrid = new System.Windows.Forms.CheckBox();
            this.BlocksPanel = new System.Windows.Forms.Panel();
            this.btnSelectText = new System.Windows.Forms.Button();
            this.btnSelectTerminator = new System.Windows.Forms.Button();
            this.btnSelectParalelogram = new System.Windows.Forms.Button();
            this.btnSelectRectangle = new System.Windows.Forms.Button();
            this.btnSelectEllipse = new System.Windows.Forms.Button();
            this.btnSelectDiamond = new System.Windows.Forms.Button();
            this.btnSelectHexagon = new System.Windows.Forms.Button();
            this.labelArrows = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectTwoHeadedArrow = new System.Windows.Forms.Button();
            this.btnSelectLineArrow = new System.Windows.Forms.Button();
            this.btnSelectFilledTrArrow = new System.Windows.Forms.Button();
            this.btnSelectEmptyTrArrow = new System.Windows.Forms.Button();
            this.btnSelectArrow = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelBlocks = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.unsetSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblExportImport = new System.Windows.Forms.Label();
            this.panelCanvas = new BlockDiagramEditor.Controls.BufferedPanel();
            this.panelArrowStyleEdit = new System.Windows.Forms.Panel();
            this.nudArrowWidth = new System.Windows.Forms.NumericUpDown();
            this.lblArrowWidth = new System.Windows.Forms.Label();
            this.lblArrowColor = new System.Windows.Forms.Label();
            this.btnArrowColor = new System.Windows.Forms.Button();
            this.btnApplyArrowStyle = new System.Windows.Forms.Button();
            this.panelBlockStyleEdit = new System.Windows.Forms.Panel();
            this.lblBlockTextColor = new System.Windows.Forms.Label();
            this.btnBlockTextColor = new System.Windows.Forms.Button();
            this.tbBlockFont = new System.Windows.Forms.TextBox();
            this.lblBlockFont = new System.Windows.Forms.Label();
            this.nudBlockBorderWidth = new System.Windows.Forms.NumericUpDown();
            this.lblBlockBorderWidth = new System.Windows.Forms.Label();
            this.lblBlockBorderColor = new System.Windows.Forms.Label();
            this.btnBlockBorderColor = new System.Windows.Forms.Button();
            this.lblBlockColor = new System.Windows.Forms.Label();
            this.btnBLockColor = new System.Windows.Forms.Button();
            this.nudBlockWidth = new System.Windows.Forms.NumericUpDown();
            this.nudBlockHeight = new System.Windows.Forms.NumericUpDown();
            this.nudBlockY = new System.Windows.Forms.NumericUpDown();
            this.nudBlockX = new System.Windows.Forms.NumericUpDown();
            this.btnApplyBlockStyle = new System.Windows.Forms.Button();
            this.lblBlockWidth = new System.Windows.Forms.Label();
            this.lblBlockHeight = new System.Windows.Forms.Label();
            this.lblBlockY = new System.Windows.Forms.Label();
            this.lblBlockX = new System.Windows.Forms.Label();
            this.labelScale = new System.Windows.Forms.Label();
            this.BlocksPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelCanvas.SuspendLayout();
            this.panelArrowStyleEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudArrowWidth)).BeginInit();
            this.panelBlockStyleEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockBorderWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockX)).BeginInit();
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
            this.btnDelete.Location = new System.Drawing.Point(8, 703);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(170, 48);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // showGrid
            // 
            this.showGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showGrid.AutoSize = true;
            this.showGrid.Checked = true;
            this.showGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGrid.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showGrid.Location = new System.Drawing.Point(8, 766);
            this.showGrid.Name = "showGrid";
            this.showGrid.Size = new System.Drawing.Size(63, 23);
            this.showGrid.TabIndex = 7;
            this.showGrid.Text = "Сітка";
            this.showGrid.UseVisualStyleBackColor = true;
            this.showGrid.CheckedChanged += new System.EventHandler(this.showCenter_CheckedChanged);
            // 
            // BlocksPanel
            // 
            this.BlocksPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BlocksPanel.AutoScroll = true;
            this.BlocksPanel.BackColor = System.Drawing.Color.LightGray;
            this.BlocksPanel.Controls.Add(this.btnSelectText);
            this.BlocksPanel.Controls.Add(this.btnSelectTerminator);
            this.BlocksPanel.Controls.Add(this.btnSelectParalelogram);
            this.BlocksPanel.Controls.Add(this.btnSelectRectangle);
            this.BlocksPanel.Controls.Add(this.btnSelectEllipse);
            this.BlocksPanel.Controls.Add(this.btnSelectDiamond);
            this.BlocksPanel.Controls.Add(this.btnSelectHexagon);
            this.BlocksPanel.Location = new System.Drawing.Point(3, 23);
            this.BlocksPanel.Name = "BlocksPanel";
            this.BlocksPanel.Size = new System.Drawing.Size(167, 310);
            this.BlocksPanel.TabIndex = 9;
            // 
            // btnSelectText
            // 
            this.btnSelectText.BackColor = System.Drawing.Color.White;
            this.btnSelectText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectText.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectText.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectText.Location = new System.Drawing.Point(8, 429);
            this.btnSelectText.Name = "btnSelectText";
            this.btnSelectText.Size = new System.Drawing.Size(130, 65);
            this.btnSelectText.TabIndex = 6;
            this.btnSelectText.TabStop = false;
            this.btnSelectText.Text = "Текст";
            this.btnSelectText.UseVisualStyleBackColor = false;
            this.btnSelectText.Click += new System.EventHandler(this.btnSelectText_Click);
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
            this.btnSelectTerminator.Location = new System.Drawing.Point(8, 3);
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
            this.btnSelectParalelogram.Location = new System.Drawing.Point(8, 74);
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
            this.btnSelectRectangle.Location = new System.Drawing.Point(8, 145);
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
            this.btnSelectEllipse.Location = new System.Drawing.Point(8, 358);
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
            this.btnSelectDiamond.Location = new System.Drawing.Point(8, 216);
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
            this.btnSelectHexagon.Location = new System.Drawing.Point(8, 287);
            this.btnSelectHexagon.Name = "btnSelectHexagon";
            this.btnSelectHexagon.Size = new System.Drawing.Size(130, 65);
            this.btnSelectHexagon.TabIndex = 5;
            this.btnSelectHexagon.TabStop = false;
            this.btnSelectHexagon.UseVisualStyleBackColor = false;
            this.btnSelectHexagon.Click += new System.EventHandler(this.btnSelectHexagon_Click);
            // 
            // labelArrows
            // 
            this.labelArrows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelArrows.AutoSize = true;
            this.labelArrows.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelArrows.Location = new System.Drawing.Point(3, 337);
            this.labelArrows.Name = "labelArrows";
            this.labelArrows.Size = new System.Drawing.Size(58, 19);
            this.labelArrows.TabIndex = 11;
            this.labelArrows.Text = "Cтрілки";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnSelectTwoHeadedArrow);
            this.panel1.Controls.Add(this.btnSelectLineArrow);
            this.panel1.Controls.Add(this.btnSelectFilledTrArrow);
            this.panel1.Controls.Add(this.btnSelectEmptyTrArrow);
            this.panel1.Controls.Add(this.btnSelectArrow);
            this.panel1.Location = new System.Drawing.Point(3, 359);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 311);
            this.panel1.TabIndex = 10;
            // 
            // btnSelectTwoHeadedArrow
            // 
            this.btnSelectTwoHeadedArrow.BackColor = System.Drawing.Color.White;
            this.btnSelectTwoHeadedArrow.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.TwoHeadedArrow;
            this.btnSelectTwoHeadedArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectTwoHeadedArrow.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectTwoHeadedArrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectTwoHeadedArrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectTwoHeadedArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectTwoHeadedArrow.Location = new System.Drawing.Point(8, 287);
            this.btnSelectTwoHeadedArrow.Name = "btnSelectTwoHeadedArrow";
            this.btnSelectTwoHeadedArrow.Size = new System.Drawing.Size(130, 65);
            this.btnSelectTwoHeadedArrow.TabIndex = 17;
            this.btnSelectTwoHeadedArrow.TabStop = false;
            this.btnSelectTwoHeadedArrow.UseVisualStyleBackColor = false;
            this.btnSelectTwoHeadedArrow.Click += new System.EventHandler(this.btnSelectTwoHeadedArrow_Click);
            // 
            // btnSelectLineArrow
            // 
            this.btnSelectLineArrow.BackColor = System.Drawing.Color.White;
            this.btnSelectLineArrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectLineArrow.BackgroundImage")));
            this.btnSelectLineArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectLineArrow.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectLineArrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectLineArrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectLineArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectLineArrow.Location = new System.Drawing.Point(8, 216);
            this.btnSelectLineArrow.Name = "btnSelectLineArrow";
            this.btnSelectLineArrow.Size = new System.Drawing.Size(130, 65);
            this.btnSelectLineArrow.TabIndex = 16;
            this.btnSelectLineArrow.TabStop = false;
            this.btnSelectLineArrow.UseVisualStyleBackColor = false;
            this.btnSelectLineArrow.Click += new System.EventHandler(this.btnSelectLineArrow_Click);
            // 
            // btnSelectFilledTrArrow
            // 
            this.btnSelectFilledTrArrow.BackColor = System.Drawing.Color.White;
            this.btnSelectFilledTrArrow.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.FilledTrArrow;
            this.btnSelectFilledTrArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectFilledTrArrow.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectFilledTrArrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectFilledTrArrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectFilledTrArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFilledTrArrow.Location = new System.Drawing.Point(8, 145);
            this.btnSelectFilledTrArrow.Name = "btnSelectFilledTrArrow";
            this.btnSelectFilledTrArrow.Size = new System.Drawing.Size(130, 65);
            this.btnSelectFilledTrArrow.TabIndex = 15;
            this.btnSelectFilledTrArrow.TabStop = false;
            this.btnSelectFilledTrArrow.UseVisualStyleBackColor = false;
            this.btnSelectFilledTrArrow.Click += new System.EventHandler(this.btnSelectFilledTrArrow_Click);
            // 
            // btnSelectEmptyTrArrow
            // 
            this.btnSelectEmptyTrArrow.BackColor = System.Drawing.Color.White;
            this.btnSelectEmptyTrArrow.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.EmptyTrArrow;
            this.btnSelectEmptyTrArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectEmptyTrArrow.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectEmptyTrArrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectEmptyTrArrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectEmptyTrArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectEmptyTrArrow.Location = new System.Drawing.Point(8, 74);
            this.btnSelectEmptyTrArrow.Name = "btnSelectEmptyTrArrow";
            this.btnSelectEmptyTrArrow.Size = new System.Drawing.Size(130, 65);
            this.btnSelectEmptyTrArrow.TabIndex = 14;
            this.btnSelectEmptyTrArrow.TabStop = false;
            this.btnSelectEmptyTrArrow.UseVisualStyleBackColor = false;
            this.btnSelectEmptyTrArrow.Click += new System.EventHandler(this.btnSelectEmptyTrArrow_Click);
            // 
            // btnSelectArrow
            // 
            this.btnSelectArrow.BackColor = System.Drawing.Color.White;
            this.btnSelectArrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectArrow.BackgroundImage")));
            this.btnSelectArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectArrow.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectArrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectArrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectArrow.Location = new System.Drawing.Point(8, 3);
            this.btnSelectArrow.Name = "btnSelectArrow";
            this.btnSelectArrow.Size = new System.Drawing.Size(130, 65);
            this.btnSelectArrow.TabIndex = 13;
            this.btnSelectArrow.TabStop = false;
            this.btnSelectArrow.UseVisualStyleBackColor = false;
            this.btnSelectArrow.Click += new System.EventHandler(this.btnSelectClasicArrow_Click);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSearch.Location = new System.Drawing.Point(187, 8);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(55, 19);
            this.labelSearch.TabIndex = 12;
            this.labelSearch.Text = "Пошук:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSearch.Location = new System.Drawing.Point(245, 7);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(263, 24);
            this.textBoxSearch.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelArrows, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.BlocksPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelBlocks, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(173, 673);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // labelBlocks
            // 
            this.labelBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBlocks.AutoSize = true;
            this.labelBlocks.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBlocks.Location = new System.Drawing.Point(3, 1);
            this.labelBlocks.Name = "labelBlocks";
            this.labelBlocks.Size = new System.Drawing.Size(48, 19);
            this.labelBlocks.TabIndex = 12;
            this.labelBlocks.Text = "Блоки";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.Export;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExport.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(1165, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(25, 25);
            this.btnExport.TabIndex = 17;
            this.btnExport.TabStop = false;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.White;
            this.btnImport.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.Import;
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(1196, 8);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(25, 25);
            this.btnImport.TabIndex = 16;
            this.btnImport.TabStop = false;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
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
            this.unsetSearch.Location = new System.Drawing.Point(542, 8);
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
            this.btnSearch.BackgroundImage = global::BlockDiagramEditor.WF.Properties.Resources.Search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(514, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(22, 22);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.TabStop = false;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblExportImport
            // 
            this.lblExportImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExportImport.AutoSize = true;
            this.lblExportImport.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblExportImport.Location = new System.Drawing.Point(1023, 9);
            this.lblExportImport.Name = "lblExportImport";
            this.lblExportImport.Size = new System.Drawing.Size(128, 19);
            this.lblExportImport.TabIndex = 35;
            this.lblExportImport.Text = "Зберегти/відкрити";
            // 
            // panelCanvas
            // 
            this.panelCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCanvas.BackColor = System.Drawing.Color.DarkGray;
            this.panelCanvas.Controls.Add(this.panelArrowStyleEdit);
            this.panelCanvas.Controls.Add(this.panelBlockStyleEdit);
            this.panelCanvas.Controls.Add(this.labelScale);
            this.panelCanvas.Location = new System.Drawing.Point(191, 34);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(1030, 755);
            this.panelCanvas.TabIndex = 2;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            this.panelCanvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseDoubleClick);
            this.panelCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseDown);
            this.panelCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseMove);
            this.panelCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseUp);
            // 
            // panelArrowStyleEdit
            // 
            this.panelArrowStyleEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelArrowStyleEdit.BackColor = System.Drawing.Color.LightGray;
            this.panelArrowStyleEdit.Controls.Add(this.nudArrowWidth);
            this.panelArrowStyleEdit.Controls.Add(this.lblArrowWidth);
            this.panelArrowStyleEdit.Controls.Add(this.lblArrowColor);
            this.panelArrowStyleEdit.Controls.Add(this.btnArrowColor);
            this.panelArrowStyleEdit.Controls.Add(this.btnApplyArrowStyle);
            this.panelArrowStyleEdit.Location = new System.Drawing.Point(808, 3);
            this.panelArrowStyleEdit.Name = "panelArrowStyleEdit";
            this.panelArrowStyleEdit.Size = new System.Drawing.Size(219, 121);
            this.panelArrowStyleEdit.TabIndex = 35;
            this.panelArrowStyleEdit.Visible = false;
            // 
            // nudArrowWidth
            // 
            this.nudArrowWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudArrowWidth.Location = new System.Drawing.Point(129, 37);
            this.nudArrowWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudArrowWidth.Name = "nudArrowWidth";
            this.nudArrowWidth.Size = new System.Drawing.Size(79, 22);
            this.nudArrowWidth.TabIndex = 31;
            // 
            // lblArrowWidth
            // 
            this.lblArrowWidth.AutoSize = true;
            this.lblArrowWidth.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblArrowWidth.Location = new System.Drawing.Point(3, 37);
            this.lblArrowWidth.Name = "lblArrowWidth";
            this.lblArrowWidth.Size = new System.Drawing.Size(118, 19);
            this.lblArrowWidth.TabIndex = 30;
            this.lblArrowWidth.Text = "Товщина стрілки";
            // 
            // lblArrowColor
            // 
            this.lblArrowColor.AutoSize = true;
            this.lblArrowColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblArrowColor.Location = new System.Drawing.Point(26, 12);
            this.lblArrowColor.Name = "lblArrowColor";
            this.lblArrowColor.Size = new System.Drawing.Size(95, 19);
            this.lblArrowColor.TabIndex = 29;
            this.lblArrowColor.Text = "Колір стрілки";
            // 
            // btnArrowColor
            // 
            this.btnArrowColor.BackColor = System.Drawing.Color.White;
            this.btnArrowColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnArrowColor.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnArrowColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnArrowColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnArrowColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArrowColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnArrowColor.Location = new System.Drawing.Point(129, 12);
            this.btnArrowColor.Name = "btnArrowColor";
            this.btnArrowColor.Size = new System.Drawing.Size(79, 19);
            this.btnArrowColor.TabIndex = 28;
            this.btnArrowColor.TabStop = false;
            this.btnArrowColor.UseVisualStyleBackColor = false;
            this.btnArrowColor.Click += new System.EventHandler(this.btnArrowColor_Click);
            // 
            // btnApplyArrowStyle
            // 
            this.btnApplyArrowStyle.BackColor = System.Drawing.Color.White;
            this.btnApplyArrowStyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApplyArrowStyle.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnApplyArrowStyle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnApplyArrowStyle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnApplyArrowStyle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyArrowStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApplyArrowStyle.Location = new System.Drawing.Point(7, 74);
            this.btnApplyArrowStyle.Name = "btnApplyArrowStyle";
            this.btnApplyArrowStyle.Size = new System.Drawing.Size(111, 38);
            this.btnApplyArrowStyle.TabIndex = 7;
            this.btnApplyArrowStyle.TabStop = false;
            this.btnApplyArrowStyle.Text = "Застосувати";
            this.btnApplyArrowStyle.UseVisualStyleBackColor = false;
            this.btnApplyArrowStyle.Click += new System.EventHandler(this.btnApplyArrowStyle_Click);
            // 
            // panelBlockStyleEdit
            // 
            this.panelBlockStyleEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBlockStyleEdit.BackColor = System.Drawing.Color.LightGray;
            this.panelBlockStyleEdit.Controls.Add(this.lblBlockTextColor);
            this.panelBlockStyleEdit.Controls.Add(this.btnBlockTextColor);
            this.panelBlockStyleEdit.Controls.Add(this.tbBlockFont);
            this.panelBlockStyleEdit.Controls.Add(this.lblBlockFont);
            this.panelBlockStyleEdit.Controls.Add(this.nudBlockBorderWidth);
            this.panelBlockStyleEdit.Controls.Add(this.lblBlockBorderWidth);
            this.panelBlockStyleEdit.Controls.Add(this.lblBlockBorderColor);
            this.panelBlockStyleEdit.Controls.Add(this.btnBlockBorderColor);
            this.panelBlockStyleEdit.Controls.Add(this.lblBlockColor);
            this.panelBlockStyleEdit.Controls.Add(this.btnBLockColor);
            this.panelBlockStyleEdit.Controls.Add(this.nudBlockWidth);
            this.panelBlockStyleEdit.Controls.Add(this.nudBlockHeight);
            this.panelBlockStyleEdit.Controls.Add(this.nudBlockY);
            this.panelBlockStyleEdit.Controls.Add(this.nudBlockX);
            this.panelBlockStyleEdit.Controls.Add(this.btnApplyBlockStyle);
            this.panelBlockStyleEdit.Controls.Add(this.lblBlockWidth);
            this.panelBlockStyleEdit.Controls.Add(this.lblBlockHeight);
            this.panelBlockStyleEdit.Controls.Add(this.lblBlockY);
            this.panelBlockStyleEdit.Controls.Add(this.lblBlockX);
            this.panelBlockStyleEdit.Location = new System.Drawing.Point(599, 3);
            this.panelBlockStyleEdit.Name = "panelBlockStyleEdit";
            this.panelBlockStyleEdit.Size = new System.Drawing.Size(428, 254);
            this.panelBlockStyleEdit.TabIndex = 1;
            this.panelBlockStyleEdit.Visible = false;
            // 
            // lblBlockTextColor
            // 
            this.lblBlockTextColor.AutoSize = true;
            this.lblBlockTextColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBlockTextColor.Location = new System.Drawing.Point(3, 167);
            this.lblBlockTextColor.Name = "lblBlockTextColor";
            this.lblBlockTextColor.Size = new System.Drawing.Size(88, 19);
            this.lblBlockTextColor.TabIndex = 34;
            this.lblBlockTextColor.Text = "Колір тексту";
            // 
            // btnBlockTextColor
            // 
            this.btnBlockTextColor.BackColor = System.Drawing.Color.White;
            this.btnBlockTextColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlockTextColor.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnBlockTextColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBlockTextColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBlockTextColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlockTextColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBlockTextColor.Location = new System.Drawing.Point(99, 167);
            this.btnBlockTextColor.Name = "btnBlockTextColor";
            this.btnBlockTextColor.Size = new System.Drawing.Size(79, 19);
            this.btnBlockTextColor.TabIndex = 33;
            this.btnBlockTextColor.TabStop = false;
            this.btnBlockTextColor.UseVisualStyleBackColor = false;
            this.btnBlockTextColor.Click += new System.EventHandler(this.btnBlockTextColor_Click);
            // 
            // tbBlockFont
            // 
            this.tbBlockFont.BackColor = System.Drawing.Color.White;
            this.tbBlockFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBlockFont.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBlockFont.Location = new System.Drawing.Point(99, 137);
            this.tbBlockFont.Name = "tbBlockFont";
            this.tbBlockFont.ReadOnly = true;
            this.tbBlockFont.Size = new System.Drawing.Size(321, 24);
            this.tbBlockFont.TabIndex = 16;
            this.tbBlockFont.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbBlockFont_MouseClick);
            // 
            // lblBlockFont
            // 
            this.lblBlockFont.AutoSize = true;
            this.lblBlockFont.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBlockFont.Location = new System.Drawing.Point(37, 139);
            this.lblBlockFont.Name = "lblBlockFont";
            this.lblBlockFont.Size = new System.Drawing.Size(54, 19);
            this.lblBlockFont.TabIndex = 32;
            this.lblBlockFont.Text = "Шрифт";
            // 
            // nudBlockBorderWidth
            // 
            this.nudBlockBorderWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudBlockBorderWidth.Location = new System.Drawing.Point(341, 99);
            this.nudBlockBorderWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBlockBorderWidth.Name = "nudBlockBorderWidth";
            this.nudBlockBorderWidth.Size = new System.Drawing.Size(79, 22);
            this.nudBlockBorderWidth.TabIndex = 31;
            // 
            // lblBlockBorderWidth
            // 
            this.lblBlockBorderWidth.AutoSize = true;
            this.lblBlockBorderWidth.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBlockBorderWidth.Location = new System.Drawing.Point(193, 99);
            this.lblBlockBorderWidth.Name = "lblBlockBorderWidth";
            this.lblBlockBorderWidth.Size = new System.Drawing.Size(140, 19);
            this.lblBlockBorderWidth.TabIndex = 30;
            this.lblBlockBorderWidth.Text = "Товщина обведення";
            // 
            // lblBlockBorderColor
            // 
            this.lblBlockBorderColor.AutoSize = true;
            this.lblBlockBorderColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBlockBorderColor.Location = new System.Drawing.Point(216, 74);
            this.lblBlockBorderColor.Name = "lblBlockBorderColor";
            this.lblBlockBorderColor.Size = new System.Drawing.Size(117, 19);
            this.lblBlockBorderColor.TabIndex = 29;
            this.lblBlockBorderColor.Text = "Колір обведення";
            // 
            // btnBlockBorderColor
            // 
            this.btnBlockBorderColor.BackColor = System.Drawing.Color.White;
            this.btnBlockBorderColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlockBorderColor.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnBlockBorderColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBlockBorderColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBlockBorderColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlockBorderColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBlockBorderColor.Location = new System.Drawing.Point(341, 74);
            this.btnBlockBorderColor.Name = "btnBlockBorderColor";
            this.btnBlockBorderColor.Size = new System.Drawing.Size(79, 19);
            this.btnBlockBorderColor.TabIndex = 28;
            this.btnBlockBorderColor.TabStop = false;
            this.btnBlockBorderColor.UseVisualStyleBackColor = false;
            this.btnBlockBorderColor.Click += new System.EventHandler(this.btnBlockBorderColor_Click);
            // 
            // lblBlockColor
            // 
            this.lblBlockColor.AutoSize = true;
            this.lblBlockColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBlockColor.Location = new System.Drawing.Point(3, 74);
            this.lblBlockColor.Name = "lblBlockColor";
            this.lblBlockColor.Size = new System.Drawing.Size(86, 19);
            this.lblBlockColor.TabIndex = 27;
            this.lblBlockColor.Text = "Колір блоку";
            // 
            // btnBLockColor
            // 
            this.btnBLockColor.BackColor = System.Drawing.Color.White;
            this.btnBLockColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBLockColor.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnBLockColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBLockColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBLockColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBLockColor.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBLockColor.Location = new System.Drawing.Point(97, 74);
            this.btnBLockColor.Name = "btnBLockColor";
            this.btnBLockColor.Size = new System.Drawing.Size(79, 19);
            this.btnBLockColor.TabIndex = 26;
            this.btnBLockColor.TabStop = false;
            this.btnBLockColor.UseVisualStyleBackColor = false;
            this.btnBLockColor.Click += new System.EventHandler(this.btnBLockColor_Click);
            // 
            // nudBlockWidth
            // 
            this.nudBlockWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudBlockWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBlockWidth.Location = new System.Drawing.Point(341, 10);
            this.nudBlockWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBlockWidth.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudBlockWidth.Name = "nudBlockWidth";
            this.nudBlockWidth.Size = new System.Drawing.Size(79, 22);
            this.nudBlockWidth.TabIndex = 25;
            this.nudBlockWidth.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // nudBlockHeight
            // 
            this.nudBlockHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudBlockHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBlockHeight.Location = new System.Drawing.Point(341, 37);
            this.nudBlockHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBlockHeight.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudBlockHeight.Name = "nudBlockHeight";
            this.nudBlockHeight.Size = new System.Drawing.Size(79, 22);
            this.nudBlockHeight.TabIndex = 24;
            this.nudBlockHeight.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // nudBlockY
            // 
            this.nudBlockY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudBlockY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBlockY.Location = new System.Drawing.Point(97, 37);
            this.nudBlockY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBlockY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.nudBlockY.Name = "nudBlockY";
            this.nudBlockY.Size = new System.Drawing.Size(79, 22);
            this.nudBlockY.TabIndex = 23;
            // 
            // nudBlockX
            // 
            this.nudBlockX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudBlockX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBlockX.Location = new System.Drawing.Point(97, 10);
            this.nudBlockX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBlockX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.nudBlockX.Name = "nudBlockX";
            this.nudBlockX.Size = new System.Drawing.Size(79, 22);
            this.nudBlockX.TabIndex = 22;
            // 
            // btnApplyBlockStyle
            // 
            this.btnApplyBlockStyle.BackColor = System.Drawing.Color.White;
            this.btnApplyBlockStyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApplyBlockStyle.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnApplyBlockStyle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnApplyBlockStyle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnApplyBlockStyle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyBlockStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApplyBlockStyle.Location = new System.Drawing.Point(7, 209);
            this.btnApplyBlockStyle.Name = "btnApplyBlockStyle";
            this.btnApplyBlockStyle.Size = new System.Drawing.Size(111, 38);
            this.btnApplyBlockStyle.TabIndex = 7;
            this.btnApplyBlockStyle.TabStop = false;
            this.btnApplyBlockStyle.Text = "Застосувати";
            this.btnApplyBlockStyle.UseVisualStyleBackColor = false;
            this.btnApplyBlockStyle.Click += new System.EventHandler(this.btnApplyBlockStyle_Click);
            // 
            // lblBlockWidth
            // 
            this.lblBlockWidth.AutoSize = true;
            this.lblBlockWidth.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBlockWidth.Location = new System.Drawing.Point(272, 10);
            this.lblBlockWidth.Name = "lblBlockWidth";
            this.lblBlockWidth.Size = new System.Drawing.Size(61, 19);
            this.lblBlockWidth.TabIndex = 19;
            this.lblBlockWidth.Text = "Ширина";
            // 
            // lblBlockHeight
            // 
            this.lblBlockHeight.AutoSize = true;
            this.lblBlockHeight.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBlockHeight.Location = new System.Drawing.Point(272, 37);
            this.lblBlockHeight.Name = "lblBlockHeight";
            this.lblBlockHeight.Size = new System.Drawing.Size(53, 19);
            this.lblBlockHeight.TabIndex = 18;
            this.lblBlockHeight.Text = "Висота";
            // 
            // lblBlockY
            // 
            this.lblBlockY.AutoSize = true;
            this.lblBlockY.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBlockY.Location = new System.Drawing.Point(72, 37);
            this.lblBlockY.Name = "lblBlockY";
            this.lblBlockY.Size = new System.Drawing.Size(17, 19);
            this.lblBlockY.TabIndex = 1;
            this.lblBlockY.Text = "Y";
            // 
            // lblBlockX
            // 
            this.lblBlockX.AutoSize = true;
            this.lblBlockX.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBlockX.Location = new System.Drawing.Point(72, 10);
            this.lblBlockX.Name = "lblBlockX";
            this.lblBlockX.Size = new System.Drawing.Size(17, 19);
            this.lblBlockX.TabIndex = 0;
            this.lblBlockX.Text = "X";
            // 
            // labelScale
            // 
            this.labelScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelScale.AutoSize = true;
            this.labelScale.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScale.Location = new System.Drawing.Point(3, 733);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(111, 19);
            this.labelScale.TabIndex = 0;
            this.labelScale.Text = "Масштаб: 100%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1233, 801);
            this.Controls.Add(this.lblExportImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.unsetSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.showGrid);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelCanvas.ResumeLayout(false);
            this.panelCanvas.PerformLayout();
            this.panelArrowStyleEdit.ResumeLayout(false);
            this.panelArrowStyleEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudArrowWidth)).EndInit();
            this.panelBlockStyleEdit.ResumeLayout(false);
            this.panelBlockStyleEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockBorderWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockX)).EndInit();
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
        private System.Windows.Forms.CheckBox showGrid;
        private System.Windows.Forms.Panel BlocksPanel;
        private System.Windows.Forms.Label labelArrows;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button unsetSearch;
        private System.Windows.Forms.Button btnSelectText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelBlocks;
        private System.Windows.Forms.Button btnSelectTwoHeadedArrow;
        private System.Windows.Forms.Button btnSelectLineArrow;
        private System.Windows.Forms.Button btnSelectFilledTrArrow;
        private System.Windows.Forms.Button btnSelectEmptyTrArrow;
        private System.Windows.Forms.Button btnSelectArrow;
        private System.Windows.Forms.Panel panelBlockStyleEdit;
        private System.Windows.Forms.Label lblBlockY;
        private System.Windows.Forms.Label lblBlockX;
        private System.Windows.Forms.Label lblBlockWidth;
        private System.Windows.Forms.Label lblBlockHeight;
        private System.Windows.Forms.Button btnApplyBlockStyle;
        private System.Windows.Forms.NumericUpDown nudBlockX;
        private System.Windows.Forms.NumericUpDown nudBlockWidth;
        private System.Windows.Forms.NumericUpDown nudBlockHeight;
        private System.Windows.Forms.NumericUpDown nudBlockY;
        private System.Windows.Forms.Button btnBLockColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lblBlockBorderColor;
        private System.Windows.Forms.Button btnBlockBorderColor;
        private System.Windows.Forms.Label lblBlockColor;
        private System.Windows.Forms.NumericUpDown nudBlockBorderWidth;
        private System.Windows.Forms.Label lblBlockBorderWidth;
        private System.Windows.Forms.Label lblBlockFont;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.TextBox tbBlockFont;
        private System.Windows.Forms.Label lblBlockTextColor;
        private System.Windows.Forms.Button btnBlockTextColor;
        private System.Windows.Forms.Panel panelArrowStyleEdit;
        private System.Windows.Forms.NumericUpDown nudArrowWidth;
        private System.Windows.Forms.Label lblArrowWidth;
        private System.Windows.Forms.Label lblArrowColor;
        private System.Windows.Forms.Button btnArrowColor;
        private System.Windows.Forms.Button btnApplyArrowStyle;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblExportImport;
    }
}

