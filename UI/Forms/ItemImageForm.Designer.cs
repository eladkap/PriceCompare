namespace UI.Forms
{
    partial class ItemImageForm
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
            this.pictureBox_item = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_item)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_item
            // 
            this.pictureBox_item.Location = new System.Drawing.Point(264, 134);
            this.pictureBox_item.Name = "pictureBox_item";
            this.pictureBox_item.Size = new System.Drawing.Size(342, 252);
            this.pictureBox_item.TabIndex = 0;
            this.pictureBox_item.TabStop = false;
            // 
            // ItemImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 514);
            this.Controls.Add(this.pictureBox_item);
            this.Name = "ItemImageForm";
            this.Text = "ItemImageForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_item;
    }
}