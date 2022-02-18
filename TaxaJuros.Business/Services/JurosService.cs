using TaxaJuros.Domain.Intefaces.Business;
using TaxaJuros.Domain.Model.DTO;

namespace TaxaJuros.Business.Services
{
    public class JurosService : IJurosServices
    {
        const double _taxa = 0.01;

        public JurosService() { }

        public JurosDTO GetJuros()
        {
            return  new JurosDTO { taxa = _taxa };
        }
    }
}
