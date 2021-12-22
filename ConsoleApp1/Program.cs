using System;

namespace FirstApp
{
	class Company
	{
		public string Type;
		public string Name;
	}

	class Department
	{
		public Company Company;
		public City City;
	}

	class City
	{
		public string Name;
	}

	class Program
	{
		static void Main(string[] args)
		{
			var department = GetCurrentDepartment();
		}

		static Department GetCurrentDepartment()
		{
			// logic
		}

	}