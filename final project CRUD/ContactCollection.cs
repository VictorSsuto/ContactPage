using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project_CRUD
{
    class ContactCollection
    {
        //used to create the user
        public ContactCollection(string Fname, string Lname, string phone, string email)
        {
            this.First_Name = Fname;
            this.Last_Name = Lname;
            this.Phone_Number = phone;
            this.Email = email;
        }

        //added an ID since we are updating, deleting and viewing a specific contact
        public ContactCollection(int id, string Fname, string Lname, string phone, string email)
        {
            this.Id = id;
            this.First_Name = Fname;
            this.Last_Name = Lname;
            this.Phone_Number = phone;
            this.Email = email;
        }



        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }





    }
}
