using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstreCWEB.Data.Repository.Items;

namespace OstreCWEB.Services
{
    public interface ITestService
    {
        public List<Item> GetItems();
    }
}
