using FinalLab;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Panels
{
    public class ItemPricePanel
    {
        Item _item;
        double _price;
        Label _lbl_itemName;
        Label _lbl_itemPrice;
        FlowLayoutPanel _panel;
        private int FontSize = 10;

        public ItemPricePanel(Item item, double price)
        {
            _item = item;
            _price = price;
            SetLabelItemName();
            SetLabelPrice();
            SetPanel();
        }

        public FlowLayoutPanel Panel { get { return _panel; } }

        public void SetPanel()
        {
            _panel = new FlowLayoutPanel();
            _panel.FlowDirection = FlowDirection.LeftToRight;
            _panel.Controls.Add(_lbl_itemName);
            _panel.Controls.Add(_lbl_itemPrice);
            _panel.BorderStyle = BorderStyle.FixedSingle;
            _panel.Height = 100;
            _panel.Width = 200;
        }

        public void SetLabelItemName()
        {
            _lbl_itemName = new Label();
            _lbl_itemName.Name = "lbl_itemName";
            _lbl_itemName.Font = new Font("Arial", FontSize, FontStyle.Bold);
            _lbl_itemName.ForeColor = Color.DarkBlue;
            _lbl_itemName.Text = _item.ItemName;
            _lbl_itemName.AutoSize = true;
            _lbl_itemName.Height = 20;
            _lbl_itemName.Width = 50;
            _lbl_itemName.Anchor = AnchorStyles.Left;
        }

        public void SetLabelPrice()
        {
            _lbl_itemPrice = new Label();
            _lbl_itemPrice.Name = "_lbl_totalCost";
            _lbl_itemPrice.Font = new Font("Arial", FontSize, FontStyle.Bold);
            _lbl_itemPrice.ForeColor = Color.ForestGreen;
            _price = Math.Round(_price, Constants.CostProximity);
            string priceString = _price == 0 ? "None" : $"{_price} {Constants.Currency}";
            _lbl_itemPrice.Text = priceString;
            _lbl_itemPrice.AutoSize = true;
            _lbl_itemPrice.Height = 20;
            _lbl_itemPrice.Width = 50;
            _lbl_itemPrice.Anchor = AnchorStyles.Left;
        }
    }
}
