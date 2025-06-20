﻿using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class UserManager : BaseManager
    {


        /*
         * Metodo para la creacion de un usuario
         * Valida que el usuario sea mayor de 18 annios 
         * Valida que el codigo de usuario este disponible 
         * Valida que el correo electronico no este registrado
         * Envia un correo electronico de bienvenida 
         */
        public void Create(User user)
        {
            try
            {
                //Validar la edad
                if (IsOver18(user)){
                    var uCrud = new UserCrudFactory();
             
                    //Consultamos en la bd si existe un usuario con ese codigo
                    var uExist =uCrud.RetrieveByUserCode<User>(user);

                    if (uExist == null){

                    //Consultamos si en la bd existe un usuario con ese email.
                    uExist=uCrud.RetrieveByEmail<User>(user);
                     
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
            catch(Exception ex) 
                {
                    ManagerExeception(ex);
                }
            }
          private bool IsOver18(User user) {

            var currentDate = DateTime.Now;
            int age = currentDate.Year - user.BirthDate.Year;

            if (user.BirthDate>currentDate.AddYears(-age).Date)
                {
                    age--;
                }
            return age >= 18;
                
            }
        }
    }

