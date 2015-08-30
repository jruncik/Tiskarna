using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NHibernate;
using TV.Core;
using TV.Core.Context;
using TV.Core.Rights;
using TV.Model;
using TV.ModelImpl.DbModel;

namespace TV.ModelImpl.Model.PaperFormats
{
    public class PaperFormats : IPaperFormats
    {
        public PaperFormats()
        {
            InitializeBuildInFormats();
            ReadCustomFormats();
        }

        public IList<IPaperFormat> Formats
        {
            get { return _paperFormats; }
        }

        public IPaperFormat AddFormat(string name, int width, int height)
        {
            CheckRights();
            IPaperFormat paperFormat = TryFindPaperFormat(name);
            if (paperFormat != null)
            {
                AppliactionContext.Log.Error(this, String.Format(Resources.PaperFormatAlreadyExist, paperFormat.Name));
                throw new TvException(String.Format(Resources.PaperFormatAlreadyExist, paperFormat.Name));
            }

            PaperFormatStorable newPaperFormat = new PaperFormatStorable(new DbPaperFormat());
            newPaperFormat.Name = name;
            newPaperFormat.Size = new Size(width, height);

            newPaperFormat.Save();
            _paperFormats.Add(newPaperFormat);

            return newPaperFormat;
        }

        public void DeleteFormat(IPaperFormat paperformat)
        {
            CheckRights();
            if (paperformat.IsBuildIn)
            {
                AppliactionContext.Log.Error(this, "Format can't be deleted.");
                AppliactionContext.Log.Error(this, String.Format(Resources.PapeFormatIsBuildinFormat, paperformat.Name));
                throw new TvException(String.Format(Resources.PapeFormatIsBuildinFormat, paperformat.Name));
            }

            PaperFormatStorable storablePaperFormat = paperformat as PaperFormatStorable;
            _paperFormats.Remove(storablePaperFormat);
            storablePaperFormat.Delete();
        }

        private void InitializeBuildInFormats()
        {
            InitializeBuildInFormatsA();
            InitializeBuildInFormatsB();
            InitializeBuildInFormatsC();
            InitializeBuildInFormatsRa();
            InitializeBuildInFormatsSra();
        }

        private void InitializeBuildInFormatsA()
        {
            _paperFormats.Add(new PaperFormatBuildin("A0", 841, 1189));
            _paperFormats.Add(new PaperFormatBuildin("A1", 594, 841));
            _paperFormats.Add(new PaperFormatBuildin("A2", 420, 594));
            _paperFormats.Add(new PaperFormatBuildin("A3", 297, 420));
            _paperFormats.Add(new PaperFormatBuildin("A4", 210, 297));
            _paperFormats.Add(new PaperFormatBuildin("A5", 148, 210));
            _paperFormats.Add(new PaperFormatBuildin("A6", 105, 148));
            _paperFormats.Add(new PaperFormatBuildin("A7", 74, 105));
            _paperFormats.Add(new PaperFormatBuildin("A8", 52, 74));
            _paperFormats.Add(new PaperFormatBuildin("A8", 52, 74));
            _paperFormats.Add(new PaperFormatBuildin("A9", 37, 52));
            _paperFormats.Add(new PaperFormatBuildin("A10", 26, 37));
        }

        private void InitializeBuildInFormatsB()
        {
            _paperFormats.Add(new PaperFormatBuildin("B0", 1000, 1414));
            _paperFormats.Add(new PaperFormatBuildin("B1", 707, 1000));
            _paperFormats.Add(new PaperFormatBuildin("B2", 500, 707));
            _paperFormats.Add(new PaperFormatBuildin("B3", 353, 500));
            _paperFormats.Add(new PaperFormatBuildin("B4", 250, 353));
            _paperFormats.Add(new PaperFormatBuildin("B5", 176, 250));
            _paperFormats.Add(new PaperFormatBuildin("B6", 125, 176));
            _paperFormats.Add(new PaperFormatBuildin("B7", 88, 125));
            _paperFormats.Add(new PaperFormatBuildin("B8", 62, 88));
            _paperFormats.Add(new PaperFormatBuildin("B9", 44, 62));
            _paperFormats.Add(new PaperFormatBuildin("B10", 31, 44));
        }

        private void InitializeBuildInFormatsC()
        {
            _paperFormats.Add(new PaperFormatBuildin("C0", 917, 1297));
            _paperFormats.Add(new PaperFormatBuildin("C1", 648, 917));
            _paperFormats.Add(new PaperFormatBuildin("C2", 458, 648));
            _paperFormats.Add(new PaperFormatBuildin("C3", 324, 458));
            _paperFormats.Add(new PaperFormatBuildin("C4", 229, 324));
            _paperFormats.Add(new PaperFormatBuildin("C5", 162, 229));
            _paperFormats.Add(new PaperFormatBuildin("C6", 114, 162));
            _paperFormats.Add(new PaperFormatBuildin("C7", 81, 114));
            _paperFormats.Add(new PaperFormatBuildin("C8", 57, 81));
            _paperFormats.Add(new PaperFormatBuildin("C9", 40, 57));
            _paperFormats.Add(new PaperFormatBuildin("C10", 28, 40));
        }

        private void InitializeBuildInFormatsRa()
        {
            _paperFormats.Add(new PaperFormatBuildin("RA0", 860, 1220));
            _paperFormats.Add(new PaperFormatBuildin("RA1", 610, 860));
            _paperFormats.Add(new PaperFormatBuildin("RA2", 430, 610));
            _paperFormats.Add(new PaperFormatBuildin("RA3", 305, 430));
            _paperFormats.Add(new PaperFormatBuildin("RA4", 215, 305));
        }

        private void InitializeBuildInFormatsSra()
        {
            _paperFormats.Add(new PaperFormatBuildin("SRA0", 900, 1280));
            _paperFormats.Add(new PaperFormatBuildin("SRA1", 640, 900));
            _paperFormats.Add(new PaperFormatBuildin("SRA2", 450, 640));
            _paperFormats.Add(new PaperFormatBuildin("SRA3", 320, 450));
            _paperFormats.Add(new PaperFormatBuildin("SRA4", 225, 320));
        }

        private void ReadCustomFormats()
        {
            using (AppliactionContext.Log.LogTime(this, "Reading all custom aper formats"))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    IList<DbPaperFormat> dbPaperFormats = session.CreateCriteria<DbPaperFormat>().List<DbPaperFormat>();
                    foreach (DbPaperFormat dbPaperFormat in dbPaperFormats)
                    {
                        IPaperFormat newCustomPaperFormat = new PaperFormatStorable(dbPaperFormat);
                        _paperFormats.Add(newCustomPaperFormat);
                        AppliactionContext.Log.Debug(this, String.Format("Custom paper format '{0}' loaded from DB.", newCustomPaperFormat));
                    }
                }
            }
        }

        private void CheckRights()
        {
            if (!UserContext.Context.IsInRole(Roles.ManageUsers))
            {
                AppliactionContext.Log.Error(this, String.Format(Resources.NotEnoughtRights, UserContext.User.Username));
                throw new RightsException(String.Format(Resources.NotEnoughtRights, UserContext.User.Username));
            }
        }

        private IPaperFormat TryFindPaperFormat(string formatName)
        {
            return _paperFormats.FirstOrDefault(format => String.Compare(formatName, format.Name, StringComparison.OrdinalIgnoreCase) == 0);
        }

        private readonly IList<IPaperFormat> _paperFormats = new List<IPaperFormat>(64);
    }
}