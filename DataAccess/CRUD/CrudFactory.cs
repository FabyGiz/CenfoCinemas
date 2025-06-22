using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{

    //clase padre/madre abstracta de los crud
    //define como se hacen los crud en la arquitectura.
    public abstract class CrudFactory
    {

        protected SQLDao _sqlDao;


        //Definir los metodos que forman parte del contrato
        //C=create
        //R=retrieve
        //U=update
        //D=delete

        public abstract void Create(BaseDTO baseDTO);
        public abstract void Update(BaseDTO baseDTO);

        public abstract void Delete(BaseDTO baseDTO);

        public abstract T Retrieve <T>();
        public abstract T RetrieveById<T>(int id);

        public abstract List<T> RetrieveAll<T>();



    }
}
