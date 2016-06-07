var tweetCtrl = function($scope, notificationFactory, apiService)
{
        // Get Top 10 Employees
    notificationFactory.info('Loading data, please wait...');
    getTweets(); //init instead of ng-init in view
    function getTweets () {
        apiService.getTweets('mattdunndc')
            .success(function (tweets) {
                $scope.tweets = tweets;
            })
            .error(function (error) {
                notificationFactory.error('Unable to load data '+error.message);
            });
    }
}
mod.controller('tweetCtrl', tweetCtrl);
