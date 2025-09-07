﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SMSApp.Models;
using SMSApp.Models.SC;
using System.Diagnostics;
using System.Security.Claims;
using WebTemplate.Models.BLL;
using System.Data;
using Newtonsoft.Json;
using SMSApp.Models.DAL;
using Microsoft.AspNetCore.Authorization;

namespace SMSApp.Controllers
{
    [Authorize]
    public class ControllerMap : Controller
    {
        private readonly ILogger<ControllerMap> _logger;
        private IConfiguration Configuration;

        public ControllerMap(ILogger<ControllerMap> logger, IConfiguration _configuration)
        {
            _logger = logger;
            Configuration = _configuration;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("ControllerMapList");
        }

        [HttpGet]
        public ActionResult New()
        {
            ControllerMapSC mControllerMapSC = new ControllerMapSC();
            mControllerMapSC.Status = "1";

            return View("ControllerMapForm", mControllerMapSC);
        }

        [HttpPost]
        public IActionResult SaveControllerMap(ControllerMapSC vControllerMapSC)
        {
            ControllerMapBLL mControllerMapBLL = null;

            mControllerMapBLL = new ControllerMapBLL();

            vControllerMapSC.IsEdit = vControllerMapSC.ControllerMapId == null ? "N" : "Y";

            vControllerMapSC.CurrUserId = User.GetUserId();

            mControllerMapBLL.SaveControllerMap(vControllerMapSC, Configuration);

            return Json(new
            {
                IsSuccess = "Y"
            });
        }

        [HttpPost]
        public IActionResult ViewControllerMapList()
        {
            ControllerMapBLL mControllerMapBLL = null;
            DataSet mDset = null;

            mControllerMapBLL = new ControllerMapBLL();

            mDset = mControllerMapBLL.ViewControllerMapList("", Configuration);

            return Json(JsonConvert.SerializeObject(mDset));
        }

        [HttpGet]
        public ActionResult Edit(String id)
        {
            ControllerMapBLL mControllerMapBLL = null;
            ControllerMapSC mControllerMapSC = null;

            mControllerMapBLL = new ControllerMapBLL();
            mControllerMapSC = new ControllerMapSC();

            mControllerMapSC = mControllerMapBLL.ControllerMapGetById(id, Configuration);

            return View("ControllerMapForm", mControllerMapSC);
        }

        [HttpPost]
        public IActionResult GetAllFloor()
        {
            ControllerMapBLL mControllerMapBLL = null;
            DataSet mDset = null;
            string vCurrUsrId = string.Empty;

            mControllerMapBLL = new ControllerMapBLL();
            vCurrUsrId = User.GetUserId();

            mDset = mControllerMapBLL.GetAllFloor(vCurrUsrId, Configuration);

            return Json(JsonConvert.SerializeObject(mDset));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}