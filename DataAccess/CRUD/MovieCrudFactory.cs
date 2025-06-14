using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class MovieCrudFactory : CrudFactory
    {
        public MovieCrudFactory() { 
            _sqlDao = SQLDao.GetInstance();
        }
        public override void Create(BaseDTO baseDTO)
        {
            var movies = baseDTO as Movies;

            var sqlOperation = new SQLOperation() { ProcedureName = "CRE_MOVIES_PR" };
            sqlOperation.AddStringParameter("P_Title", movies.Title);
            sqlOperation.AddStringParameter("P_Description", movies.Description);
            sqlOperation.AddDateTimeParam("P_ReleaseDate",movies.RelaseDate);
            sqlOperation.AddStringParameter("P_Genre", movies.Genre);
            sqlOperation.AddStringParameter("P_Director", movies.Director);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstMovies = new List<T>();

            var sqlOperation = new SQLOperation() { ProcedureName = "RET_ALL_MOVIES_PR" };

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if(lstResults.Count > 0)
            {
                foreach(var row in lstResults){

                    var movies = BuildMovies(row);
                    lstMovies.Add((T)Convert.ChangeType(movies, typeof(T)));
                }
            }
            return lstMovies;
        }

        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_MOVIES_BY_ID_PR" };
            sqlOperation.AddIntParam("P_ID", id);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var movies = BuildMovies(row);

                return (T)Convert.ChangeType(movies, typeof(T));

            }

            return default(T);
        }

        public T RetrieveByTitle<T>(Movies movies)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_MOVIE_BY_TITLE_PR" };
            sqlOperation.AddStringParameter("P_TITLE", movies.Title);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                movies = BuildMovies(row);

                return (T)Convert.ChangeType(movies, typeof(T));
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

        private Movies BuildMovies(Dictionary<string, object> row)
        {
            var movies = new Movies()
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                //Updated = (DateTime)row["Updated"],
                Title = (string)row["Title"],
                Description = (string)row["Description"],
                Director = (string)row["Director"],
                RelaseDate = (DateTime)row["ReleaseDate"]

            };

            return movies;
        }
    }
}
