﻿
namespace BookStoreModel
{
    public class AddressModel
    {
        public int AddressID { get; set; }
        public string? FullAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int TypeID { get; set; }
        public int UserID { get; set; }
    }
}
