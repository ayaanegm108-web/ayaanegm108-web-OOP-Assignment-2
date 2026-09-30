using System;
using System.Collections.Generic;
using System.Text;

namespace src.SrpLab.Ward
{
    internal class BasicData
    {

        protected readonly Dictionary<int, string> _bedPatient = new();
        protected readonly Dictionary<int, int> _vitalsScore = new();
        protected readonly List<string> _pagerLog = new();
    }
}
