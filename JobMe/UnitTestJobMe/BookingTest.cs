using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer;

namespace UnitTestJobMe
{
    [TestClass]
    public class BookingTest
    {
        /// <summary>
        /// Testing the creation of a session in the database. by going through the controller. 
        /// The controller method reurns a bool (boolean) that will be true if the create method was succesfull and vice verza.
        /// Then the bool is tested with the IsTrue, where the test will pass if the bool is returned true.
        /// </summary>
        [TestMethod]
        public void TestCreateBooking()
        {
            //Arrange
            //Starting by instanciating Booking and Booking controller, that are required for the test to be executed.
            Booking booking = new Booking();
            BookingCtr bookingCtr = new BookingCtr();

            //Act
            //Returns the 'inserted' boolean by calling the Booking Controllers Create method with the given Booking object
            bool inserted = bookingCtr.Create(booking);

            //Assert
            //Tests wheter or not the 'inserted' bool it true or not. If it is true the test will pass.
            Assert.IsTrue(inserted);
        }
    }
}
