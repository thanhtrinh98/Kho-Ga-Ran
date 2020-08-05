using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lớp_BUS;
using Lớp_DAL;
using Lớp_Entites;

namespace CNPM_nhóm_1
{
    public partial class DMKhachHang : Form
    {
        public DMKhachHang()
        {
            InitializeComponent();
        }
        BUS_tblKhachHang bus = new BUS_tblKhachHang();
        EC_tblKhachHang ec = new EC_tblKhachHang();
        bool themmoi;
        // hàm khóa điều khiển
        void khoadieukhien()
        {
        }
        // hàm mở điều khiển
        void modieukhien()
        {
            btxoa.Enabled = false;
        }
        // hàm mặc định giá trị rỗng
        void setnull()
        {
        }
        void hienthi(string DieuKien)
        {
            dataGridView1.DataSource = bus.taobang(DieuKien);
        }
        private void DMKhachHang_Load(object sender, EventArgs e)
        {

            mobtn();
            dongtxt();
            hien();
        }

        private bool validate() { 
            if(fielddckh.Text == "" ||fieldemailkh.Text == "" ||fieldSDT.Text == "" ||fieldtenkh.Text == "" ){
                MessageBox.Show("Bạn phải điền đầy đủ các trường !");
                return false;
            }
            return true;
        }

        private void hien()
        {
            string sql = @"SELECT * FROM DMKhachHang";

            dataGridView1.DataSource = DbHelper.getTable(sql);
        }

        private void binding()
        {
            fielddckh.DataBindings.Clear();
            fieldemailkh.DataBindings.Clear();
            fieldmakh.DataBindings.Clear();
            fieldSDT.DataBindings.Clear();
            fieldtenkh.DataBindings.Clear();


            fielddckh.DataBindings.Add("Text", dataGridView1.DataSource, "diachikh");
            fieldemailkh.DataBindings.Add("Text", dataGridView1.DataSource, "emailkh");
            fieldmakh.DataBindings.Add("Text", dataGridView1.DataSource, "makh");
            fieldSDT.DataBindings.Add("Text", dataGridView1.DataSource, "sdtkh");
            fieldtenkh.DataBindings.Add("Text", dataGridView1.DataSource, "tenkh");
        }
        private void motxt()
        {
            fielddckh.Enabled = true;
            fieldemailkh.Enabled = true;
            fieldSDT.Enabled = true;
            fieldtenkh.Enabled = true;
        }

        private void dongtxt()
        {
            fielddckh.Enabled = false;
            fieldemailkh.Enabled = false;
            fieldSDT.Enabled = false;
            fieldtenkh.Enabled = false;
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























        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btthem_Click(object sender, EventArgs e)
        {
            modieukhien();
            setnull();
            themmoi = true;
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            modieukhien();
            fieldmakh.Enabled = false;
            themmoi = false;
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                ec.Makh = fieldmakh.Text;
                bus.xoadulieu(ec);
                MessageBox.Show("đã xóa");
                khoadieukhien();
                setnull();
                hienthi("");
            }
            catch
            {
                MessageBox.Show("không thể xóa");
            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridkh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

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

        private void btxoa_Click_1(object sender, EventArgs e)
        {

            motxt();
            dongbtn();
            state = "delete";
            binding();
        }

        private void btluu_Click_1(object sender, EventArgs e)
        {
            if (validate())
            {



                if (state == "insert")
                {
                    //MessageBox.Show("INSERT INTO PhieuNhap(MaPhieuNhap, TenNCC, TenMH, SoLuongNhap,GiaNhap,TienDaThanhToan,NgayThanhToan) VALUES (" + Convert.ToInt32(txtMaPhieuNhap.Text) + ",N'" + txtTenNCC.Text + "',N'" + txtTenMH.Text + "'," + Convert.ToInt32(txtSoLuongNhap.Text) + "," + Convert.ToInt32(txtGiaNhap.Text) + "," + Convert.ToInt32(txtTienDaThanhToan.Text) + ",'"+txtNgayThanhToan.Value.ToShortDateString().ToString() +"')");
                    string sql = @"INSERT INTO [QLKhoHang].[dbo].[DMKhachHang]
           ([tenkh]
           ,[sdtkh]
           ,[emailkh]
           ,[diachikh])
     VALUES
           (N'"+fieldtenkh.Text+@"'
           ,"+Convert.ToInt64(fieldSDT.Text)+@"
           ,N'" + fieldemailkh.Text+ @"'
           ,N'" + fielddckh.Text + @"'
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
                    string sql = @"UPDATE [QLKhoHang].[dbo].[DMKhachHang]
   SET [tenkh] = N'" + fieldtenkh.Text + @"'
      ,[sdtkh] = " + Convert.ToInt64(fieldSDT.Text) + @"
      ,[emailkh] = N'" + fieldemailkh.Text + @"'
      ,[diachikh] = N'" + fielddckh.Text + @"'
 WHERE makh = "+Convert.ToInt64(fieldmakh.Text);



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
                string sql = @"DELETE FROM [QLKhoHang].[dbo].[DMKhachHang]
 WHERE makh = " + Convert.ToInt64(fieldmakh.Text);


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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT * FROM DMKhachHang";
            DataTable data = DbHelper.getTable(sql);  //lấy dữ liệu từ bảng KhachHang
            if (fieldTim.Text != "")
            {
                data.DefaultView.RowFilter = "tenkh LIKE '%" + fieldTim.Text + "%' ";  //filter lọc dữ liệu
            }
            else
            {
                data.DefaultView.RowFilter = "";
            }

            dataGridView1.DataSource = data;  //gán giá trị vào datagridview
        }

        
    }
}
