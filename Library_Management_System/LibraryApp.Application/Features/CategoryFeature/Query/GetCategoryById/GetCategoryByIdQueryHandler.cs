using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.CategoryFeature.Query.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var categoryFindStatus = await _categoryRepository.GetCategoryByIdAsync(request.id);
            return categoryFindStatus;
        }
    }
}
