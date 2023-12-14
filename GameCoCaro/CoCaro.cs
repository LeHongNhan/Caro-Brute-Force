using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCoCaro
{
    public enum KetThuc
    {
        HoaCo,
        Player1,
        Player2,
        Com
    }
    public class CoCaro
    {
        public static Pen pen;
        public static SolidBrush sbWhite;
        public static SolidBrush sbBlack;
        private OCo[,] _mangOCo;
        private BanCo _BanCo;
        private Stack<OCo> stkCacNuocDaDi;
        private Stack<OCo> stkCacNuocDaUndo;
        private int _LuotDi;
        private bool _sansang;
        private KetThuc _KetThuc;
        public bool Sansang { get => _sansang; set => _sansang = value; }
        public int CheDoChoi { get => _CheDoChoi; set => _CheDoChoi = value; }

        private int _CheDoChoi;

        public CoCaro() 
        {
            pen = new Pen(Color.Red);
            sbWhite = new SolidBrush(Color.White);
            sbBlack = new SolidBrush(Color.Black);
            _BanCo = new BanCo(20, 20);
            _mangOCo = new OCo[_BanCo.SoDong, _BanCo.SoCot];
            stkCacNuocDaDi = new Stack<OCo>();
            stkCacNuocDaUndo = new Stack<OCo>();
            _LuotDi = 1;
        }
        public void veBanCo(Graphics g) 
        {
            _BanCo.veBanCo(g);
        }
        public void KhoiTaoMangOCo()
        {
            for (int i = 0; i < _BanCo.SoDong; i++)
            {
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    _mangOCo[i, j] = new OCo(i, j, new Point(j*OCo._ChieuRong, i*OCo._ChieuCao), 0);
                }
            }
        }
        public bool danhCo(int mouseX, int mouseY, Graphics g) 
        {
            if (mouseX % OCo._ChieuRong == 0 || mouseY%OCo._ChieuCao == 0)
            {
                return false;
            }
            int cot = mouseX / OCo._ChieuRong;
            int dong = mouseY / OCo._ChieuCao;
            if (_mangOCo[dong, cot].SoHuu != 0)
            {
                return false;
            }
            switch(_LuotDi)
            {
                case 1:
                    {
                        _mangOCo[dong, cot].SoHuu = 1;
                        _BanCo.veQuanCo(g, _mangOCo[dong, cot].ViTri, sbBlack);
                        _LuotDi = 2;
                        break;
                    }
                case 2:
                    {
                        _mangOCo[dong, cot].SoHuu = 2;
                        _BanCo.veQuanCo(g, _mangOCo[dong, cot].ViTri, sbWhite);
                        _LuotDi = 1;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Lỗi");
                        break;
                    }
            }



            stkCacNuocDaDi.Push(_mangOCo[dong, cot]);
            stkCacNuocDaUndo = new Stack<OCo>();
            return true;
        }
        public void veLaiQuanCo(Graphics g)
        {
            foreach(OCo oCo in stkCacNuocDaDi) 
            {
                if (oCo.SoHuu == 1)
                {
                    _BanCo.veQuanCo(g, oCo.ViTri, sbBlack);
                }
                else if (oCo.SoHuu == 2)
                {
                    _BanCo.veQuanCo(g, oCo.ViTri, sbWhite);
                }
            }
        }
        public void startPVP(Graphics g)
        {
            _CheDoChoi = 1;
            stkCacNuocDaDi = new Stack<OCo>();
            stkCacNuocDaUndo = new Stack<OCo>();
            _sansang = true;
            stkCacNuocDaDi = new Stack<OCo>();
            KhoiTaoMangOCo();
            veBanCo(g);

        }
        public void startPVE(Graphics g)
        {
            _CheDoChoi = 2;
            stkCacNuocDaDi = new Stack<OCo>();
            stkCacNuocDaUndo = new Stack<OCo>();
            _sansang = true;
            stkCacNuocDaDi = new Stack<OCo>();
            KhoiTaoMangOCo();
            veBanCo(g);
            khoiDongCom(g);

        }
        public void undo(Graphics g)
        {
            if (stkCacNuocDaDi.Count != 0)
            {                
                OCo oco = stkCacNuocDaDi.Pop();
                stkCacNuocDaUndo.Push(new OCo ( oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu ));
                _mangOCo[oco.Dong, oco.Cot].SoHuu = 0;
            }
            veBanCo(g);
            veLaiQuanCo(g);
            if(_LuotDi == 1)
            {
                _LuotDi = 2;
            }
            else
            {
                _LuotDi = 1;
            }
        }
        public void redo(Graphics g)
        {
            if (stkCacNuocDaUndo.Count != 0)
            {
                OCo oco = stkCacNuocDaUndo.Pop();
                stkCacNuocDaDi.Push(new OCo(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                _mangOCo[oco.Dong, oco.Cot].SoHuu = oco.SoHuu;
                _BanCo.veQuanCo(g,oco.ViTri,oco.SoHuu==1?sbBlack:sbWhite);
            }
            veBanCo(g);
            veLaiQuanCo(g);
            if (_LuotDi == 1)
            {
                _LuotDi = 2;
            }
            else
            {
                _LuotDi = 1;
            }
        }
        //keet thuc
        public void ketThucTroChoi  ()
        {
            switch(_KetThuc)
            {
                case KetThuc.HoaCo:
                    {
                        MessageBox.Show("Hòa cờ!");
                        break;
                    }
                case KetThuc.Player1:
                    {
                        MessageBox.Show("Người chơi 1 thắng!");
                        break;
                    }
                case KetThuc.Player2:
                    {
                        MessageBox.Show("Người chơi 2 thắng!");
                        break;
                    }
                case KetThuc.Com:
                    {
                        MessageBox.Show("Máy thắng!");
                        break;
                    }
            }
            _sansang = false;
        }
        //Duyệt
        #region kiem tra
        private bool duyetDoc(int currDong, int currCot, int currSoHuu)
        {
            if(currDong > _BanCo.SoDong - 5)
            {
                return false;
            }
            int dem;
            for (dem = 1; dem < 5; dem++)
            {
                if (_mangOCo[currDong + dem, currCot].SoHuu != currSoHuu)
                {
                    return false;
                }
            }
            if (currDong == 0 || currDong + dem == _BanCo.SoDong)
            {
                return true;
            }
            if (_mangOCo[currDong - 1, currCot].SoHuu == 0 || _mangOCo[currDong + dem, currCot].SoHuu == 0)
            {
                return true;
            }
            return false;
        }
        private bool duyetNgang(int currDong, int currCot, int currSoHuu)
        {
            if (currDong > _BanCo.SoDong - 5)
            {
                return false;
            }
            int dem;
            for (dem = 1; dem < 5; dem++)
            {
                if (_mangOCo[currDong, currCot + dem].SoHuu != currSoHuu)
                {
                    return false;
                }
            }
            if (currCot == 0 || currCot + dem == _BanCo.SoCot)
            {
                return true;
            }
            if (_mangOCo[currDong , currCot - 1].SoHuu == 0 || _mangOCo[currDong , currCot + dem].SoHuu == 0)
            {
                return true;
            }
            return false;
        }
        private bool duyetCheoXuoi(int currDong, int currCot, int currSoHuu)
        {
            if (currDong > _BanCo.SoDong - 5 || currCot > _BanCo.SoCot - 5)
            {
                return false;
            }
            int dem;
            for (dem = 1; dem < 5; dem++)
            {
                if (_mangOCo[currDong + dem, currCot + dem].SoHuu != currSoHuu)
                {
                    return false;
                }
            }
            if (currCot == 0 || currDong + dem == _BanCo.SoDong || currCot == 0 || currCot + dem == _BanCo.SoCot)
            {
                return true;
            }
            if (_mangOCo[currDong - 1, currCot - 1].SoHuu == 0 || _mangOCo[currDong + dem, currCot + dem].SoHuu == 0)
            {
                return true;
            }
            return false;
        }
        private bool duyetCheoNguoc(int currDong, int currCot, int currSoHuu)
        {
            if (currDong < 4 || currCot >  _BanCo.SoCot - 5)
            {
                return false;
            }
            int dem;
            for (dem = 1; dem < 5; dem++)
            {
                if (_mangOCo[currDong - dem, currCot + dem].SoHuu != currSoHuu)
                {
                    return false;
                }
            }
            if (currDong == 4 || currDong == _BanCo.SoDong - 1 || currCot == 0 || currCot == _BanCo.SoCot - 1)
            {
                return true;
            }
            if (_mangOCo[currDong + 1, currCot - 1].SoHuu == 0 || _mangOCo[currDong - dem, currCot + dem].SoHuu == 0)
            {
                return true;
            }
            return false;
        }
        public bool kiemTraThang()
        {
            if (stkCacNuocDaDi.Count == _BanCo.SoCot*_BanCo.SoDong)
            {
                _KetThuc = KetThuc.HoaCo;
                return true;
            }
            foreach (OCo oCo in stkCacNuocDaDi)
            {
                if (duyetDoc(oCo.Dong, oCo.Cot, oCo.SoHuu) || duyetNgang(oCo.Dong, oCo.Cot, oCo.SoHuu) || duyetCheoXuoi(oCo.Dong, oCo.Cot, oCo.SoHuu) || duyetCheoNguoc(oCo.Dong, oCo.Cot, oCo.SoHuu))
                {
                    _KetThuc = oCo.SoHuu == 1 ? KetThuc.Player1 : KetThuc.Player2;
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region AI
        private long[] mangDiemTanCong = new long[7] {0, 3, 24, 192, 1536, 12288, 98304};
        private long[] mangDiemPhongNgu = new long[7] { 0, 1, 9, 81, 729, 6561, 59049 };
        public void khoiDongCom(Graphics g) 
        {
            if (stkCacNuocDaDi.Count == 0)
            {
                danhCo(_BanCo.SoDong / 2 * OCo._ChieuCao + 1, _BanCo.SoCot/2 * OCo._ChieuRong + 1, g);

            }
            else
            {
                OCo oco = TimKiemNuocDi();
                danhCo(oco.ViTri.X + 1, oco.ViTri.Y + 1, g);
            }
        }

        private OCo TimKiemNuocDi()
        {
            OCo OCoResult = new OCo();
            long diemMax = 0;
            for (int i = 0; i < _BanCo.SoDong; i++)
            {
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    if (_mangOCo[i, j].SoHuu == 0)
                    {
                        long diemTanCong = diemTC_DuyetNgang(i, j) + diemTC_DuyetDoc(i, j) + diemTC_DuyetCheoNguoc(i, j) + diemTC_DuyetCheoXuoi(i, j);
                        long diemPhongNgu = DiemPN_DuyetNgang(i, j) + DiemPN_DuyetDoc(i, j) + DiemPN_DuyetCheoNguoc(i, j) + DiemPN_DuyetCheoXuoi(i, j);
                        long diemTam = diemTanCong > diemPhongNgu ? diemTanCong : diemPhongNgu;
                        if (diemMax < diemTam)
                        {
                            diemMax = diemTam;
                            OCoResult = new OCo(_mangOCo[i, j].Dong, _mangOCo[i, j].Cot, _mangOCo[i, j].ViTri, _mangOCo[i,j].SoHuu);
                        }
                    }
                }
            }
            return OCoResult;
        }
        #region TanCong
        private long diemTC_DuyetNgang(int currDong, int currCot)
        {
            long diemTong = 0;
            long diemTC = 0;
            int soQuanTa = 0;
            int soQUanDich = 0;
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot; dem++)
            {
                if (_mangOCo[currDong , currCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_mangOCo[currDong, currCot + dem].SoHuu == 2)
                {
                    soQUanDich++;
                    break;
                }
                else
                {
                    break;
                }
            }
            for (int dem = 1; dem < 6 && currCot - dem >= 0; dem++)
            {
                if (_mangOCo[currDong, currCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_mangOCo[currDong, currCot - dem].SoHuu == 2)
                {
                    soQUanDich++;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (soQUanDich == 2)
            {
                return 0;
            }
            diemTong -= mangDiemPhongNgu[soQUanDich + 1];
            diemTC += mangDiemTanCong[soQuanTa];
            diemTong += diemTC;
            return diemTong;

        }
        private long diemTC_DuyetDoc(int currDong, int currCot)
        {
            long diemTong = 0;
            long diemTC = 0;
            int soQuanTa = 0;
            int soQUanDich = 0;
            for (int dem = 1; dem < 6 && currDong + dem < _BanCo.SoDong; dem++)
            {
                if (_mangOCo[currDong + dem, currCot].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_mangOCo[currDong + dem, currCot].SoHuu == 2)
                {
                    soQUanDich++;
                    break;
                }
                else
                {
                    break;
                }
            }
            for (int dem = 1; dem < 6 && currDong - dem >= 0; dem++)
            {
                if (_mangOCo[currDong - dem, currCot].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_mangOCo[currDong - dem, currCot].SoHuu == 2)
                {
                    soQUanDich++;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (soQUanDich == 2)
            {
                return 0;
            }
            diemTong -= mangDiemPhongNgu[soQUanDich + 1];
            diemTC += mangDiemTanCong[soQuanTa];
            diemTong += diemTC;
            return diemTong;
        }
        private long diemTC_DuyetCheoNguoc(int currDong, int currCot)
        {
            long diemTong = 0;
            long diemTC = 0;
            int soQuanTa = 0;
            int soQUanDich = 0;
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong - dem >= 0; dem++)
            {
                if (_mangOCo[currDong - dem, currCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_mangOCo[currDong - dem, currCot + dem].SoHuu == 2)
                {
                    soQUanDich++;
                    break;
                }
                else
                {
                    break;
                }
            }
            for (int dem = 1; dem < 6 && currCot - dem >= 0 && currDong + dem < _BanCo.SoDong; dem++)
            {
                if (_mangOCo[currDong + dem, currCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_mangOCo[currDong + dem, currCot - dem].SoHuu == 2)
                {
                    soQUanDich++;
                    break;
                }
                else
                {
                    break;
                }
                if (soQUanDich == 2)
                {
                    return 0;
                }
            }
            if (soQUanDich == 2)
            {
                return 0;
            }
            diemTong -= mangDiemPhongNgu[soQUanDich + 1];
            diemTC += mangDiemTanCong[soQuanTa];
            diemTong += diemTC;
            return diemTong;
        }
        private long diemTC_DuyetCheoXuoi(int currDong, int currCot)
        {
            long diemTong = 0;
            long diemTC = 0;
            int soQuanTa = 0;
            int soQUanDich = 0;
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong - dem >= 0; dem++)
            {
                if (_mangOCo[currDong - dem, currCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_mangOCo[currDong - dem, currCot + dem].SoHuu == 2)
                {
                    soQUanDich++;
                    break;
                }
                else
                {
                    break;
                }
            }
            for (int dem = 1; dem < 6 && currCot - dem >= 0 && currDong + dem < _BanCo.SoDong; dem++)
            {
                if (_mangOCo[currDong + dem, currCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                }
                else if (_mangOCo[currDong + dem, currCot - dem].SoHuu == 2)
                {
                    soQUanDich++;
                    break;
                }
                else
                {
                    break;
                }
                if (soQUanDich == 2)
                {
                    return 0;
                }
            }
            diemTong -= mangDiemPhongNgu[soQUanDich + 1];
            diemTC += mangDiemTanCong[soQuanTa];
            diemTong += diemTC;
            return diemTong;
        }
        #endregion
        #region Phong Ngu
        private long DiemPN_DuyetNgang(int currDong, int currCot)
        {
            long diemTong = 0;
            int soQuanTa = 0;
            int soQUanDich = 0;
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot; dem++)
            {
                if (_mangOCo[currDong, currCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_mangOCo[currDong, currCot + dem].SoHuu == 2)
                {
                    soQUanDich++;
                }
                else
                {
                    break;
                }
            }
            for (int dem = 1; dem < 6 && currCot - dem >= 0; dem++)
            {
                if (_mangOCo[currDong, currCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_mangOCo[currDong, currCot - dem].SoHuu == 2)
                {
                    soQUanDich++;
                }
                else
                {
                    break;
                }
            }
            if (soQuanTa == 2)
            {
                return 0;
            }
            diemTong += mangDiemPhongNgu[soQuanTa];
            return diemTong;
        }
        private long DiemPN_DuyetDoc(int currDong, int currCot)
        {
            long diemTong = 0;
            int soQuanTa = 0;
            int soQUanDich = 0;
            for (int dem = 1; dem < 6 && currDong + dem < _BanCo.SoDong; dem++)
            {
                if (_mangOCo[currDong + dem, currCot].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_mangOCo[currDong + dem, currCot].SoHuu == 2)
                {
                    soQUanDich++;
                }
                else
                {
                    break;
                }
            }
            for (int dem = 1; dem < 6 && currDong - dem >= 0; dem++)
            {
                if (_mangOCo[currDong - dem, currCot].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_mangOCo[currDong - dem, currCot].SoHuu == 2)
                {
                    soQUanDich++;
                }
                else
                {
                    break;
                }
            }
            if (soQuanTa == 2)
            {
                return 0;
            }
            diemTong += mangDiemPhongNgu[soQuanTa];
            return diemTong;
        }
        private long DiemPN_DuyetCheoNguoc(int currDong, int currCot)
        {
            long diemTong = 0;
            int soQuanTa = 0;
            int soQUanDich = 0;
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong - dem >= 0; dem++)
            {
                if (_mangOCo[currDong - dem, currCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_mangOCo[currDong - dem, currCot + dem].SoHuu == 2)
                {
                    soQUanDich++;
                }
                else
                {
                    break;
                }
            }
            for (int dem = 1; dem < 6 && currCot - dem >= 0 && currDong + dem < _BanCo.SoDong; dem++)
            {
                if (_mangOCo[currDong + dem, currCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_mangOCo[currDong + dem, currCot - dem].SoHuu == 2)
                {
                    soQUanDich++;
                }
                else
                {
                    break;
                }
            }
            if (soQuanTa == 2)
            {
                return 0;
            }
            diemTong += mangDiemPhongNgu[soQuanTa];
            return diemTong;
        }
        private long DiemPN_DuyetCheoXuoi(int currDong, int currCot)
        {
            long diemTong = 0;
            long diemTC = 0;
            int soQuanTa = 0;
            int soQUanDich = 0;
            for (int dem = 1; dem < 6 && currCot + dem < _BanCo.SoCot && currDong - dem >= 0; dem++)
            {
                if (_mangOCo[currDong - dem, currCot + dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_mangOCo[currDong - dem, currCot + dem].SoHuu == 2)
                {
                    soQUanDich++;
                }
                else
                {
                    break;
                }
            }
            for (int dem = 1; dem < 6 && currCot - dem >= 0 && currDong - dem >= 0; dem++)
            {
                if (_mangOCo[currDong - dem, currCot - dem].SoHuu == 1)
                {
                    soQuanTa++;
                    break;
                }
                else if (_mangOCo[currDong - dem, currCot - dem].SoHuu == 2)
                {
                    soQUanDich++;
                }
                else
                {
                    break;
                }
            }
            if (soQuanTa == 2)
            {
                return 0;
            }
            diemTong += mangDiemPhongNgu[soQuanTa];
            return diemTong;
        }
        #endregion
        #endregion
    }
}
