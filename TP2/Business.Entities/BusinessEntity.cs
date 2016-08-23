using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {
        private int _ID; 
        private Estados _Estado;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public Estados Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public BusinessEntity()
        {
            this.Estado = Estados.Nuevo;
        }
        public enum Estados
        { 
            Eliminar,
            Nuevo,
            Modificar,
            No_Modificar
        }
    }
}
