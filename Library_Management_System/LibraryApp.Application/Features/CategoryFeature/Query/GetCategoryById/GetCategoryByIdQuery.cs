using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.CategoryFeature.Query.GetCategoryById
{
    public record GetCategoryByIdQuery(int id) : IRequest<Category>;

}
