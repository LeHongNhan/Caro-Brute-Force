using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameCoCaro
{
    public class BanCo
    {
        private int _SoDong;
        private int _SoCot;
        public int SoDong { get => _SoDong; set => _SoDong = value; }
        public int SoCot { get => _SoCot; set => _SoCot = value; }
        public BanCo()
        {
            SoDong = 0;
            SoCot = 0;
        }
        public BanCo(int SoDong, int SoCot)
        {
            this.SoDong = SoDong;
            this.SoCot = SoCot;
        }


        public void veBanCo(Graphics g)
        {
            for (int i = 0; i <= SoCot; i++) 
            {
                g.DrawLine(CoCaro.pen, i*OCo._ChieuRong, 0, i*OCo._ChieuRong, SoDong*OCo._ChieuCao);
            }
            for (int j = 0; j <= SoCot; j++)
            {
                g.DrawLine(CoCaro.pen, 0, j * OCo._ChieuCao, SoCot*OCo._ChieuRong, j*OCo._ChieuCao);
            }

        }
        public void veQuanCo(Graphics g, Point p, SolidBrush sb)
        {
            g.FillEllipse(sb, p.X, p.Y, OCo._ChieuRong, OCo._ChieuCao);
        }
        public void xoaQuanCo( Graphics g, Point p, SolidBrush sb)
        {
            g.FillRectangle(sb, p.X, p.Y, OCo._ChieuRong, OCo._ChieuCao);
        }
    }
}
