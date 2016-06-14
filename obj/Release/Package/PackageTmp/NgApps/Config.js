app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('cars', {
            url: '/',
            templateUrl: 'NgApps/Templates/Cars.html',
            controller: 'ctrNewCar'
        })
        .state('home', {
            url: '/home',
            templateUrl: 'NgApps/Templates/Home.html',
            controller: 'HomeController'
        })
        .state('about', {
            url: '/aboutpage',
            templateUrl: 'NgApps/Templates/About.html',
            controller: 'AboutController'
        })
        .state('contact', {
            url: '/contactpage',
            templateUrl: 'NgApps/Templates/Contact.html',
            controller: 'ContactController'
        })
        .state('apiHelp', {
            url: '/apihelp',
            templateUrl: 'NgApps/Templates/ApiHelp.html',
            controller: 'ApiHelpController'
        })

}]);