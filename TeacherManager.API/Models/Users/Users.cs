﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherManager.API.Models.Users
{
    public class Users
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
