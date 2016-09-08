namespace FinalLab.Forms
{
    partial class CartForm
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
            this.lbl_myCart = new System.Windows.Forms.Label();
            this.flowLayoutPanel_cartPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_saveCart = new System.Windows.Forms.Button();
            this.lbl_cartSize = new System.Windows.Forms.Label();
            this.btn_clearCart = new System.Windows.Forms.Button();
            this.lbl_totalCostLabel = new System.Windows.Forms.Label();
            this.lbl_totalCost = new System.Windows.Forms.Label();
            this.lbl_chainStore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_myCart
            // 
            this.lbl_myCart.AutoSize = true;
            this.lbl_myCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_myCart.Location = new System.Drawing.Point(327, 34);
            this.lbl_myCart.Name = "lbl_myCart";
            this.lbl_myCart.Size = new System.Drawing.Size(88, 26);
            this.lbl_myCart.TabIndex = 0;
            this.lbl_myCart.Text = "My Cart";
            // 
            // flowLayoutPanel_cartPanel
            // 
            this.flowLayoutPanel_cartPanel.Location = new System.Drawing.Point(206, 120);
            this.flowLayoutPanel_cartPanel.Name = "flowLayoutPanel_cartPanel";
            this.flowLayoutPanel_cartPanel.Size = new System.Drawing.Size(700, 100);
            this.flowLayoutPanel_cartPanel.TabIndex = 1;
            // 
            // btn_saveCart
            // 
            this.btn_saveCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_saveCart.Location = new System.Drawing.Point(33, 40);
            this.btn_saveCart.Name = "btn_saveCart";
            this.btn_saveCart.Size = new System.Drawing.Size(107, 23);
            this.btn_saveCart.TabIndex = 2;
            this.btn_saveCart.Text = "Save Cart";
            this.btn_saveCart.UseVisualStyleBackColor = true;
            this.btn_saveCart.Click += new System.EventHandler(this.btn_saveCart_Click);
            // 
            // lbl_cartSize
            // 
            this.lbl_cartSize.AutoSize = true;
            this.lbl_cartSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_cartSize.Location = new System.Drawing.Point(794, 43);
            this.lbl_cartSize.Name = "lbl_cartSize";
            this.lbl_cartSize.Size = new System.Drawing.Size(16, 17);
            this.lbl_cartSize.TabIndex = 3;
            this.lbl_cartSize.Text = "0";
            // 
            // btn_clearCart
            // 
            this.btn_clearCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_clearCart.Location = new System.Drawing.Point(33, 124);
            this.btn_clearCart.Name = "btn_clearCart";
            this.btn_clearCart.Size = new System.Drawing.Size(107, 23);
            this.btn_clearCart.TabIndex = 4;
            this.btn_clearCart.Text = "Clear Cart";
            this.btn_clearCart.UseVisualStyleBackColor = true;
            this.btn_clearCart.Click += new System.EventHandler(this.btn_clearCart_Click);
            // 
            // lbl_totalCostLabel
            // 
            this.lbl_totalCostLabel.AutoSize = true;
            this.lbl_totalCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_totalCostLabel.Location = new System.Drawing.Point(29, 180);
            this.lbl_totalCostLabel.Name = "lbl_totalCostLabel";
            this.lbl_totalCostLabel.Size = new System.Drawing.Size(81, 20);
            this.lbl_totalCostLabel.TabIndex = 5;
            this.lbl_totalCostLabel.Text = "Total Cost";
            // 
            // lbl_totalCost
            // 
            this.lbl_totalCost.AutoSize = true;
            this.lbl_totalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_totalCost.Location = new System.Drawing.Point(29, 236);
            this.lbl_totalCost.Name = "lbl_totalCost";
            this.lbl_totalCost.Size = new System.Drawing.Size(36, 20);
            this.lbl_totalCost.TabIndex = 5;
            this.lbl_totalCost.Text = "NIS";
            // 
            // lbl_chainStore
            // 
            this.lbl_chainStore.AutoSize = true;
            this.lbl_chainStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_chainStore.Location = new System.Drawing.Point(495, 40);
            this.lbl_chainStore.Name = "lbl_chainStore";
            this.lbl_chainStore.Size = new System.Drawing.Size(51, 20);
            this.lbl_chainStore.TabIndex = 6;
            this.lbl_chainStore.Text = "label1";
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.lbl_chainStore);
            this.Controls.Add(this.lbl_totalCost);
            this.Controls.Add(this.lbl_totalCostLabel);
            this.Controls.Add(this.btn_clearCart);
            this.Controls.Add(this.lbl_cartSize);
            this.Controls.Add(this.btn_saveCart);
            this.Controls.Add(this.flowLayoutPanel_cartPanel);
            this.Controls.Add(this.lbl_myCart);
            this.Name = "CartForm";
            this.Text = "Cart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_myCart;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_cartPanel;
        private System.Windows.Forms.Button btn_saveCart;
        private System.Windows.Forms.Label lbl_cartSize;
        private System.Windows.Forms.Button btn_clearCart;
        private System.Windows.Forms.Label lbl_totalCostLabel;
        private System.Windows.Forms.Label lbl_totalCost;
        private System.Windows.Forms.Label lbl_chainStore;
    }
}