using Web.Support.Domain;

namespace Web.Support.Repository
{
    public interface IGymMembershipConfigurationRepository
    {
        GymMembershipConfiguration ConfigureMembership(string monthlyMembership, decimal amount);
    }
}