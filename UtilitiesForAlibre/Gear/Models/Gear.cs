namespace Bolsover.Gear.Models
{
    public class Gear : IGear
    {
        private double _module;
        private double _numberOfTeeth;
        private double _pressureAngle;
        private double _workingPressureAngle;
        private double _helixAngle;
        private double _rootFilletFactor;
        private double _addendumFilletFactor;
        private string _gearType;
        private double _circularBacklash;
        private double _delta;
        private double _workingCentreDistance;
        private double _standardCentreDistance;
        private double _centreDistanceIncrementFactor;
        private double _pitchDiameter;
        private double _workingPitchDiameter;
        private double _baseCircleDiameter;
        private double _rootCircleDiameter;
        private double _addendumCircleDiameter;
        private double _dedendumCircleDiameter;
        private double _profileShift;
        private double _axialPitch;
        private double _helixPitchLength;
        private double _helicalPressureAngle;
        private double _involuteFunction;
        private double _transverseModule;
        private double _rootFilletDiameter;
        private double _tipReliefRadius;
        private double _contactRatio;
        private double _coefficientOfProfileShift;


        public double Module
        {
            get => _module;
            set => _module = value;
        }

        public double NumberOfTeeth
        {
            get => _numberOfTeeth;
            set => _numberOfTeeth = value;
        }

        public double PressureAngle
        {
            get => _pressureAngle;
            set => _pressureAngle = value;
        }

        public double WorkingPressureAngle
        {
            get => _workingPressureAngle;
            set => _workingPressureAngle = value;
        }

        public double HelixAngle
        {
            get => _helixAngle;
            set => _helixAngle = value;
        }

        public double RootFilletFactor
        {
            get => _rootFilletFactor;
            set => _rootFilletFactor = value;
        }

        public double AddendumFilletFactor
        {
            get => _addendumFilletFactor;
            set => _addendumFilletFactor = value;
        }

        public string GearType
        {
            get => _gearType;
            set => _gearType = value;
        }

        public double CircularBacklash
        {
            get => _circularBacklash;
            set => _circularBacklash = value;
        }

        public double Delta
        {
            get => _delta;
            set => _delta = value;
        }

        public double WorkingCentreDistance
        {
            get => _workingCentreDistance;
            set => _workingCentreDistance = value;
        }

        public double StandardCentreDistance
        {
            get => _standardCentreDistance;
            set => _standardCentreDistance = value;
        }

        public double CentreDistanceIncrementFactor
        {
            get => _centreDistanceIncrementFactor;
            set => _centreDistanceIncrementFactor = value;
        }

        public double PitchDiameter
        {
            get => _pitchDiameter;
            set => _pitchDiameter = value;
        }

        public double WorkingPitchDiameter
        {
            get => _workingPitchDiameter;
            set => _workingPitchDiameter = value;
        }

        public double BaseCircleDiameter
        {
            get => _baseCircleDiameter;
            set => _baseCircleDiameter = value;
        }

        public double RootCircleDiameter
        {
            get => _rootCircleDiameter;
            set => _rootCircleDiameter = value;
        }

        public double AddendumCircleDiameter
        {
            get => _addendumCircleDiameter;
            set => _addendumCircleDiameter = value;
        }

        public double DedendumCircleDiameter
        {
            get => _dedendumCircleDiameter;
            set => _dedendumCircleDiameter = value;
        }

        public double CoefficientOfProfileShift
        {
            get => _coefficientOfProfileShift;
            set => _coefficientOfProfileShift = value;
        }

        public double ProfileShift
        {
            get => _profileShift;
            set => _profileShift = value;
        }

        public double AxialPitch
        {
            get => _axialPitch;
            set => _axialPitch = value;
        }

        public double HelixPitchLength
        {
            get => _helixPitchLength;
            set => _helixPitchLength = value;
        }

        public double HelicalPressureAngle
        {
            get => _helicalPressureAngle;
            set => _helicalPressureAngle = value;
        }

        public double InvoluteFunction
        {
            get => _involuteFunction;
            set => _involuteFunction = value;
        }

        public double TransverseModule
        {
            get => _transverseModule;
            set => _transverseModule = value;
        }

        public double RootFilletDiameter
        {
            get => _rootFilletDiameter;
            set => _rootFilletDiameter = value;
        }

        public double TipReliefRadius
        {
            get => _tipReliefRadius;
            set => _tipReliefRadius = value;
        }

        public double ContactRatio
        {
            get => _contactRatio;
            set => _contactRatio = value;
        }
    }
}