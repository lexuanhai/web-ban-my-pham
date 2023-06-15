using Dapper;
using Domain;
using Dto;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory
{
    public interface IProductReponsitory
    {
        List<Products> GetAll();
        void Add(ProductModel model);
        bool Update(ProductModel model);
        bool Delete(int id);
    }
    public class ProductReponsitory : IProductReponsitory
    {

        private readonly IConfiguration _configuration;
        public ProductReponsitory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Products> GetAll()
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"SELECT * FROM Product WHERE IsDeleted = 0";
                    var categories = con.Query<Products>(query).ToList();                                
                    return categories;
                }
                catch(Exception ex)
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void Add(ProductModel model)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = con;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "Add_Category";
                        command.Parameters.AddWithValue("@Name", model.Name);
                        //command.Parameters.AddWithValue("@ParentId", model.ParentId);
                        command.Parameters.AddWithValue("@Description", model.Description);
                        //command.Parameters.AddWithValue("@Status", model.Status);
                        command.Parameters.AddWithValue("@IsDeleted", 0);
                        command.ExecuteNonQuery();
                    }
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public bool Update(ProductModel model)
        {
            if (model != null && model.Id > 0)
            {
                var connectionString = this.GetConnection();
                using (var con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        using (var command = new SqlCommand())
                        {
                            command.Connection = con;
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "Update_Category";
                            command.Parameters.AddWithValue("@Id", model.Id);
                            command.Parameters.AddWithValue("@Name", model.Name);
                            //command.Parameters.AddWithValue("@ParentId", model.ParentId);
                            command.Parameters.AddWithValue("@Description", model.Description);
                            //command.Parameters.AddWithValue("@Status", model.Status);
                            command.Parameters.AddWithValue("@IsDeleted", 0);
                            command.ExecuteNonQuery();
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return false;
            
        }
        public bool Delete(int id)
        {
            if (id > 0)
            {
                var connectionString = this.GetConnection();
                using (var con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        using (var command = new SqlCommand())
                        {
                            command.Connection = con;
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "Delete_Category";
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return false;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("AppDbContext").Value;
            return connection;
        }
    }
}
