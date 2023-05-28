using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class ProjectTestBase : AuthTestBase
    {
        public static List<ProjectData> GenerateUniqueProjectsData(int count, List<ProjectData> existingProjects)
        {
            List<ProjectData> newProjects = new List<ProjectData>();
            for (int i = 0; i <= count; i++)
            {
                bool uniqueProjName = true;
                newProjects.Add(new ProjectData(GenerateRandomString(10)));
                do
                {
                    foreach (ProjectData project in existingProjects)
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
            return newProjects;
        }
    }
}
