using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer;
using ModelLayer;

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
            DateTime startDateAndTime = new DateTime(2017, 11, 30, 12, 0, 0);
            DateTime endDateAndtime = new DateTime(2017, 11, 30, 16, 0, 0);
            int numbersOfInterviews = 4;
            Booking booking = new Booking(startDateAndTime, endDateAndtime, numbersOfInterviews, 6);
            BookingCtr bookingCtr = new BookingCtr();

            //Act
            //Returns the 'inserted' boolean by calling the Booking Controllers Create method with the given Booking object
            bool inserted = bookingCtr.Create(booking);

            //Assert
            //Tests wheter or not the 'inserted' bool it true or not. If it is true the test will pass.
            Assert.IsTrue(inserted);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            Booking booking = new Booking();
            booking.Id = 6;
            BookingCtr bookingCtr = new BookingCtr();

            //Act
            Booking returnedBooking = bookingCtr.Get(booking.Id);

            //Assert
            Assert.AreEqual(booking.Id, returnedBooking.Id);
        }
    }
}
