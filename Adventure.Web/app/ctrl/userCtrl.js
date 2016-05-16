var userCtrl = function($scope, customerService, notificationFactory)
{
        // Get Top 10 Employees
        $scope.getCustomers = function () {
            (new customerService()).$getAll()
                .then(function (data) {

                    $scope.currentPage = 1;
                    $scope.pageSize = 10;

                    $scope.customers = data.value;
                                       
                    $scope.pageChangeHandler = function (num) {
                        console.log('page changed to ' + num);
                    };

                    notificationFactory.success('Customers loaded.');
                });
        };        
}
mod.controller('userCtrl', userCtrl);
