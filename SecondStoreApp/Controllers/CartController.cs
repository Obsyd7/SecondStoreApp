using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondStoreApp.DAL;
using SecondStoreApp.Infrastructure;
using SecondStoreApp.ViewModels;

namespace SecondStoreApp.Controllers
{
    public class CartController : Controller
    {
        private CartManager cartManager;

        private SessionManager sessionManager { get; set; }

        private StoreDbContext db;

        public CartController()
        {
            db = new StoreDbContext();
            sessionManager = new SessionManager();
            cartManager = new CartManager(sessionManager, db);
        }

        public ActionResult Index()
        {
            var orderItem = cartManager.DownloadCart();
            var fullPrice = cartManager.DownloadCartValue();

            var cartViewModel = new CartViewModel()
            {
                OrderPosition = orderItem,
                TotalPrice = fullPrice
            };

            return View(cartViewModel);
        }

        public ActionResult AddToCart(int id)
        {
            cartManager.AddToCart(id);
            return RedirectToAction("Index");
        }

        public int DownloadNumberOfItemsFromCart()
        {
            return cartManager.DownloadCartItemNumber();
        }


    }
}