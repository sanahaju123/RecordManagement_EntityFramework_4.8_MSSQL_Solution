

using RecordManagementApp.DAL.Interrfaces;
using RecordManagementApp.DAL.Services;
using RecordManagementApp.DAL.Services.Repository;
using RecordManagementApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Record = RecordManagementApp.Models.Record;

namespace RecordManagementApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IRecordService _recordService;
        public readonly Mock<IRecordRepository> recordservice = new Mock<IRecordRepository>();

        private readonly Record _record;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Record_Name_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                recordservice.Setup(repo => repo.CreateRecord(_record)).ReturnsAsync(_record);
                var result = await _recordService.CreateRecord(_record);
                var actualLength = _record.Name.ToString().Length;
                if (result.Name.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Record_Description_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                recordservice.Setup(repo => repo.CreateRecord(_record)).ReturnsAsync(_record);
                var result = await _recordService.CreateRecord(_record);
                var actualLength = _record.Description.ToString().Length;
                if (result.Description.ToString().Length == actualLength)
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