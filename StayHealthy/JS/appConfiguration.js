window.appConfig = {
    apiRoot: "http://localhost:3000/api/",
    debug: 0
};

var app = angular.module('StayHealthyApp', ['ui.router', 'ngMaterial']);


app.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $urlRouterProvider.otherwise('/Home');

    var Home = {
        name: 'Home',
        url: '/Home',
        templateUrl: 'StayHealthy/Templates/HomePage.html'
    }

    var MyMeasurement = {
        name: 'MyMeasurement',
        url: '/MyMeasurement',
        templateUrl: '~/Templates/MyMeasurement.html'
    }


    $stateProvider.state(Home);
    $stateProvider.state(MyMeasurement);

});

app.constant('configurationService', {
    apiUrl: 'StayHealthy/StayHealthyApi/',
    baseUrl: '/',
    enableDebug: true
});


//app.factory('SessionDetail', function (config) {
//    var currentUser;
//    return {
//        currentUser: function (Email, Password) {
//            $http.get(config.apiUrl + '/api/GetUserDetail?Email=' + Email + "&Password=" + Password).then(function (response) {
//                currentUser = response.data;
//            });
//        }
//    }
//});
