using BooksDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksMVC.Helper
{
    public class HelperClass
    {
        public static List<SelectListItem> UserListItems(List<User> Userlist)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in Userlist)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id
                });
            }
            return listItems;
        }
    }
}