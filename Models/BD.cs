using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;
namespace Pizzas.API.Models{

 public static class BD{

     private static string _connectionString = @"Server=A-CEO-13;
     DataBase=DAI-Pizzas;Trusted_Connection=True;";

     public static Pizza ConsultaPizza(int Id){
         Pizza Pizza1 = null;
             string sql = "SELECT * FROM Pizzas WHERE Id=@Pizza1";
              using (SqlConnection bd = new SqlConnection(_connectionString)){
             Pizza1= bd.QueryFirstOrDefault<Pizza>(sql,new {Pizza1=Id});
         }
         return Pizza1;
    }

    public static void Create(Pizza pizza){
            string sql = "INSERT into Pizzas(Id,Nombre,LibreGluten,Importe,Descripcion)VALUES(@Id,@nombre,@libregluten,@importe,@descripcion)";
            using (SqlConnection bd = new SqlConnection(_connectionString)){
            bd.Execute(sql,new {Id=pizza.Id, Nombre=pizza.Nombre,Libregluten=pizza.LibreGluten,Importe=pizza.Importe,Descripcion=pizza.Descripcion});
         }
    }
    
    
    public static void Update(Pizza pizza){
                string sql = "UPDATE into Pizzas(Id,Nombre,LibreGluten,Importe,Descripcion)VALUES(@Id,@nombre,@libregluten,@importe,@descripcion)WHERE(Id=@Id)";
                using (SqlConnection bd = new SqlConnection(_connectionString)){
                bd.QueryFirstOrDefault(sql,new {Id=pizza.Id, Nombre=pizza.Nombre,Libregluten=pizza.LibreGluten,Importe=pizza.Importe,Descripcion=pizza.Descripcion});
            }
    }

    
    public static void Delete(int Id){
                string sql = "DELETE FROM Pizzas WHERE Id=@Id";
                using (SqlConnection bd = new SqlConnection(_connectionString)){
                bd.Execute(sql,new {pizza=Id});
            }
    }
 }
}