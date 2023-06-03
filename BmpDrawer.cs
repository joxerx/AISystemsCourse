using System;
using System.Drawing;

namespace rolling
{
    internal class BmpDrawer
    {
        private int _x0;
        private int _y0;
        private int _y1;
        private int _oneKnot;
        private string _diagPath;
        public BmpDrawer(int x0, int y0, int y1, int oneKnot, string path)
        {
            _x0 = x0;
            _y0 = y0;
            _y1 = y1;
            _oneKnot = oneKnot;
            _diagPath = path;
        }
        public Bitmap UpdImg(double startSide, double startPSide, double startKeel, double sideWidth, double pSideWidth, double keelWidth, OriginD inpData)
        {
            float angle = (float)((float)Math.PI * (float)(180 - (float)inpData._course) / 180.0);
            Bitmap bmp = new Bitmap(_diagPath);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Gold)), (float)(_x0 - startSide * _oneKnot) + 4, _y1, (float)(sideWidth * _oneKnot), _y0);
                gr.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)), (float)(_x0 - startPSide * _oneKnot) + 4, _y1, (float)(pSideWidth * _oneKnot), _y0);
                gr.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.DeepSkyBlue)), (float)(_x0 - startKeel * _oneKnot) + 4, _y1, (float)(keelWidth * _oneKnot), _y0);
                float x = (float)((inpData.VK * _oneKnot) * Math.Cos(angle) + _x0);
                float y = (float)(_y0-(inpData.VK * _oneKnot) * Math.Sin(angle));
                gr.FillEllipse(new SolidBrush(Color.Red), x, y, 10, 10);
            }
            return bmp;
        }
    }
}