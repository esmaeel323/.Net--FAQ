using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAQ.Models;
using Microsoft.EntityFrameworkCore;

namespace FAQ
{
    public class FAQdb
    {
        private readonly FAQContext _context;

        public FAQdb(FAQContext context)
        {
            _context = context;

        }

        public List<FAQs> HentAllFAQ()
        {

            List<FAQs> alleFAQs = _context.FAQs.Where(q => q.id > 0 && q.id <= 5).Select(q => new FAQs()
            {
                id = q.id,
                question = q.question,
                answer = q.answer,
               
            }).ToList();
            return alleFAQs;
        }

        public List<FAQs> HentStrAvgFAQ()
        {

            List<FAQs> alleFAQs = _context.FAQs.Where(q => q.id > 5 && q.id <= 10).Select(q => new FAQs()
            {
                id = q.id,
                question = q.question,
                answer = q.answer,
               
            }).ToList();
            return alleFAQs;
        }
       

        public List<FAQs> hentsvar(int id)
        {
            List<FAQs> ensvar = _context.FAQs.Where(q => q.id == id).Select(q => new FAQs()
            {
                id = q.id,
                answer = q.answer,
                like = q.like,
                dislike = q.dislike

            }).ToList();

            return ensvar;
        }

        public bool lagreFAQ(Question innFAQ)
        {
            var nyFAQ = new Question
            {

                navn = innFAQ.navn,
                epost = innFAQ.epost,
                question = innFAQ.question
            };

            try
            {
                _context.Question.Add(nyFAQ);
                _context.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }

        public bool editlikes(int id, FAQs innfaq)
        {

            FAQs forFAQ = _context.FAQs.FirstOrDefault(l => l.id == id);
            if (forFAQ == null)
            {
                return false;
            }

            forFAQ.like = forFAQ.like + innfaq.like;
            forFAQ.dislike = forFAQ.dislike + innfaq.dislike;

            try
            {

                _context.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }

    }
}
