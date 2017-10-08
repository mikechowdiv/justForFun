using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Models;
using System.Collections.Generic;

namespace RepoTest
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void CanReadDataFromDB()
        {
            StudentRepo studentRepository = new StudentRepo();
        List<Student> students = studentRepository.GetAll();
            Assert.AreEqual(2,students.Count);
        }
    }
}
