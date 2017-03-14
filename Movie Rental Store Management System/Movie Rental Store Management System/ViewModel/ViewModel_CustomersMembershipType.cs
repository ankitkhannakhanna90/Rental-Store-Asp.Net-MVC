using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_Rental_Store_Management_System.Models;

namespace Movie_Rental_Store_Management_System.ViewModel
{
    public class ViewModel_CustomersMembershipType
    {
        public Customer Customer { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }
        public string Title
        {
            get
            {
                if (Customer.Id == 0 )
                    return "New Customers";
                else
                    return "Edit Customers";
            }
        }

    }
}