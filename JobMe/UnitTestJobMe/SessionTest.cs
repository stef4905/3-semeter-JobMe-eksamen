using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer;
using ModelLayer;

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
            Session session = new Session();
            Booking booking = new Booking();
            SessionCtr sessiongCtr = new sessionCtr();

            //Act
            //Returns the 'inserted' bool, that comes from calling the Session Controllers create method with the given session object. 
            bool inserted = sessionCtr.Create(session, booking);

            //Assert
            //Is tested by checking wehter the inserted bool is true or false. If it is true i will pass.
            Assert.IsTrue(inserted);
        }
    }
}
