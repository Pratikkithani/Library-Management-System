using System.Security.Claims;
using LibraryApp.Application.Features.CategoryFeature.Command.AddCategory;
using LibraryApp.Application.Features.CategoryFeature.Command.DeleteCategory;
using LibraryApp.Application.Features.CategoryFeature.Query.GetCategories;
using LibraryApp.Application.Features.CategoryFeature.Query.GetCategoryById;
using LibraryApp.Application.Features.LoanFeature.Command.BorrowBook;
using LibraryApp.Application.Features.LoanFeature.Command.ReturnBook;
using LibraryApp.Application.Features.LoanFeature.Query.GetLoanById;
using LibraryApp.Application.Features.LoanFeature.Query.GetLoans;
using LibraryApp.Application.Features.LoanFeature.Query.GetLoansByUserId;
using LibraryApp.Application.Interfaces;
using LibraryApp.Application.Models.LoanDto;
using LibraryApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class LoanController : ControllerBase
    {
        readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        readonly ILoggedInUserService _loggedInUserService;
        public LoanController(IMediator mediator, IHttpContextAccessor httpContextAccessor, ILoggedInUserService loggedInUserService)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _loggedInUserService = loggedInUserService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLoansAsync()
        {
            var allLoans = await _mediator.Send(new GetLoansQuery());
            return Ok(allLoans);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetLoansByUserIdAsync()
        {
            var userid = _loggedInUserService.UserId;
            if (userid == null)
            {
                return Unauthorized();
            }
            var allLoans = await _mediator.Send(new GetLoansByUserIdQuery(userid));
            return Ok(allLoans);
        }

        [HttpPost]
        public async Task<IActionResult> BorrowBookAsync(LoanDto loandto)
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid").Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var result = await _mediator.Send(new BorrowBookCommand(loandto, userId));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetLoanByIdQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ReturnBookAsync(int id)
        {
            var result = await _mediator.Send(new ReturnBookCommand(id));
            return Ok(result);

        }
    }
}
