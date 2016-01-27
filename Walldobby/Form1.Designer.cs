namespace Walldobby
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
            this.components = new System.ComponentModel.Container();
            this.WindowSpotLumos = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WindowSpotNox = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DiningTableSpotNox = new System.Windows.Forms.Button();
            this.DiningTableSpotLumos = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PCLedNox = new System.Windows.Forms.Button();
            this.PCLedLumos = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CouchLedNox = new System.Windows.Forms.Button();
            this.CouchLedLumos = new System.Windows.Forms.Button();
            this.WindowSpotSlider = new System.Windows.Forms.TrackBar();
            this.DiningTableSpotSlider = new System.Windows.Forms.TrackBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.HallwaySlider = new System.Windows.Forms.TrackBar();
            this.HallwayNox = new System.Windows.Forms.Button();
            this.HallwayLumos = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.BedsideLightNox = new System.Windows.Forms.Button();
            this.BedsideLightLumos = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.LargeBedroomLightSlider = new System.Windows.Forms.TrackBar();
            this.LargeBedroomLightNox = new System.Windows.Forms.Button();
            this.LargeBedroomLightLumos = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InsideTemperatureLabel = new System.Windows.Forms.Label();
            this.OutsideTemperatureLabel = new System.Windows.Forms.Label();
            this.TemperatureUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WindowSpotSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiningTableSpotSlider)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HallwaySlider)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LargeBedroomLightSlider)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // WindowSpotLumos
            // 
            this.WindowSpotLumos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowSpotLumos.Location = new System.Drawing.Point(18, 23);
            this.WindowSpotLumos.Name = "WindowSpotLumos";
            this.WindowSpotLumos.Size = new System.Drawing.Size(154, 56);
            this.WindowSpotLumos.TabIndex = 0;
            this.WindowSpotLumos.Text = "Lumos";
            this.WindowSpotLumos.UseVisualStyleBackColor = true;
            this.WindowSpotLumos.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WindowSpotSlider);
            this.groupBox1.Controls.Add(this.WindowSpotNox);
            this.groupBox1.Controls.Add(this.WindowSpotLumos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Window Spot";
            // 
            // WindowSpotNox
            // 
            this.WindowSpotNox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowSpotNox.Location = new System.Drawing.Point(190, 23);
            this.WindowSpotNox.Name = "WindowSpotNox";
            this.WindowSpotNox.Size = new System.Drawing.Size(154, 56);
            this.WindowSpotNox.TabIndex = 1;
            this.WindowSpotNox.Text = "Nox";
            this.WindowSpotNox.UseVisualStyleBackColor = true;
            this.WindowSpotNox.Click += new System.EventHandler(this.WindowSpotNox_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(773, 353);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Living Room";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DiningTableSpotSlider);
            this.groupBox3.Controls.Add(this.DiningTableSpotNox);
            this.groupBox3.Controls.Add(this.DiningTableSpotLumos);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(751, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dining Table Spot";
            // 
            // DiningTableSpotNox
            // 
            this.DiningTableSpotNox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiningTableSpotNox.Location = new System.Drawing.Point(190, 23);
            this.DiningTableSpotNox.Name = "DiningTableSpotNox";
            this.DiningTableSpotNox.Size = new System.Drawing.Size(154, 56);
            this.DiningTableSpotNox.TabIndex = 1;
            this.DiningTableSpotNox.Text = "Nox";
            this.DiningTableSpotNox.UseVisualStyleBackColor = true;
            this.DiningTableSpotNox.Click += new System.EventHandler(this.DiningTableSpotNox_Click);
            // 
            // DiningTableSpotLumos
            // 
            this.DiningTableSpotLumos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiningTableSpotLumos.Location = new System.Drawing.Point(18, 23);
            this.DiningTableSpotLumos.Name = "DiningTableSpotLumos";
            this.DiningTableSpotLumos.Size = new System.Drawing.Size(154, 56);
            this.DiningTableSpotLumos.TabIndex = 0;
            this.DiningTableSpotLumos.Text = "Lumos";
            this.DiningTableSpotLumos.UseVisualStyleBackColor = true;
            this.DiningTableSpotLumos.Click += new System.EventHandler(this.DiningTableSpotLumos_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PCLedNox);
            this.groupBox4.Controls.Add(this.PCLedLumos);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PC LED Lights";
            // 
            // PCLedNox
            // 
            this.PCLedNox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCLedNox.Location = new System.Drawing.Point(190, 23);
            this.PCLedNox.Name = "PCLedNox";
            this.PCLedNox.Size = new System.Drawing.Size(154, 56);
            this.PCLedNox.TabIndex = 1;
            this.PCLedNox.Text = "Nox";
            this.PCLedNox.UseVisualStyleBackColor = true;
            this.PCLedNox.Click += new System.EventHandler(this.PCLedNox_Click);
            // 
            // PCLedLumos
            // 
            this.PCLedLumos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCLedLumos.Location = new System.Drawing.Point(18, 23);
            this.PCLedLumos.Name = "PCLedLumos";
            this.PCLedLumos.Size = new System.Drawing.Size(154, 56);
            this.PCLedLumos.TabIndex = 0;
            this.PCLedLumos.Text = "Lumos";
            this.PCLedLumos.UseVisualStyleBackColor = true;
            this.PCLedLumos.Click += new System.EventHandler(this.PCLedLumos_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CouchLedNox);
            this.groupBox5.Controls.Add(this.CouchLedLumos);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(389, 240);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(368, 100);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Couch LED Lights";
            // 
            // CouchLedNox
            // 
            this.CouchLedNox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CouchLedNox.Location = new System.Drawing.Point(190, 23);
            this.CouchLedNox.Name = "CouchLedNox";
            this.CouchLedNox.Size = new System.Drawing.Size(154, 56);
            this.CouchLedNox.TabIndex = 1;
            this.CouchLedNox.Text = "Nox";
            this.CouchLedNox.UseVisualStyleBackColor = true;
            this.CouchLedNox.Click += new System.EventHandler(this.CouchLedNox_Click);
            // 
            // CouchLedLumos
            // 
            this.CouchLedLumos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CouchLedLumos.Location = new System.Drawing.Point(18, 23);
            this.CouchLedLumos.Name = "CouchLedLumos";
            this.CouchLedLumos.Size = new System.Drawing.Size(154, 56);
            this.CouchLedLumos.TabIndex = 0;
            this.CouchLedLumos.Text = "Lumos";
            this.CouchLedLumos.UseVisualStyleBackColor = true;
            this.CouchLedLumos.Click += new System.EventHandler(this.CouchLedLumos_Click);
            // 
            // WindowSpotSlider
            // 
            this.WindowSpotSlider.Location = new System.Drawing.Point(360, 34);
            this.WindowSpotSlider.Maximum = 100;
            this.WindowSpotSlider.Name = "WindowSpotSlider";
            this.WindowSpotSlider.Size = new System.Drawing.Size(367, 45);
            this.WindowSpotSlider.TabIndex = 2;
            this.WindowSpotSlider.TickFrequency = 5;
            this.WindowSpotSlider.Scroll += new System.EventHandler(this.WindowSpotSlider_Scroll);
            // 
            // DiningTableSpotSlider
            // 
            this.DiningTableSpotSlider.Location = new System.Drawing.Point(360, 34);
            this.DiningTableSpotSlider.Maximum = 100;
            this.DiningTableSpotSlider.Name = "DiningTableSpotSlider";
            this.DiningTableSpotSlider.Size = new System.Drawing.Size(367, 45);
            this.DiningTableSpotSlider.TabIndex = 3;
            this.DiningTableSpotSlider.TickFrequency = 5;
            this.DiningTableSpotSlider.Scroll += new System.EventHandler(this.DiningTableSpotSlider_Scroll);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.HallwaySlider);
            this.groupBox6.Controls.Add(this.HallwayNox);
            this.groupBox6.Controls.Add(this.HallwayLumos);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(12, 371);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(773, 101);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Hallway";
            // 
            // HallwaySlider
            // 
            this.HallwaySlider.Location = new System.Drawing.Point(348, 39);
            this.HallwaySlider.Maximum = 100;
            this.HallwaySlider.Name = "HallwaySlider";
            this.HallwaySlider.Size = new System.Drawing.Size(367, 45);
            this.HallwaySlider.TabIndex = 2;
            this.HallwaySlider.TickFrequency = 5;
            this.HallwaySlider.Scroll += new System.EventHandler(this.HallwaySlider_Scroll);
            // 
            // HallwayNox
            // 
            this.HallwayNox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HallwayNox.Location = new System.Drawing.Point(178, 28);
            this.HallwayNox.Name = "HallwayNox";
            this.HallwayNox.Size = new System.Drawing.Size(154, 56);
            this.HallwayNox.TabIndex = 1;
            this.HallwayNox.Text = "Nox";
            this.HallwayNox.UseVisualStyleBackColor = true;
            this.HallwayNox.Click += new System.EventHandler(this.HallwayNox_Click);
            // 
            // HallwayLumos
            // 
            this.HallwayLumos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HallwayLumos.Location = new System.Drawing.Point(6, 28);
            this.HallwayLumos.Name = "HallwayLumos";
            this.HallwayLumos.Size = new System.Drawing.Size(154, 56);
            this.HallwayLumos.TabIndex = 0;
            this.HallwayLumos.Text = "Lumos";
            this.HallwayLumos.UseVisualStyleBackColor = true;
            this.HallwayLumos.Click += new System.EventHandler(this.HallwayLumos_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox9);
            this.groupBox7.Controls.Add(this.groupBox11);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(12, 478);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(773, 244);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Bedroom";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.BedsideLightNox);
            this.groupBox9.Controls.Add(this.BedsideLightLumos);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(4, 134);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(368, 100);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Bedside Light";
            // 
            // BedsideLightNox
            // 
            this.BedsideLightNox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BedsideLightNox.Location = new System.Drawing.Point(190, 23);
            this.BedsideLightNox.Name = "BedsideLightNox";
            this.BedsideLightNox.Size = new System.Drawing.Size(154, 56);
            this.BedsideLightNox.TabIndex = 1;
            this.BedsideLightNox.Text = "Nox";
            this.BedsideLightNox.UseVisualStyleBackColor = true;
            this.BedsideLightNox.Click += new System.EventHandler(this.BedsideLightNox_Click);
            // 
            // BedsideLightLumos
            // 
            this.BedsideLightLumos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BedsideLightLumos.Location = new System.Drawing.Point(18, 23);
            this.BedsideLightLumos.Name = "BedsideLightLumos";
            this.BedsideLightLumos.Size = new System.Drawing.Size(154, 56);
            this.BedsideLightLumos.TabIndex = 0;
            this.BedsideLightLumos.Text = "Lumos";
            this.BedsideLightLumos.UseVisualStyleBackColor = true;
            this.BedsideLightLumos.Click += new System.EventHandler(this.BedsideLightLumos_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.LargeBedroomLightSlider);
            this.groupBox11.Controls.Add(this.LargeBedroomLightNox);
            this.groupBox11.Controls.Add(this.LargeBedroomLightLumos);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(6, 28);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(751, 100);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Large light";
            // 
            // LargeBedroomLightSlider
            // 
            this.LargeBedroomLightSlider.Location = new System.Drawing.Point(360, 34);
            this.LargeBedroomLightSlider.Maximum = 100;
            this.LargeBedroomLightSlider.Name = "LargeBedroomLightSlider";
            this.LargeBedroomLightSlider.Size = new System.Drawing.Size(367, 45);
            this.LargeBedroomLightSlider.TabIndex = 2;
            this.LargeBedroomLightSlider.TickFrequency = 5;
            this.LargeBedroomLightSlider.Scroll += new System.EventHandler(this.LargeBedroomLightSlider_Scroll);
            // 
            // LargeBedroomLightNox
            // 
            this.LargeBedroomLightNox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LargeBedroomLightNox.Location = new System.Drawing.Point(190, 23);
            this.LargeBedroomLightNox.Name = "LargeBedroomLightNox";
            this.LargeBedroomLightNox.Size = new System.Drawing.Size(154, 56);
            this.LargeBedroomLightNox.TabIndex = 1;
            this.LargeBedroomLightNox.Text = "Nox";
            this.LargeBedroomLightNox.UseVisualStyleBackColor = true;
            this.LargeBedroomLightNox.Click += new System.EventHandler(this.LargeBedroomLightNox_Click);
            // 
            // LargeBedroomLightLumos
            // 
            this.LargeBedroomLightLumos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LargeBedroomLightLumos.Location = new System.Drawing.Point(18, 23);
            this.LargeBedroomLightLumos.Name = "LargeBedroomLightLumos";
            this.LargeBedroomLightLumos.Size = new System.Drawing.Size(154, 56);
            this.LargeBedroomLightLumos.TabIndex = 0;
            this.LargeBedroomLightLumos.Text = "Lumos";
            this.LargeBedroomLightLumos.UseVisualStyleBackColor = true;
            this.LargeBedroomLightLumos.Click += new System.EventHandler(this.LargeBedroomLightLumos_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox12);
            this.groupBox8.Controls.Add(this.groupBox10);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(791, 12);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(205, 234);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Temperature";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.InsideTemperatureLabel);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(7, 29);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(192, 100);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Inside";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.OutsideTemperatureLabel);
            this.groupBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.Location = new System.Drawing.Point(7, 131);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(192, 97);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Outside";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Walldobby.Properties.Resources.DOBBY2;
            this.pictureBox1.Location = new System.Drawing.Point(791, 454);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 213);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(791, 674);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 36);
            this.label1.TabIndex = 9;
            this.label1.Text = "WallDobby";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InsideTemperatureLabel
            // 
            this.InsideTemperatureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InsideTemperatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsideTemperatureLabel.Location = new System.Drawing.Point(3, 20);
            this.InsideTemperatureLabel.Name = "InsideTemperatureLabel";
            this.InsideTemperatureLabel.Size = new System.Drawing.Size(186, 77);
            this.InsideTemperatureLabel.TabIndex = 0;
            this.InsideTemperatureLabel.Text = "20 °C";
            this.InsideTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OutsideTemperatureLabel
            // 
            this.OutsideTemperatureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutsideTemperatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutsideTemperatureLabel.Location = new System.Drawing.Point(3, 20);
            this.OutsideTemperatureLabel.Name = "OutsideTemperatureLabel";
            this.OutsideTemperatureLabel.Size = new System.Drawing.Size(186, 74);
            this.OutsideTemperatureLabel.TabIndex = 1;
            this.OutsideTemperatureLabel.Text = "12 °C";
            this.OutsideTemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TemperatureUpdateTimer
            // 
            this.TemperatureUpdateTimer.Interval = 60000;
            this.TemperatureUpdateTimer.Tick += new System.EventHandler(this.TemperatureUpdateTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Walldobby";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WindowSpotSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiningTableSpotSlider)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HallwaySlider)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LargeBedroomLightSlider)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WindowSpotLumos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button WindowSpotNox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button CouchLedNox;
        private System.Windows.Forms.Button CouchLedLumos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button PCLedNox;
        private System.Windows.Forms.Button PCLedLumos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button DiningTableSpotNox;
        private System.Windows.Forms.Button DiningTableSpotLumos;
        private System.Windows.Forms.TrackBar WindowSpotSlider;
        private System.Windows.Forms.TrackBar DiningTableSpotSlider;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TrackBar HallwaySlider;
        private System.Windows.Forms.Button HallwayNox;
        private System.Windows.Forms.Button HallwayLumos;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button BedsideLightNox;
        private System.Windows.Forms.Button BedsideLightLumos;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TrackBar LargeBedroomLightSlider;
        private System.Windows.Forms.Button LargeBedroomLightNox;
        private System.Windows.Forms.Button LargeBedroomLightLumos;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label OutsideTemperatureLabel;
        private System.Windows.Forms.Label InsideTemperatureLabel;
        private System.Windows.Forms.Timer TemperatureUpdateTimer;
    }
}

