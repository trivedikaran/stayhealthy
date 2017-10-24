window.appConfig = {
    apiRoot: "http://localhost:3000/api/",
    debug: 0
};

var app = angular.module('StayHealthyApp', ['ngRoute', "ui.router",'ngMaterial']);

app.config(function ($routeProvider, $locationProvider, $stateProvider) {
    var Home = {
        name: 'Home',
        url: '/Home',
        templateUrl: 'Templates/HomePage.html'
    }


    $stateProvider.state(Home);

    $routeProvider.otherwise('/Home');
});
