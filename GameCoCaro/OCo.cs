using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoCaro
{
    public class OCo
    {
        public const int _ChieuRong = 25;
        public const int _ChieuCao = 25;
        private int _Dong;
        public int Dong { get => _Dong; set => _Dong = value; }
        private int _Cot;
        public int Cot { get => _Cot; set => _Cot = value; }
        private Point _viTri;
        public Point ViTri { get => _viTri; set => _viTri = value; }
        private int _SoHuu;
        public int SoHuu { get => _SoHuu; set => _SoHuu = value; }
        public OCo() { }
        public OCo(int dong, int cot,Point viTri, int soHuu)
        {
            Dong = dong;
            Cot = cot;
            ViTri = viTri;
            SoHuu = soHuu;
        }
    }
}
