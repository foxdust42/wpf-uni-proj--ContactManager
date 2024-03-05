﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
	public class Contact
	{
		public string? Name { get; set;}
		public string? Surname { get; set;}
		public string? Email { get; set;}
		public string? Phone { get; set;}
		public Gender Gender { get; set; }

		public Contact()
		{

		}

	}

	public enum Gender
	{
		Male,
		Female,
		Other,
		Unknown
	}

}
