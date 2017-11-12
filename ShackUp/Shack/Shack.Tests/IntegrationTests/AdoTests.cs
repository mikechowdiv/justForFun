using NUnit.Framework;
using ShackUp.Data.ADO;
using ShackUp.Models.Queries;
using ShackUp.Models.Tables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shack.Tests.IntegrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadStates()
        {
            var repo = new StatesRepoADO();

            var states = repo.GetAll();

            Assert.AreEqual(3, states.Count);
            Assert.AreEqual("KY", states[0].StateId);
            Assert.AreEqual("Kentucky", states[0].StateName);
        }

        [Test]
        public void CanLoadBathroomType()
        {
            var repo = new BathroomTypesRepoADO();
            var types = repo.GetAll();

            Assert.AreEqual(3, types.Count);
            Assert.AreEqual(1, types[0].BathroomTypeId);
            Assert.AreEqual("Indoor", types[0].BathroomTypeName);
        }

        [Test]
        public void CanLoadListing()
        {
            var repo = new ListingsRepoADO();
            var listing = repo.GetById(1);

            Assert.IsNotNull(listing);
            Assert.AreEqual(1, listing.ListingId);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", listing.UserId);
            Assert.AreEqual("OH", listing.StateId);
            Assert.AreEqual(3, listing.BathroomTypeId);
            Assert.AreEqual("Test shack1", listing.Nickname);
            Assert.AreEqual("Cleveland",listing.City);
            Assert.AreEqual(100M, listing.Rate);
            Assert.AreEqual(400M, listing.SquareFootage);
            Assert.AreEqual(false,listing.HasElectric);
            Assert.AreEqual(true,listing.HasHeat);
            Assert.AreEqual("placeholder.png", listing.ImageFileName);
        }

        [Test]
        public void NotFoundListingReturnNull()
        {
            var repo = new ListingsRepoADO();
            var listing = repo.GetById(100000);

            Assert.IsNull(listing);
        }

        [Test]
        public void CanAddListing()
        {
            Listing listingToAdd = new Listing();
            var repo = new ListingsRepoADO();

            listingToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            listingToAdd.StateId = "OH";
            listingToAdd.Nickname = "My Test Shack";
            listingToAdd.BathroomTypeId = 1;
            listingToAdd.City = "Columbus";
            listingToAdd.Rate = 50M;
            listingToAdd.SquareFootage = 100M;
            listingToAdd.HasElectric = true;
            listingToAdd.HasHeat = true;
            listingToAdd.ImageFileName = "placeholder.png";

            repo.Insert(listingToAdd);

            Assert.AreEqual(21, listingToAdd.ListingId);


        }


        [Test]
        public void CanUpdateListing()
        {
            Listing listingToAdd = new Listing();
            var repo = new ListingsRepoADO();

            listingToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            listingToAdd.StateId = "OH";
            listingToAdd.Nickname = "My Test Shack";
            listingToAdd.BathroomTypeId = 1;
            listingToAdd.City = "Columbus";
            listingToAdd.Rate = 50M;
            listingToAdd.SquareFootage = 100M;
            listingToAdd.HasElectric = true;
            listingToAdd.HasHeat = true;
            listingToAdd.ImageFileName = "placeholder.png";

            repo.Insert(listingToAdd);

            listingToAdd.StateId = "KY";
            listingToAdd.Nickname = "My updated shack";
            listingToAdd.BathroomTypeId = 2;
            listingToAdd.City = "Louisville";
            listingToAdd.Rate = 25M;
            listingToAdd.SquareFootage = 75M;
            listingToAdd.HasElectric = false;
            listingToAdd.HasHeat = false;
            listingToAdd.ImageFileName = "updated.png";

            repo.Update(listingToAdd);

            var updatedListing = repo.GetById(21);

            Assert.AreEqual("KY",updatedListing.StateId);
            Assert.AreEqual("My updated shack",updatedListing.Nickname);
            Assert.AreEqual(2, updatedListing.BathroomTypeId);
            Assert.AreEqual("Louisville",updatedListing.City);
            Assert.AreEqual(25M,updatedListing.Rate);
            Assert.AreEqual(75M, updatedListing.SquareFootage);
            Assert.AreEqual(false,updatedListing.HasElectric);
            Assert.AreEqual(false,updatedListing.HasHeat);
            Assert.AreEqual("updated.png",updatedListing.ImageFileName);
        }

        [Test]
        public void CanDeleteListing()
        {
            Listing listingToAdd = new Listing();
            var repo = new ListingsRepoADO();

            listingToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            listingToAdd.StateId = "OH";
            listingToAdd.Nickname = "My Test Shack";
            listingToAdd.BathroomTypeId = 1;
            listingToAdd.City = "Columbus";
            listingToAdd.Rate = 50M;
            listingToAdd.SquareFootage = 100M;
            listingToAdd.HasElectric = true;
            listingToAdd.HasHeat = true;
            listingToAdd.ImageFileName = "placeholder.png";

            repo.Insert(listingToAdd);

            var loaded = repo.GetById(21);
            Assert.IsNotNull(loaded);
            repo.Delete(21);
            loaded = repo.GetById(21);
            Assert.IsNull(loaded);
        }

        [Test]
        public void CanLoadRecentListing()
        {
            var repo = new ListingsRepoADO();
            List<ListingShortItem>listings = repo.GetRecent().ToList();
            Assert.AreEqual(5, listings.Count());

            Assert.AreEqual(6, listings[0].ListingId);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", listings[0].UserId);
            Assert.AreEqual(150M, listings[0].Rate);
            Assert.AreEqual("Cleveland", listings[0].City);
            Assert.AreEqual("OH", listings[0].StateId);
            Assert.AreEqual("placeholder.png", listings[0].ImageFileName);
        }
    }
}
