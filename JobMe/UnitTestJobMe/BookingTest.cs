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
            //Variables to store wich applier is sat
            int applier1Id;
            bool applier1Bool = false;
            int applier2Id;
            bool applier2Bool = false;
            BookingCtr bookingCtr = new BookingCtr();
            SessionCtr sessionCtr = new SessionCtr();
            MeetingCtr meetingCtr = new MeetingCtr();
            ApplierCtr applierCtr = new ApplierCtr();

            // Get Appliers
            Applier applier1 = applierCtr.Get(4);
            Applier applier2 = applierCtr.Get(5);

            //Set the store variables
            applier1Id = applier1.Id;
            applier2Id = applier2.Id;

            // Get booking
            Booking booking1 = bookingCtr.Get(85);

            // Get Meeting
            Meeting meeting1 = meetingCtr.Get(booking1.MeetingId);

            // Get Session
            Session session1 = sessionCtr.Get(146);
            Session session2 = sessionCtr.Get(146);

            // Sets Applierd ID equal to sessions applier ID.
            session1.ApplierId = applier1.Id;
            session2.ApplierId = applier2.Id;


            //Act
            ThreadStart doIt;
            ThreadStart doItAgain;
            doIt = () => sessionCtr.Update(session1);
            doItAgain = () => sessionCtr.Update(session1);


            // Starts thread 1
            Thread thread1 = new Thread(doIt);
            thread1.Start();

            // Starts thread 2
            Thread thread2 = new Thread(doIt);
            thread2.Start();

            // Gets the current session after update
            Session sessionGet = sessionCtr.Get(54);

            // Checks to see which applier gets the current session.
            if (sessionGet.ApplierId == applier1Id)
            {
                applier1Bool = true;
            }
            else if (sessionGet.ApplierId == applier2Id)
            {
                applier2Bool = true;
            }
            else
            {
                //No code here. If not parsed the test fails
            }

            //Assert
            Assert.IsTrue(applier1Bool || applier2Bool);
        }
    }
}
