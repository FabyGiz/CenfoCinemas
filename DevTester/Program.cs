

using CoreApp;
using DataAccess.CRUD;
using DataAccess.DAO;
using DTOs;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

public class Program{
    
    public static void Main(string[] args)
    {

        Console.WriteLine("Seleccione la opcion deseada");
        Console.WriteLine("1.Crear usuario");
        Console.WriteLine("2.Consultar usuarios");
        Console.WriteLine("3.Actualizar usuarios");
        Console.WriteLine("4.Eliminar usuarios");
        Console.WriteLine("5.Crear peliculas");
        Console.WriteLine("6.Consultar peliculas");
        Console.WriteLine("7.Actualizar peliculas");
        Console.WriteLine("8.Eliminar peliculas");

        var option=Int32.Parse(Console.ReadLine());
        var sqlOperation = new SQLOperation();

        switch (option)
        {
            case 1:
                Console.WriteLine("Digite el codigo de usuario");
                var UserCode=Console.ReadLine();

                Console.WriteLine("Digite el codigo de nombre");
                var name = Console.ReadLine();

                Console.WriteLine("Digite el codigo de email");
                var email = Console.ReadLine();

                Console.WriteLine("Digite el codigo de password");
                var password = Console.ReadLine();

                var status = "AC";

                Console.WriteLine("Digite la fecha de nacimiento");
                var bdate = DateTime.Parse(Console.ReadLine());
                
                //Creamos el objeto del usuario a partir de los valores capturados en consola
                var user = new User()
                {
                    UserCode = UserCode,
                    Name = name,
                    Email = email,
                    Password = password,
                    Status = status,
                    BirthDate = bdate
                };

                var um = new UserManager();
                um.Create (user);

             break;
             /*case 2: 
                    uCrud=new UserCrudFactory();
                    var listUsers = uCrud.RetrieveAll<User>();
                    foreach(var u in listUser)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(u));
                }
              */ break;

            case 3: Console.WriteLine("Acrualizar Usuario");

            break;

            case 4:
                Console.WriteLine("Eliminar Usuario");

                Console.WriteLine("Digite el userCode:");
                var userCode = Console.ReadLine();

                var user1 = new User
                {
                    UserCode = userCode
                };

                var um1 = new UserManager ();
                um1.Delete(user1);

                break;



            case 5:
                Console.WriteLine("Digite el titulo");
                var title = Console.ReadLine();

                Console.WriteLine("Digite la descripcion");
                var description = Console.ReadLine();

                Console.WriteLine("Digite la fecha la lanzamiento");
                var rDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Digite el genero de la pelicula");
                var genrre = Console.ReadLine();

                Console.WriteLine("Digite el director");
                var director = Console.ReadLine();

                //Creamos el objeto de pelicula a partir de los valores capturados en consola

                var movies = new Movies()
                {
                    Title = title,
                    Description = description,
                    RelaseDate = rDate,
                    Genre = genrre,
                    Director = director
                };

                var mm = new MovieManager();
                mm.Create (movies);

                break;

            case 8:
                Console.WriteLine("Eliminar Pelicula");

                Console.WriteLine("Digite el titulo:");
                var Title = Console.ReadLine();

                var movies1 = new Movies
                {
                    Title = Title
                };

                var mm1 = new MovieManager();
                mm1.Delete(movies1);

                break;


        }

        //var sqlDao = SQLDao.GetInstance();

        //sqlDao.ExecuteProcedure (sqlOperation);
        
    }

}
