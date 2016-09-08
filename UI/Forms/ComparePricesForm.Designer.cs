namespace FinalLab.Forms
{
    partial class ComparePricesForm
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
            this.flowLayoutPanel_storesCosts = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox_chain1 = new System.Windows.Forms.ComboBox();
            this.comboBox_chain2 = new System.Windows.Forms.ComboBox();
            this.comboBox_store1 = new System.Windows.Forms.ComboBox();
            this.comboBox_store2 = new System.Windows.Forms.ComboBox();
            this.lbl_store1 = new System.Windows.Forms.Label();
            this.lbl_store2 = new System.Windows.Forms.Label();
            this.lbl_chooseChain1 = new System.Windows.Forms.Label();
            this.lbl_chooseChain2 = new System.Windows.Forms.Label();
            this.lbl_chooseStore1 = new System.Windows.Forms.Label();
            this.lbl_chooseStore2 = new System.Windows.Forms.Label();
            this.btn_compare = new System.Windows.Forms.Button();
            this.pictureBox_chainLogo1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_chainLogo2 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel_comparison = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_chainLogo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_chainLogo2)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_storesCosts
            // 
            this.flowLayoutPanel_storesCosts.Location = new System.Drawing.Point(28, 64);
            this.flowLayoutPanel_storesCosts.Name = "flowLayoutPanel_storesCosts";
            this.flowLayoutPanel_storesCosts.Size = new System.Drawing.Size(126, 260);
            this.flowLayoutPanel_storesCosts.TabIndex = 0;
            // 
            // comboBox_chain1
            // 
            this.comboBox_chain1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBox_chain1.FormattingEnabled = true;
            this.comboBox_chain1.Location = new System.Drawing.Point(553, 155);
            this.comboBox_chain1.Name = "comboBox_chain1";
            this.comboBox_chain1.Size = new System.Drawing.Size(225, 24);
            this.comboBox_chain1.TabIndex = 1;
            this.comboBox_chain1.SelectedIndexChanged += new System.EventHandler(this.comboBox_chain1_SelectedIndexChanged);
            // 
            // comboBox_chain2
            // 
            this.comboBox_chain2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBox_chain2.FormattingEnabled = true;
            this.comboBox_chain2.Location = new System.Drawing.Point(970, 155);
            this.comboBox_chain2.Name = "comboBox_chain2";
            this.comboBox_chain2.Size = new System.Drawing.Size(225, 24);
            this.comboBox_chain2.TabIndex = 1;
            this.comboBox_chain2.SelectedIndexChanged += new System.EventHandler(this.comboBox_chain2_SelectedIndexChanged);
            // 
            // comboBox_store1
            // 
            this.comboBox_store1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBox_store1.FormattingEnabled = true;
            this.comboBox_store1.Location = new System.Drawing.Point(553, 202);
            this.comboBox_store1.Name = "comboBox_store1";
            this.comboBox_store1.Size = new System.Drawing.Size(225, 24);
            this.comboBox_store1.TabIndex = 1;
            this.comboBox_store1.SelectedIndexChanged += new System.EventHandler(this.comboBox_store1_SelectedIndexChanged);
            // 
            // comboBox_store2
            // 
            this.comboBox_store2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBox_store2.FormattingEnabled = true;
            this.comboBox_store2.Location = new System.Drawing.Point(970, 202);
            this.comboBox_store2.Name = "comboBox_store2";
            this.comboBox_store2.Size = new System.Drawing.Size(225, 24);
            this.comboBox_store2.TabIndex = 1;
            this.comboBox_store2.SelectedIndexChanged += new System.EventHandler(this.comboBox_store2_SelectedIndexChanged);
            // 
            // lbl_store1
            // 
            this.lbl_store1.AutoSize = true;
            this.lbl_store1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_store1.Location = new System.Drawing.Point(439, 112);
            this.lbl_store1.Name = "lbl_store1";
            this.lbl_store1.Size = new System.Drawing.Size(61, 24);
            this.lbl_store1.TabIndex = 2;
            this.lbl_store1.Text = "store1";
            // 
            // lbl_store2
            // 
            this.lbl_store2.AutoSize = true;
            this.lbl_store2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_store2.Location = new System.Drawing.Point(850, 112);
            this.lbl_store2.Name = "lbl_store2";
            this.lbl_store2.Size = new System.Drawing.Size(61, 24);
            this.lbl_store2.TabIndex = 2;
            this.lbl_store2.Text = "store2";
            // 
            // lbl_chooseChain1
            // 
            this.lbl_chooseChain1.AutoSize = true;
            this.lbl_chooseChain1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_chooseChain1.Location = new System.Drawing.Point(454, 158);
            this.lbl_chooseChain1.Name = "lbl_chooseChain1";
            this.lbl_chooseChain1.Size = new System.Drawing.Size(46, 17);
            this.lbl_chooseChain1.TabIndex = 3;
            this.lbl_chooseChain1.Text = "label1";
            // 
            // lbl_chooseChain2
            // 
            this.lbl_chooseChain2.AutoSize = true;
            this.lbl_chooseChain2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_chooseChain2.Location = new System.Drawing.Point(865, 158);
            this.lbl_chooseChain2.Name = "lbl_chooseChain2";
            this.lbl_chooseChain2.Size = new System.Drawing.Size(46, 17);
            this.lbl_chooseChain2.TabIndex = 3;
            this.lbl_chooseChain2.Text = "label1";
            // 
            // lbl_chooseStore1
            // 
            this.lbl_chooseStore1.AutoSize = true;
            this.lbl_chooseStore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_chooseStore1.Location = new System.Drawing.Point(454, 209);
            this.lbl_chooseStore1.Name = "lbl_chooseStore1";
            this.lbl_chooseStore1.Size = new System.Drawing.Size(46, 17);
            this.lbl_chooseStore1.TabIndex = 3;
            this.lbl_chooseStore1.Text = "label1";
            // 
            // lbl_chooseStore2
            // 
            this.lbl_chooseStore2.AutoSize = true;
            this.lbl_chooseStore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_chooseStore2.Location = new System.Drawing.Point(865, 209);
            this.lbl_chooseStore2.Name = "lbl_chooseStore2";
            this.lbl_chooseStore2.Size = new System.Drawing.Size(46, 17);
            this.lbl_chooseStore2.TabIndex = 3;
            this.lbl_chooseStore2.Text = "label1";
            // 
            // btn_compare
            // 
            this.btn_compare.Enabled = false;
            this.btn_compare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_compare.Location = new System.Drawing.Point(703, 261);
            this.btn_compare.Name = "btn_compare";
            this.btn_compare.Size = new System.Drawing.Size(75, 27);
            this.btn_compare.TabIndex = 4;
            this.btn_compare.Text = "Compare";
            this.btn_compare.UseVisualStyleBackColor = true;
            this.btn_compare.Click += new System.EventHandler(this.btn_compare_Click);
            // 
            // pictureBox_chainLogo1
            // 
            this.pictureBox_chainLogo1.Location = new System.Drawing.Point(553, 12);
            this.pictureBox_chainLogo1.Name = "pictureBox_chainLogo1";
            this.pictureBox_chainLogo1.Size = new System.Drawing.Size(225, 63);
            this.pictureBox_chainLogo1.TabIndex = 14;
            this.pictureBox_chainLogo1.TabStop = false;
            // 
            // pictureBox_chainLogo2
            // 
            this.pictureBox_chainLogo2.Location = new System.Drawing.Point(970, 12);
            this.pictureBox_chainLogo2.Name = "pictureBox_chainLogo2";
            this.pictureBox_chainLogo2.Size = new System.Drawing.Size(225, 63);
            this.pictureBox_chainLogo2.TabIndex = 14;
            this.pictureBox_chainLogo2.TabStop = false;
            // 
            // flowLayoutPanel_comparison
            // 
            this.flowLayoutPanel_comparison.Location = new System.Drawing.Point(457, 353);
            this.flowLayoutPanel_comparison.Name = "flowLayoutPanel_comparison";
            this.flowLayoutPanel_comparison.Size = new System.Drawing.Size(738, 100);
            this.flowLayoutPanel_comparison.TabIndex = 15;
            // 
            // ComparePricesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 662);
            this.Controls.Add(this.flowLayoutPanel_comparison);
            this.Controls.Add(this.pictureBox_chainLogo2);
            this.Controls.Add(this.pictureBox_chainLogo1);
            this.Controls.Add(this.btn_compare);
            this.Controls.Add(this.lbl_chooseChain2);
            this.Controls.Add(this.lbl_chooseStore2);
            this.Controls.Add(this.lbl_chooseStore1);
            this.Controls.Add(this.lbl_chooseChain1);
            this.Controls.Add(this.lbl_store2);
            this.Controls.Add(this.lbl_store1);
            this.Controls.Add(this.comboBox_chain2);
            this.Controls.Add(this.comboBox_store2);
            this.Controls.Add(this.comboBox_store1);
            this.Controls.Add(this.comboBox_chain1);
            this.Controls.Add(this.flowLayoutPanel_storesCosts);
            this.Name = "ComparePricesForm";
            this.Text = "ComparePricesForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_chainLogo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_chainLogo2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_storesCosts;
        private System.Windows.Forms.ComboBox comboBox_chain1;
        private System.Windows.Forms.ComboBox comboBox_chain2;
        private System.Windows.Forms.ComboBox comboBox_store1;
        private System.Windows.Forms.ComboBox comboBox_store2;
        private System.Windows.Forms.Label lbl_store1;
        private System.Windows.Forms.Label lbl_store2;
        private System.Windows.Forms.Label lbl_chooseChain1;
        private System.Windows.Forms.Label lbl_chooseChain2;
        private System.Windows.Forms.Label lbl_chooseStore1;
        private System.Windows.Forms.Label lbl_chooseStore2;
        private System.Windows.Forms.Button btn_compare;
        private System.Windows.Forms.PictureBox pictureBox_chainLogo1;
        private System.Windows.Forms.PictureBox pictureBox_chainLogo2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_comparison;
    }
}