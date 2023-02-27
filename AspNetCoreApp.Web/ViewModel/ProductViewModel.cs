using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AspNetCoreApp.Web.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Remote(action: "HasProductName", controller:"Product")] // Burada hasproduct action nu gidip ismin daha çnce kullanılıp kullanılmadığını kontrol eder.
        [Required(ErrorMessage = "İsim alanı boş geçilemez.")]
        [StringLength(50, ErrorMessage = "Karekter uzunluğu en fazla 100 olabilir.")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Fiyat bilgisi 1 ile 100 arasında olması gerek.")]
        public decimal Price { get; set; }
        [Range(1, 100, ErrorMessage = "Fiyat bilgisi 1 ile 100 arasında olması gerek.")]
        public int? Stock { get; set; }
        public DateTime DateTime { get; set; }
        public IFormFile Image { get; set; }
        [ValidateNever]
        public string ImagePath { get; set; }
    }
}
