using System;
using System.Collections.Generic;

namespace Practice
{
	class Program
	{
		/* 1. Tạo class có thuộc tính chung để nhiều đối tượng có thể kế thừa thuộc tính đó.
		   2. Không thể tạo đối tượng từ lớp abstract.
		 */
		public abstract class Person
		{
			// Thuộc tính của lớp cha.
			/*
			 get và set là Tính Encapsulation.
			 get: Chỉ được xem giá trị, không thay đổi được giá trị Ex: string name {get}.
			 */
			private string name;  // field
			public string Name    // property
			{
				get { return name; }
				set { name = value; }
			}
			public int age { get; set; }
			public string gender { get; set; }
			public string readerCode { get; set; }
		}

		// 1. Tạo lớp Reader kế thừa thuộc tính của lớp cha.
		public class Reader : Person
		{
			// Khởi tạo đối tượng.
			//public Reader(
			//	string nameValue,
			//	int ageValue,
			//	string genderValue,
			//	string readerCodeValue
			//	)
			//{
			//	Name = nameValue;
			//	age = ageValue;
			//	gender = genderValue;
			//	readerCode = readerCodeValue;
			//}
			public void Talk()
			{
				Console.WriteLine("Tôi là người đọc.");
			}
		}

		// 2. Tạo class Librarian kế thừa class Person.
		public class Librarian : Person
		{
			public void Talk()
			{
				Console.WriteLine("Tôi là người thủ thư.");
			}
		}

		// 3. Muốn quản lý nhiều thư viện thì seo ?
		public class Branch : Person
		{
			public string branchCode { get; set; }
			public int maxReader { get; set; }

			static List<Reader> ReadersList = new List<Reader>();

			// Phương thức khởi tạo.
			public Branch(string codeValue, int maxReaderValue)
			{
				branchCode = codeValue;
				maxReader = maxReaderValue;
				Console.WriteLine("Branch {0} tối đa {1} người được tạo", codeValue, maxReader);
			}

			// Kiểm tra số người tối đa.
			public bool MaxReaderReached()
			{
				if (ReadersList.Count >= maxReader)
				{
					return true;
				}
				else { return false; }
			}

			// Hàm thêm truyền vào class Reader.
			public void AddReader(Reader reader)
			{
				if (!MaxReaderReached())
				{
					ReadersList.Add(reader);
					Console.WriteLine("Reader {0} added successfully !", reader.Name);
				}
				else
				{
					Console.WriteLine("Cannot add {0}. Maximum reader !", reader.Name);
				}

			}

			// Muốn xem chi nhánh này tổng có bao nhiêu người đăng ký rồi.
			public void ShowTotalReader()
			{
				Console.WriteLine("Total reader for {0} is {1}", this.branchCode, ReadersList.Count);
			}

			// Hiển thị từng người đăng ký
			public void ShowReader()
			{
				foreach (Reader item in ReadersList)
				{
					Console.WriteLine("Name: {0}, Age: {1}, Gender: {2}, ReaderCode: {3}",
						item.Name, item.age, item.gender, item.readerCode);
				}
				ShowTotalReader();
			}
		}

		public static void Main(string[] args)
		{
			/*1. Đối tượng người đọc, in ra thuộc tính và phương thức. 
			  2. Dùng constructor để truyền value thông qua object.
			 */
			//Reader reader = new Reader("Định", 18, "Nam", "001");
			Reader reader = new Reader();
			reader.Name = "TEST01";
			Console.WriteLine(reader.Name);
			Reader reader2 = reader;
			reader2.Name = "TEST02";
			Console.WriteLine(reader2.Name);
			//Reader reader2 = new Reader("Định2", 18, "Nam", "002");
			//Console.WriteLine(reader.Name);
			//reader.Talk();
			//// 2. Đổi tượng Librarian.
			//Librarian librarian = new Librarian();
			//librarian.Talk();

			/*Tối đa 10 người được tạo.
			  Truyền từ hàm khởi tạo vào.
			 */
			//Branch branch = new Branch("001", 10);
			//branch.AddReader(reader);
			////branch.AddReader(reader2);
			//branch.ShowReader();
		}
	}
}
