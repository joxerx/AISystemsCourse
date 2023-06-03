using System;

namespace rolling
{
    public static class Handler
    {
        public static double GetEnd(string pitchType, OriginD know)
        {
            if (pitchType == "S") return know._VV - know.LV / (1.2 * know._PSP);
            else if (pitchType == "PS") return know._VV - know.LV / (2.15 * know._PSP);
            else if (pitchType == "K") return know._VV - know.LV / (1.2 * know._PKP);
            else return double.MinValue;
        }
        public static double GetWidth(string pitchType, OriginD knowledge)
        {
            if (pitchType == "S") return knowledge._VV - knowledge.LV / (1.2 * knowledge._PSP) - (knowledge._VV - knowledge.LV / (0.8 * knowledge._PSP));
            else if (pitchType == "PS") return knowledge._VV - knowledge.LV / (2.15 * knowledge._PSP) - (knowledge._VV - knowledge.LV / (1.85 * knowledge._PSP));
            else if (pitchType == "K") return knowledge._VV - knowledge.LV / (1.2 * knowledge._PKP) - (knowledge._VV - knowledge.LV / (0.8 * knowledge._PKP));
            return double.MinValue;
        }
    }
}
