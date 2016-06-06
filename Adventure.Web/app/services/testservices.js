mod.factory('dataService', function ($resource) {
    var odataUrl = 'http://localhost:4999/odata/';
    var apiUrl = 'http://localhost:4999/api/tweets/mattdunndc';
    //http://twitterservice.azurewebsites.net/api/tweets/mattdunndc'
    //http://http://localhost:4999/odata/CustomersDTO

    return $resource('', {},
        {
            'getAll': { method: 'GET', params: { entity: '@entity' }, url: odataUrl + ':entity' },
            'getTop10': { method: 'GET', url: odataUrl + '?$top=10' },
            'create': { method: 'POST', url: odataUrl },
            'patch': { method: 'PATCH', params: { key: '@key' }, url: odataUrl + '(:key)' },
            'getEmployee': { method: 'GET', params: { key: '@key' }, url: odataUrl + '(:key)' },
            'getEmployeeAdderss': { method: 'GET', params: { key: '@key' }, url: odataUrl + '(:key)' + '/Address' },
            'getEmployeeCompany': { method: 'GET', params: { key: '@key' }, url: odataUrl + '(:key)' + '/Company' },
            'deleteEmployee': { method: 'DELETE', params: { key: '@key' }, url: odataUrl + '(:key)' },
            'addEmployee': { method: 'POST', url: odataUrl }
        });
}).factory('notificationFactory', function () {
    return {
        success: function (text) {
            toastr.success(text, "Success");
        },
        info: function (text) {
            toastr.info(text, "Information");
        },
        warning: function (text) {
            toastr.warning(text, "Warning");
        },
        error: function (text) {
            toastr.error(text, "Error");
        }
    };
})
.factory('apiService', ['$http',function ($http) {
    var urlBase = 'http://localhost:4999/api';
    var apiService = {};
    apiService.getTweets = function (userName) {
        return $http.get(urlBase + '/tweets/'+userName);
    };

    return apiService;
    
}])
