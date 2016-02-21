using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class FichiersZip
    {
        private int idZip;
        private int idCast;      
        private string nomZip; 

        public int IdZip
        {
            get { return idZip; }
            set { idZip = value; }
        }


        public string NomZip
        {
            get { return nomZip;}
            set { nomZip = value; }

        }

        public int IdCast
        {
            get { return idCast; }
            set { idCast = value; }
        }
    }
}
