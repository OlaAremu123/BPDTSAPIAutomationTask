using BPDTSAPIAutomationTask.Hooks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using BPDTSAPIAutomationTask.Models;
using Newtonsoft.Json;

namespace BPDTSAPIAutomationTask.StepDefinitions
{
    [Binding]
    public class UsersStepDefinitions
    {
        Context context;
         
        public UsersStepDefinitions(Context _context)
        {
            context = _context;
        }

        [Given(@"that BPDTSTestApp web services with GET endpoint (.*) is running")]
        public void GivenThatBPDTSTestAppWebServicesWithGETEndpointUsersIsRunning(string resource)
        {
            context.GetHttpMethod(resource);
        }

        [Then(@"the status code for GET endpoint is equal to (.*)")]
        public void ThenTheStatusCodeForGETEndpointIsEqualToOK(string expectedResult)
        {
            // string actualResult = context.statusCode;
            Assert.AreEqual(expectedResult, context.statusCode, $"{expectedResult} result is not equal to an actual result of {context.statusCode}");
        }

        [Then(@"the following records should be retrived from users")]
        public void ThenTheFollowingRecordsShouldBeRetrivedFromUsers(Table table)
        {
            var expectedResult = table.CreateSet<UsersModel>(); // change table records to a list which is a collection
            string actualResponseContent = context.content;     // this will be JSON format which consists of many things beyond our needs
            var actualResult = JsonConvert.DeserializeObject<List<UsersModel>>(actualResponseContent); // it will take out all data under first_name attribute/column
            Assert.IsTrue(CompareTwoCollections(expectedResult, actualResult));
        }

        public bool CompareTwoCollections(object firstCollection, object secondCollection)
        {
            var firstObject = JsonConvert.SerializeObject(firstCollection);
            var secondObject = JsonConvert.SerializeObject(secondCollection);
            return firstObject == secondObject;
        }
    }
}
