using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Company
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Type { set; get; }
        public string Address { set; get; }
        public string Description { set; get; }
        public string Size { set; get; }
        public string Logo { set; get; }
        public decimal UpdatedDate { set; get; }
        public int TotalComment { set; get; }
    }
}
