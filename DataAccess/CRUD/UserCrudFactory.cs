using DataAccess.DAO;
using DTOs;

namespace DataAccess.CRUD
{

    
    public class UserCrudFactory : CrudFactory
    {
        public UserCrudFactory() {
            _sqlDao = SQLDao.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            var user = baseDTO as User;

            var sqlOperation = new SQLOperation() { ProcedureName = "CRE_USER_PR" };
            sqlOperation.AddStringParameter("P_UserCode", user.UserCode);
            sqlOperation.AddStringParameter("P_Name", user.Name);
            sqlOperation.AddStringParameter("P_Email", user.Email);
            sqlOperation.AddStringParameter("P_Password", user.Password);
            sqlOperation.AddStringParameter("P_Status", user.Status);
            sqlOperation.AddDateTimeParam("P_BirthDate", user.BirthDate);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUsers = new List<T>();

            var sqlOperation = new SQLOperation() { ProcedureName = "RET_ALL_USER_PR" };

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if(lstResults.Count > 0){

                foreach(var row in lstResults){
                    var user = BuildUser(row);
                    lstUsers.Add((T)Convert.ChangeType(user, typeof(T)));
                }
            }
            return lstUsers;

        }

        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_USER_BY_ID_PR" };
            sqlOperation.AddIntParam("P_ID", id);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0){
                var row=lstResults[0];
                var user = BuildUser(row);

                return (T) Convert.ChangeType(user, typeof(T));

            }

            return default (T);
        }

        public T RetrieveByUserCode<T>(User user)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_USER_BY_CODE_PR" };
            sqlOperation.AddStringParameter("P_CODE", user.UserCode);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                user = BuildUser(row);

                return (T)Convert.ChangeType(user, typeof(T));
            }
            return default(T);
        }

        public T RetrieveByEmail<T>(User user)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_USER_BY_EMAIL_PR" };
            sqlOperation.AddStringParameter("P_EMAIL", user.Email);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                user = BuildUser(row);

                return (T)Convert.ChangeType(user, typeof(T));
            }
            return default(T);
        }
        

        public override T Retrievw<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        //METODO QUE CONVIERTE EL DICCIONARIO EN UN USUARIO

        private User BuildUser(Dictionary<string, object> row)
        {
            var user = new User()
            {
                Id = (int) row["Id"],
                Created = (DateTime)row["Created"],
                //Updated = (DateTime)row["Updated"],
                UserCode = (string)row["Name"],
                Email = (string)row["Email"],
                Password = (string)row["Password"],
                Status = (string)row["Status"],
                BirthDate= (DateTime)row["BirthDate"]

            };

            return user;
        }
    }
}
