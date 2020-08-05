using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CNPM_nhóm_1
{
    class DbHelper
    {
        //lấy chuỗi kết nối tới cơ sở dữ liệu
        static string connString = @"Data Source=DESKTOP-S8FJPHB\SQLEXPRESS1;Initial Catalog=QLKhoHang;Integrated Security=True";
        //static string connString = @"Data Source=(local);Initial Catalog=QLKhoHang;Integrated Security=True";

        //tạo biến kết nối
        static SqlConnection connect;

        //hàm mở kết nối
        public static SqlConnection Open()
        {
            connect = new SqlConnection(connString); //khai báo một biến kết nối mới với giá trị truyền vào là Chuỗi connString
            try
            {
                connect.Open();  //mở kết nối
            }
            catch (Exception ex)
            {  //nếu không kết nối được
                MessageBox.Show(ex.Message.ToString());   //hiện thông báo lỗi ngoại lê
            }
            return connect; //trả về biến kết nối
        }


        //hàm lấy tất cả dữ liệu từ 1 hoặc nhiều bảng trong CSDL trả về là dữ liệu dạng bảng (DataTable)
        public static DataTable getTable(string sql)
        {
            DataTable result = new DataTable();   //tạo mới 1 biến lưu dữ liệu dạng bảng
            SqlCommand cmd = new SqlCommand(sql, Open());  //tạo biến xử lý lệnh thao tác với CSDL, với giá trị truyền vào là chuỗi sql và biến kết nối (connect được lấy ra từ hàm Open())
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();  //tạo một biến trung gian lưu dữ liệu
                da.SelectCommand = cmd;
                da.Fill(result);  //làm đầy biến result
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return result; //trả về biến result
        }


        //hàm xử lý lệnh INSERT,UPDATE,DELETE(thêm, sửa, xóa) với giá trị truyên vào là chuỗi sql
        public static int Query(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Open());  //tạo đối tượng xử các lệnh sql
            try
            {
                return cmd.ExecuteNonQuery();   //xử lý lệnh sql trả về giá trị là số dòng bị ảnh hưởng >= 0
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("FK_")){
                    MessageBox.Show("Dữ liệu bạn đang xóa đang được sử dụng ở bảng khác, hãy kiểm tra lại !");
                }
                else
                MessageBox.Show(ex.Message.ToString());
            }
            return -1;
        }


        //hàm  xuất dữ liệu từ DataGridView(bảng trong các form) ra file Excel
        public static void ExportExcel(DataGridView dgv)
        {
            string text = "";  //khai báo biến text để lưu dữ liệu từng dòng từng cột của bảng

            for (int i = 0; i < dgv.Columns.Count; i++)
            {  //chạy vòng for để lấy tên cột của bảng
                if (dgv.Columns[i].Visible == true)
                {
                    text += dgv.Columns[i].HeaderText + "\t";    //lưu giá trị Tên cột vào File Text
                }
            }
            text += "\n";

            for (int i = 0; i < dgv.Rows.Count; i++)   //chạy vòng for lấy giá trị của từng dòng từng cột trong bảng 
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Columns[j].Visible == true)
                    {
                        text += dgv.Rows[i].Cells[j].Value.ToString() + "\t";   //gán giá trị vào biến text
                    }
                }
                text += "\n";
            }


            SaveFileDialog sfd = new SaveFileDialog();   //tạo 1 thông báo lưu trữ file excel
            sfd.Filter = "Excel | *.csv";  //xác định định dạng file excel
            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                System.IO.File.WriteAllText(sfd.FileName, text, Encoding.Unicode);  //ghi ra file excel
            }
        }
    }
}
