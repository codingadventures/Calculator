using System;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Text.Encoding;

namespace ConsoleApplication1
{
    internal enum Operator
    {
        [Description("+")]
        Add = 43,
        [Description("-")]
        Sub = 45,
        [Description("*")]
        Mul = 42,
        [Description("/")]
        Div = 47,
        [Description("%")]
        Perc = 37
    }

    internal class Parser
    {
        public event EventHandler<string> OperatorInserted;
        public event EventHandler<string> OperatorReplaced;
        public event EventHandler NumberInserted;
        public event EventHandler NumberTyped;
        public event EventHandler MoreThanOneDotInserted;
        public event EventHandler EnterInserted;
        public event EventHandler InvalidChar;
        
        private readonly Queue<byte> _numberAccumulator = new Queue<byte>();

        private readonly Queue<Operator> _operations = new Queue<Operator>();
        private readonly Queue<float> _numbers = new Queue<float>();

        public bool IsResultAvalable => _operations.Count > 0 && _numbers.Count > 1;
        
        public void Add(byte ascii)
        {
            if (ascii.IsNumber())
            {
                OnNumberTyped();
                _numberAccumulator.Enqueue(ascii);
            }

            if (ascii.IsDot())
            {
                if (!_numberAccumulator.Contains(46))
                   _numberAccumulator.Enqueue(ascii);
                else
                    OnMoreThanOneDotInserted();
            }

            if (ascii.IsEnter())
            {
                ProcessNumbersInserted();
                OnEnterInserted();
                return;
            }

            if (!ascii.IsOperation()) 
                return;

            //handle operator replacement
            Operator op = (Operator) ascii;
            var description = ((Operator)ascii).GetEnumDescription();

            ProcessNumbersInserted();
            
            ProcessOperatorsInserted(description, op);
        }

        private void ProcessOperatorsInserted(string description, Operator op)
        {
            if (_operations.Count + 1 > _numbers.Count)
            {
                _operations.Dequeue();
                OnOperatorReplaced(description);
            }
            _operations.Enqueue(op);
            OnOperatorInserted(description);
        }

        private void ProcessNumbersInserted()
        {
            if (_numberAccumulator.Count > 0)
            {
                var number = ASCII.GetString(_numberAccumulator.ToArray());
                _numbers.Enqueue(float.Parse(number));
                _numberAccumulator.Clear();
                OnNumberInserted();
            }
        }

        public float CalculateResult()
        {
            if (!IsResultAvalable) 
                return 0.0f;
            
            float result = 0;

            while (_operations.Count > 0 && _numbers.Count > 0)
            {
                Operator @operator = _operations.Dequeue();
                var number1 = _numbers.Dequeue();
                var number2 = _numbers.Dequeue();
                switch (@operator)
                {
                    case Operator.Add:
                        result = number1 + number2;
                        break;
                    case Operator.Sub:
                        result = number1 - number2;
                        break;
                    case Operator.Mul:
                        result = number1 * number2;
                        break;
                    case Operator.Div:
                        result = number1 / number2;
                        break;
                    case Operator.Perc:
                        break;
                }
            }
            _numbers.Enqueue(result);

            return result;
        }

        protected virtual void OnNumberInserted()
        {
            NumberInserted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnMoreThanOneDotInserted()
        {
            MoreThanOneDotInserted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnEnterInserted()
        {
            EnterInserted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnOperatorInserted(string e)
        {
            OperatorInserted?.Invoke(this, e);
        }

        protected virtual void OnOperatorReplaced(string e)
        {
            OperatorReplaced?.Invoke(this, e);
        }

        protected virtual void OnNumberTyped()
        {
            NumberTyped?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnInvalidChar()
        {
            InvalidChar?.Invoke(this, EventArgs.Empty);
        }
    }
}