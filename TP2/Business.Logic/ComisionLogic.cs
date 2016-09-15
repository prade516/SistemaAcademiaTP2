using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
   public class ComisionLogic
    {
        private Data.Database.ComisionesD _Comision;

        public Data.Database.ComisionesD Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }
        public ComisionLogic()
        {
            Comision= new Data.Database.ComisionesD();
        }
        public List<Comisiones> GetAll()
        {
            return Comision.GetAll();
        }
        public List<Business.Entities.Comisiones> GetByComision(string desc_comision)
        {
            return Comision.GetByComision(desc_comision);
        }
        public void Delete(Business.Entities.Comisiones id)
        {
            Comision.Save(id);
        }
        public void Save(Business.Entities.Comisiones usur)
        {
            Comision.Save(usur);
        }
        public void Update(Business.Entities.Comisiones usur)
        {
            Comision.Save(usur);
        }
    }
}
