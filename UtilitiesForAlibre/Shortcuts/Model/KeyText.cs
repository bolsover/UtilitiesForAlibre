using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bolsover.Shortcuts.Model
{
    public sealed class KeyText : INotifyPropertyChanged
    {
        private string _aKeyText;
        
        private string _altGrKeyText;
        
        private string _apostropheKeyText;
        
        private string _backslashKeyText;
        
        private string _backSlashKeyText;
        
        private string _backspaceKeyText;
        
        private string _bKeyText;
        
        private string _capsLockKeyText;
        
        private string _cKeyText;
        
        private string _closeBracketKeyText;
        
        private string _commaKeyText;
        
        private string _deleteKeyText;
        
        private string _dKeyText;
        
        private string _downKeyText;
        
        private string _eightKeyText;
        
        private string _eKeyText;
        
        private string _endKeyText;
        
        private string _enterKeyText;
        
        
        private string _equalKeyText;
        
        private string _equalsKeyText;
        
        private string _escapeKeyText;
        
        private string _f10KeyText;
        
        private string _f11KeyText;
        
        private string _f12KeyText;
        private string _f1KeyText;
        
        private string _f2KeyText;
        
        private string _f3KeyText;
        
        private string _f4KeyText;
        
        private string _f5KeyText;
        
        private string _f6KeyText;
        
        private string _f7KeyText;
        
        private string _f8KeyText;
        
        private string _f9KeyText;
        
        private string _fiveKeyText;
        
        private string _fKeyText;
        private string _fnKeyText;
        
        private string _forwardSlashKeyText;
        
        private string _fourKeyText;
        
        private string _gKeyText;
        
        private string _graveKeyText;
        
        
        private string _hashKeyText;
        
        private string _hKeyText;
        
        private string _homeKeyText;
        
        private string _iKeyText;
        
        private string _insertKeyText;
        
        private string _jKeyText;
        
        private string _kKeyText;
        
        private string _leftAltKeyText;
        
        private string _leftBracketKeyText;
        
        private string _leftCtrlKeyText;
        
        private string _leftKeyText;
        
        private string _leftShiftKeyText;
        
        private string _lKeyText;
        
        private string _minusKeyText;
        
        private string _mKeyText;
        
        private string _nineKeyText;
        
        private string _nKeyText;
        
        private string _num0KeyText;
        
        private string _num1KeyText;
        
        private string _num2KeyText;
        
        private string _num3KeyText;
        
        private string _num4KeyText;
        
        private string _num5KeyText;
        
        private string _num6KeyText;
        
        private string _num7KeyText;
        
        private string _num8KeyText;
        
        private string _num9KeyText;
        
        private string _numDecimalKeyText;
        
        private string _numDivideKeyText;
        
        private string _numEnterKeyText;
        
        private string _numLockKeyText;
        
        private string _numMinusKeyText;
        
        private string _numMultiplyKeyText;
        
        private string _numPad0KeyText;
        
        private string _numPad1KeyText;
        
        private string _numPad2KeyText;
        
        private string _numPad3KeyText;
        
        private string _numPad4KeyText;
        
        private string _numPad5KeyText;
        
        private string _numPad6KeyText;
        
        private string _numPad7KeyText;
        
        private string _numPad8KeyText;
        
        private string _numPad9KeyText;
        
        private string _numPadDivideKeyText;
        
        private string _numPadEnterKeyText;
        
        private string _numPadMinusKeyText;
        
        private string _numPadMultiplyKeyText;
        
        private string _numPadPeriodKeyText;
        
        private string _numPadPlusKeyText;
        
        private string _numPlusKeyText;
        
        private string _oKeyText;
        
        private string _oneKeyText;
        
        private string _openBracketKeyText;
        
        private string _pageDownKeyText;
        
        private string _pageUpKeyText;
        
        
        private string _pauseBreakKeyText;
        
        private string _periodKeyText;
        
        private string _pKeyText;
        
        private string _printScreenKeyText;
        
        private string _qKeyText;
        
        private string _rightBracketKeyText;
        
        private string _rightCtrlKeyText;
        
        private string _rightKeyText;
        
        private string _rightShiftKeyText;
        
        private string _rKeyText;
        
        private string _scrollLockKeyText;
        
        private string _semicolonKeyText;
        
        private string _sevenKeyText;
        
        private string _sixKeyText;
        
        private string _sKeyText;
        
        
        private string _slashKeyText;
        
        private string _spaceKeyText;
        
        private string _tabKeyText;
        
        private string _threeKeyText;
        
        private string _tKeyText;
        
        private string _twoKeyText;
        
        private string _uKeyText;
        
        private string _upKeyText;
        
        private string _vKeyText;
        private string _windowKeyText;
        
        private string _wKeyText;
        
        private string _xKeyText;
        
        private string _yKeyText;
        
        private string _zeroKeyText;
        
        private string _zKeyText;
        
        public string F1KeyText
        {
            get => _f1KeyText;
            set => SetField(ref _f1KeyText, value);
        }
        
        public string F2KeyText
        {
            get => _f2KeyText;
            set => SetField(ref _f2KeyText, value);
        }
        
        public string F3KeyText
        {
            get => _f3KeyText;
            set => SetField(ref _f3KeyText, value);
        }
        
        public string F4KeyText
        {
            get => _f4KeyText;
            set => SetField(ref _f4KeyText, value);
        }
        
        public string F5KeyText
        {
            get => _f5KeyText;
            set => SetField(ref _f5KeyText, value);
        }
        
        public string F6KeyText
        {
            get => _f6KeyText;
            set => SetField(ref _f6KeyText, value);
        }
        
        public string F7KeyText
        {
            get => _f7KeyText;
            set => SetField(ref _f7KeyText, value);
        }
        
        public string F8KeyText
        {
            get => _f8KeyText;
            set => SetField(ref _f8KeyText, value);
        }
        
        public string F9KeyText
        {
            get => _f9KeyText;
            set => SetField(ref _f9KeyText, value);
        }
        
        public string F10KeyText
        {
            get => _f10KeyText;
            set => SetField(ref _f10KeyText, value);
        }
        
        public string F11KeyText
        {
            get => _f11KeyText;
            set => SetField(ref _f11KeyText, value);
        }
        
        public string F12KeyText
        {
            get => _f12KeyText;
            set => SetField(ref _f12KeyText, value);
        }
        
        public string AKeyText
        {
            get => _aKeyText;
            set => SetField(ref _aKeyText, value);
        }
        
        public string BKeyText
        {
            get => _bKeyText;
            set => SetField(ref _bKeyText, value);
        }
        
        public string CKeyText
        {
            get => _cKeyText;
            set => SetField(ref _cKeyText, value);
        }
        
        public string DKeyText
        {
            get => _dKeyText;
            set => SetField(ref _dKeyText, value);
        }
        
        public string EKeyText
        {
            get => _eKeyText;
            set => SetField(ref _eKeyText, value);
        }
        
        public string FKeyText
        {
            get => _fKeyText;
            set => SetField(ref _fKeyText, value);
        }
        
        public string GKeyText
        {
            get => _gKeyText;
            set => SetField(ref _gKeyText, value);
        }
        
        public string HKeyText
        {
            get => _hKeyText;
            set => SetField(ref _hKeyText, value);
        }
        
        public string IKeyText
        {
            get => _iKeyText;
            set => SetField(ref _iKeyText, value);
        }
        
        public string JKeyText
        {
            get => _jKeyText;
            set => SetField(ref _jKeyText, value);
        }
        
        public string KKeyText
        {
            get => _kKeyText;
            set => SetField(ref _kKeyText, value);
        }
        
        public string LKeyText
        {
            get => _lKeyText;
            set => SetField(ref _lKeyText, value);
        }
        
        public string MKeyText
        {
            get => _mKeyText;
            set => SetField(ref _mKeyText, value);
        }
        
        public string NKeyText
        {
            get => _nKeyText;
            set => SetField(ref _nKeyText, value);
        }
        
        public string OKeyText
        {
            get => _oKeyText;
            set => SetField(ref _oKeyText, value);
        }
        
        public string PKeyText
        {
            get => _pKeyText;
            set => SetField(ref _pKeyText, value);
        }
        
        public string QKeyText
        {
            get => _qKeyText;
            set => SetField(ref _qKeyText, value);
        }
        
        public string RKeyText
        {
            get => _rKeyText;
            set => SetField(ref _rKeyText, value);
        }
        
        public string SKeyText
        {
            get => _sKeyText;
            set => SetField(ref _sKeyText, value);
        }
        
        public string TKeyText
        {
            get => _tKeyText;
            set => SetField(ref _tKeyText, value);
        }
        
        public string UKeyText
        {
            get => _uKeyText;
            set => SetField(ref _uKeyText, value);
        }
        
        public string VKeyText
        {
            get => _vKeyText;
            set => SetField(ref _vKeyText, value);
        }
        
        public string WKeyText
        {
            get => _wKeyText;
            set => SetField(ref _wKeyText, value);
        }
        
        public string XKeyText
        {
            get => _xKeyText;
            set => SetField(ref _xKeyText, value);
        }
        
        public string YKeyText
        {
            get => _yKeyText;
            set => SetField(ref _yKeyText, value);
        }
        
        public string ZKeyText
        {
            get => _zKeyText;
            set => SetField(ref _zKeyText, value);
        }
        
        public string ZeroKeyText
        {
            get => _zeroKeyText;
            set => SetField(ref _zeroKeyText, value);
        }
        
        public string OneKeyText
        {
            get => _oneKeyText;
            set => SetField(ref _oneKeyText, value);
        }
        
        public string TwoKeyText
        {
            get => _twoKeyText;
            set => SetField(ref _twoKeyText, value);
        }
        
        public string ThreeKeyText
        {
            get => _threeKeyText;
            set => SetField(ref _threeKeyText, value);
        }
        
        public string FourKeyText
        {
            get => _fourKeyText;
            set => SetField(ref _fourKeyText, value);
        }
        
        public string FiveKeyText
        {
            get => _fiveKeyText;
            set => SetField(ref _fiveKeyText, value);
        }
        
        public string SixKeyText
        {
            get => _sixKeyText;
            set => SetField(ref _sixKeyText, value);
        }
        
        public string SevenKeyText
        {
            get => _sevenKeyText;
            set => SetField(ref _sevenKeyText, value);
        }
        
        public string EightKeyText
        {
            get => _eightKeyText;
            set => SetField(ref _eightKeyText, value);
        }
        
        public string NineKeyText
        {
            get => _nineKeyText;
            set => SetField(ref _nineKeyText, value);
        }
        
        public string MinusKeyText
        {
            get => _minusKeyText;
            set => SetField(ref _minusKeyText, value);
        }
        
        public string EqualsKeyText
        {
            get => _equalsKeyText;
            set => SetField(ref _equalsKeyText, value);
        }
        
        public string CommaKeyText
        {
            get => _commaKeyText;
            set => SetField(ref _commaKeyText, value);
        }
        
        public string PeriodKeyText
        {
            get => _periodKeyText;
            set => SetField(ref _periodKeyText, value);
        }
        
        public string OpenBracketKeyText
        {
            get => _openBracketKeyText;
            set => SetField(ref _openBracketKeyText, value);
        }
        
        public string CloseBracketKeyText
        {
            get => _closeBracketKeyText;
            set => SetField(ref _closeBracketKeyText, value);
        }
        
        public string SemicolonKeyText
        {
            get => _semicolonKeyText;
            set => SetField(ref _semicolonKeyText, value);
        }
        
        public string ApostropheKeyText
        {
            get => _apostropheKeyText;
            set => SetField(ref _apostropheKeyText, value);
        }
        
        public string ForwardSlashKeyText
        {
            get => _forwardSlashKeyText;
            set => SetField(ref _forwardSlashKeyText, value);
        }
        
        public string BackSlashKeyText
        {
            get => _backSlashKeyText;
            set => SetField(ref _backSlashKeyText, value);
        }
        
        public string GraveKeyText
        {
            get => _graveKeyText;
            set => SetField(ref _graveKeyText, value);
        }
        
        public string SpaceKeyText
        {
            get => _spaceKeyText;
            set => SetField(ref _spaceKeyText, value);
        }
        
        public string EnterKeyText
        {
            get => _enterKeyText;
            set => SetField(ref _enterKeyText, value);
        }
        
        public string EscapeKeyText
        {
            get => _escapeKeyText;
            set => SetField(ref _escapeKeyText, value);
        }
        
        public string InsertKeyText
        {
            get => _insertKeyText;
            set => SetField(ref _insertKeyText, value);
        }
        
        public string DeleteKeyText
        {
            get => _deleteKeyText;
            set => SetField(ref _deleteKeyText, value);
        }
        
        public string HomeKeyText
        {
            get => _homeKeyText;
            set => SetField(ref _homeKeyText, value);
        }
        
        public string EndKeyText
        {
            get => _endKeyText;
            set => SetField(ref _endKeyText, value);
        }
        
        public string PageUpKeyText
        {
            get => _pageUpKeyText;
            set => SetField(ref _pageUpKeyText, value);
        }
        
        public string PageDownKeyText
        {
            get => _pageDownKeyText;
            set => SetField(ref _pageDownKeyText, value);
        }
        
        public string LeftKeyText
        {
            get => _leftKeyText;
            set => SetField(ref _leftKeyText, value);
        }
        
        public string RightKeyText
        {
            get => _rightKeyText;
            set => SetField(ref _rightKeyText, value);
        }
        
        public string UpKeyText
        {
            get => _upKeyText;
            set => SetField(ref _upKeyText, value);
        }
        
        public string DownKeyText
        {
            get => _downKeyText;
            set => SetField(ref _downKeyText, value);
        }
        
        public string NumLockKeyText
        {
            get => _numLockKeyText;
            set => SetField(ref _numLockKeyText, value);
        }
        
        public string NumPad0KeyText
        {
            get => _numPad0KeyText;
            set => SetField(ref _numPad0KeyText, value);
        }
        
        public string NumPad1KeyText
        {
            get => _numPad1KeyText;
            set => SetField(ref _numPad1KeyText, value);
        }
        
        public string NumPad2KeyText
        {
            get => _numPad2KeyText;
            set => SetField(ref _numPad2KeyText, value);
        }
        
        public string NumPad3KeyText
        {
            get => _numPad3KeyText;
            set => SetField(ref _numPad3KeyText, value);
        }
        
        public string NumPad4KeyText
        {
            get => _numPad4KeyText;
            set => SetField(ref _numPad4KeyText, value);
        }
        
        public string NumPad5KeyText
        {
            get => _numPad5KeyText;
            set => SetField(ref _numPad5KeyText, value);
        }
        
        public string NumPad6KeyText
        {
            get => _numPad6KeyText;
            set => SetField(ref _numPad6KeyText, value);
        }
        
        public string NumPad7KeyText
        {
            get => _numPad7KeyText;
            set => SetField(ref _numPad7KeyText, value);
        }
        
        public string NumPad8KeyText
        {
            get => _numPad8KeyText;
            set => SetField(ref _numPad8KeyText, value);
        }
        
        public string NumPad9KeyText
        {
            get => _numPad9KeyText;
            set => SetField(ref _numPad9KeyText, value);
        }
        
        public string NumPadPeriodKeyText
        {
            get => _numPadPeriodKeyText;
            set => SetField(ref _numPadPeriodKeyText, value);
        }
        
        public string NumPadDivideKeyText
        {
            get => _numPadDivideKeyText;
            set => SetField(ref _numPadDivideKeyText, value);
        }
        
        public string NumPadMultiplyKeyText
        {
            get => _numPadMultiplyKeyText;
            set => SetField(ref _numPadMultiplyKeyText, value);
        }
        
        public string NumPadMinusKeyText
        {
            get => _numPadMinusKeyText;
            set => SetField(ref _numPadMinusKeyText, value);
        }
        
        public string NumPadPlusKeyText
        {
            get => _numPadPlusKeyText;
            set => SetField(ref _numPadPlusKeyText, value);
        }
        
        public string NumPadEnterKeyText
        {
            get => _numPadEnterKeyText;
            set => SetField(ref _numPadEnterKeyText, value);
        }
        
        public string PauseBreakKeyText
        {
            get => _pauseBreakKeyText;
            set => SetField(ref _pauseBreakKeyText, value);
        }
        
        public string PrintScreenKeyText
        {
            get => _printScreenKeyText;
            set => SetField(ref _printScreenKeyText, value);
        }
        
        public string ScrollLockKeyText
        {
            get => _scrollLockKeyText;
            set => SetField(ref _scrollLockKeyText, value);
        }
        
        public string CapsLockKeyText
        {
            get => _capsLockKeyText;
            set => SetField(ref _capsLockKeyText, value);
        }
        
        public string EqualKeyText
        {
            get => _equalKeyText;
            set => SetField(ref _equalKeyText, value);
        }
        
        public string BackslashKeyText
        {
            get => _backslashKeyText;
            set => SetField(ref _backslashKeyText, value);
        }
        
        public string LeftBracketKeyText
        {
            get => _leftBracketKeyText;
            set => SetField(ref _leftBracketKeyText, value);
        }
        
        public string RightBracketKeyText
        {
            get => _rightBracketKeyText;
            set => SetField(ref _rightBracketKeyText, value);
        }
        
        public string SlashKeyText
        {
            get => _slashKeyText;
            set => SetField(ref _slashKeyText, value);
        }
        
        public string HashKeyText
        {
            get => _hashKeyText;
            set => SetField(ref _hashKeyText, value);
        }
        
        public string WindowKeyText
        {
            get => _windowKeyText;
            set => SetField(ref _windowKeyText, value);
        }
        
        public string FnKeyText
        {
            get => _fnKeyText;
            set => SetField(ref _fnKeyText, value);
        }
        
        public string LeftCtrlKeyText
        {
            get => _leftCtrlKeyText;
            set => SetField(ref _leftCtrlKeyText, value);
        }
        
        public string LeftAltKeyText
        {
            get => _leftAltKeyText;
            set => SetField(ref _leftAltKeyText, value);
        }
        
        public string RightCtrlKeyText
        {
            get => _rightCtrlKeyText;
            set => SetField(ref _rightCtrlKeyText, value);
        }
        
        public string AltGrKeyText
        {
            get => _altGrKeyText;
            set => SetField(ref _altGrKeyText, value);
        }
        
        public string NumEnterKeyText
        {
            get => _numEnterKeyText;
            set => SetField(ref _numEnterKeyText, value);
        }
        
        public string NumPlusKeyText
        {
            get => _numPlusKeyText;
            set => SetField(ref _numPlusKeyText, value);
        }
        
        public string NumMinusKeyText
        {
            get => _numMinusKeyText;
            set => SetField(ref _numMinusKeyText, value);
        }
        
        public string NumMultiplyKeyText
        {
            get => _numMultiplyKeyText;
            set => SetField(ref _numMultiplyKeyText, value);
        }
        
        public string NumDivideKeyText
        {
            get => _numDivideKeyText;
            set => SetField(ref _numDivideKeyText, value);
        }
        
        public string Num0KeyText
        {
            get => _num0KeyText;
            set => SetField(ref _num0KeyText, value);
        }
        
        public string Num1KeyText
        {
            get => _num1KeyText;
            set => SetField(ref _num1KeyText, value);
        }
        
        public string Num2KeyText
        {
            get => _num2KeyText;
            set => SetField(ref _num2KeyText, value);
        }
        
        public string Num3KeyText
        {
            get => _num3KeyText;
            set => SetField(ref _num3KeyText, value);
        }
        
        public string Num4KeyText
        {
            get => _num4KeyText;
            set => SetField(ref _num4KeyText, value);
        }
        
        public string Num5KeyText
        {
            get => _num5KeyText;
            set => SetField(ref _num5KeyText, value);
        }
        
        public string Num6KeyText
        {
            get => _num6KeyText;
            set => SetField(ref _num6KeyText, value);
        }
        
        public string Num7KeyText
        {
            get => _num7KeyText;
            set => SetField(ref _num7KeyText, value);
        }
        
        public string Num8KeyText
        {
            get => _num8KeyText;
            set => SetField(ref _num8KeyText, value);
        }
        
        public string Num9KeyText
        {
            get => _num9KeyText;
            set => SetField(ref _num9KeyText, value);
        }
        
        public string NumDecimalKeyText
        {
            get => _numDecimalKeyText;
            set => SetField(ref _numDecimalKeyText, value);
        }
        
        public string BackspaceKeyText
        {
            get => _backspaceKeyText;
            set => SetField(ref _backspaceKeyText, value);
        }
        
        public string TabKeyText
        {
            get => _tabKeyText;
            set => SetField(ref _tabKeyText, value);
        }
        
        public string RightShiftKeyText
        {
            get => _rightShiftKeyText;
            set => SetField(ref _rightShiftKeyText, value);
        }
        
        public string LeftShiftKeyText
        {
            get => _leftShiftKeyText;
            set => SetField(ref _leftShiftKeyText, value);
        }
        
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}