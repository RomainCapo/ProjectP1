using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur.classes.dames
{
    class Pion
    {
        bool bIsDames = false;
        readonly bool bIsWhite;

        public Pion(bool _isWhite)
        {
            bIsWhite = _isWhite;
        }

        public bool GetColor()
        {
            return bIsWhite;
        }

        public bool GetState()
        {
            return bIsDames;
        }

        public void Upgrade()
        {
            bIsDames = true;
        }
    }
}
