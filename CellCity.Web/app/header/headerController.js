app.controller('headerController', function ($scope, $rootScope, userService) {
    $scope.siginData = [];

    $scope.sigin = function () {
        userService.getUsers().then(function (results) {
            $scope.users = results.data.values;
        }, function (error) {
            alert(error);
        });
    }
});