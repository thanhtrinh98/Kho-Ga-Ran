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
    public partial class Phiếu_Xuất : Form
    {
        public Phiếu_Xuất()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Phiếu_Xuất_Load(object sender, EventArgs e)
        {
            string sql = @"SELECT * FROM DMKhachHang";

            fieldMaKH.DataSource = DbHelper.getTable(sql);

            fieldMaKH.DisplayMember = "tenkh";

            fieldMaKH.ValueMember = "makh";


            string sql1 = @"SELECT * FROM DMHangHoa";

            fieldMaHH.DataSource = DbHelper.getTable(sql1);

            fieldMaHH.DisplayMember = "tenhh";

            fieldMaHH.ValueMember = "mahh";


            mobtn();
            dongtxt();
            hien();
        }

        private bool validate() { 
            if(fieldMaHH.Text == "" ||fieldMaKH.Text == "" ||fieldNguoiXuat.Text == "" ||fieldSoLuongXuat.Text == "" ){
                MessageBox.Show("Bạn phải điền đầy đủ các trường !");
                return false;
            }
            return true;
        }

        private void hien()
        {
            string sql = @"SELECT     PhieuXuat.NgayXuat, PhieuXuat.NguoiXuat, PhieuXuat.MaKH, PhieuXuat.SoLuongXuat, PhieuXuat.MaHH, PhieuXuat.MaPXK, DMKhachHang.tenkh, 
                      DMHangHoa.tenhh
FROM         DMHangHoa INNER JOIN
                      PhieuXuat ON DMHangHoa.mahh = PhieuXuat.MaHH INNER JOIN
                      DMKhachHang ON PhieuXuat.MaKH = DMKhachHang.makh";

            dataGridView1.DataSource = DbHelper.getTable(sql);
        }

        private void binding()
        {
            fieldMaHH.DataBindings.Clear();
            fieldMaKH.DataBindings.Clear();
            fieldMaPXK.DataBindings.Clear();
            fieldNgayXuat.DataBindings.Clear();
            fieldNguoiXuat.DataBindings.Clear();
            fieldSoLuongXuat.DataBindings.Clear();

            fieldMaHH.DataBindings.Add("Text", dataGridView1.DataSource, "MaHH");
            fieldMaKH.DataBindings.Add("Text", dataGridView1.DataSource, "MaKH");
            fieldMaPXK.DataBindings.Add("Text", dataGridView1.DataSource, "MaPXK");
            fieldNgayXuat.DataBindings.Add("Text", dataGridView1.DataSource, "NgayXuat");
            fieldNguoiXuat.DataBindings.Add("Text", dataGridView1.DataSource, "NguoiXuat");
            fieldSoLuongXuat.DataBindings.Add("Text", dataGridView1.DataSource, "SoLuongXuat");

        }
        private void motxt()
        {
            fieldMaHH.Enabled = true;
            fieldMaKH.Enabled = true;
            fieldNgayXuat.Enabled = true;
            fieldNguoiXuat.Enabled = true;
            fieldSoLuongXuat.Enabled = true;
        }

        private void dongtxt()
        {
            fieldMaHH.Enabled = false;
            fieldMaKH.Enabled = false;
            fieldNgayXuat.Enabled = false;
            fieldNguoiXuat.Enabled = false;
            fieldSoLuongXuat.Enabled = false;
        }

        private void mobtn()
        {
            btluu.Enabled = false;
            btnhuy.Enabled = false;
            btthem.Enabled = true;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }

        private void dongbtn()
        {
            btluu.Enabled = true;
            btnhuy.Enabled = true;
            btthem.Enabled = false;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }

        string state = "";

        private void btthem_Click(object sender, EventArgs e)
        {

            motxt();
            dongbtn();
            state = "insert";
        }

        private void btsua_Click(object sender, EventArgs e)
        {

            motxt();
            dongbtn();
            state = "update";
            binding();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {

            motxt();
            dongbtn();
            state = "delete";
            binding();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

            this.Close();
            new Form1().Visible = true;
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (validate())
            {



                if (state == "insert")
                {
                    //MessageBox.Show("INSERT INTO PhieuNhap(MaPhieuNhap, TenNCC, TenMH, SoLuongNhap,GiaNhap,TienDaThanhToan,NgayThanhToan) VALUES (" + Convert.ToInt32(txtMaPhieuNhap.Text) + ",N'" + txtTenNCC.Text + "',N'" + txtTenMH.Text + "'," + Convert.ToInt32(txtSoLuongNhap.Text) + "," + Convert.ToInt32(txtGiaNhap.Text) + "," + Convert.ToInt32(txtTienDaThanhToan.Text) + ",'"+txtNgayThanhToan.Value.ToShortDateString().ToString() +"')");
                    string sql = @"INSERT INTO [QLKhoHang].[dbo].[PhieuXuat]
           ([NgayXuat]
           ,[NguoiXuat]
           ,[MaKH]
           ,[SoLuongXuat]
           ,[MaHH])
     VALUES
           ('"+fieldNgayXuat.Value.ToString("yyyy/MM/dd")+@"'
           ,N'"+fieldNguoiXuat.Text+@"'
           ,"+fieldMaKH.SelectedValue+@"
           ," + Convert.ToInt64(fieldSoLuongXuat.Text) + @"
           ," + fieldMaHH.SelectedValue + @"
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
                    string sql = @"UPDATE [QLKhoHang].[dbo].[PhieuXuat]
   SET [NgayXuat] ='" + fieldNgayXuat.Value.ToString("yyyy/MM/dd") + @"'
      ,[NguoiXuat] = N'" + fieldNguoiXuat.Text + @"'
      ,[MaKH] =" + fieldMaKH.SelectedValue + @"
      ,[SoLuongXuat] =" + Convert.ToInt64(fieldSoLuongXuat.Text) + @"
      ,[MaHH] = " + fieldMaHH.SelectedValue + @"
 WHERE MaPXK = "+Convert.ToInt64(fieldMaPXK.Text);



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
            if (state == "delete" && validate())
            {
                string sql = @"DELETE [QLKhoHang].[dbo].[PhieuXuat]
 WHERE MaPXK = " + Convert.ToInt64(fieldMaPXK.Text);


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

        private void xoatxt() {
            
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {

            mobtn();
            dongtxt();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DbHelper.ExportExcel(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT     PhieuXuat.NgayXuat, PhieuXuat.NguoiXuat, PhieuXuat.MaKH, PhieuXuat.SoLuongXuat, PhieuXuat.MaHH, PhieuXuat.MaPXK, DMKhachHang.tenkh, 
                      DMHangHoa.tenhh
                      FROM         DMHangHoa INNER JOIN
                      PhieuXuat ON DMHangHoa.mahh = PhieuXuat.MaHH INNER JOIN
                      DMKhachHang ON PhieuXuat.MaKH = DMKhachHang.makh";
            DataTable data = DbHelper.getTable(sql);  //lấy dữ liệu từ bảng KhachHang
            if (txtTim.Text != "")
            {
                data.DefaultView.RowFilter = "NguoiXuat LIKE '%" + txtTim.Text + "%' OR tenkh LIKE '%" + txtTim.Text + "%' OR tenhh LIKE '%" + txtTim.Text + "%'";  //filter lọc dữ liệu
            }
            else
            {
                data.DefaultView.RowFilter = "";
            }

            dataGridView1.DataSource = data;  //gán giá trị vào datagridview
        }
    }
}
