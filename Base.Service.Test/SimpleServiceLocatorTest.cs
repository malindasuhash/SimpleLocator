using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Service.Test
{
    [TestClass]
    public class SimpleServiceLocatorTest
    {
        [TestMethod]
        public void Set_ShouldRegisterService()
        {
            // Arrange
            ISimpleServiceLocator location = new SimpleServiceLocator();

            // Act
            var t = new Dummy1();
            location.Set<IDummy>(t);

            // Assert
            var internalItems = location as SimpleServiceLocator;

            Assert.AreEqual(1, internalItems.Services.Count, "There should only be 1 item.");
            Assert.AreEqual(typeof(IDummy), internalItems.Services.First().Key, "Type should be of IDummy type.");
            Assert.IsNotNull(internalItems.Services.First().Value, "Object should not be null.");
            Assert.AreSame(t, internalItems.Services.First().Value, "Should return the same item.");
        } 

        [TestMethod]
        public void Set_RegisteringSameItemShouldOverwriteExisting()
        {
            // Arrange
            var location = new SimpleServiceLocator();

            var t1 = new Dummy1();
            var t2 = new Dummy1();

            location.Set<IDummy>(t1);

            // Act
            location.Set<IDummy>(t2);
            Assert.AreSame(t2, location.Services.First().Value, "Should have overwritten previous registration.");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceLocatorException))]
        public void Set_OnlyInterfacesCanBeRegistered()
        {
            // Arrange
            var location = new SimpleServiceLocator();

            var dummy = new Dummy1();

            // Act
            location.Set<Dummy1>(dummy);
        }

        [TestMethod]
        public void Get_ShouldReturnRegisteredInstance()
        {
            // Arrange
            var location = new SimpleServiceLocator();

            var dummy = new Dummy1();
            location.Set<IDummy>(dummy);
            
            // Act
            var instance = location.Get<IDummy>();

            // Act
            Assert.AreSame(dummy, instance, "Should return the same instance.");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceLocatorException))]
        public void Get_WhenRequistedTypeIsNotFound_ShouldThrowException()
        {
            // Arrange
            var location = new SimpleServiceLocator();

            // Act
            location.Get<IDummy>();
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceLocatorException))]
        public void Initialise_WhenCalledSecondTime_ShouldThrowException()
        {
            // Arrange
            var location = new SimpleServiceLocator();

            location.Initialise();

            // Act
            location.Initialise();
        }
    }

    internal interface IDummy
    {
    }

    internal class Dummy1 : IDummy
    {
    }
}
