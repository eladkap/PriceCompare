using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class ItemImageForm : Form
    {
        public ItemImageForm()
        {
            InitializeComponent();
        }

        internal void ShowImage(string itemPicUrl)
        {
            pictureBox_item.ImageLocation = itemPicUrl;
            pictureBox_item.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
