using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    class ProjectCreationTests : ProjectTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            //подготовка данных
            AccountData account = new AccountData() { Name = "administrator", Password = "root" };
            List<ProjectData> oldProjectsList = app.API.GetProjectsList(account);
            List<ProjectData> addingProjects = GenerateUniqueProjectsData(0, oldProjectsList);
            
            //действия
            app.PM.Create(addingProjects);

            //подготовка проверок
            List<ProjectData> newProjectsList = app.API.GetProjectsList(account);
            oldProjectsList.Add(addingProjects[0]);
            oldProjectsList.Sort();
            newProjectsList.Sort();

            //проверки
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }

        [Test]
        public void TestLocators()
        {
            app.PM.TestLocator();
        }
    }
}
