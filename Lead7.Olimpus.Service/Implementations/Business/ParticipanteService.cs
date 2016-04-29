using Lead7.Olimpus.Domain.Business;
using Lead7.Olimpus.Repository.Interfaces.Business;
using Lead7.Olimpus.Service.Interfaces.Business;

namespace Lead7.Olimpus.Service.Implementations.Business
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IParticipanteRepository _participanteRepository;

        public ParticipanteService(IParticipanteRepository repository)
        {
            _participanteRepository = repository;
        }

        public Participante GetParticipante(int id)
        {
            return _participanteRepository.Get(id);
        }
    }
}