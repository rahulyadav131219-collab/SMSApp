﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSApp.Models
{
    public static class StoredProcedures
    {
        public const string spr_User_Save = "[Masters].[spr_User_Save]";
        public const string spr_User_FloorMap = "[Masters].[spr_User_FloorMap]";
        public const string spr_User_GetUserList = "[Masters].[spr_User_GetUserList]";
        public const string spr_User_GetUserById = "[Masters].[spr_User_GetUserById]";

        public const string spr_Role_Save = "[Masters].[spr_Role_Save]";
        public const string spr_GetAllRoles = "[Masters].[spr_GetAllRoles]";
        public const string spr_Roles_GetList = "[Masters].[spr_Roles_GetList]";

        public const string spr_Floor_Save = "[Masters].[spr_Floor_Save]";
        public const string spr_Image_Save = "[Masters].[spr_Image_Save]";
        public const string spr_Floor_GetList = "[Masters].[spr_Floor_GetList]";
        public const string spr_GetAllFloor = "[Masters].[spr_GetAllFloor]";
        public const string spr_FloorAdmin_List = "[Masters].[spr_FloorAdmin_List]";
        public const string spr_Floor_GetById = "[Masters].[spr_Floor_GetById]";
        public const string spr_FloorMap_Save = "[Masters].[spr_FloorMap_Save]";
        public const string spr_GetFloorMapDtls = "[Masters].[spr_GetFloorMapDtls]";

        public const string spr_Floor_BookSeat = "[dbo].[spr_Floor_BookSeat]";

        public const string spr_GetAllFloorList = "[Masters].[spr_GetAllFloorList]";

        public const string spr_ControllerMap_Save = "[Masters].[spr_ControllerMap_Save]";
        public const string spr_ControllerMap_GetList = "[Masters].[spr_ControllerMap_GetList]";
        public const string spr_ControllerMap_GetById = "[Masters].[spr_ControllerMap_GetById]";

        public const string spr_UserAccess_GetAllUsers = "[Masters].[spr_UserAccess_GetAllUsers]";
        public const string spr_UserAccess_GetAllFloor = "[Masters].[spr_UserAccess_GetAllFloor]";
        public const string spr_UserAccess_Save = "[Masters].[spr_UserAccess_Save]";
        public const string spr_UserAccess_SaveUsers = "[Masters].[spr_UserAccess_SaveUsers]";
        public const string spr_UserAccess_GetList = "[Masters].[spr_UserAccess_GetList]";
        public const string spr_UserAccess_GetById = "[Masters].[spr_UserAccess_GetById]";

        public const string spr_GetAllDepartment = "[Masters].[spr_GetAllDepartment]";
        public const string spr_Dashboard = "[dbo].[spr_Dashboard]";

        public const string spr_SeatBook_GetList = "[Masters].[spr_SeatBook_GetList]";

        public const string spr_User_Authenticate = "[dbo].[spr_User_Authenticate]";
    }
}