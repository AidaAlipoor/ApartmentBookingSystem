﻿using Book.Domain.Abstraction;

namespace Book.Domain.Users.UserErrors
{
    public static class UserErrors
    {
        public static Error NotFound = new(
            "User.Found",
            "The user with the specified identifier was not found");

        public static Error InvalidCredentials = new(
            "User.InvalidCredentials",
            "The provided credentials were invalid");
    }
}
