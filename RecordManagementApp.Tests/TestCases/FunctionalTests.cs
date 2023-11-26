

using RecordManagementApp.DAL.Interrfaces;
using RecordManagementApp.DAL.Services;
using RecordManagementApp.DAL.Services.Repository;
using RecordManagementApp.Models;
using RecordManagementApp.Tests.TestCases;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Record = RecordManagementApp.Models.Record;

namespace RecordManagementApp.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IRecordService _recordService;
        public readonly Mock<IRecordRepository> recordservice = new Mock<IRecordRepository>();

        private readonly Record _record;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _recordService = new RecordService(recordservice.Object);

            _output = output;

            _record = new Record
            {
                RecordId = 1,
                Name = "Sample Record",
                DateCreated = DateTime.Now,
                Description = "This is a sample record."
            };
        }


        [Fact]
        public async Task<bool> Testfor_Create_Record()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                recordservice.Setup(repos => repos.CreateRecord(_record)).ReturnsAsync(_record);
                var result = await _recordService.CreateRecord(_record);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_Update_Record()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                recordservice.Setup(repos => repos.UpdateRecord(_record)).ReturnsAsync(_record);
                var result = await _recordService.UpdateRecord(_record);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_GetRecordById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                recordservice.Setup(repos => repos.GetRecordById(id)).ReturnsAsync(_record);
                var result = await _recordService.GetRecordById(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_DeleteRecordById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                recordservice.Setup(repos => repos.DeleteRecordById(id)).ReturnsAsync(response);
                var result = await _recordService.DeleteRecordById(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}