namespace UI.Forms
{
    partial class ExpensiveCheapForm
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
            this.cheapPanel_store1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cheapPanel_store2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_storeName1 = new System.Windows.Forms.Label();
            this.lbl_storeName2 = new System.Windows.Forms.Label();
            this.expensivePanel_store1 = new System.Windows.Forms.FlowLayoutPanel();
            this.expensivePanel_store2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_mostCheap = new System.Windows.Forms.Label();
            this.lbl_mostExpensive = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cheapPanel_store1
            // 
            this.cheapPanel_store1.Location = new System.Drawing.Point(43, 178);
            this.cheapPanel_store1.Name = "cheapPanel_store1";
            this.cheapPanel_store1.Size = new System.Drawing.Size(200, 100);
            this.cheapPanel_store1.TabIndex = 0;
            // 
            // cheapPanel_store2
            // 
            this.cheapPanel_store2.Location = new System.Drawing.Point(752, 178);
            this.cheapPanel_store2.Name = "cheapPanel_store2";
            this.cheapPanel_store2.Size = new System.Drawing.Size(200, 100);
            this.cheapPanel_store2.TabIndex = 0;
            // 
            // lbl_storeName1
            // 
            this.lbl_storeName1.AutoSize = true;
            this.lbl_storeName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_storeName1.Location = new System.Drawing.Point(282, 46);
            this.lbl_storeName1.Name = "lbl_storeName1";
            this.lbl_storeName1.Size = new System.Drawing.Size(60, 24);
            this.lbl_storeName1.TabIndex = 1;
            this.lbl_storeName1.Text = "label1";
            // 
            // lbl_storeName2
            // 
            this.lbl_storeName2.AutoSize = true;
            this.lbl_storeName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_storeName2.Location = new System.Drawing.Point(892, 46);
            this.lbl_storeName2.Name = "lbl_storeName2";
            this.lbl_storeName2.Size = new System.Drawing.Size(60, 24);
            this.lbl_storeName2.TabIndex = 1;
            this.lbl_storeName2.Text = "label1";
            // 
            // expensivePanel_store1
            // 
            this.expensivePanel_store1.Location = new System.Drawing.Point(361, 178);
            this.expensivePanel_store1.Name = "expensivePanel_store1";
            this.expensivePanel_store1.Size = new System.Drawing.Size(200, 100);
            this.expensivePanel_store1.TabIndex = 0;
            // 
            // expensivePanel_store2
            // 
            this.expensivePanel_store2.Location = new System.Drawing.Point(1112, 178);
            this.expensivePanel_store2.Name = "expensivePanel_store2";
            this.expensivePanel_store2.Size = new System.Drawing.Size(200, 100);
            this.expensivePanel_store2.TabIndex = 0;
            // 
            // lbl_mostCheap
            // 
            this.lbl_mostCheap.AutoSize = true;
            this.lbl_mostCheap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_mostCheap.Location = new System.Drawing.Point(78, 106);
            this.lbl_mostCheap.Name = "lbl_mostCheap";
            this.lbl_mostCheap.Size = new System.Drawing.Size(95, 20);
            this.lbl_mostCheap.TabIndex = 1;
            this.lbl_mostCheap.Text = "Most Cheap";
            // 
            // lbl_mostExpensive
            // 
            this.lbl_mostExpensive.AutoSize = true;
            this.lbl_mostExpensive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_mostExpensive.Location = new System.Drawing.Point(441, 106);
            this.lbl_mostExpensive.Name = "lbl_mostExpensive";
            this.lbl_mostExpensive.Size = new System.Drawing.Size(120, 20);
            this.lbl_mostExpensive.TabIndex = 1;
            this.lbl_mostExpensive.Text = "Most Expensive";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(1157, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Most Expensive";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(801, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Most Cheap";
            // 
            // ExpensiveCheapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1497, 641);
            this.Controls.Add(this.lbl_storeName2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_mostExpensive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_mostCheap);
            this.Controls.Add(this.lbl_storeName1);
            this.Controls.Add(this.cheapPanel_store2);
            this.Controls.Add(this.expensivePanel_store2);
            this.Controls.Add(this.expensivePanel_store1);
            this.Controls.Add(this.cheapPanel_store1);
            this.Name = "ExpensiveCheapForm";
            this.Text = "ExpensiveCheapForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel cheapPanel_store1;
        private System.Windows.Forms.FlowLayoutPanel cheapPanel_store2;
        private System.Windows.Forms.Label lbl_storeName1;
        private System.Windows.Forms.Label lbl_storeName2;
        private System.Windows.Forms.FlowLayoutPanel expensivePanel_store1;
        private System.Windows.Forms.FlowLayoutPanel expensivePanel_store2;
        private System.Windows.Forms.Label lbl_mostCheap;
        private System.Windows.Forms.Label lbl_mostExpensive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}