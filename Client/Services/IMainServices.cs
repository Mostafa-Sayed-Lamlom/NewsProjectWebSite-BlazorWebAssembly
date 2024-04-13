﻿namespace BlazorApp1.Client.Services
{
    public interface IMainServices<T> where T : class
    {
        Task<List<T>> GetAll(string ApiName );
        Task<T> GetRow(string ApiName);
        Task<T> AddNewRow(T entity, string ApiName);
		Task<T> UpdateRow(T entity, string ApiName);
        Task DeleteRow(string ApiName);
	}
}
