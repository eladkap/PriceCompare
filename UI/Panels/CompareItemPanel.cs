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
        Label _lbl_price1;
        Label _lbl_price2;

        FlowLayoutPanel _panel;
        private int FontSize = 10;

        public CompareItemPanel(Item item, Price price1, Price price2)
        {
            _item = item;
            _price1 = price1;
            _price2 = price2;
            SetLabelItemName();
            SetLabelPrice1();
            SetLabelPrice2();
            SetPanel();
            MarkNotFoundItemInStore();
            MarkPrices(); 
        }

        public FlowLayoutPanel Panel { get { return _panel; } }

        public void SetPanel()
        {
            _panel = new FlowLayoutPanel();
            _panel.Name = "flowLayoutPanel_panel";
            _panel.FlowDirection = FlowDirection.RightToLeft;
            _panel.Controls.Add(_lbl_itemName);
            _panel.Controls.Add(_lbl_price1);
            _panel.Controls.Add(_lbl_price2);
            _panel.BorderStyle = BorderStyle.FixedSingle;
            _panel.Height = 80;
            _panel.Width = 600;
            MarkNotFoundItemInStore();
        }

        private void SetLabelItemName()
        {
            _lbl_itemName = new Label();
            _lbl_itemName.Name = "lbl_itemName";
            _lbl_itemName.Text = _item.ItemName;
            _lbl_itemName.Font = new Font("Arial", FontSize, FontStyle.Bold);
        }

        public void SetLabelPrice1()
        {
            _lbl_price1 = new Label();
            _lbl_price1.Name = "lbl_price1";
            _lbl_price1.Font = new Font("Arial", FontSize, FontStyle.Bold);
            _lbl_price1.Text = $"{_price2?.price.ToString()} {Constants.Currency}";
            _lbl_price1.AutoSize = true;
            _lbl_price1.Height = 20;
            _lbl_price1.Width = 50;
            _lbl_price1.Anchor = AnchorStyles.Left;
        }

        public void SetLabelPrice2()
        {
            _lbl_price2 = new Label();
            _lbl_price2.Name = "lbl_price1";
            _lbl_price2.Font = new Font("Arial", FontSize, FontStyle.Bold);
            _lbl_price2.Text = $"{_price1?.price.ToString()} {Constants.Currency}";
            _lbl_price2.AutoSize = true;
            _lbl_price2.Height = 20;
            _lbl_price2.Width = 50;
            _lbl_price2.Anchor = AnchorStyles.Left;
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
                if (_price1.price > _price2.price)
                {
                    _lbl_price1.ForeColor = Color.Green;
                    _lbl_price2.ForeColor = Color.Red;
                }
                else if (_price1.price < _price2.price)
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
