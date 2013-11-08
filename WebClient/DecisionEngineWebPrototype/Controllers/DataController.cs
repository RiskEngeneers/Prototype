using System;
using System.Linq;
using System.Web.Mvc;
using DecisionEngineWebPrototype.Models;

namespace DecisionEngineWebPrototype.Controllers
{
    public class DataController : Controller
    {
        public ActionResult Load()
        {
            if (!Request.AcceptTypes.Contains("application/json"))
            {
                throw new InvalidOperationException("Only application/json is supported");
            }

            var dataMock = new DataRoot
            {
                Groups = new[]
                {
                    new ActivityGroup
                    {
                        Name = "Main activities",
                        Groups = new []
                        {
                            new ActivityGroup
                            {
                                Name = "Empty sub-group"
                            }
                        },
                        Condtition = "Some ivalid expression", 
                        Activities = new []
                        {
                            new Activity
                            {
                                Name = "First activity",
                                Condition = "return javaScript.Expession.For.FirstActivity();",
                                ApproveRules = new []
                                {
                                    new Rule {Name = "Rule 1", Expression = "Some another expression"},
                                    new Rule {Name = "Rule 2", Expression = "Some another expression"},
                                },
                                RejectRules = new []
                                {
                                    new Rule {Name = "Rule 5", Expression = "Some another expression"},
                                    new Rule {Name = "Rule 6", Expression = "Some another expression"},
                                },
                            },
                            new Activity
                            {
                                Name = "Second activity",
                                Condition = "return javaScript_Expession_For_SecondActivity();",
                                SuspendRules = new []
                                {
                                    new Rule {Name = "Rule 3", Expression = "Some another expression"},
                                    new Rule {Name = "Rule 4", Expression = "Some another expression"},
                                }
                            }
                        }
                    }
                }
            };

            return Json(dataMock, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Save()
        {
            return Json(new { id = 1, value = "new" });
        }

    }
}
