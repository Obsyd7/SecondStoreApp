using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Hangfire;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SecondStoreApp.DAL;
using SecondStoreApp.Infrastructure;
using SecondStoreApp.Models;
using SecondStoreApp.ViewModels;

namespace SecondStoreApp.Controllers
{
    public class CartController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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

        public ActionResult DeleteFromCart(int courseId)
        {
            var itemNumber = cartManager.DeleteFromCart(courseId);
            var cartItemNumber = cartManager.DownloadCartItemNumber();
            var cartValue = cartManager.DownloadCartValue();

            var result = new CartDeleteViewModel()
            {
                DeletedItemId = courseId,
                DeletedItemNumber = cartItemNumber,
                CartTotalCost = cartValue,
                CartItemNumber = itemNumber
            };

            return Json(result);
        }

        public async Task<ActionResult> Pay()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order
                {
                    FirstName =  user.UserData.FirstName,
                    LastName = user.UserData.LastName,
                    Address = user.UserData.Address,
                    City = user.UserData.City,
                    Postcode = user.UserData.Postcode,
                    Email = user.UserData.Email,
                    Phone = user.UserData.Phone
                };

                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Account", new {returnUrl = Url.Action("Pay", "Cart")});
            }

            
        }

        [HttpPost]
        public async Task<ActionResult> Pay(Order orderDetail)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var newOrder = cartManager.CreateOrder(orderDetail, userId);

                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);

                cartManager.EmptyCart();

                string url = Url.Action("ConfirmOrderEmail", "Cart", new { orderId = newOrder.OrderId, lastName = newOrder.LastName}, Request.Url.Scheme);

                BackgroundJob.Enqueue(() => Call(url));

                //mailService.SendConfirmationOrder(newOrder);

                return RedirectToAction("ConfirmOrder");
            }
            else
                return View(orderDetail);
        }

        public void Call(string url)
        {
            var req = WebRequest.Create(url);
            req.GetResponseAsync();
        }

        public ActionResult ConfirmOrderEmail(int orderId, string lastName)
        {
            var order = db.Orders.Include("OrderPosition").Include("OrderPosition.Course").SingleOrDefault(o => o.OrderId == orderId && o.LastName == lastName);

            if (order == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var email = new OrderConfirmationEmail();
            email.To = order.Email;
            email.From = "secondstore@gmail.com";
            email.Value = order.OrderValue;
            email.OrderNumber = order.OrderId;
            email.OrderPosition = order.OrderPosition;

            email.Send();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult ConfirmOrder()
        {
            return View();
        }
    }
}