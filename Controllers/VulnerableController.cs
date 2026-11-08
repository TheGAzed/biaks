using biaks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace biaks.Controllers {
	public class VulnerableController(IConfiguration configuration) : Controller {
		private readonly string _connectionString = 
			configuration.GetConnectionString("DefaultConnection");

		[HttpGet]
		public IActionResult Search() {
			return View();
		}

		/*
		[HttpPost]
		public IActionResult Search(string productName) {
			var products = new List<Product>();

			// ! ZRANITEĽNÝ KÓD: Priame vkladanie vstupu do SQL dotazu
			string sql = "SELECT Id, Name, Price FROM Products WHERE Name LIKE '%" 
				+ productName + "%'";

			using (var connection = new SqlConnection(_connectionString)) {
				using (var command = new SqlCommand(sql, connection)) {
					connection.Open();
					using (var reader = command.ExecuteReader()) {
						while (reader.Read()) {
							products.Add(new Product {
								Id = reader.GetInt32(0),
								Name = reader.GetString(1),
								Price = reader.GetDecimal(2)
							});
						}
					}
				}
			}

			ViewBag.Products = products;
			ViewBag.SearchTerm = productName;
			return View();
		}
		*/
		[HttpPost]
		public IActionResult Search(string productName) {
			var products = new List<Product>();

			string sql = "SELECT Id, Name, Price FROM Products WHERE Name LIKE @ProductName";

			using (var connection = new SqlConnection(_connectionString)) {
				using (var command = new SqlCommand(sql, connection)) {
					command.Parameters.AddWithValue("@ProductName", "%" + productName + "%");

					connection.Open();
					using (var reader = command.ExecuteReader()) {
						while (reader.Read()) {
							products.Add(new Product {
								Id = reader.GetInt32(0),
								Name = reader.GetString(1),
								Price = reader.GetDecimal(2)
							});
						}
					}
				}
			}

			ViewBag.Products = products;
			ViewBag.SearchTerm = productName;
			return View();
		}
	}
}
