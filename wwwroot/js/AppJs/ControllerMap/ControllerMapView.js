
app.controller('ControllerMapViewCtrl', function ($scope, $http) {

	$scope.ControllerMapList = [];

	$scope.LoadControllerMapViewList = function () {
		
		$http.post("/ControllerMap/ViewControllerMapList",
			{
			}
		).then(function (resp) {

			var mData = JSON.parse(resp.data);

			$scope.ControllerMapList = mData.Table;

		}, function (data) {
		});
	}

	$scope.LoadControllerMapViewList();

	$scope.RedirectUserToControllerMap = function (vId) {
		window.location.href = "/ControllerMap/Edit/" + vId;
	}
});
