
using BusinessLayer.Abstract;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Dto.Dtos.Auth;
using CarBook.Dto.Dtos.ReservationDto;
using CarBook.Dto.Dtos.ResponseDto;
using CarBook.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using System;
using Castle.Core.Smtp;
using Order = CarBook.Domain.Entities.Order;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _orderService;
        protected ResponseDto _response;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
            _response = new ResponseDto();
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var result = await _orderService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var result = await _orderService.GetByIdAsync(id);
            return Ok(result);
        }
        

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.RemoveAsync(new Order { Id = id });
            return Ok("Order deleted successfully");
        }

      
        [HttpPost("CreateStripeSession")]
        public async Task<ResponseDto> CreateStripeSession([FromBody] StripeRequestDto stripeRequestDto)
        {
            try
            {

                var options = new SessionCreateOptions
                {
                    SuccessUrl = stripeRequestDto.ApprovedUrl,
                    CancelUrl = stripeRequestDto.CancelUrl,
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",

                };




                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(stripeRequestDto.OrderHeader.TotalPrice * 100), // $20.99 -> 2099
                        Currency = "nok",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = stripeRequestDto.OrderHeader.CarModel
                        }
                    },
                    Quantity = 1
                };

                options.LineItems.Add(sessionLineItem);


                var service = new SessionService();
                Session session = service.Create(options);
                stripeRequestDto.StripeSessionUrl = session.Url;
                _orderService.UpdateStripeSessionId(stripeRequestDto.OrderHeader.Id, session.Id);

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }

            return _response;
        }


      
        [HttpPost("ValidateStripeSession")]
        public async Task<ResponseDto> ValidateStripeSession([FromBody] int orderHeaderId)
        {
            try
            {

                var orderHeader = await _orderService.GetByIdAsync(orderHeaderId);

                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);

                var paymentIntentService = new PaymentIntentService();
                PaymentIntent paymentIntent = paymentIntentService.Get(session.PaymentIntentId);

                if (paymentIntent.Status == "succeeded")
                {
                    //then payment was successful
                    orderHeader.PaymentIntentId = paymentIntent.Id;
                    orderHeader.Status = OrderServiceDto.Status_Approved;
                    await _orderService.UpdateAsync(orderHeader);
                    RewardsDto rewardsDto = new()
                    {
                        OrderId = orderHeader.Id,
                        RewardsActivity = Convert.ToInt32(orderHeader.TotalPrice),
                        UserId = orderHeader.UserId
                    };
                }

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }

            return _response;
        }


        [Authorize]
        [HttpPost("UpdateOrderStatus/{orderId:int}")]
        public async Task<ResponseDto> UpdateOrderStatus(int orderId, [FromBody] string newStatus)
        {
            try
            {
                var orderHeader = await _orderService.GetByIdAsync(orderId);
                if (orderHeader != null)
                {
                    if (newStatus == OrderServiceDto.Status_Cancelled)
                    {
                        //we will give refund
                        var options = new RefundCreateOptions
                        {
                            Reason = RefundReasons.RequestedByCustomer,
                            PaymentIntent = orderHeader.PaymentIntentId
                        };

                        var service = new RefundService();
                        Refund refund = service.Create(options);
                    }

                    orderHeader.Status = newStatus;
                    await _orderService.UpdateAsync(orderHeader);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
            }

            return _response;
        }

    }
}
