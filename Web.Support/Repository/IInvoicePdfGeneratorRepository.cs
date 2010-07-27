using Web.Support.Domain;

namespace Web.Support.Repository
{
    public interface IInvoicePdfGeneratorRepository
    {
        PdfInvoice CreatePdfInvoice(GymMembershipConfiguration gymMembershipConfiguration);
    }
}