using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecondStoreApp.DAL;
using SecondStoreApp.Models;

namespace SecondStoreApp.Infrastructure
{
    public class CartMenager
    {
        private StoreDbContext db;

        private ISessionMenager session;

        public CartMenager(ISessionMenager session, StoreDbContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<CartItem> DownloadCart()
        {
            List<CartItem> cart;

            if (session.Get<List<CartItem>>(Const.CartSessionKey)==null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = session.Get<List<CartItem>>(Const.CartSessionKey);
            }

            return cart;
        }

        public void AddToCart(int courseId)
        {
            var cart = DownloadCart();
            var cartItem = cart.Find(c => c.Course.CourseId == courseId);

            if (cartItem != null)
            {
                cartItem.Number++;
            }
            else
            {
                var toAddCourse = db.Courses.SingleOrDefault(c => c.CourseId == courseId);

                if (toAddCourse != null)
                {
                    var newCartItem = new CartItem()
                    {
                        Course = toAddCourse,
                        Number = 1,
                        Value = toAddCourse.CoursePrice
                    };

                    cart.Add(newCartItem);
                }
            }

            session.Set(Const.CartSessionKey, cart);
        }

        public int DeleteFromCart(int courseId)
        {
            var cart = DownloadCart();
            var cartPosition = cart.Find(c => c.Course.CourseId == courseId);

            if (cartPosition != null)
            {
                if (cartPosition.Number > 1)
                {
                    cartPosition.Number--;
                    return cartPosition.Number;
                }
                else
                {
                    cart.Remove(cartPosition);
                }
            }

            return 0;
        }

        public decimal DownloadCartValue()
        {
            var cart = DownloadCart();
            return cart.Sum(c => (c.Number) * c.Value);
        }

        public int DownloadCartItemNumber()
        {
            var cart = DownloadCart();
            int number = cart.Sum(c => c.Number);
            return number;
        }

        public Order CreateOrder(Order newOrder, int userId)
        {
            var cart = DownloadCart();

            newOrder.DateAdded = DateTime.Now;
            
            //newOrder.userId = userId;

            db.Orders.Add(newOrder);

            if (newOrder.OrderPosition != null)
                newOrder.OrderPosition = new List<OrderPosition>();
                decimal cartValue = 0;
             
                foreach (var item in cart)
                {
                    var newOrderPosition = new OrderPosition()
                    {
                        CourseId = item.Course.CourseId,
                        Volume = item.Number,
                        OrderCost = item.Value
                    };

                    cartValue += (item.Number * item.Course.CoursePrice);
                    newOrder.OrderPosition.Add(newOrderPosition);
                }

                newOrder.OrderValue = cartValue;
                db.SaveChanges();

                return newOrder;
        }
    }
    
}