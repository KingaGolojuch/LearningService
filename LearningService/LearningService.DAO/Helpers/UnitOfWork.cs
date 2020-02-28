﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Reflection;
using LearningService.DAO.Entities;

namespace LearningService.DAO.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        public ISession Session { get; set; }

        static UnitOfWork()
        {
            var mapping = MappingHelper.GetIdentityMappings(new[] { typeof(ApplicationUser) });

            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(x => x.FromConnectionStringWithKey("DefaultConnection")))
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
                    //we add HBM container for storing named queries only!!! for traditional mapping use Fluent!
                    m.HbmMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
                })
                .ExposeConfiguration(cfg => cfg.AddDeserializedMapping(mapping, null))
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}