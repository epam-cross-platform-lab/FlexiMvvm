using System.Threading.Tasks;

namespace FirstScreen.Core.Infrastructure.Data
{
    public class UserProfileRepository : IUserProfileRepository
    {
        public async Task<UserProfile> Get(string email)
        {
            return await Task.FromResult(new UserProfile
            {
                Email = email,
                FirstName = "Jeremy",
                LastName = "Simpson"
            });
        }

        public async Task Update(UserProfile profile)
        {
            await Task.Delay(100);

            System.Diagnostics.Debug.WriteLine(
                $"Updated: {profile.Email} -> {profile.FirstName} {profile.LastName}");
        }
    }
}
