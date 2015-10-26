using System;
using NHibernate;
using TV.Core.Context;
using TV.Model;
using TV.ModelImpl.DbModel;

namespace TV.ModelImpl.Model
{
    public class FinishingJob : IFinishingJob
    {
        /// <summary> Cislovani </summary>
        public bool Numbering
        {
            get { return Flags == FinishingJobFlag.Numbering; }
            set { SetFlag(value, FinishingJobFlag.Numbering); }
        }

        /// <summary> Falcovani </summary>
        public bool Foldding
        {
            get { return Flags == FinishingJobFlag.Foldding; }
            set { SetFlag(value, FinishingJobFlag.Foldding); }
        }

        /// <summary> Perforace </summary>
        public bool Perforation
        {
            get { return Flags == FinishingJobFlag.Perforation; }
            set { SetFlag(value, FinishingJobFlag.Perforation); }
        }

        /// <summary> Vysek </summary>
        public bool Cut
        {
            get { return Flags == FinishingJobFlag.Cut; }
            set { SetFlag(value, FinishingJobFlag.Cut); }
        }

        /// <summary> Bigovani </summary>
        public bool Bigovani
        {
            get { return Flags == FinishingJobFlag.Bigovani; }
            set { SetFlag(value, FinishingJobFlag.Bigovani); }
        }

        /// <summary> Snaseni </summary>
        public bool Assembling
        {
            get { return Flags == FinishingJobFlag.Assembling; }
            set { SetFlag(value, FinishingJobFlag.Assembling); }
        }

        /// <summary> Lepeni </summary>
        public bool Gluing
        {
            get { return Flags == FinishingJobFlag.Gluing; }
            set { SetFlag(value, FinishingJobFlag.Gluing); }
        }

        /// <summary> Siti </summary>
        public bool Needling
        {
            get { return Flags == FinishingJobFlag.Needling; }
            set { SetFlag(value, FinishingJobFlag.Needling); }
        }

        /// <summary> Saminace </summary>
        public bool Lamination
        {
            get { return Flags == FinishingJobFlag.Lamination; }
            set { SetFlag(value, FinishingJobFlag.Lamination); }
        }

        /// <summary> Jine prace </summary>
        public string Other
        {
            get { return _dbFinishingJob.Other; }
            set { _dbFinishingJob.Other = value; }
        }

        public FinishingJobFlag Flags
        {
            get { return (FinishingJobFlag)_dbFinishingJob.Flags; }
            set { _dbFinishingJob.Flags = (int)value; }
        }

        public virtual Guid Id
        {
            get { return _dbFinishingJob.Id; }
            set { _dbFinishingJob.Id = value; }
        }

        public FinishingJob() :
            this(new DbFinishingJob())
        {
        }

        public FinishingJob(DbFinishingJob dbFinishingJob)
        {
            _dbFinishingJob = dbFinishingJob;
        }

        public void Save()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Save finishing job '{0} {1}'.", Flags, Other)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        if (Id == Guid.Empty)
                        {
                            session.Save(_dbFinishingJob);
                        }
                        else
                        {
                            session.Update(_dbFinishingJob);
                        }
                        tx.Commit();
                    }
                }
            }
        }

        public void Reload()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Reload finishing job '{0} {1}'.", Flags, Other)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        DbFinishingJob reloadedFinishingJob = session.Load<DbFinishingJob>(_dbFinishingJob.Id);

                        _dbFinishingJob.Flags = reloadedFinishingJob.Flags;
                        _dbFinishingJob.Other = reloadedFinishingJob.Other;
                    }
                }
            }
        }

        public void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Delete finishing job '{0} {1}'.", Flags, Other)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        session.Delete(_dbFinishingJob);
                        tx.Commit();
                    }
                }
            }
        }

        private void SetFlag(bool value, FinishingJobFlag flag)
        {
            if (value)
            {
                Flags |= flag;
            }
            else
            {
                Flags &= ~flag;
            }
        }

        private DbFinishingJob _dbFinishingJob;
    }
}