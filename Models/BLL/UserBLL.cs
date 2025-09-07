using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using Newtonsoft.Json;
using SMSApp.Models;
using SMSApp.Models.DAL;
using SMSApp.Models.SC;

namespace WebTemplate.Models.BLL
{
    public class UserBLL
    {
        public void SaveUser(UserSC vUserSC, IConfiguration _configuration)
        {
            UserDAL mUserDAL = null;
            string vUserId = string.Empty;
            TransactionScope mTransactionScope = null;

            mUserDAL = new UserDAL(_configuration);
            mTransactionScope = new TransactionScope();

            using (mTransactionScope)
            {
                vUserSC.Password = PwdHelper.Encrypt(vUserSC.Password);

                vUserId = mUserDAL.SaveUser(vUserSC);

                //if (!string.IsNullOrEmpty(vUserSC.FloorSelect))
                //{
                //    vUserSC.FloorSelectDT = JsonConvert.DeserializeObject<DataTable>(vUserSC.FloorSelect);

                //    if (vUserSC.FloorSelectDT != null)
                //    {
                //        if (vUserSC.FloorSelectDT.Columns.Contains("$$hashKey"))
                //            vUserSC.FloorSelectDT.Columns.Remove("$$hashKey");

                //        if (vUserSC.FloorSelectDT.Columns.Contains("UserId"))
                //            vUserSC.FloorSelectDT.Columns.Remove("UserId");
                //    }


                //    if (vUserSC.FloorSelectDT != null && vUserSC.FloorSelectDT.Rows.Count > 0)
                //    {
                //        if (!string.IsNullOrEmpty(vUserId))
                //        {
                //            mUserDAL.SaveUserFloorMap(vUserSC);
                //        }
                //    }
                //}

                mTransactionScope.Complete();
            }

            mTransactionScope.Dispose();
        }

        public DataSet ViewUserList(String vCurrUserId, IConfiguration _configuration)
        {
            UserDAL mUserDAL = null;
            DataSet mDset = null;

            mUserDAL = new UserDAL(_configuration);

            mDset = mUserDAL.ViewUserList(vCurrUserId);

            return mDset;
        }

        public UserSC UserGetById(String vRoleId, IConfiguration _configuration)
        {
            UserDAL mUserDAL = null;
            UserSC mUserSC = null;

            mUserDAL = new UserDAL(_configuration);
            mUserSC = new UserSC();

            mUserSC = mUserDAL.UserGetById(vRoleId);

            return mUserSC;
        }

        public DataSet GetAllRoles(IConfiguration _configuration)
        {
            UserDAL mUserDAL = null;
            DataSet mDset = null;

            mUserDAL = new UserDAL(_configuration);

            mDset = mUserDAL.GetAllRoles();

            return mDset;
        }

        public DataSet GetAllDepartment(IConfiguration _configuration)
        {
            UserDAL mUserDAL = null;
            DataSet mDset = null;

            mUserDAL = new UserDAL(_configuration);

            mDset = mUserDAL.GetAllDepartment();

            return mDset;
        }


    }
}
