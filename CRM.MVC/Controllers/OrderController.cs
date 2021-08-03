using AutoMapper;
using AutoMapper.QueryableExtensions;
using CRM.Models;
using CRM.MVC.ViewModels;
using CRM.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CRM.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        public JsonResult ViewOrdersRevenues(int orderId = 0)
        {
            List<OrderRevenue> revenues = unitOfWork.OrderRevenueRepository.GetOrderRevenues(orderId);
            return Json(new { data = revenues }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ViewOrdersExpenses(int orderId = 0)
        {
            List<OrderExpense> expenses = unitOfWork.OrderExpenseRepository.GetOrderExpenses(orderId);
            return Json(new { data = expenses }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddEditOrderExpense(int id = 0,int orderId = 0)
        {
            var orderExpenseDto = new OrderExpensesShowDto();
            //Add
            if (id == 0)
            {
                orderExpenseDto.OrderId = orderId;
                return View(orderExpenseDto);
            }
            //edit
            else
            {
                OrderExpense orderExpense = unitOfWork.OrderExpenseRepository.GetOneBy(x => x.Id == id);
                Mapper.Map(orderExpense, orderExpenseDto);
                return View(orderExpenseDto);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditOrderExpense(OrderExpensesShowDto orderExpenseDto)
        {
            var orderExpense = new OrderExpense();
            Mapper.Map(orderExpenseDto, orderExpense);

            switch (orderExpense.Id)
            {
                case 0:
                    {
                        unitOfWork.OrderExpenseRepository.Insert(orderExpense);
                        unitOfWork.Complete();
                        return Json(new { success = true, message = "تم اضافةالمصروف بنجاح" }, JsonRequestBehavior.AllowGet);
                    }
                default:
                    unitOfWork.OrderExpenseRepository.Update(orderExpense);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل الاوردر بنجاح" }, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public JsonResult DisableOrder(int Id)
        {
            //prepare order for disable
            Order order = unitOfWork.OrdersRepository.GetOneBy(x => x.Id == Id);
            var payed = unitOfWork.OrdersRepository.GetSumPayed(order.Id);
            
            //store order in OldOrders table
            var oldOrder = new OldOrder()
            {
                OldPrice = order.Price,
                OrderId = order.Id
            };

            order.Price = payed;
            order.Required = payed - order.Discount;
            order.isDone = true;
            unitOfWork.OrdersRepository.Update(order);
            unitOfWork.OldOrderRepository.Insert(oldOrder);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم انهاء الاوردر بنجاح" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EnableOrder(int id)
        {
            OldOrder oldOrder = unitOfWork.OldOrderRepository.GetOneBy(x => x.OrderId == id);
            Order order = unitOfWork.OrdersRepository.GetOneBy(x => x.Id == id);

            order.isDone = false;
            order.Price = oldOrder.OldPrice;
            order.Required = oldOrder.OldPrice - order.Discount;

            unitOfWork.OldOrderRepository.Delete(oldOrder.Id);
            unitOfWork.OrdersRepository.Update(order);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم اعادة الاوردر للخدمة،وبطّل لعب بقى" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewLatestOrdersIndex()
        {
            return View();
        }

        public JsonResult ViewLatestOrders()
        {
            List<Order> orders = unitOfWork.OrdersRepository
                .GetAll()
                .Include(x=>x.Client)
                .OrderByDescending(x => x.OrderDate)
                .ToList();

            var orderDtos = new List<OrdersShowDto>();
            Mapper.Map(orders, orderDtos);

            if (orders.Count > 0)
            {
                foreach (var order in orderDtos)
                {
                    var payed = unitOfWork.OrdersRepository.GetSumPayed(order.Id);
                    order.Payed = payed;
                    order.Remaining = order.Required - payed;
                    // order.Expenses = make this
                }
            }
            return Json(new { data = orderDtos }, JsonRequestBehavior.AllowGet);
        }



        public JsonResult ViewAllOrdersByClientId(int clientId)
        {
            List<Order> orders = unitOfWork.OrdersRepository
                .GetAll(x => x.ClientId == clientId)
                .OrderBy(x => !x.isDone).ThenByDescending(x => x.OrderDate)
                .ToList();

            var orderDtos = new List<OrdersShowDto>();
            Mapper.Map(orders, orderDtos);

            if (orders.Count > 0)
            {
                foreach (var order in orderDtos)
                {
                    var payed = unitOfWork.OrdersRepository.GetSumPayed(order.Id);
                    order.Payed = payed;
                    order.Remaining = order.Required - payed;
                    // order.Expenses = make this
                }
            }
            return Json(new { data = orderDtos }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteRevenue(int Id)
        {
            OrderRevenue orderRev = unitOfWork.OrderRevenueRepository.GetOneBy(x => x.Id == Id);
            //Make order not done anyway after deleting any revenue
            Order order = unitOfWork.OrdersRepository.GetOneBy(x => x.Id == orderRev.OrderId);
            order.isDone = false;
            unitOfWork.OrdersRepository.Update(order);

            unitOfWork.OrderRevenueRepository.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف الدفع بنجاح" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteExpense(int Id)
        {
            unitOfWork.OrderExpenseRepository.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف المصروف بنجاح" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Show all orders by client id
        /// </summary>
        /// <param name="Id">client id</param>
        /// <returns>client dto</returns>
        public ActionResult ViewOrders(int Id)
        {
            var clientDto = new ClientDto();
            Client client = unitOfWork.ClientsRepository.GetOneBy(x => x.Id == Id);

            Mapper.Map(client, clientDto);
            return View(clientDto);
        }


        /// <summary>
        /// Shows all expenses and reveneues by order id
        /// </summary>
        /// <param name="Id">order id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ShowRevenuesExpenses(int Id = 0)
        {
            Order order = unitOfWork.OrdersRepository.GetOneBy(x => x.Id == Id);
            //Main Page contains tab control
            //that renders ViewOrdersRevenues-ViewOrdersExpenses
            var dto = new ShowRevenuesExpenses()
            {
                OrderId = Id,
                OrderName = order.Name,
                isDone = order.isDone
            };
            return View(dto);
        }


        [HttpGet]
        public ActionResult AddEditOrderRevenue(int id = 0, int orderId = 0)
        {
            Order order = unitOfWork.OrdersRepository.GetOneBy(x => x.Id == orderId);
            var oldPayed = unitOfWork.OrdersRepository.GetSumPayed(order.Id);
            var oldRemaining = (order.Price - order.Discount) - oldPayed;

            var addOrderRevenueDto = new OrderRevenuesAddDto();    
            Mapper.Map(order, addOrderRevenueDto);
            addOrderRevenueDto.OldPayed = oldPayed;
            addOrderRevenueDto.OldRemaining = oldRemaining;
            //Add
            if (id == 0)
            {
                return View(addOrderRevenueDto);
            }
            //edit
            else
            {
                return View(addOrderRevenueDto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditOrderRevenue(OrderRevenuesAddDto addOrderRevenueDto)
        {
            var orderRevenue = new OrderRevenue()
            {
                OrderId = addOrderRevenueDto.OrderId,
                Amount = addOrderRevenueDto.Amount,
                Order = null,
                OptionalNote = addOrderRevenueDto.OptionalNote,
                RevenueDate = addOrderRevenueDto.RevenueDate
            };
            //check if order is done
            var payedNow = addOrderRevenueDto.Amount;
            var payedBefore = unitOfWork.OrdersRepository.GetSumPayed(addOrderRevenueDto.OrderId);
            var price = unitOfWork.OrdersRepository.GetOrderPrice(addOrderRevenueDto.OrderId);        
            if (price == payedBefore + payedNow)   //اوردر منتهي
            {
                Order order = unitOfWork.OrdersRepository.GetOneBy(x => x.Id == addOrderRevenueDto.OrderId);
                order.isDone = true;
                //ضيف السعر في الجدول دة عشان تعرف تعمل اعادة للاوردر بعد كدة لو عايز
                var oldOrder = new OldOrder()
                {
                    OldPrice = order.Price,
                    OrderId = order.Id
                };
                unitOfWork.OldOrderRepository.Insert(oldOrder);
                unitOfWork.OrdersRepository.Update(order);
            }
            //add
            switch (addOrderRevenueDto.Id)
            {
                case 0:
                    unitOfWork.OrderRevenueRepository.Insert(orderRevenue);
                    unitOfWork.Complete();

                    return Json(new { success = true, message = "تم اضافة الدفع بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    return Json(new { success = true, message = "تم تعديل الدفع بنجاح" }, JsonRequestBehavior.AllowGet);
            }
        }












        [HttpGet]
        public ActionResult AddEditOrder(int id = 0, int clientId = 0)
        {
            var orderAddDto = new OrdersAddDto();

            //Add operation
            if (id == 0)
            {
                orderAddDto.ClientId = clientId;
                return View(orderAddDto);
            }
            //edit operation
            else
            {
                Order order = unitOfWork.OrdersRepository.GetOneBy(x => x.Id == id);
                Mapper.Map(order, orderAddDto);
                return View(orderAddDto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditOrder(OrdersAddDto orderAddDto)
        {
            var order = new Order();
            Mapper.Map(orderAddDto, order);

            switch (orderAddDto.Id)
            {  //add operation
                case 0:
                    {
                        if (orderAddDto.Required == orderAddDto.Payed)
                        {
                            order.isDone = true;
                        }
                        var orderRevenue = new OrderRevenue()
                        {
                            RevenueDate = order.OrderDate,
                            OptionalNote = "عربون",
                            Amount = orderAddDto.Payed
                        };
                        order.Revenues.Add(orderRevenue);
                        unitOfWork.OrdersRepository.Insert(order);
                        unitOfWork.Complete();
                        return Json(new { success = true, message = "تم اضافةالاوردر بنجاح" }, JsonRequestBehavior.AllowGet);
                    }
                default:
                    unitOfWork.OrdersRepository.Update(order);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل الاوردر بنجاح" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteOrder(int Id)
        {
            unitOfWork.OrdersRepository.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف الاوردر بنجاح" }, JsonRequestBehavior.AllowGet);
        }
    }
}
