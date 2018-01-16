window.appConfig = {
    apiRoot: "http://localhost:3000/api/",
    debug: 0
};

var app = angular.module('StayHealthyApp', ['ui.router', 'ngMaterial']);

app.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {

    $urlRouterProvider.otherwise('/Dashboard');

    $locationProvider.html5Mode(true).hashPrefix('!');

    var Dashboard = {
        name: 'Dashboard',
        url: '/Dashboard',
        templateUrl: '/Templates/Dashboard.html'
    }

    var MyMeasurement = {
        name: 'MyMeasurement',
        url: '/MyMeasurement',
        templateUrl: '/Templates/MyMeasurement.html'
    }

    $stateProvider.state(Dashboard);
    $stateProvider.state(MyMeasurement);

})
.run(function ($http, $rootScope, $location, $filter, $state) {

    //var now1 = new Date();
    //var GETLocalStorageDateTime = localStorageService.get("CurrentDateTime");
    //var diff = (now1.getTime() - new Date(GETLocalStorageDateTime).getTime());

    //if (diff > 10000) {

    //    localStorageService.clearAll();
    //    localStorageService.set("CurrentDateTime", now1);
    //    if (document.location.origin.toLowerCase() != document.location.href.toString().toLowerCase()) {

    //        location.href = document.location.origin;
    //    }
    //    //localStorageService.remove("loggedInUser");
    //    //localStorageService.remove("ImpersonatedUserDetail");
    //    //localStorageService.remove("NotificationMesseges");
    //    //localStorageService.remove("userPermissions");
    //    //localStorageService.remove("CurrentDateTime");

    //    //if (localStorageService != undefined) {
    //    //    for (var i = 0; i < localStorageService.keys(0).length; i++) {

    //    //        if (localStorageService.keys(0)[i].split('-')[0] == 'pageName') {

    //    //            localStorageService.remove(localStorageService.keys(0)[i]);
    //    //        }
    //    //    }
    //    //    var now = new Date();
    //    //    localStorageService.set("CurrentDateTime", now);

    //    //}


    //    //if (!document.location.origin &&  document.location.href.toString().toLowerCase().indexOf('home') == -1) {

    //    //    location.href = document.location.origin;
    //    //}



    //}


    //localStorageService.remove("NotificationMesseges");
    //localStorageService.remove("userPermissions");
    //$rootScope.$state = $state;

    //$rootScope.GlobalDateFormat = 'MM/dd/yyyy';

    //function InitGlobalVariables() {

    //    $rootScope.CurrentUser = function () {
    //        var user = localStorageService.get("loggedInUser");
    //        if (user != null) {
    //            return user;
    //        }
    //        return null;
    //    };

    //    $rootScope.CurrentUserInternalId = function () {
    //        var user = $rootScope.CurrentUser();
    //        if (user != null) {
    //            return user.InternalId;
    //        }
    //        return 0;
    //    };

    //    $rootScope.CurrentUserIsAdmin = function () {
    //        var user = $rootScope.CurrentUser();
    //        if (user != null) { return user.IsAdmin; }
    //        return false;
    //    };

    //}


    //InitGlobalVariables();
    //InitGloablEnums();

    //$rootScope.isSubModuleAccessibleToUser = function (subModule, func) {
    //    var permissions = [];
    //     permissions = localStorageService.get("userPermissions");
    //    if (subModule == 'default') {
    //        return true;
    //    }
    //    if (permissions == null) {
    //        var userPermissions = permissionService.GetUserPermissions(user.InternalId)

    //        userPermissions.success(function (permissions) {
    //            localStorageService.set("userPermissions", permissions);
    //            permissions = localStorageService.get("userPermissions");                
    //            return false;
    //        });
    //    }   
    //    if (permissions != undefined && permissions != null)
    //            {
    //           if (permissions.length) {
    //           return $filter('filter')(permissions, { SubModule: subModule, Function: func }, true).length >= 1;
    //         }
    //     }

    //    else {
    //        return true;
    //    }

    //}



    $rootScope.$on('$locationChangeStart', function (event, next, current) {

        var geturlparameters = next.toString().split('?')[1];
        var isAlreadyDecoded = false;
        if (geturlparameters != undefined) {
            if (geturlparameters.indexOf('~') == -1)
                isAlreadyDecoded = true;
        }
        if (isAlreadyDecoded) {
            window.location.href = 'home/accessdenied';
        }

    });
    // Redirect to login if route requires auth and you're not logged in
    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
        $state.previous = fromState;
        $state.previousParams = fromParams;
        if (fromState.name != "") {
            //localStorageService.remove("previous");
            //localStorageService.set("previous", $state.previous);
            //localStorageService.remove("previousParams");
            //localStorageService.set("previousParams", $state.previousParams);
        }
        if (!(fromParams == toParams)) {
            //encodeParams(toParams);

        }
        // to track previous url
        $state.previousHref = $state.href(fromState, fromParams)
    });
});

app.constant('configurationService', {
    apiUrl: 'StayHealthyApi/',
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
