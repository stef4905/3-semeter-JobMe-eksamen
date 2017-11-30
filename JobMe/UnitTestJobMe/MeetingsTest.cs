using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer;
using ModelLayer;

namespace UnitTestJobMe
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testing the creation of a session in the database. by going through the controller. 
        /// The controller method reurns a bool (boolean) that will be true if the create method was succesfull and vice verza.
        /// Then the bool is tested with the IsTrue, where the test will pass if the bool is returned true.
        /// </summary>
        [TestMethod]
        public void TestCreateMeeting()
        {
            //Arrange
            //Starting by instanciating a new Meeting and Meeting Controller, that are required for the test to execute
            Meeting meeting = new Meeting(1, 1);
            MeetingCtr meetingCtr = new MeetingCtr();

            //Act
            //Retuns the Metting 'inserted' that are given by the Meeting Controllers Create method by the given Meeting object
            Meeting inserted = meetingCtr.Create(meeting);

            //Assert
            //Test wehter the 'inserted' is true og false. If it is true the test wil pass.
            Assert.IsTrue(inserted.Id != 0);
        }
    }
}
