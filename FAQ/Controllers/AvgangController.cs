using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAQ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAQ.Controllers
{
    [Route("api/[controller]")]
    public class AvgangFAQController : Controller
    {
        private readonly FAQContext _context;
        public AvgangFAQController(FAQContext context)
        {
            _context = context;
        }


        [HttpGet]
        public JsonResult Get()
        {
            var faqdb = new FAQdb(_context);
            List<FAQs> alleFAQs = faqdb.HentStrAvgFAQ();
            return Json(alleFAQs);
        }

    }
      
    
}