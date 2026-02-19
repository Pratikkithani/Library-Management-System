using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.CategoryFeature.Command.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Category>
    {
        readonly ICategoryRepository _categoryRepository;
        public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.AddCategoryAsync(request.category);
            return category;
        }
    }
}



