﻿using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.Core.Models.Shop;
using JeSuisCatho.Web.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JeSuisCatho.Web.API.Core.Dto;

namespace JeSuisCatho.Web.API.Persistence.DataAccess
{
    public class OrderDataAccessLayer : IOrderService
    {
        readonly JeSuisCathoDbContext _dbContext;
        public OrderDataAccessLayer(JeSuisCathoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateOrder(string userId, OrdersDto orderDetails)
        {
            try
            {
                StringBuilder orderid = new StringBuilder();
                orderid.Append(CreateRandomNumber(3));
                orderid.Append('-');
                orderid.Append(CreateRandomNumber(6));

                CustomerOrders customerOrder = new CustomerOrders
                {
                    OrderId = orderid.ToString(),
                    UserId = userId,
                    DateCreated = DateTime.Now.Date,
                    CartTotal = orderDetails.CartTotal
                };
                _dbContext.CustomerOrders.Add(customerOrder);
                _dbContext.SaveChanges();

                foreach (CartItemDto order in orderDetails.OrderDetails)
                {
                    CustomerOrderDetails productDetails = new CustomerOrderDetails
                    {
                        OrderId = orderid.ToString(),
                        ProductId = order.Product.Id,
                        Quantity = order.Quantity,
                        Price = order.Product.SellUnitPrice
                    };
                    _dbContext.CustomerOrderDetails.Add(productDetails);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<OrdersDto> GetOrderList(string userId)
        {
            List<OrdersDto> userOrders = new List<OrdersDto>();
            List<string> userOrderId = new List<string>();

            userOrderId = _dbContext.CustomerOrders.Where(x => x.UserId == userId)
                .Select(x => x.OrderId).ToList();

            foreach (string orderid in userOrderId)
            {
                OrdersDto order = new OrdersDto
                {
                    OrderId = orderid,
                    CartTotal = _dbContext.CustomerOrders.FirstOrDefault(x => x.OrderId == orderid).CartTotal,
                    OrderDate = _dbContext.CustomerOrders.FirstOrDefault(x => x.OrderId == orderid).DateCreated
                };

                List<CustomerOrderDetails> orderDetail = _dbContext.CustomerOrderDetails.Where(x => x.OrderId == orderid).ToList();

                order.OrderDetails = new List<CartItemDto>();

                foreach (CustomerOrderDetails customerOrder in orderDetail)
                {
                    CartItemDto item = new CartItemDto();

                    Product product = new Product
                    {
                        Id = customerOrder.ProductId,
                        InfoProductName = _dbContext.Products.FirstOrDefault(x => x.Id == customerOrder.ProductId && customerOrder.OrderId == orderid).InfoProductName,
                        SellUnitPrice = _dbContext.CustomerOrderDetails.FirstOrDefault(x => x.ProductId == customerOrder.ProductId && customerOrder.OrderId == orderid).Price
                    };

                    item.Product = product;
                    item.Quantity = _dbContext.CustomerOrderDetails.FirstOrDefault(x => x.ProductId == customerOrder.ProductId && x.OrderId == orderid).Quantity;

                    order.OrderDetails.Add(item);
                }
                userOrders.Add(order);
            }
            return userOrders.OrderByDescending(x => x.OrderDate).ToList();
        }

        int CreateRandomNumber(int length)
        {
            Random rnd = new Random();
            return rnd.Next(Convert.ToInt32(Math.Pow(10, length - 1)), Convert.ToInt32(Math.Pow(10, length)));
        }
    }
}
