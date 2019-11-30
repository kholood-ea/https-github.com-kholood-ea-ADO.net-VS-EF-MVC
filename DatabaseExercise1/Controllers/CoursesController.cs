using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseExercise1.Models;
using System.Data;


namespace DatabaseExercise1.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses

        public ActionResult Index()
        {
            List<Course> Courselist = new List<Course>();
            DataTable table = new DataTable();


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseDBContext"].ConnectionString))
            {
                // Reading from database using SqlDataReader
                using (SqlCommand cmd = new SqlCommand("select * from Course", con))
                {
                   
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Course cor = new Course();
                        // get the results of each column
                        cor.Id = Convert.ToInt32((string)rdr["Id"].ToString());
                        cor.Name = (string)rdr["Name"];
                        cor.Hours = Convert.ToInt32((string)rdr["Hours"].ToString());
                        Courselist.Add(cor);
                    }
                    rdr.Close();

                    // Reading from database using SqlDataAdapter

                    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //    da.Fill(table);
                    //    for (int i = 0; i < table.Rows.Count; i++)
                    //    {
                    //        Course cor = new Course();
                    //        cor.Id = Convert.ToInt32(table.Rows[i]["id"].ToString());
                    //        cor.Name = table.Rows[i]["Name"].ToString();
                    //        cor.Hours = Convert.ToInt32(table.Rows[i]["hours"].ToString());
                    //        Courselist.Add(cor);
                    //    }
                    //}
                    con.Close();
                }
                return View(Courselist);
            }


        }
        // Reading from database using Entity framework

        CourseDBContext cdbc = new CourseDBContext();
        public ActionResult Index1()
        {

            return View(cdbc.courses.ToList());
        }

    }
}
