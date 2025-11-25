using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_DotNet.Models.ViewModel
{
     public class ProductVM
    {
          public Product Product { get; set; }

        //for drop down of categories
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList {  get; set; }
    }
}
