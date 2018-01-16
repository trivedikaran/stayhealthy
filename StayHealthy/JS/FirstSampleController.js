app.controller('HomeController', function ($timeout, $http, $rootScope, $filter, $scope, $window, $compile, $state, $interval, $http, $log, $q, configurationService) {
    var userId = angular.element("#UserId").val();
    $scope.ABC = "Hello World from Dashboard";
    $http.get(configurationService.apiUrl + 'api/GetUserDetailById?Id=1').then(
    function (response) {
        if (response != null && response.data != null && response.data.Data.length > 0) {
            $scope.UserDetail = response.data.Data[0];
        }
    });
});