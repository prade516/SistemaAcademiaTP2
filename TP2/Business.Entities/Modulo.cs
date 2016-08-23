using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Modulo
    {
        private int _Id_Modulo;
        private string _Desc_Modulo;
        private string _Ejecutar;
        public int Id_Modulo
        {
            get { return _Id_Modulo; }
            set { _Id_Modulo = value; }
        }
        public string Desc_Modulo
        {
            get { return _Desc_Modulo; }
            set { _Desc_Modulo = value; }
        }
        public string Ejecutar
        {
            get { return _Ejecutar; }
            set { _Ejecutar = value; }
        }
    }
}
