using System;

namespace Web.Support.Domain
{
    public class GymMembershipConfiguration
    {
        private readonly string _monthlyMembership;
        private readonly decimal _amount;

        public GymMembershipConfiguration(string monthlyMembership, decimal amount)
        {
            _monthlyMembership = monthlyMembership;
            _amount = amount;
        }

        public decimal Amount
        {
            get { return _amount; }
        }

        public string MonthlyMembership
        {
            get { return _monthlyMembership; }
        }

        public override bool Equals(object obj)
        {
            var other = (GymMembershipConfiguration) obj;
            return other.MonthlyMembership.Equals(this.MonthlyMembership)
                   && other.Amount.Equals(this.Amount);
        }

        public override int GetHashCode()
        {
            return this.MonthlyMembership.GetHashCode() + this.Amount.GetHashCode();
        }
    }
}