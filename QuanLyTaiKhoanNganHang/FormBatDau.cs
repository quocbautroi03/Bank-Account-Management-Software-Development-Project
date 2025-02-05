﻿using System;
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
    public partial class FormBatDau : Form
    {
        public FormBatDau()
        {
            InitializeComponent();
        }

        private void FormBatDau_Load(object sender, EventArgs e)
        {
            timer1.Start();

            // Khởi tạo và cấu hình Timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = delay;
            timer.Tick += Timer_Tick;

            // Bắt đầu hiệu ứng chữ chạy
            timer.Start();
        }

        int startpos = 0; // vị trí bắt đầu thời gian là 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 1;
            MyprogressBar.Value = startpos;
            if (MyprogressBar.Value == 70)
            {
                MyprogressBar.Value = 0;
                timer1.Stop();
                this.Close();
                FormKhachHang formKhachHang = new FormKhachHang();
                formKhachHang.Show();
            }
        }

        // thêm dòng chữ chạy
        private string[] texts = new string[]
        {
            "Đang kết nối tới database ...",
            "Kết nối các form ...",
            "Đang mở hệ thống ..."
        };

        private int currentIndex = 0;
        private System.Windows.Forms.Timer timer;
        private int delay = 2000; // Khoảng thời gian (milisecond) giữa mỗi dòng chữ

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Cập nhật nội dung của Label với dòng chữ hiện tại
            lblDongChuChay.Text = texts[currentIndex];

            // Tăng chỉ số currentIndex để chuyển sang dòng chữ tiếp theo
            currentIndex++;

            // Nếu currentIndex vượt quá chỉ số của mảng texts, đặt lại currentIndex về 0
            if (currentIndex >= texts.Length)
                currentIndex = 0;
        }
    }
}
