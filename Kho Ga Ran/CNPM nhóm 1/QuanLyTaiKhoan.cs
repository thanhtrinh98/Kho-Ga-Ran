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
    public partial class QuanLyTaiKhoan : Form
    {
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            hien();
        }

        private bool validate() { 
            if(fieldTenDN.Text == "" ||fieldMatKhau.Text == "" ){
                MessageBox.Show("Bạn phải điền đầy đủ các trường !");
                return false;
            }
            return true;
        }

        private void hien()
        {
            string sql = @"SELECT * FROM TaiKhoanNV where Role <> 'A'";

            dataGridView1.DataSource = DbHelper.getTable(sql);

            binding();
        }

        private void binding()
        {
            fieldMaTK.DataBindings.Clear();
            fieldTenDN.DataBindings.Clear();
            fieldMatKhau.DataBindings.Clear();

            fieldMaTK.DataBindings.Add("Text", dataGridView1.DataSource, "MaTK");
            fieldTenDN.DataBindings.Add("Text", dataGridView1.DataSource, "TenTK");
            fieldMatKhau.DataBindings.Add("Text", dataGridView1.DataSource, "MKTK");

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Close();
            new Form1().Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                string sql = @"INSERT INTO [QLKhoHang].[dbo].[TaiKhoanNV]
                                   ([TenTK]
                                   ,[Role]
                                   ,[MKTK])
                             VALUES
                                   ('"+fieldTenDN.Text+@"'
                                   ,'N'
                                   ,'"+fieldMatKhau.Text+@"'
                                    )";

                if (DbHelper.Query(sql) == -1)
                {
                    MessageBox.Show("Có lỗi trong quá trình thêm !");
                }
                else
                {
                    MessageBox.Show("Thêm thành công !");
                    hien();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                string sql = @"UPDATE [QLKhoHang].[dbo].[TaiKhoanNV]
                               SET [TenTK] = '" + fieldTenDN.Text + @"'
                                  ,[Role] = 'N'
                                  ,[MKTK] = '" + fieldMatKhau.Text + @"'
                             WHERE MaTK = "+Convert.ToInt64(fieldMaTK.Text);

                if (DbHelper.Query(sql) == -1)
                {
                    MessageBox.Show("Có lỗi trong quá trình sửa !");
                }
                else
                {
                    MessageBox.Show("Sửa thành công !");
                    hien();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                string sql = @"DELETE FROM [QLKhoHang].[dbo].[TaiKhoanNV]
                             WHERE MaTK = " + Convert.ToInt64(fieldMaTK.Text);

                if (DbHelper.Query(sql) == -1)
                {
                    MessageBox.Show("Có lỗi trong quá trình xóa !");
                }
                else
                {
                    MessageBox.Show("Xóa thành công !");
                    hien();
                }
            }
        }
    }
}
