using System.Drawing;
using System.Windows.Forms;

namespace FinalLab.Panels
{
    public class CompareItemPanel
    {
        Item _item;
        Price _price1;
        Price _price2;
        Label _lbl_itemName;
        Label _lbl_amount;
        Label _lbl_price1;
        Label _lbl_totalPrice1;
        Label _lbl_price2;
        Label _lbl_totalPrice2;

        FlowLayoutPanel _panel;
        private int FontSize = 10;

        public CompareItemPanel()
        {
        }

        public CompareItemPanel(Item item, Price price1, Price price2)
        {
            _item = item;
            _price1 = price1;
            _price2 = price2;
            SetLabelItemName(_item.ItemName);
            SetLabelAmount(_item.QtyInPackage.ToString());
            SetLabelPrice1(price1?.PriceValue.ToString());
            SetLabelTotalPrice1((_price1?.PriceValue * _item.QtyInPackage).ToString());
            SetLabelPrice2(price2?.PriceValue.ToString());
            SetLabelTotalPrice2((_price2?.PriceValue * _item.QtyInPackage).ToString());
            SetPanel(Color.Azure);
            MarkNotFoundItemInStore();
            MarkPrices();
        }

        public FlowLayoutPanel Panel { get { return _panel; } }

        public void AddHeader(Color backgroundColor)
        {
            SetLabelItemName("Item Name");
            SetLabelAmount("Amount");
            SetLabelPrice1("Price");
            SetLabelTotalPrice1("Total Price 1");
            SetLabelPrice2("Price 2");
            SetLabelTotalPrice2("Total Price 2");
            SetPanel(backgroundColor);
        }

        public void SetPanel(Color backgroundColor)
        {
            _panel = new FlowLayoutPanel();
            _panel.Name = "flowLayoutPanel_panel";
            _panel.BackColor = backgroundColor;
            _panel.FlowDirection = FlowDirection.LeftToRight;
            _panel.Controls.Add(_lbl_itemName);
            _panel.Controls.Add(_lbl_amount);
            _panel.Controls.Add(_lbl_price1);
            _panel.Controls.Add(_lbl_totalPrice1);
            _panel.Controls.Add(_lbl_price2);
            _panel.Controls.Add(_lbl_totalPrice2);
            _panel.BorderStyle = BorderStyle.FixedSingle;
            _panel.Height = 80;
            _panel.Width = 600;
            MarkNotFoundItemInStore();
        }

        private void SetLabel(Label label, string name, string text)
        {
            label.Name = name;
            label.Font = new Font("Arial", FontSize, FontStyle.Bold);
            label.Text = text;
            label.AutoSize = true;
            label.Height = 20;
            label.Width = 100;
            label.Anchor = AnchorStyles.Left;
        }

        private void SetLabelItemName(string itemName)
        {
            _lbl_itemName = new Label();
            SetLabel(_lbl_itemName, "lbl_itemName", itemName);
        }

        private void SetLabelAmount(string amount)
        {
            _lbl_amount = new Label();
            SetLabel(_lbl_amount, "lbl_amount", amount);
        }

        public void SetLabelPrice1(string price1)
        {
            _lbl_price1 = new Label();
            SetLabel(_lbl_price1, "lbl_price1", $"{price1} [{Constants.Currency}]");
        }

        public void SetLabelPrice2(string price2)
        {
            _lbl_price2 = new Label();
            SetLabel(_lbl_price2, "lbl_price2", $"{price2} [{Constants.Currency}]");
        }

        public void SetLabelTotalPrice1(string totalPrice1)
        {
            _lbl_totalPrice1 = new Label();
            SetLabel(_lbl_totalPrice1, "_lbl_totalPrice1", $"{totalPrice1} [{Constants.Currency}]");
        }

        public void SetLabelTotalPrice2(string totalPrice2)
        {
            _lbl_totalPrice2 = new Label();
            SetLabel(_lbl_totalPrice2, "_lbl_totalPrice2", $"{totalPrice2} [{Constants.Currency}]");
        }

        private void MarkNotFoundItemInStore()
        {
            if (_price1 == null)
            {
                _panel.ForeColor = Color.Gray;
            }
            if (_price2 == null)
            {
                _panel.ForeColor = Color.Gray;
            }
        }

        private void MarkPrices()
        {
            if (_price1 != null && _price2 != null)
            {
                if (_price1.PriceValue < _price2.PriceValue)
                {
                    _lbl_price1.ForeColor = Color.Green;
                    _lbl_price2.ForeColor = Color.Red;
                }
                else if (_price1.PriceValue > _price2.PriceValue)
                {
                    _lbl_price2.ForeColor = Color.Green;
                    _lbl_price1.ForeColor = Color.Red;
                }
                else
                {
                    _lbl_price1.ForeColor = Color.Blue;
                    _lbl_price2.ForeColor = Color.Blue;
                }
            }
        }
    }
}
