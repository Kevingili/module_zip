using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BlZip
    {
        public static void InsertFichiersZip(BO.FichiersZip zip)
        {
            DAL.DacInsert.InsertFichierZip(zip);
        }
        public static bool ExistZip(string nomzip)
        {
            return DAL.DacInsert.ExistZip(nomzip);
        }
    }
}
