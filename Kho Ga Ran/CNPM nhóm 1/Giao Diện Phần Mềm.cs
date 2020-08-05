using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM_nhóm_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new DangNhap().Visible = true;
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Class.role == "A")
            {
                
                this.Visible = false;
                new QuanLyTaiKhoan().ShowDialog();
            }
            else
            {
                MessageBox.Show("Chỉ admin mới có thể quản lý tài khoản");
            }
        }

        private void dMHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new DMHangHoa().ShowDialog();
        }

        private void dMNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new DMNhaCungCap().ShowDialog();
        }

        private void dMKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new DMKhachHang().ShowDialog();
        }

        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void xuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nhậpKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Phiếu_Nhập().ShowDialog();
        }

        private void xuấtKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Phiếu_Xuất().ShowDialog();
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
