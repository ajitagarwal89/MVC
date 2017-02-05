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
        public void AddProducts(ProductsModel obj,out string errormsg)
        {
            try
            {
                conncetion();
                SqlCommand cmd = new SqlCommand("insProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@productName", obj.productName.Trim().ToString());
                cmd.Parameters.AddWithValue("@ProductDesciption", obj.ProductDesciption.ToString());
                cmd.Parameters.AddWithValue("@ProductColor", obj.ProductColor.ToString());
                cmd.Parameters.AddWithValue("@ProductListPrice", obj.ProductListPrice);
                cmd.Parameters.Add("@errormsg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                con.Open();
                int i = cmd.ExecuteNonQuery();
                errormsg = Convert.ToString(cmd.Parameters["@errormsg"].Value);
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public void UpdProduct(ProductsModel objupd)
        {
            string errormsg;
            try
            {
                conncetion();
                
                SqlCommand cmd = new SqlCommand("updProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@productID", objupd.productID);
                cmd.Parameters.AddWithValue("@productName", objupd.productName.Trim().ToString());
                cmd.Parameters.AddWithValue("@ProductDesciption", objupd.ProductDesciption.ToString());
                cmd.Parameters.AddWithValue("@ProductColor", objupd.ProductColor.ToString());
                cmd.Parameters.AddWithValue("@ProductListPrice", objupd.ProductListPrice);
                cmd.Parameters.Add("@errormsg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                con.Open();
                int i = cmd.ExecuteNonQuery();
                errormsg = Convert.ToString(cmd.Parameters["@errormsg"].Value);
                con.Close();
                           }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }   
        public void delProduct(ProductsModel objdel)
        { try
            {
                conncetion();

                SqlCommand cmd = new SqlCommand("delProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@productID", objdel.productID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
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
                        {  productID=Convert.ToInt32(dr["productID"]),
                            productName = Convert.ToString(dr["productName"]),
                            ProductDesciption = Convert.ToString(dr["ProductDesciption"]),
                            ProductColor = Convert.ToString(dr["ProductColor"]),
                            ProductListPrice = Convert.ToInt32(dr["ProductListPrice"])
                        }).ToList();
            return PrdtList;

        }

        

    }

}