using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Services.Seed
{
    public interface ISeeder
    {
        public Task SeedCharactersDb();
    }
}
