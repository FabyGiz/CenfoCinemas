function UsersViewController() {

    this.ViewName = "Users";
    this.ApiEndPointName = "";

    //metodo constructor
    this.InitView = function () {
        console.log("User init view --: ok");
    }

}

$(document).ready(function (){  //con $ llamamos a JQuery
    var vc = new UsersViewController();
    vc.InitView();
})