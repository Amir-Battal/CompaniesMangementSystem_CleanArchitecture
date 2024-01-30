//using CleanArchitecture.Application.Interfaces;
//using CleanArchitecture.Domain.Entities;
//using CleanArchitecture.Persistence.Data;
//using Microsoft.EntityFrameworkCore;

//namespace CleanArchitecture.Persistence.Interfaces;

//public class UnitOfWork : IUnitOfWork
//{
//    private readonly AppDbContext _context;

//    public UnitOfWork(AppDbContext context)
//    {
//        _context = context;
//    }

//    public DbSet<Company> companies
//    {
//        get;
//    }

//    public async Task<int> SaveChangesAsync()
//    {
//        return await _context.SaveChangesAsync();
//    }
//}
