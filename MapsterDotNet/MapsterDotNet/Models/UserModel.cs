﻿using Mapster;
using MapsterDotNet.Entities;

namespace MapsterDotNet.Models
{
    public class UserModel : BaseModel<UserModel, User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime CreatedOn = DateTime.UtcNow;

        public DateTime UpdatedOn = DateTime.UtcNow;

        public bool Active = true;
    }
}
