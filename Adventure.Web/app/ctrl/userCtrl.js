var userCtrl = function($scope, dataService, notificationFactory)
{
        // Get Top 10 Employees
        notificationFactory.info('Loading data, please wait...');
        $scope.getCustomers; //init
        $scope.getCustomers = function () {
            (new dataService()).$getAll({ entity: 'CustomersDTO' })
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
        


        $scope.sort = function (keyname) {
            $scope.sortKey = keyname; //set the sortKey to the param passed
            $scope.reverse = !$scope.reverse; //if true make it false and vice versa
        };
        
        $scope.getCustomers(); //init

        // Set active customer for patch update
        $scope.setCustomer = function (customer) {
            $scope.currentCustomer = customer;
            notificationFactory.info('set customer...');
            //$scope.setCurrentEmployeeAddress();
            //$scope.setCurrentEmployeeCompany();
        };       
            

}
mod.controller('userCtrl', userCtrl);
