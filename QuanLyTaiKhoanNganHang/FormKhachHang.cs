using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiKhoanNganHang
{
    public partial class FormKhachHang : Form
    {
        private List<Button> buttons; // Danh sách các Button
        private Button selectedButton; // Button đang được chọn
        private void InitializeButtons()
        {
            // Khởi tạo danh sách các Button
            buttons = new List<Button>
            {
                btnHome,
                btnChuyenKhoan,
                btnKiemTraSoDu,
                btnGiaoDich,

                // Thêm các Button khác vào danh sách
            };

            // Đặt sự kiện Click cho các Button
            foreach (Button button in buttons)
            {
                button.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Kiểm tra nếu Button đã được chọn trước đó
            if (clickedButton == selectedButton)
            {
                // Không làm gì nếu Button đã được chọn trước đó
                return;
            }

            // Đặt lại màu chữ của Button trước đó về màu ban đầu (nếu có)
            if (selectedButton != null)
            {
                selectedButton.ForeColor = SystemColors.ButtonHighlight;
            }

            // Thay đổi màu chữ của Button được nhấn thành màu mới
            clickedButton.ForeColor = Color.Black;

            // Lưu Button được nhấn vào selectedButton
            selectedButton = clickedButton;
        }

        public FormKhachHang()
        {
            InitializeComponent();
            InitializeButtons();  // để thay đổi màu sác của chữ trong button khi button đó được ấn vào.

            // Khởi tạo timer
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000; // 1 giây
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }


        // Phương thức để cập nhật giờ
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Cập nhật và hiển thị giờ mới
            lblDataTimeNow.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            // Thiết lập Form hiện tại thành MdiContainer
            this.IsMdiContainer = true;

            FormHome formHome = new FormHome();
            formHome.MdiParent = this;
            formHome.Show();
        }

        private void btnChuyenKhoan_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FormChuyenTien formChuyenTien = new FormChuyenTien();
            formChuyenTien.MdiParent = this;
            formChuyenTien.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FormHome formHome = new FormHome();
            formHome.MdiParent = this;
            formHome.Show();
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FormGiaoDich formGiaoDich = new FormGiaoDich();
            formGiaoDich.MdiParent = this;
            formGiaoDich.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn Có Chắc Chắn Muốn Đăng Xuất.",
                "Xác Nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                FormDangNhap formDangNhap = new FormDangNhap();
                formDangNhap.Show();
            }
        }

        private void đăngNhậpTàiKhoảnKhácToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn Có Chắc Chắn Muốn Đăng Nhập Tài Khoản Khác.",
                "Xác Nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                FormDangNhap formDangNhap = new FormDangNhap();
                formDangNhap.Show();
            }
        }

        public void xemChiTiếtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FormThongTinGiaoDich formThongTinGiaoDich = new FormThongTinGiaoDich();
            formThongTinGiaoDich.MdiParent = this;
            formThongTinGiaoDich.Show();
        }

        private void btnSuaThongTinTaiKhoan_Click(object sender, EventArgs e)
        {
            FormSuaThongTinTaiKhoan formSuaThongTinTaiKhoan = new FormSuaThongTinTaiKhoan();
            formSuaThongTinTaiKhoan.MdiParent = this;
            formSuaThongTinTaiKhoan.Show();
        }

        private void btnKiemTraSoDu_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FormKiemTraSoDu formKiemTraSoDu = new FormKiemTraSoDu();
            formKiemTraSoDu.MdiParent = this;
            formKiemTraSoDu.Show();
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FormThongTinGiaoDich formThongTinGiaoDich = new FormThongTinGiaoDich();
            formThongTinGiaoDich.MdiParent = this;
            formThongTinGiaoDich.Show();
        }

        private void hướngDẫnDùngAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMayTinh formMayTinh = new FormMayTinh();
            formMayTinh.Show();
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            this.Close();
            Close();
            // đồng hồ dừng khi form bị đóng.
            timer1.Stop();
        }

    }
}

