using Musicalog.Data.Models;
using Musicalog.Data.Repositories.Interfaces;

namespace Musicalog.Data.Repositories
{
    public class LabelsRepository : SqlRepository<Label>, ILabelsRepository
    {
        public LabelsRepository(AlbumsContext context) : base(context)
        { }
    }
}
