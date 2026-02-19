using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using LibraryApp.Domain;
using MediatR;
using static LibraryApp.Application.Features.CategoryFeature.Query.GetCategories.GetCategoriesQuery;

namespace LibraryApp.Application.Features.CategoryFeature.Query.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
    {
        readonly ICategoryRepository _categoryRepository;
        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var allCategories = await _categoryRepository.GetCategories();
            return allCategories;
        }
    }
}

       
