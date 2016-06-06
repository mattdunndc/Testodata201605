var mod = angular.module('testapp', ['ngRoute','ngMaterial','ui.bootstrap', 'angular-advanced-searchbox', 'ngResource', 'angularUtils.directives.dirPagination'])
.config(function ($routeProvider, $locationProvider) {
    //Path - it should be same as href link
    $routeProvider.when('/Home/About', { templateUrl: '/Views/Home/About.cshtml', controller: '2userCtrl' });
    $routeProvider.when('/Home/Search', { templateUrl: '/Views/Home/Search.cshtml', controller: '3testCtrl' });
    $locationProvider.html5Mode(true);
})
.config(function ($mdThemingProvider) {
    $mdThemingProvider.theme('default')
      .accentPalette('orange');
})
;
