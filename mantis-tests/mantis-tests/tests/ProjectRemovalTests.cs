using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            int index = 4;
            List<ProjectData> oldListProjects = app.PM.GetProjecttList();
            List<ProjectData> newProjects = new List<ProjectData>();
            if ((index + 1) > oldListProjects.Count)
            {
                for (int i = 0; i <= (index - oldListProjects.Count); i++)
                {
                    bool uniqueProjName = true;
                    newProjects.Add(new ProjectData(GenerateRandomString(10)));
                    do
                    {
                        foreach (ProjectData project in oldListProjects)
                        {
                            if (project.Name == newProjects[i].Name)
                            {
                                newProjects[i].Name = GenerateRandomString(10);
                                uniqueProjName = false;
                                break;
                            }
                            uniqueProjName = true;
                        }
                    } while (!uniqueProjName);
                }
                app.PM.Create(newProjects);
                oldListProjects = app.PM.GetProjecttList();
            }

            app.PM.Remove(index);

            List<ProjectData> newListProjects = app.PM.GetProjecttList();
            oldListProjects.RemoveAt(index);
            oldListProjects.Sort();
            newListProjects.Sort();

            Assert.AreEqual(oldListProjects, newListProjects);
        }
    }
}
