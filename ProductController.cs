using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Documents;
using Exam.Models;

namespace Exam.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB; Initial Catalog=Exam;Integrated Security=True ";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;

            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Products";

            List<Products> li = new List<Products>();
            try
            {
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while(dr.Read())
                {
                    li.Add(new Products { ProductId =(int)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate=(decimal)dr["Rate"],Description = dr["Description"].ToString(), CategoryName = dr["CategoryName"].ToString()});
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();
            return View(li);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB; Initial Catalog=Exam;Integrated Security=True ";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;

            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Products where ProductId = @ProductId";
            cmdInsert.Parameters.AddWithValue("@ProductId", id);

            SqlDataReader dr = cmdInsert.ExecuteReader();
            Products project = null;
            if(dr.Read())
            {
                project = new Products { ProductId = (int)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate = (decimal)dr["Rate"], Description = dr["Description"].ToString(), CategoryName = dr["CategoryName"].ToString() };
            }
            else
            {
                ViewBag.ErrorMessage = "Not Found";
            }
            cn.Close();
            return View(project);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products pd)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB; Initial Catalog=Exam;Integrated Security=True ";
            cn.Open();

            try
            {
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;

                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "Update Products set ProductId =@ProductId, ProductName=@ProductName,Rate=@Rate,Description=@Description,CategoryName=@CategoryName where ProductId =@ProductId";
                cmdInsert.Parameters.AddWithValue("@ProductId", id);
                cmdInsert.Parameters.AddWithValue("@ProductName", pd.ProductName);
                cmdInsert.Parameters.AddWithValue("@Rate", pd.Rate);
                cmdInsert.Parameters.AddWithValue("@Description", pd.Description);
                cmdInsert.Parameters.AddWithValue("@CategoryName", pd.CategoryName);

                cmdInsert.ExecuteNonQuery();
                Console.WriteLine(cmdInsert.CommandText);
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult MyData()
        {
            return View();
        }
    }
}
