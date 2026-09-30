using System;
using System.Collections.Generic;
using System.Text;

namespace src.SrpLab.Kitchen
{
    internal class Selector
    {
        public string select(bool hasAllergens, int etaMinutes)
        {
            return hasAllergens ? "LANE-ALLERGY" : etaMinutes > 20 ? "LANE-SLOW" : "LANE-FAST";
        }
    }
}
