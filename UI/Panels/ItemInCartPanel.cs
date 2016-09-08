using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalLab
{
    public class ItemInCartPanel
    {
        Item _item;
        Price _price;
        FlowLayoutPanel _panel;
        private int FontSize = 8;

        public ItemInCartPanel(Item item, Price price)
        {
            _item = item;
            _price = price;
            SetLabelAmount();
            SetButtonIncrementUnit();
            SetButtonDecrementUnit();
            SetButtonRemoveFromCart();
            SetLabelItemCode();
            SetLabelItemName();
            SetLabelPriceUnit(price);
            SetLabelPriceTotal(price);
            SetPanel();
        }

        public FlowLayoutPanel Panel { get { return _panel; } }

        public void SetPanel()
        {
            _panel = new FlowLayoutPanel();
            _panel.Name = "flowLayoutPanel_panel";
            _panel.FlowDirection = FlowDirection.LeftToRight;
            _panel.Controls.Add(LblItemCode);
            _panel.Controls.Add(LblItemName);
            _panel.Controls.Add(LblPriceUnit);
            _panel.Controls.Add(LblPriceTotal);
            _panel.Controls.Add(LblAmount);
            _panel.Controls.Add(BtnIncrementUnit);
            _panel.Controls.Add(BtnDecrementUnit);
            _panel.Controls.Add(BtnRemoveFromCart);
            _panel.BorderStyle = BorderStyle.FixedSingle;
            _panel.Height = 80;
            _panel.Width = 700;
            MarkNotFoundItemInStore();
        }

        private void MarkNotFoundItemInStore()
        {
            if (_price == null)
            {
                _panel.ForeColor = Color.Red;
                BtnIncrementUnit.Enabled = false;
                BtnDecrementUnit.Enabled = false;
            }
        }

        private void SetLabelAmount()
        {
            LblAmount = new Label();
            LblAmount.Name = "lbl_amount";
            LblAmount.Text = $"{_item.QtyInPackage}";
            LblAmount.Font = new Font("Arial", FontSize, FontStyle.Bold);
        }

        private void SetButtonIncrementUnit()
        {
            BtnIncrementUnit = new Button();
            BtnIncrementUnit.Name = "btn_incrementUnit";
            BtnIncrementUnit.Text = "+";
            BtnIncrementUnit.Font = new Font("Arial", FontSize, FontStyle.Bold);
        }

        private void SetButtonDecrementUnit()
        {
            BtnDecrementUnit = new Button();
            BtnDecrementUnit.Name = "btn_decrementUnit";
            BtnDecrementUnit.Text = "-";
            BtnDecrementUnit.Font = new Font("Arial", FontSize, FontStyle.Bold);
        }

        private void SetLabelItemPriceMargin(Label label)
        {
            label.Margin = new Padding(10, 10, 10, 10);
        }

        public void SetLabelPriceUnit(Price price)
        {
            LblPriceUnit = new Label();
            LblPriceUnit.Name = "lbl_priceUnit";
            LblPriceUnit.Font = new Font("Arial", FontSize, FontStyle.Bold);
            LblPriceUnit.Text = $"{price?.price.ToString()} {Constants.Currency}";
            LblPriceUnit.AutoSize = true;
            LblPriceUnit.Height = 20;
            LblPriceUnit.Width = 50;
            LblPriceUnit.Anchor = AnchorStyles.Left;
            SetLabelItemPriceMargin(LblPriceUnit);
        }

        public void SetLabelPriceTotal(Price price)
        {
            LblPriceTotal = new Label();
            LblPriceTotal.Name = "lbl_priceTotal";
            LblPriceTotal.Font = new Font("Arial", FontSize, FontStyle.Bold);
            LblPriceTotal.Text = $"{price?.price.ToString()} {Constants.Currency}";
            LblPriceTotal.AutoSize = true;
            LblPriceTotal.Height = 20;
            LblPriceTotal.Width = 50;
            LblPriceTotal.Anchor = AnchorStyles.Left;
            SetLabelItemPriceMargin(LblPriceTotal);
        }

        private void SetButtonRemoveFromCart()
        {
            BtnRemoveFromCart = new Button();
            BtnRemoveFromCart.Name = "btn_removeFromCart";
            BtnRemoveFromCart.Font = new Font("Arial", FontSize, FontStyle.Bold);
            BtnRemoveFromCart.Text = "Remove";
            BtnRemoveFromCart.AutoSize = true;
            // BtnRemoveFromCart.Height = 20;
            //BtnRemoveFromCart.Height = 50;
            BtnRemoveFromCart.Anchor = AnchorStyles.Left;
        }

        private void SetLabelItemCode()
        {
            LblItemCode = new Label();
            LblItemCode.Name = "lbl_itemCode";
            LblItemCode.Text = _item.ItemCode;
            LblItemCode.Visible = false;
            LblItemCode.Font = new Font("Arial", FontSize, FontStyle.Bold);
        }

        private void SetLabelItemName()
        {
            LblItemName = new Label();
            LblItemName.Name = "lbl_itemName";
            LblItemName.Text = _item.ItemName;
            LblItemName.Font = new Font("Arial", FontSize, FontStyle.Bold);
        }

        public Button BtnRemoveFromCart { get; set; }

        public Button BtnIncrementUnit { get; set; }

        public Button BtnDecrementUnit { get; set; }

        public Label LblAmount { get; set; }

        public Label LblItemName { get; set; }

        public Label LblItemCode { get; set; }

        public Label LblPriceUnit { get; set; }

        public Label LblPriceTotal { get; set; }
    }
}
