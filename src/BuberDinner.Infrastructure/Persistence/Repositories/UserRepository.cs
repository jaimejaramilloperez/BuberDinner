﻿using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = [];

    public User? GetUserByEmail(string email)
    {
        return Users.Find(x => x.Email == email);
    }

    public void Add(User user)
    {
        Users.Add(user);
    }
}
