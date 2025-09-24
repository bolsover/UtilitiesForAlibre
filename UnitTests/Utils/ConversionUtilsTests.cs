using System;
using Bolsover.Utils;
using NUnit.Framework;

namespace UnitTests.Utils
{
    [TestFixture]
    public class ConversionUtilsTests
    {
        [Test]
        public void RadiansTest()
        {
            var degrees = 90.0;
            var expected = Math.PI / 2;
            var actual = ConversionUtils.Radians(degrees);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void DegreesTest()
        {
            var radians = Math.PI / 2;
            var expected = 90.0;
            var actual = ConversionUtils.Degrees(radians);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void MillimetersToInchesTest()
        {
            var mm = 25.4;
            double expected = 1;
            var actual = ConversionUtils.MillimetersToInches(mm);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void InchesToMillimetersTest()
        {
            double inches = 1;
            var expected = 25.4;
            var actual = ConversionUtils.InchesToMillimeters(inches);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void ModuleToDiametralPitchTest()
        {
            double module = 1;
            var expected = 25.4;
            var actual = ConversionUtils.ModuleToDiametralPitch(module);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void DiametralPitchToModuleTest()
        {
            var diametralPitch = 25.4;
            double expected = 1;
            var actual = ConversionUtils.DiametralPitchToModule(diametralPitch);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void PitchMillimetersToModuleTest()
        {
            var pitchMillimeters = Math.PI;
            double expected = 1;
            var actual = ConversionUtils.PitchMillimetersToModule(pitchMillimeters);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void ModuleToPitchInchesTest()
        {
            double module = 1;
            var expected = Math.PI / 25.4;
            var actual = ConversionUtils.ModuleToPitchInches(module);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void PitchInchesToModuleTest()
        {
            var pitchInches = Math.PI / 25.4;
            double expected = 1;
            var actual = ConversionUtils.PitchInchesToModule(pitchInches);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void ModuleToCircularPitchTest()
        {
            double module = 1;
            var expected = Math.PI;
            var actual = ConversionUtils.ModuleToCircularPitch(module);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void NormalModuleToRadialModuleTest()
        {
            double axialModule = 1;
            var helixAngle = ConversionUtils.Radians(20);
            var expected = axialModule / Math.Sin(helixAngle);
            var actual = ConversionUtils.WormNormalModuleToRadialModule(axialModule, helixAngle);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void RadialModuleToNormalModuleTest()
        {
            double axialModule = 1;
            var helixAngle = ConversionUtils.Radians(20);
            var expected = axialModule * Math.Sin(helixAngle);
            var actual = ConversionUtils.WormRadialModuleToNormalModule(axialModule, helixAngle);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void NormalModuleToAxialModuleTest()
        {
            double axialModule = 1;
            var helixAngle = ConversionUtils.Radians(20);
            var expected = axialModule / Math.Cos(helixAngle);
            //double expected = 1;
            var actual = ConversionUtils.WormNormalModuleToAxialModule(axialModule, helixAngle);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void AxialModuleToNormalModuleTest()
        {
            double axialModule = 1;
            var helixAngle = ConversionUtils.Radians(20);
            var expected = axialModule * Math.Cos(helixAngle);
            //double expected = 1;
            var actual = ConversionUtils.WormAxialModuleToNormalModule(axialModule, helixAngle);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void RadialModuleToAxialModuleTest()
        {
            double axialModule = 1;
            var helixAngle = ConversionUtils.Radians(20);
            var expected = 0.36397023;
            var actual = ConversionUtils.WormRadialModuleToAxialModule(axialModule, helixAngle);
            Assert.AreEqual(expected, actual, 1e-6);
        }
        
        [Test]
        public void AxialModuleToRadialModuleTest()
        {
            double axialModule = 1;
            var helixAngle = ConversionUtils.Radians(20);
            var expected = 2.747477;
            var actual = ConversionUtils.WormAxialModuleToRadialModule(axialModule, helixAngle);
            Assert.AreEqual(expected, actual, 1e-6);
        }
    }
}