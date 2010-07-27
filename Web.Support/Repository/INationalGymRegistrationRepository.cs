using Web.Support.Domain;

namespace Web.Support.Repository
{
    public interface INationalGymRegistrationRepository
    {
        void RegisterMembership(GymMembershipConfiguration gymMembershipConfiguration);
    }
}