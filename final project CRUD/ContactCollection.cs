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
        public ContactCollection(string first, string Last, int age, int phone, string email)
        {
            this.First_name = first;
            this.Last_name = Last;
            this.Age = age;
            this.Phone_number = phone;
            this.Email = email;
        }

        //added an ID since we are updating, deleting and viewing a specific contact
        public ContactCollection(int id, string first, string Last, int age, int phone, string email)
        {
            this.Id = id;
            this.First_name = first;
            this.Last_name = Last;
            this.Age = age;
            this.Phone_number = phone;
            this.Email = email;
        }



        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int Age { get; set; }
        public int Phone_number { get; set; }
        public string Email { get; set; }





    }
}
