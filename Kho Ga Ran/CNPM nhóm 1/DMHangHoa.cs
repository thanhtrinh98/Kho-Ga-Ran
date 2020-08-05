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
    public partial class DMHangHoa : Form
    {
        public DMHangHoa()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtemailkh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsdtkh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttenkh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtdckh_TextChanged(object sender, EventArgs e)
        {

        }

        private void btxoa_Click(object sender, EventArgs e)
        {

        }

        private void btluu_Click(object sender, EventArgs e)
        {

        }

        private void btsua_Click(object sender, EventArgs e)
        {

        }

        private void btthem_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            motxt();
            dongbtn();
            state = "delete";
            binding();
        }

        private void DMHangHoa_Load(object sender, EventArgs e)
        {
            mobtn();
            dongtxt();
            hien();
        }

        private bool validate() { 
            if(fieldDonViTinh.Text == "" || fieldSL.Text == "" || fieldTenHH.Text == "" ){
                MessageBox.Show("Bạn phải điền đầy đủ các trường !");
                return false;
            }
            return true;
        }

        private void hien()
        {
            string sql = @"SELECT * FROM DMHangHoa";

            dataGridView1.DataSource = DbHelper.getTable(sql);
        }

        private void binding()
        {
            fieldDonViTinh.DataBindings.Clear();
            fieldMaHH.DataBindings.Clear();
            fieldNgayNhap.DataBindings.Clear();
            fieldSL.DataBindings.Clear();
            fieldTenHH.DataBindings.Clear();


            fieldDonViTinh.DataBindings.Add("Text", dataGridView1.DataSource, "donvitinh");
            fieldMaHH.DataBindings.Add("Text", dataGridView1.DataSource, "mahh");
            fieldNgayNhap.DataBindings.Add("value", dataGridView1.DataSource, "ngaynhap");
            fieldSL.DataBindings.Add("Text", dataGridView1.DataSource, "soluong");
            fieldTenHH.DataBindings.Add("Text", dataGridView1.DataSource, "tenhh");
        }

        private void motxt(){
            fieldDonViTinh.Enabled = true;
            fieldNgayNhap.Enabled = true;
            fieldSL.Enabled = true;
            fieldTenHH.Enabled = true;
        }

        private void dongtxt() {
            fieldDonViTinh.Enabled = false;
            fieldNgayNhap.Enabled = false;
            fieldSL.Enabled = false;
            fieldTenHH.Enabled = false;
        }

        private void mobtn()
        {
            btthem.Enabled = true;
            btsua.Enabled = true;
            btxoa.Enabled = true;
            btnhuy.Enabled = false;
            btluu.Enabled = false;
        }

        private void dongbtn()
        {
            btthem.Enabled = false;
            btsua.Enabled = false;
            btxoa.Enabled = false;
            btnhuy.Enabled = true;
            btluu.Enabled = true;
        }

        string state = "";

        private void btthem_Click_1(object sender, EventArgs e)
        {
            motxt();
            dongbtn();
            state = "insert";
        }

        private void btsua_Click_1(object sender, EventArgs e)
        {
            motxt();
            dongbtn();
            state = "update";
            binding();
        }

        private void btluu_Click_1(object sender, EventArgs e)
        {
            if (validate())
            {



                if (state == "insert")
                {
                    //MessageBox.Show("INSERT INTO PhieuNhap(MaPhieuNhap, TenNCC, TenMH, SoLuongNhap,GiaNhap,TienDaThanhToan,NgayThanhToan) VALUES (" + Convert.ToInt32(txtMaPhieuNhap.Text) + ",N'" + txtTenNCC.Text + "',N'" + txtTenMH.Text + "'," + Convert.ToInt32(txtSoLuongNhap.Text) + "," + Convert.ToInt32(txtGiaNhap.Text) + "," + Convert.ToInt32(txtTienDaThanhToan.Text) + ",'"+txtNgayThanhToan.Value.ToShortDateString().ToString() +"')");
                    string sql = @"INSERT INTO [QLKhoHang].[dbo].[DMHangHoa]
           ([tenhh]
           ,[soluong]
           ,[donvitinh]
           ,[ngaynhap])
     VALUES
           (N'"+fieldTenHH.Text+@"'
           ,"+Convert.ToInt64(fieldSL.Text)+@"
           ,N'"+fieldDonViTinh.Text+@"'
           ,'" + fieldNgayNhap.Value.ToString("yyyy/MM/dd") + @"'
)";

                    if (DbHelper.Query(sql) != -1)
                    {
                        MessageBox.Show("Thêm thành công !");
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong quá trình thêm");
                    }
                }
                //end add
                else if (state == "update")
                {
                    string sql = @"UPDATE [QLKhoHang].[dbo].[DMHangHoa]
   SET [tenhh] = N'" + fieldTenHH.Text + @"'
      ,[soluong] = " + Convert.ToInt64(fieldSL.Text) + @"
      ,[donvitinh] = N'" + fieldDonViTinh.Text + @"'
      ,[ngaynhap] = '" + fieldNgayNhap.Value.ToString("yyyy/MM/dd") + @"'
 WHERE mahh = "+Convert.ToInt64(fieldMaHH.Text);



                    if (DbHelper.Query(sql) != -1)
                    {
                        MessageBox.Show("Sửa thành công !");
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong quá trình Sửa");
                    }

                }

                hien();
                dongtxt();
                mobtn();
            }//end validate
            if (state == "delete"&&validate())
            {
                string sql = @"DELETE [QLKhoHang].[dbo].[DMHangHoa]
 WHERE mahh = " + Convert.ToInt64(fieldMaHH.Text);


                if (DbHelper.Query(sql) != -1)
                {
                    MessageBox.Show("Xóa thành công !");
                }
                else
                {
                    MessageBox.Show("Có lỗi trong quá trình Xóa");
                }

                hien();
                dongtxt();
                mobtn();
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            mobtn();
            dongtxt();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Visible = true;
        }

        private void button3_Click321(object sender, EventArgs e)
        {
            string sql = @"SELECT * FROM DMHangHoa";
            DataTable data = DbHelper.getTable(sql);  //lấy dữ liệu từ bảng KhachHang
            if (fieldTim.Text != "")
            {
                data.DefaultView.RowFilter = "tenhh LIKE '%" + fieldTim.Text + "%'";  //filter lọc dữ liệu
            }
            else
            {
                data.DefaultView.RowFilter = "";
            }

            dataGridView1.DataSource = data;  //gán giá trị vào datagridview
        }
    }
}
