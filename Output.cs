using System;
namespace rolling
{
    class Output
    {
        OriginD _input = new OriginD();
        BmpDrawer _drawer = new BmpDrawer(542,520,80,16, @"..\..\Resources\Diag.jpg");
        string _res = "\nИзмените курсовой угол! См. диаграмму качки.\n";
        internal void Input(double course, double psi, double teta) => _input.ReadInput(course, psi, teta);

        internal string Predict()
        {
            if (Is_ORBK()) return "\nС вероятностью в " + Convert.ToString(_input._percent * 100) + "%" + " возможен основной резонанс бортовой качки\n" + _res;
            if (Is_PRBK()) return "\nС вероятностью в " + Convert.ToString(_input._percent * 100) + "%" + " возможен параметрический резонанс бортовой качки\n" + _res;
            if (Is_ORKK()) return "\nС вероятностью в " + Convert.ToString(_input._percent * 100) + "%" + " возможен основной резонанс килевой качки\n" + _res; 
            return "Все ОК!";
        }

        private bool Is_ORBK() => _input._T > _input.TM && (_input._PV / _input._PSP > 0.8) && (_input._PV / _input._PSP < 1.2);
        private bool Is_PRBK() => _input._T > _input.TM && (_input._PV / _input._PSP > 1.85) && (_input._PV / _input._PSP < 2.15);
        private bool Is_ORKK() => _input._P > _input.PM && (_input._PV / _input._PKP > 0.8) && (_input._PV / _input._PKP < 1.2);
        internal System.Drawing.Image Draw()
        {
            double start = Handler.GetEnd("S", _input);
            double startP = Handler.GetEnd("PS", _input);
            double startK = Handler.GetEnd("K", _input);
            double sideWidth = Handler.GetWidth("S", _input);
            double pSideWidth = Handler.GetWidth("PS", _input);
            double keelWidt = Handler.GetWidth("K", _input);
            return _drawer.UpdImg(start, startP, startK, sideWidth, pSideWidth, keelWidt, _input);
        }
    }
}
