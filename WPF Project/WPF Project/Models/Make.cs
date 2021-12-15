using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Project.Models
{
    internal static class Make
    {
        private static readonly string name = "Audi";
        private static readonly string country = "Germany";
        private static readonly string category = "luxury";

        public static string Name
        {
            get { return name; }
        }

        public static string Country
        {
            get { return country; }
        }

        public static string Category
        {
            get { return category; }
        }
    }

}
