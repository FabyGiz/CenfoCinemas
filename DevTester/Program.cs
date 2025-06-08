

using DataAccess.DAO;

public class Program{
    
    public static void Main(string[] args)
    {
        var sqlOperation = new SQLOperation();
        sqlOperation.ProcedureName = "CRE_USER_PR";

        sqlOperation.AddStringParameter("P_UserCode", "friveram");
        sqlOperation.AddStringParameter("P_Name", "Fabiola");
        sqlOperation.AddStringParameter("P_Email", "friveram@ucenfotec.ac.cr");
        sqlOperation.AddStringParameter("P_Password", "Fabiola123!");
        sqlOperation.AddStringParameter("P_Status", "AC");
        sqlOperation.AddDateTimeParam("P_BirthDate",DateTime.Now);

        var sqlDao = SQLDao.GetInstance();

        sqlDao.ExecuteProcedure (sqlOperation);
        
    }

}
