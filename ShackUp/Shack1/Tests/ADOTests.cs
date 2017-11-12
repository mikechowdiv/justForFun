using Data.ADO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ADOTests
    {
        [Test]
        public void CanLoadStates()
        {
            var repo = new StatesRepoADO() { };
            var states = repo.GetAll();
            Assert.AreEqual(3, states.Count);
        }
    }
}
