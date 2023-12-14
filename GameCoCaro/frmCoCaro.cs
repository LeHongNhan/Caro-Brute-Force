using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCoCaro
{
    public partial class frmCoCaro : Form
    {
        private CoCaro coCaro;
        private Graphics grp;
        public frmCoCaro()
        {

            coCaro = new CoCaro();
            coCaro.KhoiTaoMangOCo();
            InitializeComponent();
            grp = pnBanCo.CreateGraphics();
        }
        string thongTin = "Đồ án trí tuệ nhân tạo\nThành viên:\nLê Hồng Nhân\nHuỳnh Minh Khang\nNguyễn Cát Tường";
        int index = 0;
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadThongTin.Start();
            btnChoiVoiNguoi.Click += new EventHandler(pVPToolStripMenuItem_Click);
        }

        private void loadThongTin_Tick(object sender, EventArgs e)
        {
            label1.Text += thongTin[index];
            index++;
            if (index == thongTin.Length)
            {
                loadThongTin.Stop();
                //label1.Text = string.Empty;
                //index = 0;
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Thoát game?", "Hỏi thoát", MessageBoxButtons.YesNo);
            if (ret == DialogResult.Yes) { Close(); }
        }

        private void pnBanCo_Paint(object sender, PaintEventArgs e)
        {
            coCaro.veBanCo(grp);
            coCaro.veLaiQuanCo(grp);
        }

        private void pnBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (coCaro.Sansang == false)
            {
                return;
            }
            coCaro.danhCo(e.X, e.Y, grp);
            if (coCaro.kiemTraThang())
            {
                coCaro.ketThucTroChoi();
            }
            if (coCaro.CheDoChoi == 2)
            {
                coCaro.khoiDongCom(grp);
                if (coCaro.kiemTraThang())
                {
                    coCaro.ketThucTroChoi();
                }
            }
        }

        private void pVPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grp.Clear(pnBanCo.BackColor);
            coCaro.startPVP(grp);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grp.Clear(pnBanCo.BackColor);
            coCaro.undo(grp);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grp.Clear(pnBanCo.BackColor);
            coCaro.redo(grp);
        }

        private void ChoiMoi_Click(object sender, EventArgs e)
        {
            grp.Clear(pnBanCo.BackColor);
            coCaro.startPVP(grp);
        }

        private void btnChoiVoimay_Click(object sender, EventArgs e)
        {
            grp.Clear(pnBanCo.BackColor);
            coCaro.startPVE(grp);
        }
    }
}
