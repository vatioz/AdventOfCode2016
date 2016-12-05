using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventLib.Day02
{
    public interface IButton
    {
        string Label { get; }

        IButton Move(string instructions);

    }

    public class Button:IButton
    {
        public string Label { get; }

        private Button _up;
        private Button _right;
        private Button _down;
        private Button _left;

        public Button(string buttonLabel)
        {
            Label = buttonLabel;
        }

        public void SetNeighbors(Button up, Button right, Button down, Button left)
        {
            _up = up;
            _right = right;
            _down = down;
            _left = left;
        }





        public virtual IButton Move(string instructions)
        {
            if (string.IsNullOrEmpty(instructions))
            {
                //Press();
                return this;
            }

            var step = instructions[0];
            var restOfInstructions = instructions.Substring(1);
            
            switch (step)
            {
                case 'U':
                    return _up.Move(restOfInstructions);
                case 'R':
                    return _right.Move(restOfInstructions);
                case 'D':
                    return _down.Move(restOfInstructions);
                case 'L':
                    return _left.Move(restOfInstructions);
                default:
                    throw new NotSupportedException($"Instruction {step} not supported.");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is string)
                return this.Label == (string) obj;

            else if(obj is Button)
                return this.Label == ((Button) obj).Label;
            else
            {
                throw new NotSupportedException($"Cannot compare Button to {obj.GetType().Name}");
            }
        }
    }

    public class NullButton : Button
    {
        private readonly Button _goBack;

        public NullButton(Button goBack) : base("null")
        {
            _goBack = goBack;
        }

        public override IButton Move(string instructions)
        {
            return _goBack.Move(instructions);
        }
    }
}
