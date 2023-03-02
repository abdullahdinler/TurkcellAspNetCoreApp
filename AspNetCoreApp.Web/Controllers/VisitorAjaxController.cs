using AspNetCoreApp.Web.Models;
using AspNetCoreApp.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApp.Web.Controllers
{
    public class VisitorAjaxController : Controller
    {
        private readonly IMapper _mapper;
        private readonly Context _context;

        public VisitorAjaxController(IMapper mapper, Context context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult VisitorAdded(VisitorViewModel visitor)
        {

            var model = _mapper.Map<Visitor>(visitor);
            model.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.Visitors.Add(model);
            _context.SaveChanges();

            return Json(new { IsSuccess = "True" });

        }


        public  IActionResult VisitorCommentList()
        {
            var values = _context.Visitors.OrderByDescending(x=>x.CreateDate).ToList();
            var model =  _mapper.Map<List<VisitorViewModel>>(values);
            return  Json( model);
        }
    }
}
