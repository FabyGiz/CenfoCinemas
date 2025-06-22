using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public  class MovieManager:BaseManager
    {
        /*
        * Metodo para la creacion de una pelicula
        * Valida que la pelicula este disponible 
        * Valida que el correo electronico no este registrado
        * Envia un correo electronico de bienvenida 
        */
        public void Create(Movies movies)
        {
            try
            {

                //Consultamos en la bd si existe un titulo con ese codigo
                    var mCrud = new MovieCrudFactory();
                    var mExist = mCrud.RetrieveByTitle<Movies>(movies);

                    if (mExist == null)
                    {
                        mCrud.Create(movies);

                        var uCrud = new MovieCrudFactory();
                        //var userEmails = uCrud.RetrieveAll<User>().Select(u  => u.Email).ToList();

                        //var emailService = new EmailService();
                        //emailService.EmailNewMovie(movies.Title, userEmails);
                    }
                    else
                    {
                        throw new Exception("El titulo de la pelicula ya se encuentra registrado");
                    }
                
            }

            catch (Exception ex)
                 {
                ManagerExeception(ex);
                 }
        }   

            public List<Movies> RetrieveAll()
        {
            var mCrud = new MovieCrudFactory();
            return mCrud.RetrieveAll<Movies>();
        }

        public Movies RetrievebyId(int id)
        {
            var mCrud = new MovieCrudFactory();
            var movies = mCrud.RetrieveById<Movies>(id);
            return movies;
        }

        public void Update (Movies movies)
        {
            try
            {
                var mCrud = new MovieCrudFactory(); 
                mCrud.Update(movies);
            }
            catch (Exception ex)
            { 
                ManagerExeception(ex);
            }
        }

        public void Delete (int id)
        {
            try
            {
                var movies = new Movies { Id = id };
                var mCrud = new MovieCrudFactory();
                mCrud.Delete(movies);
            }
            catch(Exception ex)
            {
                ManagerExeception(ex);
            }
        }
    }
}


