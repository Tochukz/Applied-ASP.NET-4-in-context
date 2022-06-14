using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySQLApp.Models;
using MySQLApp.Attributes;

namespace MySQLApp
{
	class Program
	{
		static void Main(string[] args)
		{
			// Select Single
			int bookId = 97;
			Book book = GetBook(bookId);
			if (book != null)
			{
				Console.WriteLine($"Book {bookId }, {book.title} by {book.author} at R{book.price}");
			}

			// Select Multiple
			List<Book> books = GetBooks();
			foreach(Book bk in books)
			{
				Console.WriteLine(bk.bookId + ") " + bk.title +" "+ bk.author);
			}

			// Insert
			Book bookData = new Book
			{
				title = "Febuary Book", 
				author = "Tochukwu Nwachukwu",
				edition = "2nd Edition",
				price = 2700,
				subcategoryId = 3,
			};
			Book newBook = CreateBook(bookData);
			Console.WriteLine($"New Book {newBook.bookId }, {newBook.title} by {newBook.author} at R{newBook.price}");

			// Update 
			Book bookToUpDate = new Book
			{
				bookId = 161,
				title = "July Book",
				author = "Tochukwu Nwachukwu",
				edition = "7th Edition",
				price = 2879.99f,
				subcategoryId = 3,
			};
			Book updateBook = UpdateBook(bookToUpDate);
			Console.WriteLine($"Updated Book: {updateBook.title} by {updateBook.author} now R{updateBook.price}");
			
			//Delete
			int bookIdToDel = 173;
			DeleteBook(bookIdToDel);
			Console.WriteLine("Deleted book " + bookIdToDel);

			Console.ReadLine();
		}

		static MySqlConnection Connect()
		{
			MySqlConnection connection = null;
			try
			{
				string connestionStr = "server=127.0.0.1;uid=root;pwd= ;database=ojlinks_api";
				connection = new MySqlConnection(connestionStr);			
				connection.Open();
				Console.WriteLine("Connected!");				
			}
			catch(MySqlException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return connection;
		}

		static Book GetBook(int bookId)
		{
			List<Book> books = GetBooks($"where bookId = {bookId}");
			if (books.Count == 1)
			{
				return books[0];
			}
			return null;
		}

		static List<Book> GetBooks(string clause = "LIMIT 5")
		{
			List<Book> books = new List<Book>();
			using (MySqlConnection connection = Connect())
			{
				try
				{
					string query = $"SELECT * FROM books {clause}";
					MySqlCommand command = new MySqlCommand(query, connection);
					MySqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						Book book = new Book();
						PropertyInfo[] properties = book.GetType().GetProperties();						
						foreach (PropertyInfo prop in properties)
						{
							string propName = prop.Name;
							int index = reader.GetOrdinal(propName);
							var val = reader.GetValue(index);
							if (val != DBNull.Value)
							{
								//book.GetType().GetProperty(propName).SetValue(book, val);
								prop.SetValue(book, val);
							}
						}
						books.Add(book);
					}
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
			return books;
		}

		private static void BuildInsertFields(PropertyInfo[] properties, StringBuilder builder, string prePend)
		{
			int len = properties.Length;
			for (int i = 0; i < len; i++)
			{
				PropertyInfo prop = properties[i];
				Attribute propAttr = prop.GetCustomAttribute(typeof(ModelPropAttribute));
				if (propAttr != null)
				{
					ModelPropAttribute modelAtttr = (ModelPropAttribute)propAttr;
					if (modelAtttr.AttrName == "PrimaryKey")
					{
						continue;
					}
				}
				builder.Append($"{prePend}{prop.Name}");
				if (i < len - 1)
				{
					builder.Append(", ");
				}
			}
		}

		static Book CreateBook(Book book)
		{
			using(MySqlConnection connection = Connect())
			{
				StringBuilder query = new StringBuilder("INSERT INTO books(");
				PropertyInfo[] properties = typeof(Book).GetProperties();
				BuildInsertFields(properties, query, "");
				query.Append(") VALUES(");
				BuildInsertFields(properties, query, "@");
				query.Append(");");
				Console.WriteLine(query.ToString());

				MySqlCommand command = new MySqlCommand(query.ToString(), connection);
				foreach(PropertyInfo prop in properties)
				{
					string nameLower = prop.Name.ToLower();
					Attribute propAttr = prop.GetCustomAttribute(typeof(ModelPropAttribute));
					if (propAttr != null)
					{
						ModelPropAttribute modelAtttr = (ModelPropAttribute)propAttr;
						if (modelAtttr.AttrName == "PrimaryKey")
						{
							continue;
						}
					}
					MySqlParameter param = null;
					if (prop.PropertyType == typeof(string))
					{
						param = new MySqlParameter($"@{prop.Name}", MySqlDbType.VarChar);
					}
					else if (prop.PropertyType == typeof(int))
					{
						param = new MySqlParameter($"@{prop.Name}", MySqlDbType.Int32);
					}
					else if (prop.PropertyType == typeof(float))
					{
						param = new MySqlParameter($"@{prop.Name}", MySqlDbType.Float);
					}
					else if (prop.PropertyType == typeof(DateTime))
					{
						param = new MySqlParameter($"@{prop.Name}", MySqlDbType.DateTime);												
					}
					else 
					{
						throw new NotImplementedException($"Parameter for the type for {prop.PropertyType} not yet implemented!");
					}

					if (param != null)
					{
						if (nameLower.StartsWith("created") || nameLower.StartsWith("updated"))
						{
							string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
							param.Value = now;
						}
						else
						{
							param.Value = book.GetType().GetProperty(prop.Name).GetValue(book);
						}
						command.Parameters.Add(param);
					}
					
				}
				command.Prepare();
				command.ExecuteNonQuery();
				
				MySqlCommand selectCommand = new MySqlCommand("SELECT LAST_INSERT_ID();", connection);			
				UInt64 bookId = (UInt64)selectCommand.ExecuteScalar();
				Book newBook = GetBook((int)bookId);
				return newBook;
			}
		}

		private static void BuildUpdateFields(PropertyInfo[] properties, StringBuilder builder, Book book)
		{
			int len = properties.Length;
			PropertyInfo primaryKeyProp = null;
			for (int i = 0; i < len; i++)
			{
				PropertyInfo prop = properties[i];			
				if (prop.Name.ToLower().StartsWith("created"))
				{
					continue;
				}
				Attribute propAttr = prop.GetCustomAttribute(typeof(ModelPropAttribute));
				if (propAttr != null)
				{
					ModelPropAttribute modelAtttr = (ModelPropAttribute)propAttr;
					if (modelAtttr.AttrName == "PrimaryKey")
					{
						primaryKeyProp = prop;
						continue;
					}
				}
				builder.Append($"{prop.Name}=@{prop.Name}");
				if (i < len - 1)
				{
					builder.Append(", ");
				}
			}

			if (primaryKeyProp == null)
			{
				throw new InvalidOperationException("PrimaryKey attribute not found in model for update");
			}
			builder.Append($" WHERE {primaryKeyProp.Name}=@{primaryKeyProp.Name}");
			Console.WriteLine("Query: " + builder.ToString());
		}

		static Book UpdateBook(Book book)
		{
			using (MySqlConnection connection = Connect())
			{
				StringBuilder query = new StringBuilder("UPDATE books SET ");
				PropertyInfo[] properties = book.GetType().GetProperties();
				BuildUpdateFields(properties, query, book);
				MySqlCommand command = new MySqlCommand(query.ToString(), connection);
				foreach (PropertyInfo prop in properties)
				{
					string nameLower = prop.Name.ToLower();
					if (nameLower.StartsWith("created"))
					{
						continue;
					}
					MySqlParameter param = null;
					if (prop.PropertyType == typeof(string))
					{
						param = new MySqlParameter($"@{prop.Name}", MySqlDbType.VarChar);
					}
					else if (prop.PropertyType == typeof(int))
					{
						param = new MySqlParameter($"@{prop.Name}", MySqlDbType.Int32);
					}
					else if (prop.PropertyType == typeof(float))
					{
						param = new MySqlParameter($"@{prop.Name}", MySqlDbType.Float);
					}
					else if (prop.PropertyType == typeof(DateTime))
					{
						param = new MySqlParameter($"@{prop.Name}", MySqlDbType.DateTime);
					}
					else
					{
						throw new NotImplementedException($"Parameter for the type for {prop.PropertyType} not yet implemented!");
					}


					if (param != null)
					{
						if (nameLower.ToLower().StartsWith("updated"))
						{
							string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
							param.Value = now;
						}
						else
						{
							param.Value = book.GetType().GetProperty(prop.Name).GetValue(book);
						}
						command.Parameters.Add(param);
					}
				}
				command.Prepare();
				command.ExecuteNonQuery();
				Book updateBook = GetBook(book.bookId);
				return updateBook;
			}			
		}

		static void DeleteBook(int bookId)
		{
			using (MySqlConnection connection = Connect())
			{
				string query = "DELETE FROM books WHERE bookId=@bookId";
				MySqlCommand command = new MySqlCommand(query, connection);
				MySqlParameter param = new MySqlParameter("@bookId", MySqlDbType.Int32);
				param.Value = bookId;
				command.Parameters.Add(param);
				command.Prepare();
				command.ExecuteNonQuery();
			}			
		}
	}
}
