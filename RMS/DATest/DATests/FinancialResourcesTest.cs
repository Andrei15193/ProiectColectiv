//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DALayer.DBImpl;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using ResourceManagementSystem.BusinessLogic.Entities;
//using ResourceManagementSystem.DataAccess.DAOInterface;

//namespace DATest.DATests
//{
//    [TestClass]
//    public class FinancialResourcesTest
//    {
//        [TestMethod]
//        public void GetAllTest()
//        {
//            IFinancialResources financialResources = new FinancialResources();
//            List<FinancialResource> financialRes = financialResources.All as List<FinancialResource>;
//            Assert.IsNotNull(financialRes);
//        }

//        [TestMethod]
//        public void AddFinancialResourceTest()
//        {
//            IFinancialResources financialResources = new FinancialResources();
//            List<FinancialResource> beforeResources = financialResources.All as List<FinancialResource>;
//            Assert.IsNotNull(beforeResources);

//            FinancialResource fr = new FinancialResource(Convert.ToUInt32(new Random().Next(20, 100)), Currency.RON);
//            financialResources.AddFinancialResource(fr);

//            List<FinancialResource> afterResources = financialResources.All as List<FinancialResource>;
//            Assert.IsNotNull(afterResources);

//            Assert.AreEqual(beforeResources.Count + 1, afterResources.Count);

//            bool found = false;
//            for (int i = 0; i < afterResources.Count && !found; i++)
//            {
//                if (afterResources[i].Currency == fr.Currency && afterResources[i].Value == fr.Value)
//                {
//                    //there is currently no better check than this.
//                    found = true;
//                }
//            }

//            Assert.IsTrue(found, "The record was not added into the database!");
//        }
//    }
//}
