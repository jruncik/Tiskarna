﻿using System;
using NHibernate;
using TV.Core.Context;
using TV.Model;
using TV.ModelImpl.DbModel;

namespace TV.ModelImpl.Model
{
    public class Proofsheet : IProofsheet
    {
        public Guid Id
        {
            get { return _dbProofSheet.Id; }
            set { _dbProofSheet.Id = value; }
        }

        public DateTime Time
        {
            get { return _dbProofSheet.Time; }
            set { _dbProofSheet.Time = value; }
        }

        public bool Passed
        {
            get { return _dbProofSheet.Passed; }
            set { _dbProofSheet.Passed = value; }
        }

        public Proofsheet() :
            this(new DbProofsheet())
        {
        }

        public Proofsheet(DbProofsheet dbProofsheet)
        {
            _dbProofSheet = dbProofsheet;
        }

        public void Save()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    if (Id == Guid.Empty)
                    {
                        using (AppliactionContext.Log.LogTime(this, $"Save proofsheet."))
                        {
                            session.Save(_dbProofSheet);
                        }
                    }
                    else
                    {
                        using (AppliactionContext.Log.LogTime(this, $"Update proofsheet {Id}"))
                        {
                            session.Update(_dbProofSheet);
                        }
                    }
                    tx.Commit();
                }
            }
        }

        public void Reload()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    using (AppliactionContext.Log.LogTime(this, $"Reload proofsheet {Id}"))
                    {
                        DbProofsheet reloadeDbProofsheet = session.Load<DbProofsheet>(_dbProofSheet.Id);

                        _dbProofSheet.Time = reloadeDbProofsheet.Time;
                        _dbProofSheet.Passed = reloadeDbProofsheet.Passed;
                    }
                    tx.Commit();
                }
            }
        }

        public void Delete()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    using (AppliactionContext.Log.LogTime(this, $"Delete proofsheet {Id}"))
                    {
                        session.Delete(_dbProofSheet);
                    }
                    tx.Commit();
                }
            }
        }

        private readonly DbProofsheet _dbProofSheet;
    }
}