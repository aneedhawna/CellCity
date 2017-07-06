app.controller('homeController', function ($scope, $rootScope,  userService, $http) {

    $scope.carousalFunction = function () {

        $('.carousel').carousel({
            interval: 1000 * 2
        });
      
    }
    $scope.carousalFunction();

    $scope.users = [];

    $scope.getUser = function () {

        userService.getUsers().then(function (results) {
            $scope.users = results.data.value;
        }, function (error) {
            alert(error);
        });
    }
   });