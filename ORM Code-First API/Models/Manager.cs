﻿namespace ORM_Code_First_API.Models
{
    public class Manager : Employee
    {
        public string ManagerDescription { get; set; }
        public virtual Department Department { get; set; }
    }
}
