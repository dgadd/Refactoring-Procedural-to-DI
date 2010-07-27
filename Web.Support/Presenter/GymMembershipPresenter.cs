using System;
using Web.Support.Repository;
using Web.Support.View;

namespace Web.Support.Presenter
{
    public class GymMembershipPresenter
    {
        private readonly IGymMembershipConfigurationRepository _gymMembershipConfigurationRepository;
        private readonly IInvoicePdfGeneratorRepository _invoicePdfGeneratorRepository;
        private readonly INationalGymRegistrationRepository _nationalGymRegistrationRepository;
        private readonly IGymMembershipRepository _gymMembershipRepository;
        private readonly IGymMembershipView _gymMembershipView;

        public GymMembershipPresenter(IGymMembershipConfigurationRepository gymMembershipConfigurationRepository, 
            IInvoicePdfGeneratorRepository invoicePdfGeneratorRepository, 
            INationalGymRegistrationRepository nationalGymRegistrationRepository, 
            IGymMembershipRepository gymMembershipRepository, 
            IGymMembershipView gymMembershipView)
        {
            _gymMembershipConfigurationRepository = gymMembershipConfigurationRepository;
            _invoicePdfGeneratorRepository = invoicePdfGeneratorRepository;
            _nationalGymRegistrationRepository = nationalGymRegistrationRepository;
            _gymMembershipRepository = gymMembershipRepository;
            _gymMembershipView = gymMembershipView;
        }

        public void ConfigureGymMembership(string name, decimal amount)
        {
            var gymMembershipConfiguration = _gymMembershipConfigurationRepository.ConfigureMembership(name, amount);
            var pdfInvoice = _invoicePdfGeneratorRepository.CreatePdfInvoice(gymMembershipConfiguration);
            _nationalGymRegistrationRepository.RegisterMembership(gymMembershipConfiguration);
            _gymMembershipRepository.Save(gymMembershipConfiguration);
            _gymMembershipView.Message = "A gym membership has been created.";
        }
    }
}