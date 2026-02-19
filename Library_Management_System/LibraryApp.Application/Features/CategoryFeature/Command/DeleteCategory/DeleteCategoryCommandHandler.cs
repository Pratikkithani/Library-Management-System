using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Exceptions;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using MediatR;

namespace LibraryApp.Application.Features.CategoryFeature.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryFindStatus = await _categoryRepository.GetCategoryByIdAsync(request.id);
            if (categoryFindStatus is null)
            {
                throw new NotFoundException($"Category with Id::{request.id} not found");

            }
            return await _categoryRepository.DeleteCategoryAsync(categoryFindStatus.CategoryId);
        }
    }
}


