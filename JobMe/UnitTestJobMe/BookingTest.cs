using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer;
using ModelLayer;
using System.Threading;
using System.Threading.Tasks;

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
        /// Testing the get method on meeting. Starting ny instanciating a new booking object with the given id 6.
        /// then the Booking controller has been created where the get method is located. 
        /// We then call the get method that returns a booking, where wi then compare the two object's Id to see if they are the same.
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

        /// <summary>
        /// Testing the update method for a Booking.
        /// We start by making a new Booking object and giving it the needed information.
        /// We then make a new booking controller that contains the method we need to test.
        /// The method is tested and returns a bool (true or false) where we check if the bool is true, where the test passes.
        /// </summary>
        [TestMethod]
        public void TestBookingUpdate()
        {
            //Arrange
            Booking booking = new Booking();
            booking.StartDateAndTime = new DateTime(2017, 12, 01, 12, 0, 0);
            booking.EndDateAndTime = new DateTime(2017, 12, 01, 16, 0, 0);
            booking.InterviewAmount = 6;
            booking.MeetingId = 6;
            booking.Id = 10;
            BookingCtr bookingCtr = new BookingCtr();

            //Act 
            bool updated = bookingCtr.Update(booking);

            //Assert
            Assert.IsTrue(updated);
        }



        [TestMethod]
        public void TestGetByMeetingId()
        {
            //Arrange

            int meetingId = 6;
            BookingCtr bookingCtr = new BookingCtr();

            //Act
            Booking returnedBooking = bookingCtr.GetBookingByMeetingId(meetingId);

            //Assert
            Assert.AreEqual(meetingId, returnedBooking.MeetingId);
        }

        [TestMethod]
        public void TestConcurrencyBookingofSession()
        {
            //Arrange
            DateTime startDateAndTime = new DateTime(2017, 12, 12, 12, 0, 0);
            DateTime endDateAndtime = new DateTime(2017, 12, 12, 16, 0, 0);
            int numbersOfInterviews = 4;
            Booking booking = new Booking(startDateAndTime, endDateAndtime, numbersOfInterviews, 6);
            Session session = new Session();
            BookingCtr bookingCtr = new BookingCtr();
            SessionCtr sessionCtr = new SessionCtr();



            //Act

            //Thread thread1 = new Thread(ThreadStart(sessionCtr.Create(session, booking)));

            //Assert
        }
    }
}
