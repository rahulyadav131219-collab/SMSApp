var _UserAccessForm = null;
var mFlrId;

app.controller('UserAccessFormCtrl', function ($scope, $http) {

	_UserAccessForm = $scope;

	$scope.UserAccessList = [];
	$scope.UserId = "0";

	$scope.GetAllUsers = function () {

		$http.post("/UserAccess/GetAllUsersList",
			{
			}
		).then(function (resp) {

			var mData = JSON.parse(resp.data);

			$scope.UserAccessList = mData.Table;

		}, function (data) {
		});
	}

	$scope.GetAllUsers();

	$scope.FloorList = [];
	$scope.FloorId = "0";

	$scope.GetAllFloor = function () {

		$http.post("/UserAccess/GetAllFloorList",
			{
			}
		).then(function (resp) {

			var mData = JSON.parse(resp.data);

			$scope.FloorList = mData.Table;

		}, function (data) {
		});
	}

	$scope.GetAllFloor();

	$scope.RedirectUserToEdit = function (vId) {
		window.location.href = "/User/Edit/" + vId;
	}

	$scope.AllMapUsers = [];
	$scope.UserId = "0";

	var mAllMapUsers = $("#txtUserJSON").val();
	
	if (mAllMapUsers != undefined && mAllMapUsers != "" && mAllMapUsers != null) {
		$scope.AllMapUsers = JSON.parse(mAllMapUsers);
	}

	$scope.AddUsers = function () {

		var mRowId = $scope.AllMapUsers.length + 1;

		var mUserId = $("#ddlUser option:selected").val().split(':')[1];
		var mUserName = $("#ddlUser option:selected").text();

		$scope.AllMapUsers.push({
			RowId: mRowId,
			UserId: mUserId,
			UserName: mUserName,
			Select: "",
			IsType: "N"
		});
	}

});

function SaveUserAccess() {

	if (_UserAccessForm.FloorId != undefined && _UserAccessForm.FloorId != "" && _UserAccessForm.FloorId != "0") {
		$("#txtFloorId").val(_UserAccessForm.FloorId);
	}

	if (_UserAccessForm.AllMapUsers != undefined && _UserAccessForm.AllMapUsers != "") {
		$("#txtUserJSON").val(JSON.stringify(_UserAccessForm.AllMapUsers));
	}

	return true;
}

function OnFloorSel() {
	mFlrId = $("#ddlFloor option:selected").val().split(':')[1];
}
