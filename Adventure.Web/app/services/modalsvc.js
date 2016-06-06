mod.factory('verifyDelete', function ($mdDialog) {
    return function (customer) {
        var confirm = $mdDialog.confirm()
          .title('Confirm Your Choice')
          .content('Are you sure you want to delete ' + customer.FirstName + ' ' + customer.LastName + '?')
          .ariaLabel('Delete User')
          .ok('Delete User')
          .cancel('Cancel');
        return $mdDialog.show(confirm);
    }
});
