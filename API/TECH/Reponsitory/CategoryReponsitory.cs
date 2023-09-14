using Dapper;
using Domain;
using Dto;
using Dto.Models;
using Dto.Search;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory
{
    public interface ICategoryReponsitory
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(CategoryModel model);
        bool Update(CategoryModel model);
        List<Category> GetDataPaging(CategoryModelSearch search);
        bool Delete(int id);
    }
    public class CategoryReponsitory: ICategoryReponsitory
    {

        private readonly IConfiguration _configuration;
        public CategoryReponsitory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAll()
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
                        command.CommandText = "GetAll";
                        var data = command.ExecuteReader(); // trả về nhiều list data
                        if (data != null && data.HasRows)
                        {
                            var lstData = new List<Category>();
                            var itemParser = data.GetRowParser<Category>(typeof(Category));
                            while (data.Read())
                            {
                                var item = itemParser(data);
                                if (item!= null)
                                    lstData.Add(item);
                            }
                            return lstData;
                        }
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public Category GetById(int id)
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
                        command.CommandText = "GetById";
                        var data = command.ExecuteReader(); // trả về nhiều list data
                        if (data != null && data.HasRows)
                        {
                            var lstData = new Category();
                            var itemParser = data.GetRowParser<Category>(typeof(Category));
                            while (data.Read())
                            {
                                var item = itemParser(data);
                                if (item != null)
                                    lstData = item;
                            }
                            return lstData;
                        }
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void Add(CategoryModel model)
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
                        command.Parameters.AddWithValue("@ParentId", model.ParentId);
                        command.Parameters.AddWithValue("@Description", model.Description);
                        command.Parameters.AddWithValue("@Status", model.Status);
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

        public bool Update(CategoryModel model)
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
                            command.Parameters.AddWithValue("@ParentId", model.ParentId);
                            command.Parameters.AddWithValue("@Description", model.Description);
                            command.Parameters.AddWithValue("@Status", model.Status);
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

        public List<Category> GetDataPaging(CategoryModelSearch search)
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
                        command.CommandText = "GetDataPaging_Category";
                        command.Parameters.AddWithValue("@PageIndex", search.PageIndex);
                        command.Parameters.AddWithValue("@PageSize", search.PageSize);
                        command.Parameters.AddWithValue("@TotalRow", 0).Direction = ParameterDirection.Output;
                       var data = command.ExecuteReader(); // trả về nhiều list data
                        int contractID = Convert.ToInt32(command.Parameters["@TotalRow"].Value);
                        if (data != null)
                        {
                            var lstData = new List<Category>();
                            var itemParser = data.GetRowParser<Category>(typeof(Category));                           
                            while (data.Read())
                            {
                                var item = itemParser(data);
                                if (item != null)
                                    lstData.Add(item);
                            }
                            return lstData;
                        }
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("AppDbContext").Value;
            return connection;
        }
    }
}
