using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer;
using ModelLayer;
using System.Collections.Generic;

namespace UnitTestJobMe
{
    [TestClass]
    public class SessionTest
    {
        /// <summary>
        /// Testing the creation of a session in the database. by going through the controller. 
        /// The controller method reurns a bool (boolean) that will be true if the create method was succesfull and vice verza.
        /// Then the bool is tested with the IsTrue, where the test will pass if the bool is returned true.
        /// </summary>
        [TestMethod]
        public void TestCreateSession()
        {
            //Arrange
            //Starting by making an instance of the Session and the Session controller, that are required for the test to be executed.
            DateTime startDateAndTime1 = new DateTime(2017, 11, 30, 12, 0, 0);
            DateTime endDateAndtime1 = new DateTime(2017, 11, 30, 12, 30, 0);
            Session session = new Session(1, startDateAndTime1, endDateAndtime1);
            DateTime startDateAndTime = new DateTime(2017, 11, 30, 12, 0, 0);
            DateTime endDateAndtime = new DateTime(2017, 11, 30, 16, 0, 0);
            int numbersOfInterviews = 4;
            Booking booking = new Booking(startDateAndTime, endDateAndtime, numbersOfInterviews, 6);
            booking.Id = 6;
            SessionCtr sessionCtr = new SessionCtr();

            //Act
            //Returns the 'inserted' bool, that comes from calling the Session Controllers create method with the given session object. 
            bool inserted = sessionCtr.Create(session, booking);

            //Assert
            //Is tested by checking wehter the inserted bool is true or false. If it is true i will pass.
            Assert.IsTrue(inserted);
        }

        [TestMethod]
        public void TestGet()
        {
            //Arrange
            Session session = new Session();
            session.Id = 1;
            SessionCtr sessionCtr = new SessionCtr();

            //Act
            Session returnedSession = sessionCtr.Get(session.Id);

            //Assert
            Assert.AreEqual(session.Id, returnedSession.Id);
        }

        [TestMethod]
        public void TestGetAll()
        {
            //Arrange
            Session session = new Session();
            session.Id = 1;
            SessionCtr sessionCtr = new SessionCtr();
            //Act
            List<Session> sessionTestList = sessionCtr.GetAll(session.Id);

            //Assert
            Assert.IsNotNull(sessionTestList);
        }

        [TestMethod]
        public void TestUpdate()
        {
            //Arrange
            DateTime startTime1 = new DateTime(2017, 11, 30, 12, 0, 0);
            DateTime endtime1 = new DateTime(2017, 11, 30, 12, 30, 0);
            Session session = new Session(1, startTime1, endtime1);
            SessionCtr sessionCtr = new SessionCtr();
            //Act
            bool check = sessionCtr.Update(session);

            //Assert
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void RemoveApplierFromSessionTest()
        {
            //Arrange
            DateTime startDateAndTime1 = new DateTime(2017, 11, 30, 12, 0, 0);
            DateTime endDateAndtime1 = new DateTime(2017, 11, 30, 12, 30, 0);
            Session session = new Session(1014, startDateAndTime1, endDateAndtime1);
            DateTime startDateAndTime = new DateTime(2017, 11, 30, 12, 0, 0);
            DateTime endDateAndtime = new DateTime(2017, 11, 30, 16, 0, 0);
            int numbersOfInterviews = 4;
            Booking booking = new Booking(startDateAndTime, endDateAndtime, numbersOfInterviews, 72);
            booking.Id = 103;
            SessionCtr sessionCtr = new SessionCtr();

            //Act
            sessionCtr.Create(session, booking);
            // Remove the session on a specific ApplierId.
            Session SessionToCheck = sessionCtr.Get(231);
            bool removed = sessionCtr.RemoveApplierFromSession(SessionToCheck);

            //Assert
            Assert.IsTrue(removed);
        }
    }

}
