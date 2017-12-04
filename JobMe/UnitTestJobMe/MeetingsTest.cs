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
            Meeting meeting = new Meeting(1);
            MeetingCtr meetingCtr = new MeetingCtr();

            //Act
            //Retuns the Metting 'inserted' that are given by the Meeting Controllers Create method by the given Meeting object
            Meeting inserted = meetingCtr.Create(meeting);

            //Assert
            //Test wehter the 'inserted' is true og false. If it is true the test wil pass.
            Assert.IsTrue(inserted.Id != 0);
        }

        /// <summary>
        /// Testing the get method on Meeting in the database. Is tested by creating a new meeting object with the id 6.
        /// This is then used in the meeting controllers get method that uses the id to find the corosponding row in the database.
        /// We then check the meeting we first created with it's id and the found meetings id.
        /// </summary>
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            Meeting meeting = new Meeting();
            meeting.Id = 6;
            MeetingCtr meetingCtr = new MeetingCtr();

            //Act
            Meeting returnedMeeting = meetingCtr.Get(meeting.Id);

            //Assert
            Assert.AreEqual(meeting.Id, returnedMeeting.Id);
        }


        /// <summary>
        /// Testing the update method on Meeting in the database. Is tested by making a new meeting object and pass into a update method. 
        /// If the method is succesful it will return a true boolean, this boolean can be used to check if the method was succesfully updating the object
        /// </summary>
        [TestMethod]
        public void TestUpdate()
        {
            //Arrange
            Meeting meeting = new Meeting(1);
            meeting.Id = 6;
            MeetingCtr meetingCtr = new MeetingCtr();

            //Act
            bool check = meetingCtr.Update(meeting);

            //Assert
            Assert.IsTrue(check);
        }



    }
}
