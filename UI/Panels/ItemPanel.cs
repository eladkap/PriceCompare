using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinalLab
{
    public class ItemPanel
    {
        Item _item;
        Price _price;
        Store _store;
        FlowLayoutPanel _panel;
        Label _lbl_itemCode;
        Label _lbl_itemName;
        Label _lbl_itemManufacturer;
        Label _lbl_itemPrice;
        Label _lbl_storeId;
        Button _btn_addToCart;
        Button _btn_priceGraph;
        PictureBox _chainLogoPic;
        Label _lbl_storeName;
        PictureBox _itemPic;
        private int FontSize = 14;

        public Button BtnAddToCart { get { return _btn_addToCart; } }

        public Button BtnPriceGraph { get { return _btn_priceGraph; } }

        public ItemPanel(Item item, Price price, Store store)
        {
            _item = item;
            _price = price;
            _store = store;
            SetLabelItemName(item);
            SetLabelItemManufacturer(item);
            SetLabelItemCode(item);
            SetLabelStoreId(store);
            SetLabelItemPrice(price);
            SetButtonAddToCart();
            SetButtonPriceGraph();
            SetStoreName(store);
            SetChainLogoPic(store);
            //SetItemPic(item);
            SetPanel();
        }

        public FlowLayoutPanel Panel { get { return _panel; } }

        public void SetPanel()
        {
            _panel = new FlowLayoutPanel();
            _panel.FlowDirection = FlowDirection.TopDown;
            _panel.Controls.Add(_lbl_itemName);
            _panel.Controls.Add(_lbl_itemManufacturer);
            _panel.Controls.Add(_lbl_itemCode);
            _panel.Controls.Add(_lbl_storeId);
            _panel.Controls.Add(_lbl_itemPrice);
            _panel.Controls.Add(_chainLogoPic);
            _panel.Controls.Add(_lbl_storeName);
            // _panel.Controls.Add(_itemPic);
            _panel.Controls.Add(_btn_addToCart);
            _panel.Controls.Add(_btn_priceGraph);
            _panel.BorderStyle = BorderStyle.FixedSingle;
            _panel.Height = 300;
            _panel.Width = 300;
        }

        public void SetLabelItemName(Item item)
        {
            _lbl_itemName = new Label();
            _lbl_itemName.Name = "lbl_itemName";
            _lbl_itemName.Text = item.ItemName;
            _lbl_itemName.Font = new Font("Arial", FontSize, FontStyle.Bold);
            _lbl_itemName.AutoSize = true;
            _lbl_itemName.Height = 20;
            _lbl_itemName.Width = 50;
            _lbl_itemName.Anchor = AnchorStyles.Top;
        }

        private void SetLabelItemCode(Item item)
        {
            _lbl_itemCode = new Label();
            _lbl_itemCode.Name = "lbl_itemCode";
            _lbl_itemCode.Text = item.ItemCode;
            _lbl_itemCode.Visible = false;
        }

        private void SetLabelItemManufacturer(Item item)
        {
            _lbl_itemManufacturer = new Label();
            _lbl_itemManufacturer.Name = "lbl_itemManufacturer";
            _lbl_itemManufacturer.Text = item.ManufacturerName;
            _lbl_itemManufacturer.Font = new Font("Arial", FontSize - 2, FontStyle.Bold);
            _lbl_itemManufacturer.AutoSize = true;
            _lbl_itemManufacturer.Height = 20;
            _lbl_itemManufacturer.Width = 50;
            _lbl_itemManufacturer.Visible = true;
            _lbl_itemManufacturer.Anchor = AnchorStyles.Top;
        }

        public void SetLabelStoreId(Store store)
        {
            _lbl_storeId = new Label();
            _lbl_storeId.Name = "lbl_storeId";
            _lbl_storeId.Text = store.StoreId;
            _lbl_storeId.Font = new Font("Arial", FontSize, FontStyle.Bold);
            _lbl_storeId.AutoSize = true;
            _lbl_storeId.Height = 20;
            _lbl_storeId.Width = 50;
            _lbl_storeId.Anchor = AnchorStyles.Top;
            _lbl_storeId.Visible = false;
        }

        public void SetLabelItemPrice(Price price)
        {
            _lbl_itemPrice = new Label();
            _lbl_itemPrice.Name = "lbl_itemPrice";
            _lbl_itemPrice.Font = new Font("Arial", FontSize, FontStyle.Bold);
            _lbl_itemPrice.ForeColor = Color.ForestGreen;
            double totalCost = Math.Round(price.PriceValue, Constants.CostProximity);
            _lbl_itemPrice.Text = $"{totalCost} {Constants.Currency}";
            _lbl_itemPrice.AutoSize = true;
            _lbl_itemPrice.Height = 20;
            _lbl_itemPrice.Width = 50;
            _lbl_itemPrice.Anchor = AnchorStyles.Bottom;
        }

        private void SetButtonAddToCart()
        {
            _btn_addToCart = new Button();
            _btn_addToCart.Name = "btn_addToCart";
            _btn_addToCart.Font = new Font("Arial", FontSize, FontStyle.Bold);
            _btn_addToCart.Text = "Add to cart";
            _btn_addToCart.AutoSize = true;
            _btn_addToCart.Height = 20;
            _btn_addToCart.Width = 50;
            _btn_addToCart.Anchor = AnchorStyles.Bottom;
        }

        private void SetButtonPriceGraph()
        {
            _btn_priceGraph = new Button();
            _btn_priceGraph.Name = "btn_priceGraph";
            _btn_priceGraph.Font = new Font("Arial", FontSize, FontStyle.Bold);
            _btn_priceGraph.Image = Image.FromFile(Constants.RootDir + @"img\priceGraphIcon.png"); 
            _btn_priceGraph.Height = 60;
            _btn_priceGraph.Width = 60;
            _btn_priceGraph.Anchor = AnchorStyles.Bottom;
        }

        public void SetStoreName(Store store)
        {
            _lbl_storeName = new Label();
            _lbl_storeName.Name = "lbl_storeName";
            _lbl_storeName.Font = new Font("Arial", FontSize, FontStyle.Bold);
            _lbl_storeName.ForeColor = Color.DarkBlue;
            _lbl_storeName.Text = store.StoreName;
            _lbl_storeName.AutoSize = true;
            _lbl_storeName.Height = 20;
            _lbl_storeName.Width = 50;
            _lbl_storeName.Anchor = AnchorStyles.Bottom;
        }

        public void SetChainLogoPic(Store store)
        {
            _chainLogoPic = new PictureBox();
            _chainLogoPic.Height = 50;
            _chainLogoPic.Width = (int)(_chainLogoPic.Height * 2.21);
            _chainLogoPic.SizeMode = PictureBoxSizeMode.Zoom;
            _chainLogoPic.Image = Image.FromFile(Constants.RootDir + @"img\chains_logo\" + store.ChainId + ".png");
            _chainLogoPic.Anchor = AnchorStyles.Bottom;
        }

        public void SetItemPic(Item item)
        {
            _itemPic = new PictureBox();
            _itemPic.Height = 100;
            _itemPic.Width = (int)(_itemPic.Height);
            _itemPic.SizeMode = PictureBoxSizeMode.Zoom;
            string query = $"{_item.ManufacturerItemDescription} {item.ManufacturerName}";
            string itemPicUrl = GoogleEngine.GetPictureUrl(query);
            if (itemPicUrl != null)
            {
                _itemPic.ImageLocation = itemPicUrl;
            }
            _itemPic.Anchor = AnchorStyles.Bottom;
        }
    }
}
