using System;

namespace rolling
{
    public class OriginD
    {
        public double LK = 30;
        public double WK = 7;
        public double DS = 2.5;
        public double MH = 0.45;
        public double VK = 10;
        public double LV = 30;
        public double TM = 15;
        public double PM = 3;
        public const double PE = 0.73;
        public const double PHE = 0.78;
        public const double PHnotE = 0.01;
        public const double MDHE1 = 0.85;
        public const double MDHE2 = 0.87;
        public const double BayesRes = PHE * PE + PHnotE * (1 - PE) + (1 - PHE) * PE + PHE * (1 - PE); 
        public const double ShortliffRes = MDHE1 + MDHE2 * (1 - MDHE1);                                
        public double _percent = Math.Round((BayesRes + ShortliffRes) / 2, 4);                         
        
        public double _VV;   
        public double _PV;   
        public double _PSP;  
        public double _PKP;  

        public double _T;    
        public double _P;    
        public double _course;

        public OriginD()
        {
            _VV = 1.25 * Math.Pow(LV, 0.5);
            _PSP = 0.8 * WK / Math.Pow(MH, 0.5);
            _PKP = 2.5 * Math.Pow(DS, 0.5);
        }

        public void ReadInput(double course, double psi, double teta)
        {
            _T = teta;
            _P = psi;
            _course = course;
            _PV = LV / (_VV - VK * Math.Cos(Math.PI * _course / 180.0));
        }

    }
}