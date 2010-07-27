using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Web.Support.Domain;

namespace Gaddzeit.Kata.Tests.Unit
{
    [TestFixture]
    public class GymMembershipConfigurationTests
    {
        [Test]
        public void TwoInstances_SameNameAndAmount_AreEqual()
        {
            const string monthlyMembership = "test";
            const decimal amount = 35.00M;
            var sut1 = new GymMembershipConfiguration(monthlyMembership, amount);
            var sut2 = new GymMembershipConfiguration(monthlyMembership, amount);
            Assert.AreEqual(sut1, sut2);
        }
    }
}
