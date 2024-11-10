﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;

namespace Tema.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IGenderRepository Gender { get; private set; }
        public ICountryRepository Country { get; private set; }
        public ICriteriaRepository Criteria { get; private set; }
        public ILanguageRepository Language { get; private set; }
        public IMaritalStatusRepository MaritalStatus { get; private set; }
        public IRegionRepository Region { get; private set; }
        public IRelationRepository Relation { get; private set; }
        public INationalityRepository Nationality { get; private set; }
        public IBankRepository Bank { get; private set; }


        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Gender = new GenderRepository(_db);
            Country = new CountryRepository(_db);
            Criteria = new CriteriaRepository(_db);
            Language = new LanguageRepository(_db);
            MaritalStatus = new MaritalStatusRepository(_db);
            Region = new RegionRepository(_db);
            Relation = new RelationRepository(_db);
            Nationality = new NationalityRepository(_db);
            Bank = new BankRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}