using System;
using System.Drawing;
using TV.Model;
using TV.ModelImpl.DbModel;

namespace TV.ModelImpl.Model
{
    public class PaperType : IPaperType
    {
        public Guid Id
        {
            get { return _dbPapertype.Id; }
            set { _dbPapertype.Id = value; }
        }

        public Color Color
        {
            get { return Color.FromArgb(_dbPapertype.Color); }
            set { _dbPapertype.Color = value.ToArgb(); }
        }

        public string Type
        {
            get { return _dbPapertype.Type; }
            set { _dbPapertype.Type = value; }
        }

        public PaperType() :
            this(new DbPaperType())
        {
        }

        public PaperType(DbPaperType dbPaperType)
        {
            _dbPapertype = dbPaperType;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        private readonly DbPaperType _dbPapertype;
    }
}