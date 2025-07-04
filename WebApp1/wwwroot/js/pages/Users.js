function UsersViewController() {

    this.ViewName = "Users";
    this.ApiEndPointName = "User";

    //Metodo constructor
    this.InitView = function () {

        console.log("User init view --> ok");
        this.LoadTable();


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


    }
}

    $(document).ready(function () {
        var vc = new UsersViewController();
        vc.InitView();
    });