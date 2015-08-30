using System;
using System.Drawing;
using NHibernate;
using TV.Core.Context;
using TV.Model;
using TV.ModelImpl.DbModel;

namespace TV.ModelImpl.Model.PaperFormats
{
    public class PaperFormatStorable : IPaperFormat
    {
        public string Name
        {
            get { return _dbPaperFormat.Name; }
            set { _dbPaperFormat.Name = value; }
        }

        public Size Size
        {
            get { return new Size(_dbPaperFormat.Width, _dbPaperFormat.Height); }
            set
            {
                _dbPaperFormat.Width = value.Width;
                _dbPaperFormat.Height = value.Height;
            }
        }

        public bool IsBuildIn
        {
            get { return false; }
        }

        public PaperFormatStorable(DbPaperFormat dbPaperFormat)
        {
            _dbPaperFormat = dbPaperFormat;
        }

        public void Save()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Save custom paper format '{0}'.", Name)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        if (_dbPaperFormat.Id == Guid.Empty)
                        {
                            session.Save(_dbPaperFormat);
                        }
                        else
                        {
                            session.Update(_dbPaperFormat);
                        }
                        tx.Commit();
                    }
                }
            }
        }

        public void Reload()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Reload custom paper format '{0}'.", Name)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        DbPaperFormat reloadedcustPaperFmt = (DbPaperFormat)session.Load<DbPaperFormat>(_dbPaperFormat.Id);

                        _dbPaperFormat.Name = reloadedcustPaperFmt.Name;
                        _dbPaperFormat.Width = reloadedcustPaperFmt.Width;
                        _dbPaperFormat.Height = reloadedcustPaperFmt.Height;
                    }
                }
            }
        }

        public void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Delete custom paper format '{0}'.", Name)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        session.Delete(_dbPaperFormat);
                        tx.Commit();
                    }
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}x{2}", Name, _dbPaperFormat.Width, _dbPaperFormat.Height);
        }

        private readonly DbPaperFormat _dbPaperFormat;
    }
}