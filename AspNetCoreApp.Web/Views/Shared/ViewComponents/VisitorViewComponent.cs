using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApp.Web.Models;
using AspNetCoreApp.Web.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AspNetCoreApp.Web.Views.Shared.ViewComponents
{
    public class VisitorViewComponent:ViewComponent
    {
        private Context _context;
        private IMapper _mapper;
        public VisitorViewComponent(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _context.Visitors.ToList();
            var model = _mapper.Map<List<VisitorViewModel>>(values);
            ViewBag.Model = model;

            return View();
        }
    }
}
