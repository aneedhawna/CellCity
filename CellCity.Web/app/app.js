var app = angular.module('myApp', ['ngRoute']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "home/home.html",
    });
    $routeProvider.when("/signin", {
        controller: "signinController",
        templateUrl: "signin/signin.html",
    });
    $routeProvider.otherwise({
        redirectTo: "/home"
    })
});