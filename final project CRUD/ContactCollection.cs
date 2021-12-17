using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project_CRUD
{
    class ContactCollection
    {
      
        //used to create the userm
        public ContactCollection(string first, string Last, string age, string phone, string email)
        {
            this.First_Name = first;
            this.Last_Name = Last;
            this.age = age;
            this.Phone_Number = phone;
            this.Email = email;
        }

        //added an ID since we are updating, deleting and viewing a specific contact
        public ContactCollection(int id, string first, string Last, string age, string phone, string email)
        {
            this.Id = id;
            this.First_Name = first;
            this.Last_Name = Last;
            this.age = age;
            this.Phone_Number = phone;
            this.Email = email;
        }



        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string age { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }





    }
}
