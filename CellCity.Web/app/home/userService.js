app.factory('userService', function ($http) {
    var userServicefactory = {};

    //function to get user list
    userServicefactory.getUsers = function () {

        return $http.get("http://localhost/CellCity.Api/odata/Users");
        //    .then(function (response) {
        //    return response;
        //});
    }

    return userServicefactory;
});