// js que maneja todo el comportamiento de la vista de los usuarios

//definir una clase js, usando prototype

function UsersViewController() {

    this.ViewName = "Users";
    this.ApiEndPointName = "";

    //metodo constructor
    this.IntView = function () {

        console.log("User init view --> ok");

    }

    //metodo para la carga de una tabla
    this.LoadTable = function () {

    }

}

$(document).ready(function (){  //con $ llamamos a JQuery
    var vc = new UsersViewController();
    vc.InitView();
})