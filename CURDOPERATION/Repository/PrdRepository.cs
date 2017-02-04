using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CURDOPERATION.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CURDOPERATION.Repository
{
    public class PrdRepository
    {
        private SqlConnection con;
        private void conncetion()
        {
            string constr = ConfigurationManager.AppSettings["myconn"].ToString();
            con = new SqlConnection(constr);
        }

        //To Add new Product
        public bool AddProducts(ProductsModel obj)
        {
            conncetion();
            SqlCommand cmd = new SqlCommand("insProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productName", obj.productName.Trim().ToString());
            cmd.Parameters.AddWithValue("@ProductDesciption", obj.ProductDesciption.ToString());
            cmd.Parameters.AddWithValue("@ProductColor", obj.ProductColor.ToString());
            cmd.Parameters.AddWithValue("@ProductListPrice", obj.ProductListPrice);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List <ProductsModel>GetProducts()
        {
            conncetion();
            List<ProductsModel> PrdtList = new List<Models.ProductsModel>();
            SqlCommand cmd = new SqlCommand("getProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            PrdtList = (from DataRow dr in dt.Rows
                        select new ProductsModel()
                        {
                            productName = Convert.ToString(dr["productName"]),
                            ProductDesciption = Convert.ToString(dr["ProductDesciption"]),
                            ProductColor = Convert.ToString(dr["ProductColor"]),
                            ProductListPrice = Convert.ToInt32(dr["ProductListPrice"])
                        }).ToList();
            return PrdtList;

        }
    }
}