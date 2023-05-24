using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            List<ProjectData> oldListProjects = app.PM.GetProjecttList();
            List<ProjectData> newProjects = new List<ProjectData>
            {
                new ProjectData(GenerateRandomString(10))
            };
            bool uniqueProjName = true;
            do
            {
                foreach (ProjectData project in oldListProjects)
                {
                    if (project.Name == newProjects[0].Name)
                    {
                        newProjects[0].Name = GenerateRandomString(10);
                        uniqueProjName = false;
                        break;
                    }
                    uniqueProjName = true;
                }
            } while (!uniqueProjName);

            app.PM.Create(newProjects);

            List<ProjectData> newListProjects = app.PM.GetProjecttList();
            oldListProjects.Add(newProjects[0]);
            oldListProjects.Sort();
            newListProjects.Sort();

            Assert.AreEqual(oldListProjects, newListProjects);
        }

        [Test]
        public void TestLocators()
        {
            app.PM.TestLocator();
        }
    }
}
