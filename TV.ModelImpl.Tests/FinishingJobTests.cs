using System;
using NUnit.Framework;
using TV.ModelImpl.Model;

namespace TV.ModelImpl.Tests
{
    [TestFixture]
    public class FinishingJobTests
    {
        [Test]
        public void TestNumberingFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Numbering, () => finishingJob.Numbering, value => finishingJob.Numbering = value);
        }

        [Test]
        public void TestFolddingFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Foldding, () => finishingJob.Foldding, value => finishingJob.Foldding = value);
        }

        [Test]
        public void TestPerforationFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Perforation, () => finishingJob.Perforation, value => finishingJob.Perforation = value);
        }

        [Test]
        public void TestCutFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Cut, () => finishingJob.Cut, value => finishingJob.Cut = value);
        }

        [Test]
        public void TestBigovaniFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Bigovani, () => finishingJob.Bigovani, value => finishingJob.Bigovani = value);
        }

        [Test]
        public void TestAssemblingFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Assembling, () => finishingJob.Assembling, value => finishingJob.Assembling = value);
        }

        [Test]
        public void TestGluingFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Gluing, () => finishingJob.Gluing, value => finishingJob.Gluing = value);
        }

        [Test]
        public void TestNeedlingFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Needling, () => finishingJob.Needling, value => finishingJob.Needling = value);
        }

        [Test]
        public void TestLaminationFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Lamination, () => finishingJob.Lamination, value => finishingJob.Lamination = value);
        }

        private static void TestSingleFlag(FinishingJob finishingJob, FinishingJobFlag testFlag, Func<bool> getFlag, Action<bool> setFlag)
        {
            Assert.IsFalse(getFlag());
            Assert.AreEqual(FinishingJobFlag.None, finishingJob.Flags);

            setFlag(true);
            Assert.IsTrue(getFlag());
            Assert.AreEqual(testFlag, finishingJob.Flags);

            setFlag(false);
            Assert.IsFalse(getFlag());
            Assert.AreEqual(FinishingJobFlag.None, finishingJob.Flags);
        }
    }
}
