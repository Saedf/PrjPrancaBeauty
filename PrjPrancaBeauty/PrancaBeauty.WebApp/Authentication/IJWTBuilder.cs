﻿namespace PrancaBeauty.WebApp.Authentication
{
    public interface IJWTBuilder
    {
        Task<string> CreateTokenAync(string UserId);
    }
}
