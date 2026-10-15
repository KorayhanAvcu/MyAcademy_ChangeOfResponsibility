using ChangeOfResp.Web.ChainOfResponsibilityPattern;
using ChangeOfResp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChangeOfResp.Web.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Treasurer _treasurer;
        private readonly AssinstantManager _assinstantManager;
        private readonly Manager _manager;
        private readonly RegionalManager _regionalManager;

        public DefaultController(Treasurer treasurer, AssinstantManager assinstantManager, Manager manager, RegionalManager regionalManager)
        {
            _treasurer = treasurer;
            _assinstantManager = assinstantManager;
            _manager = manager;
            _regionalManager = regionalManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            _treasurer.SetNextApprover(_assinstantManager);
            _assinstantManager.SetNextApprover(_manager);
            _manager.SetNextApprover(_regionalManager);

            _treasurer.ProcessRequest(model);
            return NoContent(); 
        }
    }
}
