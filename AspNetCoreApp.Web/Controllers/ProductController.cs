using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreApp.Web.Helpers;
using AspNetCoreApp.Web.Models;
using AspNetCoreApp.Web.ViewModel;
using AutoMapper;
using AspNetCoreApp.Web.Filters;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;


namespace AspNetCoreApp.Web.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly IFileProvider _fileProvider;

        public ProductController(Context context, IMapper mapper, IFileProvider fileProvider)
        {
            _context = context;
            _mapper = mapper;
            _fileProvider = fileProvider;
        }
        
        public IActionResult Index()
        {
            string text = "Merhaba Asp.Net Core";
                
            var result = _context.Products.ToList();
           
            return View(_mapper.Map<List<ProductViewModel>>(result));
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Expert = new Dictionary<String, int>()
            {
                 {"1 Ay",1},
                 {"3 Ay",3},
                 {"6 Ay",6},
                 {"12 Ay",12}
            };
            return View();
        }

        [HttpPost]
        public  IActionResult Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var root = _fileProvider.GetDirectoryContents("wwwroot");
                    var images = root.First(x => x.Name == "images");

                    var randomName = Guid.NewGuid() + Path.GetExtension(product.Image.FileName);

                    var path = Path.Combine(images.PhysicalPath, randomName);
                    using var stream = new FileStream(path, FileMode.Create);
                    product.Image.CopyTo(stream);


                    var products = _mapper.Map<Product>(product);
                    products.ImagePath = randomName;
                    

                    _context.Products.Add(products);
                    _context.SaveChanges();
                    TempData["Alert"] = "Ürün başarılı bir şekilde eklendi";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(String.Empty, "Ürün eklenirken bir hata oluştu lütfen daha sonra tekrar deneyin.");
                }
            }
            ViewBag.Expert = new Dictionary<String, int>()
            {
                {"1 Ay",1},
                {"3 Ay",3},
                {"6 Ay",6},
                {"12 Ay",12}
            };
            return View();
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(_mapper.Map<Product>(product));
            TempData["Alert"] = "Ürün başarılı bir şekilde silindi.";
            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel product)
        {
            var products = _mapper.Map<Product>(product);
            if (product.ImagePath == null)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var images = root.First(x => x.Name == "images");

                var randomName = Guid.NewGuid() + Path.GetExtension(product.Image.FileName);

                var path = Path.Combine(images.PhysicalPath, randomName);
                using var stream = new FileStream(path, FileMode.Create);
                product.Image.CopyTo(stream);
                products.ImagePath = randomName;
            }



            _context.Products.Update(products);
            _context.SaveChanges();
            TempData["Alert"] = "Ürün başarılı bir şekilde güncellendi.";
            return RedirectToAction("Index");
        }


        // Bu action da girilen ürün isminin daha önce var olup olmadığnı kontrol ettik.
        [AcceptVerbs("GET","POST")]
        public IActionResult HasProductName(string Name)
        {
            var anyProduct = _context.Products.Any(x => x.Name.ToLower() == Name.ToLower());
            if (anyProduct)
            {
                return Json("Gidiğiniz ürün daha önce eklenmiştir");
            }
            else
            {
                return Json(true);
            }
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [Route("/detay/{kod}", Name = "Detay")]
        public  IActionResult Details(int kod)
        {
            var product = _context.Products.Find(kod);
            return View(_mapper.Map<ProductViewModel>(product));
        }
        
    }
}
