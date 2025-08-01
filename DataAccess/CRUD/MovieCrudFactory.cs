﻿using DataAccess.DAO;
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

            var sqlOperation = new SQLOperation() { ProcedureName = "CRE_MOVIE_PR" };
            sqlOperation.AddStringParameter("P_Title", movies.Title);
            sqlOperation.AddStringParameter("P_Description", movies.Description);
            sqlOperation.AddDateTimeParam("P_ReleaseDate",movies.RelaseDate);
            sqlOperation.AddStringParameter("P_Genre", movies.Genre);
            sqlOperation.AddStringParameter("P_Director", movies.Director);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var movies = baseDTO as Movies;

            var sqlOperation = new SQLOperation() {ProcedureName = "DELETE_MOVIES_PR" };
            sqlOperation.AddIntParam("P_Id", movies.Id);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstMovies = new List<T>();

            var sqlOperation = new SQLOperation() { ProcedureName = "RET_ALL_MOVIES_PR" };

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if(lstResults != null)
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

            if (lstResults != null && lstResults.Count > 0 )
            {
                var row = lstResults[0];
                return (T)Convert.ChangeType(BuildMovies(row), typeof(T));

            }

            return default(T);
        }

        public T RetrieveByTitle<T>(Movies movies)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_MOVIES_BY_TITLE_PR" };
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

        public override void Update(BaseDTO baseDTO)
        {
            var movies = baseDTO as Movies;

            var sqlOperation = new SQLOperation() { ProcedureName = "UPDATE_MOVIES_PR" };

            sqlOperation.AddIntParam("P_Id", movies.Id);
            sqlOperation.AddStringParameter("P_Title", movies.Title);
            sqlOperation.AddStringParameter("P_Description", movies.Description);
            sqlOperation.AddDateTimeParam("P_ReleaseDate", movies.RelaseDate);
            sqlOperation.AddStringParameter("P_Genre", movies.Genre);
            sqlOperation.AddStringParameter("P_Director", movies.Director);

            _sqlDao.ExecuteProcedure(sqlOperation);
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
                RelaseDate = (DateTime)row["ReleaseDate"],
                Genre = (string)row["Genre"],
                Director = (string)row["Director"],
               

            };

            return movies;
        }
    }
}
