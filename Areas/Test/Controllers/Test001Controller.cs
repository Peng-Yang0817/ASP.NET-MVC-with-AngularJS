using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMvcAddAngular.Areas.Test.Controllers
{
    public class Test001Controller : Controller
    {
        // GET: Test/Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetKeywordData(string keyword)
        {
            if (keyword == "")
            {
                return Json(new IsSuccess() { successCode = true, ReturnObject = new List<string>() }, JsonRequestBehavior.AllowGet);
            }
            var datas = new List<string>
            {
                "Alice",
                "Bob",
                "Charlie",
                "David",
                "Ella",
                "Frank",
                "Henry",
                "Ivy",
                "Jack",
                "Katherine",
                "Liam",
                "Mia",
                "Noah",
                "Olivia",
                "Penelope",
                "Quinn",
                "Riley",
                "Sophia"
            };
            var ReturnData = new IsSuccess();

            try
            {
                var keyWordDatas = datas.Where(x => x.ToLower().Contains(keyword.ToLower())).ToList();
                ReturnData.ReturnObject = keyWordDatas;
                ReturnData.successCode = true;
            }
            catch
            {
                ReturnData.ReturnObject = new List<string>();
                ReturnData.successCode = false;
            }


            return Json(ReturnData, JsonRequestBehavior.AllowGet);
        }
    }

    class IsSuccess
    {
        public bool successCode { get; set; }
        public List<string> ReturnObject { get; set; }
    }
}