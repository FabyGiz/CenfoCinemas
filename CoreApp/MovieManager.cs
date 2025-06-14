using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
                {
                    var mCrud = new MoviesCrudFactory();

                    //Consultamos en la bd si existe un titulo con ese codigo
                    var mExist = mCrud.RetrieveByUserCode<Movies>(movies);

                    if (mExist == null)
                    {

                        //Consultamos si en la bd existe un usuario con ese email.
                        mExist = mCrud.RetrieveByEmail<Movies>(movies);

                        if (uExist == null)
                        {
                            uCrud.Create(user);
                            //AHORA SIGUE EL ENVIO DEL CORREO
                        }
                        else
                        {
                            throw new Exception("Este correo electronico ya se encuentra registrado");
                        }

                    }
                    else
                    {
                        throw new Exception("El codigo de usuario no esta disponible");
                    }
                }
                else
                {
                    throw new Exception("Usuario no cumple con la edad minima");
                }

            }
            catch (Exception ex)
            {
                ManagerExeception(ex);
            }
        }
        private bool IsOver18(User user)
        {

            var currentDate = DateTime.Now;
            int age = currentDate.Year - user.BirthDate.Year;

            if (user.BirthDate > currentDate.AddYears(-age).Date)
            {
                age--;
            }
            return age >= 18;

        }
    }


