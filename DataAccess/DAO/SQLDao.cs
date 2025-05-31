using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{

    /*
     *Clase u objeto que se encarga de la comunicacion con la base de datos
     *Solo ejecuta Store Procedues
     *
     *Esta clase implementa el patron del Singleton
     *Para asegurar la existencia de una unica instancia de este objeto
     *
     */
    public class SQLDao
    {
        //Paso 1: Crear una instancia privada de la misma clase
        private static SQLDao _instance;

        private string _connectionString;

        //Paso 2: Redefinir el constructor default y convertirlo en privado
        private SQLDao()
        {
            _connectionString = string.Empty;
        }
        
        //Paso 3: Definir el metodo que expone la instancia
        public static SQLDao GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SQLDao();
            }
            return _instance;
        }

        //Metodo para la ejecucion de SP (Store Procedure) sin retorno
        public void ExecuteProcedure(SQLOperation operation)
        {

        }

        //Metodo para la ejecucion de SP con retorno de data
        public List<Dictionary<string,object>> ExecuteQueryProcedure(SQLOperation operation)
        {

            //Conectar a la base de dato
            //Ejecutar el SP
            //Capturar el resultado
            //
            var list = new List<Dictionary< string, object>> ();

            return list; 
        }
 

        }
       
    }

