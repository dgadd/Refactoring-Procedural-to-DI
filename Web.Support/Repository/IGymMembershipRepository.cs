using Web.Support.Domain;

namespace Web.Support.Repository
{
    public interface IGymMembershipRepository
    {
        void Save(GymMembershipConfiguration gymMembershipConfiguration);
    }
}