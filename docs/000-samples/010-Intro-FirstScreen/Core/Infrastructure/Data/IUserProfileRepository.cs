using System;
using System.Threading.Tasks;

namespace FirstScreen.Core.Infrastructure.Data
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> Get(string email);

        Task Update(UserProfile profile);
    }
}
