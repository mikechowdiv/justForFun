using Data.ADO;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestADO
    {
        [Test]
        public void CanLoadStates()
        {
            var repo = new StatesRepoAdo();
            var states = repo.GetAll();
            Assert.AreEqual(3, states.Count);
            Assert.AreEqual("KY", states[0].StateId);
            Assert.AreEqual("Kentucky", states[0].StateName);
        }

        [Test]
        public void CanLoadBathroomType()
        {
            var repo = new BathroomTypesRepoAdo();
            var types = repo.GetAll();
            Assert.AreEqual(3, types.Count);
            Assert.AreEqual(1, types[0].BathroomTypeId);
            Assert.AreEqual("Indoor", types[0].BathroomTypeName);
        }
    }
}
