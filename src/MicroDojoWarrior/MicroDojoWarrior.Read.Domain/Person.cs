﻿using System;

namespace MicroDojoWarrior.Read.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public Guid PersonRefId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int BeltId { get; set; }
        public int Stripes { get; set; }
    }
}