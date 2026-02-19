using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Infrastructure.Context;
using LibraryApp.Application.Interfaces.MemberInterfaces;
using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repository
{
    public class MemberRespository : IMemberRepository
    {
        protected readonly LibraryDbContext _libraryDbContext;
        public MemberRespository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task<Member?> GetMemberByUserId(string userId)
        {
            return await _libraryDbContext.Members.FirstOrDefaultAsync(f => f.UserId == userId) ?? null;
        }
    }
}
