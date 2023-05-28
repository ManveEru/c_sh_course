using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : ProjectTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            //подготовка данных
            int index = 5;
            AccountData account = new AccountData() { Name = "administrator", Password = "root" };
            List<ProjectData> oldProjectsList = app.API.GetProjectsList(account);
            if ((index + 1) > oldProjectsList.Count)
            {
                List<ProjectData>  addingProjects = GenerateUniqueProjectsData(index - oldProjectsList.Count, oldProjectsList);
                app.API.CreateProjects(account, addingProjects);
                oldProjectsList = app.API.GetProjectsList(account);
            }

            //действия
            app.PM.Remove(index);

            //подготовка проверок
            List<ProjectData> newProjectsList = app.API.GetProjectsList(account);
            oldProjectsList.RemoveAt(index);
            oldProjectsList.Sort();
            newProjectsList.Sort();

            //проверки
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }
    }
}
