using System.IdentityModel.Tokens.Jwt;
using Business.Abstract;
using CarBook.Domain.Entities;
using CarBook.Dto.Dtos.Auth;
using CarBook.Dto.Dtos.Order;
using CarBook.Dto.Dtos.ResponseDto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    

    
}