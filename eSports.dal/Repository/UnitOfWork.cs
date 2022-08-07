﻿using eSports.dal.Data;
using eSports.dal.Repository.IRepository;

namespace eSports.dal.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    
    public IGameRepository Game { get; }
    public ITournamentRepository Tournament { get; }

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

        Game = new GameRepository(_dbContext);
        Tournament = new TournamentRepository(_dbContext);
    }


    
    
    
    public void Save()
    {
        _dbContext.SaveChanges();
    }
}