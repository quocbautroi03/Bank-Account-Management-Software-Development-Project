﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiKhoanNganHang
{
    public partial class FormSuaThongTinTaiKhoan : Form
    {
        SqlConnection Con = Connection.getInstance().getConnection();

        public FormSuaThongTinTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            if (cbbTenTaiKhoan.Text == "" || txtDoiMatKhau.Text == "" || txtMatKhauHienTai.Text == "" || txtXacNhanLaiMatKhau.Text == "")
            {
                MessageBox.Show("Hãy nhập vào đẩu đủ thông tin");
            } else if (txtDoiMatKhau.Text != txtXacNhanLaiMatKhau.Text)
            {
                MessageBox.Show("Điền Mật Khẩu Không Trùng Nhau.");
            }
            else
            {
                Con.Open();

                DialogResult dialogResult = MessageBox.Show("Bạn Có Chắc Chắn Đổi Mật Khẩu Không ?",
                    "Xác Nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenTaiKhoan = @TenTaiKhoan";
                    SqlCommand command = new SqlCommand(query, Con);

                    string TenTaiKhoan = string.IsNullOrEmpty(cbbTenTaiKhoan.Text) ? cbbTenTaiKhoan.SelectedItem.ToString() : cbbTenTaiKhoan.Text;
                    command.Parameters.AddWithValue("@TenTaiKhoan", TenTaiKhoan);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0) // Kiểm tra xem mã bệnh nhân đã tồn tại hay chưa
                    {
                        query = "UPDATE TaiKhoan SET MatKhau = @MatKhau  WHERE TenTaiKhoan = @TenTaiKhoan";
                        command = new SqlCommand(query, Con);

                        command.Parameters.AddWithValue("@TenTaiKhoan", TenTaiKhoan);
                        command.Parameters.AddWithValue("@MatKhau", txtDoiMatKhau.Text);

                        command.ExecuteNonQuery(); // thực hiện câu truy vấn

                        MessageBox.Show("Đã Đổi Mật Khẩu Tài Khoản (" + TenTaiKhoan + ") Thành Công.");
                    }
                    else
                    {
                        MessageBox.Show("Tài Khoản Không Tồn Tại", "Xác Nhân", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


                Con.Close();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // load dữ liệu lên combobox TenTaiKhoan
        private void LoadDataToComboBoxTenTaiKhoan()
        {
            string query = "SELECT TenTaiKhoan FROM TaiKhoan";

            using (SqlConnection connection = Connection.getInstance().getConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cbbTenTaiKhoan.Items.Add(reader.GetString(0));
                }
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }

        private void FormSuaThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDataToComboBoxTenTaiKhoan();
        }

        private void picBExitRed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMatKhauHienTai_TextChanged(object sender, EventArgs e)
        {
            txtMatKhauHienTai.UseSystemPasswordChar = true;
        }

        private void txtDoiMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtDoiMatKhau.UseSystemPasswordChar = true;
        }

        private void txtXacNhanLaiMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtXacNhanLaiMatKhau.UseSystemPasswordChar = true;
        }

        private bool isPasswordVisible = false; // Biến để theo dõi trạng thái hiển thị mật khẩu

        private void HienThiMatKhauHT_Click_1(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtMatKhauHienTai.UseSystemPasswordChar = false; // Hiện mật khẩu
            }
            else
            {
                txtMatKhauHienTai.UseSystemPasswordChar = true; // Ẩn mật khẩu
            }
        }

        private void DoiMatKhau_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtDoiMatKhau.UseSystemPasswordChar = false; // Hiện mật khẩu
            }
            else
            {
                txtDoiMatKhau.UseSystemPasswordChar = true; // Ẩn mật khẩu
            }
        }

        private void XacNhanMatKhau_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtXacNhanLaiMatKhau.UseSystemPasswordChar = false; // Hiện mật khẩu
            }
            else
            {
                txtXacNhanLaiMatKhau.UseSystemPasswordChar = true; // Ẩn mật khẩu
            }
        }

        private void txtMatKhauHienTai_TextChanged_1(object sender, EventArgs e)
        {
            txtMatKhauHienTai.UseSystemPasswordChar = true;
        }
    }
}
