﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlApp.Models;
using sqlApp.Services;

namespace sqlApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;

        public void OnGet()
        {
            ProductService productsService = new ProductService();
            Products = productsService.GetProducts();
        }
    }
}