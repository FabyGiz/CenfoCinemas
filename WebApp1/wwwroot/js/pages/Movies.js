function MoviesViewController() {
    this.ViewName = "Movies";
    this.ApiEndPointName = "Movie";

    //Metodo constructor
    this.InitView = function () {

        console.log("Movie init view --> ok");
        this.LoadTable();

        //Asociar el evento al boton
        $('#btnCreate').click(function () {
            var vc = new MoviesViewController();
            vc.Create();
        });

        $('#btnUpdate').click(function () {
            var vc = new MoviesViewController();
            vc.Update();
        })


        $('#btnDelete').click(function () {
            var vc = new MoviesViewController();
            vc.Delete();
        })


    }

    //Metodo para la carga de una tabla
    this.LoadTable = function () {

        //URL del API a invocar
        //https://localhost:7177/api/Movie/RetrieveAll

        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        /*
             "title": "Harry Potter",
              "description": "Magos                                                                                                                                                                                                                                                     ",
               "relaseDate": "2001-11-10T01:07:22.37",
               "genre": "Fantasia",
               "director": "Chris Columbus",
               "id": 4,
               "created": "2025-06-26T01:07:51.983",
               "updated": "0001-01-01T00:00:00"
               
             }
           */

        var columns = [];
        columns[0] = { 'data': 'id' }
        columns[1] = { 'data': 'title' }
        columns[2] = { 'data': 'description' }
        columns[3] = { 'data': 'relaseDate' }
        columns[4] = { 'data': 'genre' }
        columns[5] = { 'data': 'director' }

        //Invocamos a datatable para convertir la tabla simple html en una tabla mas robusta
        $("#tblMovies").DataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns,
        });

        //asignar eventos de carga de datos o binding segun el clic en la tabla
        $('#tblMovies tbody').on('click', 'tr', function () {    //tr=table row
            //extraemos la fila
            var row = $(this).closest('tr'); //closest busca el padre mas cercano

            //extraemos el dto
            //Esto nos devuelve el json de la fila selecioonada por el usuario
            //segun la data devuelta por el API
            var movieDTO = $("#tblMovies").DataTable().row(row).data();

            //Binding con el form 
            $('#txtId').val(movieDTO.id);
            $('#txtTitle').val(movieDTO.title);
            $('#txtDescription').val(movieDTO.description);
            $('#txtReleaseDate').val(movieDTO.releaseDate);
            $('#txtGenre').val(movieDTO.genre);
            $('#txtDirector').val(movieDTO.director);

            //fecha tiene un formato
            var onlyDate = movieDTO.releaseDate.split("T"); //se vuela el tiempo(hora, minutos, segundos))
            $('#txtReleaseDate').val(onlyDate[0]); //solo se deja la fecha


        })

    }




    this.Create = function () {

        var movieDTO = {};
        //Atributos con valores default que son controlados por el API

        movieDTO.id = 0;
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();
      

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Create";

        ca.PostToAPI(urlService, movieDTO, function () {
            //recargo la tabla
            $('#tblMovies').DataTable().ajax.reload();
        })
    }

    this.Update = function () {

        var movieDTO = {};
        movieDTO.id = $('#txtId').val();
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();
       

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Update";

        ca.PostToAPI(urlService, movieDTO, function () {
            //recargo la tabla
            $('#tblMovies').DataTable().ajax.reload();
        })
    }

    this.Delete = function () {
        var movieDTO = {};
        movieDTO.id = $('#txtId').val();
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();


        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Update";

        ca.PostToAPI(urlService, movieDTO, function () {
            //recargo la tabla
            $('#tblMovies').DataTable().ajax.reload();
        })
    }


}






$(document).ready(function () {
    var vc = new MoviesViewController();
    vc.InitView();
});






















