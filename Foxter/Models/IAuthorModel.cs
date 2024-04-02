using Foxter.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Models
{
    public interface IAuthorModel
    {
        public Task<bool> Create(Author authord);

        public Task<bool> Delete();

        public Task<Author?> Get();

    }
}
