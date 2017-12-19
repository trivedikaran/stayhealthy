app.controller('HomeController', function ($timeout, $http, $rootScope, $filter, $scope, $window, $compile, $state, $interval, $http, $log, $q, configurationService) {
    var userId = angular.element("#UserId").val();
    $http.get(configurationService.apiUrl + 'api/GetUserDetailById?Id=' + userId).then(
    function (response) {
        debugger;
        if (response != null && response.data != null && response.data.Data.length > 0) {
            $scope.UserDetail = response.data.Data[0];
        }
    });
});