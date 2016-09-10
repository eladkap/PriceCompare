using FinalLab.Managers;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FinalLab
{
    public class UIManager
    {
        CatalogManager _catalogManager;

        public UIManager()
        {
            _catalogManager = new CatalogManager();
        }

        public void LoadAllChains(ComboBox comboBox_chain, bool addAllChains)
        {
            ICollection<Chain> chainsList = _catalogManager.GetAllChains();
            if (addAllChains)
            {
                comboBox_chain.Items.Add("All Chains");
            }
            chainsList.ToList().ForEach((chain) => comboBox_chain.Items.Add(chain.ChainNameHebrew));
        }

        public void LoadStoresByChain(string chainName, ComboBox comboBox_store, bool addAllStores)
        {
            ICollection<Store> storesList = _catalogManager.GetStoresByChainName(chainName);
            comboBox_store.Items.Clear();
            if (addAllStores)
            {
                comboBox_store.Items.Add("All Stores");
            }
            storesList.ToList().ForEach((store) => comboBox_store.Items.Add(store.StoreName));
        }

        public void comboBox_chain_SelectedIndexChanged(ComboBox comboBox_chain, ComboBox comboBox_store, ref Chain chain, bool addAllStores)
        {
            if (comboBox_chain.SelectedItem.ToString().Length > 0)
            {
                comboBox_store.Enabled = true;
                string chainName = comboBox_chain.SelectedItem.ToString();
                LoadStoresByChain(chainName, comboBox_store, addAllStores);
                chain = _catalogManager.GetChainByName(chainName);
                comboBox_store.Enabled = true;
            }
        }

        public void comboBox_store_SelectedIndexChanged(ComboBox comboBox_store, ref Chain chain, ref Store store)
        {
            string storeName = comboBox_store.SelectedItem.ToString();
            store = _catalogManager.GetStoreByChainIdAndStoreName(chain, storeName);
        }

        public void SetChainLogoPicture(PictureBox pictureBox_chainLogo, string chainId)
        {
            pictureBox_chainLogo.Image = Image.FromFile(Constants.RootDir + @"img\chains_logo\" + chainId + ".png");
            pictureBox_chainLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_chainLogo.Height = 80;
            pictureBox_chainLogo.Width = (int)(pictureBox_chainLogo.Height * 2.21);
        }
    }
}
