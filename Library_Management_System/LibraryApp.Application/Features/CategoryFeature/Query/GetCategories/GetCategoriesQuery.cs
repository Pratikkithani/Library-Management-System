using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.CategoryFeature.Query.GetCategories
{
    public record GetCategoriesQuery : IRequest<IEnumerable<Category>>;
}
