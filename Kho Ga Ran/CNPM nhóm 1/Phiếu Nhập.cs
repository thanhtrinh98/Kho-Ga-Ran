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
    public partial class Phiếu_Nhập : Form
    {
        public Phiếu_Nhập()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Phiếu_Nhập_Load(object sender, EventArgs e)
        {
            //nạp dữ liệu vào combobox HangHoa
            string sql = @"SELECT * FROM DMHangHoa";     // chuỗi lệnh sql
            fieldMAHH.DataSource = DbHelper.getTable(sql);  //lấy thông tin từ bảng trong database gán vào DataSource của comboboxMaHangHoa

            fieldMAHH.DisplayMember = "tenhh";  //thuộc tính hiển thị

            fieldMAHH.ValueMember = "mahh"; //thuộc tính giá trị


            //nạp dữ liêu vào combobox NhaCungCap tương tự trên
            string sql1 = @"SELECT * FROM DMNhaCungCap";

            fieldMaNCC.DataSource = DbHelper.getTable(sql1);

            fieldMaNCC.DisplayMember = "tenncc";

            fieldMaNCC.ValueMember = "mancc";

            mobtn();  //
            dongtxt();
            hien();
        }

        private bool validate() {   //hàm kiểm tra hợp lệ dữ liệu
            if(fieldMAHH.Text == "" ||fieldMaNCC.Text == "" ||fieldNgayNhap.Text == "" ||fieldNguoiNhap.Text == "" ||fieldSoLuong.Text == ""){
                MessageBox.Show("Bạn phải điền đầy đủ các trường !");
                return false;
            }
            return true;
        }

        private void hien()  //hàm hiện
        {
            //chuỗi sql select
            string sql = @"SELECT MaPNK,PhieuNhap.NgayNhap,NguoiNhap,PhieuNhap.MaNCC,SoLuongNhap,PhieuNhap.MaHH,tenncc,tenhh FROM PhieuNhap INNER JOIN DMNhaCungCap ON DMNhaCungCap.mancc = PhieuNhap.MaNCC INNER JOIN DMHangHoa ON DMHangHoa.mahh = PhieuNhap.MaHH";


            //Gán datasource của datagridview = dữ liệu lệnh được từ câu lệnh sql trên
            dataGridView1.DataSource = DbHelper.getTable(sql);
        }

        private void binding()  //hàm đưa dữ liệu từ datagridview lên textbox(binding)
        {
            //xóa dữ liệu binding
            fieldMAHH.DataBindings.Clear();
            fieldMaNCC.DataBindings.Clear();
            fieldMaPNK.DataBindings.Clear();
            fieldNgayNhap.DataBindings.Clear();
            fieldNguoiNhap.DataBindings.Clear();
            fieldSoLuong.DataBindings.Clear();

            //nạp binding
            fieldMAHH.DataBindings.Add("SelectedValue", dataGridView1.DataSource, "MaHH");
            fieldMaNCC.DataBindings.Add("SelectedValue", dataGridView1.DataSource, "MaNCC");
            fieldMaPNK.DataBindings.Add("Text", dataGridView1.DataSource, "MaPNK");
            fieldNgayNhap.DataBindings.Add("Value", dataGridView1.DataSource, "NgayNhap");
            fieldNguoiNhap.DataBindings.Add("Text", dataGridView1.DataSource, "NguoiNhap");
            fieldSoLuong.DataBindings.Add("Text", dataGridView1.DataSource, "SoLuongNhap");
        }
        private void motxt()
        {
            fieldMAHH.Enabled = true;
            fieldMaNCC.Enabled = true;
            fieldNgayNhap.Enabled = true;
            fieldNguoiNhap.Enabled = true;
            fieldSoLuong.Enabled = true;
        }

        private void dongtxt()
        {
            fieldMAHH.Enabled = false;
            fieldMaNCC.Enabled = false;
            fieldNgayNhap.Enabled = false;
            fieldNguoiNhap.Enabled = false;
            fieldSoLuong.Enabled = false;
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

        string state = "";  //lưu trạng thái khi ấn các nút thêm sửa xóa











        private void label5_Click(object sender, EventArgs e)
        {

        }

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

        private void btluu_Click(object sender, EventArgs e)  //sự kiện nút lưu
        {
            if (validate())  //kiểm tra trường k rỗng thì:
            {



                if (state == "insert")  //sự kiện nút thêm
                {
                    //MessageBox.Show("INSERT INTO PhieuNhap(MaPhieuNhap, TenNCC, TenMH, SoLuongNhap,GiaNhap,TienDaThanhToan,NgayThanhToan) VALUES (" + Convert.ToInt32(txtMaPhieuNhap.Text) + ",N'" + txtTenNCC.Text + "',N'" + txtTenMH.Text + "'," + Convert.ToInt32(txtSoLuongNhap.Text) + "," + Convert.ToInt32(txtGiaNhap.Text) + "," + Convert.ToInt32(txtTienDaThanhToan.Text) + ",'"+txtNgayThanhToan.Value.ToShortDateString().ToString() +"')");
                    string sql = @"INSERT INTO [QLKhoHang].[dbo].[PhieuNhap]
           ([NgayNhap]
           ,[NguoiNhap]
           ,[MaNCC]
           ,[SoLuongNhap]
           ,[MaHH])
     VALUES
           ('"+fieldNgayNhap.Value.ToString("yyyy/MM/dd")+@"'
           ,N'"+fieldNguoiNhap.Text+@"'
           ,"+fieldMaNCC.SelectedValue+@"
           ," + Convert.ToInt64(fieldSoLuong.Text) + @"
           ," + fieldMAHH.SelectedValue + @"
           )";

                     
                    if (DbHelper.Query(sql) != -1)  //hàm thực hiện lênh sql, trả về giá trị là -1 khi không có dòng nào bị ảnh hưởng (k có dòng nào thay đổi)
                    {
                        MessageBox.Show("Thêm thành công !");
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong quá trình thêm");
                    }
                }
                //end add
                else if (state == "update")  //tương tự nút thêm
                {
                    string sql = @"UPDATE [QLKhoHang].[dbo].[PhieuNhap]
   SET [NgayNhap] = '" + fieldNgayNhap.Value.ToString("yyyy/MM/dd") + @"'
      ,[NguoiNhap] = N'" + fieldNguoiNhap.Text + @"'
      ,[MaNCC] = " + fieldMaNCC.SelectedValue + @"
      ,[SoLuongNhap] = " + Convert.ToInt64(fieldSoLuong.Text) + @"
      ,[MaHH] = " + fieldMAHH.SelectedValue + @"
 WHERE MaPNK="+Convert.ToInt64(fieldMaPNK.Text);



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
            if (state == "delete" && validate()) //tương tự nút thêm
            {
                string sql = @"DELETE FROM [QLKhoHang].[dbo].[PhieuNhap]
 WHERE MaPNK=" + Convert.ToInt64(fieldMaPNK.Text);


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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthoat_Click1(object sender, EventArgs e)
        {
            DbHelper.ExportExcel(dataGridView1);
        }

        private void btnhuy_Click1(object sender, EventArgs e)  //sự kiện nút tìm
        {
            //lấy dữ liệu để lọc
            string sql = @"SELECT MaPNK,PhieuNhap.NgayNhap,NguoiNhap,PhieuNhap.MaNCC,SoLuongNhap,PhieuNhap.MaHH,tenncc,tenhh FROM PhieuNhap INNER JOIN DMNhaCungCap ON DMNhaCungCap.mancc = PhieuNhap.MaNCC INNER JOIN DMHangHoa ON DMHangHoa.mahh = PhieuNhap.MaHH";
           
            DataTable data = DbHelper.getTable(sql);  //lấy dữ liệu từ bảng KhachHang
            
            if (txtTim.Text != "") 
            {
                data.DefaultView.RowFilter = "NguoiNhap LIKE '%" + txtTim.Text + "%' OR tenncc LIKE '%" + txtTim.Text + "%' OR tenhh LIKE '%" + txtTim.Text + "%'";  //filter lọc dữ liệu
            }
            else
            {
                data.DefaultView.RowFilter = "";
            }

            dataGridView1.DataSource = data;  //gán giá trị vào datagridview
        }
    }
}
