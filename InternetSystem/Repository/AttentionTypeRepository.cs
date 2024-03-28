using BackendBootcamp.DBModels;

namespace BackendBootcamp.Repository
{
    public class AttentionTypeRepository
    {

        private BackendbootcampContext _Context;
        public AttentionTypeRepository(BackendbootcampContext ctx)
        {
            _Context = ctx;
        }
        public List<Attentiontype> GetAttentionsType()
        {
            var attentionsTypeFound = _Context.Attentiontypes.ToList();
            return attentionsTypeFound;
        }
    }
}
