var _ControllerMapForm = null;

app.controller('ControllerMapFormCtrl', function ($scope, $http) {

	_ControllerMapForm = $scope;

	$scope.FloorList = [];

	$scope.GetAllFloor = function () {

		$http.post("/ControllerMap/GetAllFloor",
			{
			}
		).then(function (resp) {

			var mData = JSON.parse(resp.data);

			$scope.FloorList = mData.Table;

		}, function (data) {
		});
	}

	$scope.GetAllFloor();

	$scope.FormFloorList = [];

	var mFloorListJson = $("#txtFloorListJson").val();

	if (mFloorListJson != undefined & mFloorListJson != null) {
		$scope.FormFloorList = JSON.parse(mFloorListJson);
	}

	$scope.AddFloor = function () {
		
		var mRowId = $scope.FormFloorList.length + 1;
		var mFloorId = $("#ddlFloor option:selected").val();
		var mFloorName = $("#ddlFloor option:selected").text();

		$scope.FormFloorList.push({
			RowId: mRowId,
			FloorId: mFloorId,
			FloorName: mFloorName,
			IsType: "N"
		});
	}

	$scope.RemoveUser = function (vRowId) {

		for (var i = 0; i < $scope.FormFloorList.length; i++) {

			if ($scope.FormFloorList[i].RowId == vRowId) {
				$scope.FormFloorList[i].IsType = "D";
			}

		}
	}

});

function SaveControllerMap() {

	$("#txtFloorListJson").val(JSON.stringify(_ControllerMapForm.FormFloorList));

	return true;
}