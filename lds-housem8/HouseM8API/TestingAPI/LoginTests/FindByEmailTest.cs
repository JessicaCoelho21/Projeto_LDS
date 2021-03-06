﻿using HouseM8API.Data_Access;
using HouseM8API.Interfaces;
using Models;
using Xunit;

namespace HouseM8APITests.LoginTests
{
    [Collection("Sequential")]
    public class FindByEmailTest
    {
        private Connection _connection;
        private LoginFixture _fixture;

        public FindByEmailTest()
        {
            _fixture = new LoginFixture();
            this._connection = _fixture.GetConnection();
        }

        [Fact]
        public void CanFindByEmailTest()
        {
            IEmployerDAO<Employer> EmployerDAO = new EmployerDAO(_connection);
            Employer testEmployer = new Employer();
            string password = testEmployer.Password;

            testEmployer.FirstName = "Samuel";
            testEmployer.LastName = "Cunha";
            testEmployer.UserName = "samuelcunha28";
            testEmployer.Password = "samuel123";
            testEmployer.Email = "samuelcunha29@gmail.com";
            testEmployer.Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";
            testEmployer.Address = "Aparecida";

            Employer returned = EmployerDAO.Create(testEmployer);

            UserDAO userDAO = new UserDAO(_connection);

            Assert.NotNull(userDAO.FindUserByEmail("samuelcunha29@gmail.com"));

            _fixture.Dispose();
        }
    }
}
