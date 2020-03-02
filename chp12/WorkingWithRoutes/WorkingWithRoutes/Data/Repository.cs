using System;
using System.Collections.Generic;

using WorkingWithRoutes.Models;

namespace WorkingWithRoutes.Data
{
    public static class Repository
    {
        private static List<Customer> Customers;

        private static List<ItemType> ItemTypes;

        public static void InitData()
        {
            SetCustomersData();
            SetItemTypesData();
        }

        private static void SetCustomersData()
        {
            Customers = new List<Customer>
            {
                new Customer{ Id = 1, Firstname = "Chima" , Lastname = "Jacob", Email = "chima.jacob@yahoo.com", Phone = "0627863566", Address = "77 Marcus Garvey Street"},
                new Customer{ Id = 2, Firstname = "John", Lastname = "Bernard", Email = "johnb@gmail.com", Phone = "9856786983", Address = "43 Silverbird Road"},
                new Customer{ Id = 3, Firstname = "Matins", Lastname = "Lama", Email = "matin.l@gmail.com", Phone = "0784486983", Address = "54 Osasugie Street"}
            };
        }

        private static void SetItemTypesData()
        {
            ItemTypes = new List<ItemType>
            {
                new ItemType{Id = 1, Type = "Shirt", Price = 49.99f},
                new ItemType{Id = 2, Type = "Short", Price = 35.98f },
                new ItemType{Id = 3, Type = "Jacket", Price = 89.67f}
            };
        }

        public static List<Customer> GetCustomers()
        {
            return Customers;
        }

        public static List<ItemType> GetItemTypes()
        {
            return ItemTypes;
        }
    }

   
}