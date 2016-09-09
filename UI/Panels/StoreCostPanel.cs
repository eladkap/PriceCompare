using FinalLab.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalLab
{
    public class StoreCostPanel
    {
        Store _store;
        double _totalCost;
        FlowLayoutPanel _panel;
        Label _lbl_storeName;
        Label _lbl_totalCost;
        PictureBox _chainLogoPic;
        private int FontSize = 10;

        public StoreCostPanel(Store store, double totalCost)
        {
            _store = store;
            _totalCost = totalCost;
            SetLabelStoreName(store);
            SetLabelTotalCost(totalCost);
            SetChainLogoPic(store);
            SetPanel();
        }

        public FlowLayoutPanel Panel { get { return _panel; } }

        public void SetPanel()
        {
            _panel = new FlowLayoutPanel();
            _panel.FlowDirection = FlowDirection.LeftToRight;
            _panel.Controls.Add(_chainLogoPic);
            _panel.Controls.Add(_lbl_storeName);
            _panel.Controls.Add(_lbl_totalCost);
            _panel.BorderStyle = BorderStyle.FixedSingle;
            _panel.Height = 100;
            _panel.Width = 400;
        }

        public void SetLabelStoreName(Store store)
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

        public void SetLabelTotalCost(double totalCost)
        {
            _lbl_totalCost = new Label();
            _lbl_totalCost.Name = "_lbl_totalCost";
            _lbl_totalCost.Font = new Font("Arial", FontSize, FontStyle.Bold);
            _lbl_totalCost.ForeColor = Color.ForestGreen;
            totalCost = Math.Round(totalCost, Constants.CostProximity);
            _lbl_totalCost.Text = $"{totalCost} {Constants.Currency}";
            _lbl_totalCost.AutoSize = true;
            _lbl_totalCost.Height = 20;
            _lbl_totalCost.Width = 50;
            _lbl_totalCost.Anchor = AnchorStyles.Bottom;
        }

        public void SetChainLogoPic(Store store)
        {
            _chainLogoPic = new PictureBox();
            _chainLogoPic.Height = 30;
            _chainLogoPic.Width = (int)(_chainLogoPic.Height * 2.21);
            _chainLogoPic.SizeMode = PictureBoxSizeMode.Zoom;
            _chainLogoPic.Image = Image.FromFile(Constants.RootDir + @"img\chains_logo\" + store.ChainId + ".png");
            _chainLogoPic.Anchor = AnchorStyles.Bottom;
        }
    }
}
