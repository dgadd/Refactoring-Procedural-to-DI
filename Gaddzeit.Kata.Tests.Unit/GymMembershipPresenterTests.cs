using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using Web.Support.Domain;
using Web.Support.Presenter;
using Web.Support.Repository;
using Web.Support.View;

namespace Gaddzeit.Kata.Tests.Unit
{
    [TestFixture]
    public class GymMembershipPresenterTests
    {
        private MockRepository _mockRepository;
        private IGymMembershipConfigurationRepository _gymMembershipConfigurationRepository;
        private IInvoicePdfGeneratorRepository _invoicePdfGeneratorRepository;
        private INationalGymRegistrationRepository _nationalGymRegistrationRepository;
        private IGymMembershipRepository _gymMembershipRepository;
        private IGymMembershipView _gymMembershipView;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _gymMembershipConfigurationRepository = _mockRepository.StrictMock<IGymMembershipConfigurationRepository>();
            _invoicePdfGeneratorRepository = _mockRepository.StrictMock<IInvoicePdfGeneratorRepository>();
            _nationalGymRegistrationRepository = _mockRepository.StrictMock<INationalGymRegistrationRepository>();
            _gymMembershipRepository = _mockRepository.StrictMock<IGymMembershipRepository>();
            _gymMembershipView = _mockRepository.StrictMock<IGymMembershipView>();
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public void Constructor_FiveInterfaceInputs_AssignsSuccessMessageToViewMessage()
        {
            const string monthlyMembership = "Monthly Membership";
            const decimal amount = 35.00M;
            var gymMembershipConfiguration = new GymMembershipConfiguration(monthlyMembership, amount);

            Expect.Call(_gymMembershipConfigurationRepository.ConfigureMembership(monthlyMembership, amount)).Return(gymMembershipConfiguration);

            var pdfInvoice = new PdfInvoice { Name = monthlyMembership, Amount = amount };
            Expect.Call(_invoicePdfGeneratorRepository.CreatePdfInvoice(gymMembershipConfiguration)).Return(pdfInvoice);

            _nationalGymRegistrationRepository.RegisterMembership(gymMembershipConfiguration);

            _gymMembershipRepository.Save(gymMembershipConfiguration);

            _gymMembershipView.Message = "A gym membership has been created.";

            _mockRepository.ReplayAll();

            var sut = new GymMembershipPresenter(_gymMembershipConfigurationRepository,
                                                 _invoicePdfGeneratorRepository,
                                                 _nationalGymRegistrationRepository,
                                                 _gymMembershipRepository,
                                                 _gymMembershipView);
            sut.ConfigureGymMembership(monthlyMembership, amount);
        }
    }
}
