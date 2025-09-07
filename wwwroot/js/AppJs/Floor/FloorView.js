
app.controller('FloorViewCtrl', function ($scope, $http) {

	$scope.FloorList = [];

	$scope.LoadFloorViewList = function () {

		$http.post("/Floor/ViewFloorList",
			{
			}
		).then(function (resp) {

			var mData = JSON.parse(resp.data);

			$scope.FloorList = mData.Table;

		}, function (data) {
		});
	}

	$scope.LoadFloorViewList();

	$scope.RedirectFloorToEdit = function (vFloorId) {

		window.location.href = "/Floor/EditFloor/" + vFloorId;
		return false;
	}

	$scope.RedirectToMapFloorEdit = function (vFloorId) {

		window.location.href = "/Floor/EditMapFloor?id=" + vFloorId + "&vType=Map";
		return false;
	}

});
