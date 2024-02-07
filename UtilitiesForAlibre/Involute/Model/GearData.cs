namespace Bolsover.Involute.Model
{
    public class GearData
    {
        private string _item;
        private string _metricValue;
        
        private string _imperialValue;
        private string _note;
        private bool _isError;
        
        public GearData(string item, string metricValue, string imperialValue, string note, bool isError)
        {
            _item = item;
            _metricValue = metricValue;
            _imperialValue = imperialValue;
            _note = note;
            _isError = isError;
        }

        public string Item
        {
            get => _item;
            set => _item = value;
        }
        
        public string MetricValue
        {
            get => _metricValue;
            set => _metricValue = value;
        }
        
        public string ImperialValue
        {
            get => _imperialValue;
            set => _imperialValue = value;
        }
        
        public string Note
        {
            get => _note;
            set => _note = value;
        }
        
        public bool IsError
        {
            get => _isError;
            set => _isError = value;
        }
        
    }
}