using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain;

namespace LibraryApp.Application.Interfaces.MemberInterfaces
{
    public interface IMemberRepository
    {
        Task<Member?> GetMemberByUserId(string userId);

    }
}
