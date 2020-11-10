using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAQ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FAQ.Controllers
{
    [Route("api/[controller]")]
    public class FAQController : Controller
    {
        private readonly FAQContext _context;
        public FAQController(FAQContext context)
        {
            _context = context;
        }


        [HttpGet]
        public JsonResult Get()
        {
            var faqdb = new FAQdb(_context);
            List<FAQs> alleFAQs = faqdb.HentAllFAQ();
            return Json(alleFAQs);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var faqdb = new FAQdb(_context);
            List<FAQs> svar = faqdb.hentsvar(id);
            return Json(svar);
        }


        [HttpPost]
        public JsonResult Post([FromBody]Question innFAQ)
        {
            if (ModelState.IsValid)
            {
                var faqdb = new FAQdb(_context);
                bool OK = faqdb.lagreFAQ(innFAQ);
                if (OK)
                {
                    return Json("OK");
                }
            }
            return Json("Kunne ikke sette inn i DB");
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]FAQs innfaq)
        {
            if (ModelState.IsValid)
            {
                var faqdb = new FAQdb(_context);
                bool OK = faqdb.editlikes(id, innfaq);
                if (OK)
                {
                    return Json("OK");
                }
            }
            return Json("Kunne ikke endre faq i DB");
        }
    }
}
