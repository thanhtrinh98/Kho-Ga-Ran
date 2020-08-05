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
    public partial class DMNhaCungCap : Form
    {
        public DMNhaCungCap()
        {
            InitializeComponent();
        }
        BUS_tblNhaCungCap bus = new BUS_tblNhaCungCap();
        EC_tblNhaCungCap ec = new EC_tblNhaCungCap();
        bool themmoi;
        void modieukhien()
        {
            fieldMaNCC.Enabled = true;
            fieldTenNCC.Enabled = true;
            fieldSDT.Enabled = true;
            fieldEmail.Enabled = true;
            fieldDiaChi.Enabled = true;

            btthem.Enabled = false;
            btsua.Enabled = false;
            btxoa.Enabled = false;
            btluu.Enabled = true;
        }
        void khoadieukhien()
        {
            fieldMaNCC.Enabled = false;
            fieldTenNCC.Enabled = false;
            fieldSDT.Enabled = false;
            fieldEmail.Enabled = false;
            fieldDiaChi.Enabled = false;

            btthem.Enabled = true;
            btsua.Enabled = true;
            btxoa.Enabled = true;
            btluu.Enabled = false;
        }
        void setnull()
        {
            fieldMaNCC.Text = "";
            fieldTenNCC.Text = "";
            fieldSDT.Text = "";
            fieldEmail.Text= "";
            fieldDiaChi.Text = "";
        }
        void hienthidulieu(string DieuKien)
        {
            dataGridView1.DataSource = bus.taobang(DieuKien);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void DMNhaCungCap_Load(object sender, EventArgs e)
        {

            mobtn();
            dongtxt();
            hien();
        }

        private bool validate() { 
            if(fieldDiaChi.Text == "" || fieldEmail.Text == "" ||fieldSDT.Text == "" ||fieldTenNCC.Text == ""){
                MessageBox.Show("Bạn phải điền đầy đủ các trường !");
                return false;
            }
            return true;
        }

        private void hien()
        {
            string sql = @"SELECT * FROM DMNhaCungCap";

            dataGridView1.DataSource = DbHelper.getTable(sql);
        }

        private void binding()
        {
            fieldDiaChi.DataBindings.Clear();
            fieldEmail.DataBindings.Clear();
            fieldMaNCC.DataBindings.Clear();
            fieldSDT.DataBindings.Clear();
            fieldTenNCC.DataBindings.Clear();

            fieldDiaChi.DataBindings.Add("Text", dataGridView1.DataSource, "diachincc");
            fieldEmail.DataBindings.Add("Text", dataGridView1.DataSource, "emailncc");
            fieldMaNCC.DataBindings.Add("Text", dataGridView1.DataSource, "mancc");
            fieldSDT.DataBindings.Add("Text", dataGridView1.DataSource, "sdtncc");
            fieldTenNCC.DataBindings.Add("Text", dataGridView1.DataSource, "tenncc");
        }
        private void motxt()
        {
            fieldTenNCC.Enabled = true;
            fieldSDT.Enabled = true;
            fieldEmail.Enabled = true;
            fieldDiaChi.Enabled = true;
        }

        private void dongtxt()
        {
            fieldMaNCC.Enabled = false;
            fieldTenNCC.Enabled = false;
            fieldSDT.Enabled = false;
            fieldEmail.Enabled = false;
            fieldDiaChi.Enabled = false;
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
            modieukhien();
            setnull();
            themmoi = true;
            hienthidulieu("");
            setnull();
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            modieukhien();
            fieldMaNCC.Enabled = false;
            themmoi = false;
            
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            ec.Mancc = fieldMaNCC.Text;
            bus.xoadulieu(ec);
            MessageBox.Show("đã xóa");
            khoadieukhien();
            setnull();
            hienthidulieu("");
        }

        private void dataGridNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            khoadieukhien();
            try
            {
                fieldMaNCC.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                fieldTenNCC.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                fieldSDT.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                fieldEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                fieldDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[04].Value.ToString();
            }
            catch
            {
                MessageBox.Show("không có dữ liệu");
            }
        }

        private void btthem_Click_1(object sender, EventArgs e)
        {

            motxt();
            dongbtn();
            state = "insert";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btsua_Click_1(object sender, EventArgs e)
        {

            motxt();
            dongbtn();
            state = "update";
            binding();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {

            mobtn();
            dongtxt();
        }

        private void btxoa_Click_1(object sender, EventArgs e)
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
                    string sql = @"INSERT INTO [QLKhoHang].[dbo].[DMNhaCungCap]
           ([tenncc]
           ,[sdtncc]
           ,[emailncc]
           ,[diachincc])
     VALUES
           (N'"+fieldTenNCC.Text+@"'
           ," + Convert.ToInt64(fieldSDT.Text) + @"
           ,N'" + fieldEmail.Text + @"'
           ,N'" + fieldDiaChi.Text + @"'
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
                    string sql = @"UPDATE [QLKhoHang].[dbo].[DMNhaCungCap]
   SET [tenncc] = N'" + fieldTenNCC.Text + @"'
      ,[sdtncc] = " + Convert.ToInt64(fieldSDT.Text) + @"
      ,[emailncc] = N'" + fieldEmail.Text + @"'
      ,[diachincc] = N'" + fieldDiaChi.Text + @"'
 WHERE mancc ="+ Convert.ToInt64(fieldMaNCC.Text);



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
                string sql = @"DELETE [QLKhoHang].[dbo].[DMNhaCungCap]
 WHERE mancc =" + Convert.ToInt64(fieldMaNCC.Text);


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

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT * FROM DMNhaCungCap";
            DataTable data = DbHelper.getTable(sql);  //lấy dữ liệu từ bảng KhachHang
            if (fieldTim.Text != "")
            {
                data.DefaultView.RowFilter = "tenncc LIKE '%" + fieldTim.Text + "%' ";  //filter lọc dữ liệu
            }
            else
            {
                data.DefaultView.RowFilter = "";
            }

            dataGridView1.DataSource = data;  //gán giá trị vào datagridview
        }

    }
}
