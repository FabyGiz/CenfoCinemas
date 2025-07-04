function UsersViewController() {

    this.ViewName = "Users";
    this.ApiEndPointName = "User";

    //Metodo constructor
    this.InitView = function () {

        console.log("User init view --> ok");
        this.LoadTable();

        //Asociar el evento al boton
        $('#btnCreate').click(function () {
            var vc = new UsersViewController();
            vc.Create();
        });

        $('#btnUpdate').click(function () {
            var vc = new UsersViewController();
            vc.Update();
        })


        $('#btnDelete').click(function () {
            var vc = new UsersViewController();
            vc.Delete();
        })


    }

    //Metodo para la carga de una tabla
    this.LoadTable = function () {

        //URL del API a invocar
        //https://localhost:7177/api/User/RetrieveAll

        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        /*
          "userCode": "friveram",
            "name": "Fabiola",
            "email": "friveram@ucenfotec.ac.cr",
            "password": "Fabiola123!",
            "birthDate": "2025-06-08T15:42:18.073",
            "status": "AC",
                "id": 1,
            "created": "2025-06-08T21:41:42.337",
            "updated": "0001-01-01T00:00:00"

            
          }
        */

        var columns = [];
        columns[0] = { 'data': 'id' }
        columns[1] = { 'data': 'userCode' }
        columns[2] = { 'data': 'name' }
        columns[3] = { 'data': 'email' }
        columns[4] = { 'data': 'birthDate' }
        columns[5] = { 'data': 'status' }

        //Invocamos a datatable para convertir la tabla simple html en una tabla mas robusta
        $("#tblUsers").DataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns,
        });

        //asignar eventos de carga de datos o binding segun el clic en la tabla
        $('#tblUsers tbody').on('click', 'tr', function () {    //tr=table row
            //extraemos la fila
            var row = $(this).closest('tr'); //closest busca el padre mas cercano

            //extraemos el dto
            //Esto nos devuelve el json de la fila selecioonada por el usuario
            //segun la data devuelta por el API
            var userDto = $("#tblUsers").DataTable().row(row).data();

            //Binding con el form 
            $('#txtId').val(userDto.id);
            $('#txtUserCode').val(userDto.userCode);
            $('#txtName').val(userDto.name);
            $('#txtEmail').val(userDto.email);
            $('#txtStatus').val(userDto.status);

            //fecha tiene un formato
            var onlyDate = userDto.birthDate.split("T"); //se vuela el tiempo(hora, minutos, segundos))
            $('#txtBirthDate').val(onlyDate[0]); //solo se deja la fecha


        })   

    }




    this.Create = function () {

        var userDto = {};
        //Atributos con valores default que son controlados por el API

        userDto.id = 0;
        userDto.created = "2025-01-01";
        userDto.updated = "2025-01-01";

        //valores capturados en pantalla
        userDto.userCode = $('#txtUserCode').val();
        userDto.name = $('#txtName').val();
        userDto.email = $('#txtEmail').val();
        userDto.status = $('#txtStatus').val();
        userDto.birthDate = $('#txtBirthDate').val(); 
        userDto.password = $('#txtPassword').val(); 

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Create";

        ca.PostToAPI(urlService, userDto, function () {
            //recargo la tabla
            $('#tblUsers').DataTable().ajax.reload();
        })
    }

    this.Update = function () {

        var userDto = {};
        userDto.id = $('#txtId').val();
        userDto.created = "2025-01-01";
        userDto.updated = "2025-01-01";

        //valores capturados en pantalla
        userDto.userCode = $('#txtUserCode').val();
        userDto.name = $('#txtName').val();
        userDto.email = $('#txtEmail').val();
        userDto.status = $('#txtStatus').val();
        userDto.birthDate = $('#txtBirthDate').val();
        userDto.password = $('#txtPassword').val(); 

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Update";

        ca.PostToAPI(urlService, userDto, function () {
            //recargo la tabla
            $('#tblUsers').DataTable().ajax.reload();
        })
    }

    this.Delete = function () {
        var userDto = {};
        userDto.id = $('#txtId').val();
        userDto.created = "2025-01-01";
        userDto.updated = "2025-01-01";

        //valores capturados en pantalla
        userDto.userCode = $('#txtUserCode').val();
        userDto.name = $('#txtName').val();
        userDto.email = $('#txtEmail').val();
        userDto.status = $('#txtStatus').val();
        userDto.birthDate = $('#txtBirthDate').val();
        userDto.password = $('#txtPassword').val();

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Delete";

        ca.DeleteToAPI(urlService, userDto, function () {
            $('#tblUsers').DataTable().ajax.reload();
        })
    }


}






    $(document).ready(function () {
        var vc = new UsersViewController();
        vc.InitView();
    });