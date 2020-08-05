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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)  //sự kiện nút đăng nhập
        {
            if (validate())  //kiểm tra dữ liệu k rỗng thì :
            {
                //khai báo chuỗi lệnh sql
                string sql = @"select * from TaiKhoanNV where TenTK = '" + txtTaiKhoan.Text + "' and MKTK = '"+txtMatKhau.Text+"'";
                DataTable data = DbHelper.getTable(sql);

                if (data.Rows.Count <= 0)  //gọi hàm getTable từ lớp DbHelper có giá trị truyền vào là chuỗi lênh select để lấy thông tin từ bảng nếu có số dòng <= 0 thì:
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu !");
                }
                else  //nếu số dòng lấy được > 0 thì :
                {
                    MessageBox.Show("Đăng nhập thành công !");
                    Class.role = data.Rows[0]["Role"].ToString();
                    this.Visible = false;  //cho form này ẩn đi
                    new Form1().ShowDialog();  //hiện form chinh
                }
            }
        }

        private bool validate() {   //hàm kiểm tra dữ liệu nhập vào có rỗng hay k
            if(txtTaiKhoan.Text ==""|| txtMatKhau.Text == ""){
                MessageBox.Show("Bạn phải điền đầy đủ các trường !");
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)  //sự kiện nút thoát
        {
            Application.Exit();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
