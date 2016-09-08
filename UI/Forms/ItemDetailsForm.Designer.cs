namespace FinalLab.Forms
{
    partial class ItemDetailsForm
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
            this.lbl_itemName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_itemName
            // 
            this.lbl_itemName.AutoSize = true;
            this.lbl_itemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_itemName.Location = new System.Drawing.Point(181, 55);
            this.lbl_itemName.Name = "lbl_itemName";
            this.lbl_itemName.Size = new System.Drawing.Size(51, 20);
            this.lbl_itemName.TabIndex = 0;
            this.lbl_itemName.Text = "label1";
            // 
            // ItemDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 353);
            this.Controls.Add(this.lbl_itemName);
            this.Name = "ItemDetailsForm";
            this.Text = "ItemDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_itemName;
    }
}