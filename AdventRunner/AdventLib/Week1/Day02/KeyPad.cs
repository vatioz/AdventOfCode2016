using System;

namespace AdventLib.Day02
{
    public class KeyPad
    {
        IButton _startingButton;

        private IButton[] _buttons;

        public KeyPad()
        {
            
        }

        public void InitDesignKeyPad()
        {
            _buttons = new IButton[13];
            var one = new Button("1");
            var two = new Button("2");
            var three = new Button("3");
            var four = new Button("4");
            var five = new Button("5");
            var six = new Button("6");
            var seven = new Button("7");
            var eight = new Button("8");
            var nine = new Button("9");
            var a = new Button("A");
            var b = new Button("B");
            var c = new Button("C");
            var d = new Button("D");

            _buttons[0] = one;
            _buttons[1] = two;
            _buttons[2] = three;
            _buttons[3] = four;
            _buttons[4] = five;
            _buttons[5] = six;
            _buttons[6] = seven;
            _buttons[7] = eight;
            _buttons[8] = nine;
            _buttons[9] = a;
            _buttons[10] = b;
            _buttons[11] = c;
            _buttons[12] = d;


            one.SetNeighbors(new NullButton(one), new NullButton(one), three, new NullButton(one));

            two.SetNeighbors(new NullButton(two), three, six, new NullButton(two));
            three.SetNeighbors(one, four, seven, two);
            four.SetNeighbors(new NullButton(four), new NullButton(four), eight, three);

            five.SetNeighbors(new NullButton(five), six, new NullButton(five), new NullButton(five));
            six.SetNeighbors(two, seven, a, five);
            seven.SetNeighbors(three, eight, b, six);
            eight.SetNeighbors(four, nine, c, seven);
            nine.SetNeighbors(new NullButton(nine), new NullButton(nine), new NullButton(nine), eight);

            a.SetNeighbors(six, b, new NullButton(a), new NullButton(a));
            b.SetNeighbors(seven, c, d, a);
            c.SetNeighbors(eight, new NullButton(c), new NullButton(c), b);

            d.SetNeighbors(b, new NullButton(d), new NullButton(d), new NullButton(d));

            _startingButton = five;
        }

        public void InitStandardKeyPad()
        {
            _buttons = new IButton[9];

            var one = new Button("1");
            var two = new Button("2");
            var three = new Button("3");
            var four = new Button("4");
            var five = new Button("5");
            var six = new Button("6");
            var seven = new Button("7");
            var eight = new Button("8");
            var nine = new Button("9");

            _buttons[0] = one;
            _buttons[1] = two;
            _buttons[2] = three;
            _buttons[3] = four;
            _buttons[4] = five;
            _buttons[5] = six;
            _buttons[6] = seven;
            _buttons[7] = eight;
            _buttons[8] = nine;

            //var nul = new NullButton(0);
            one.SetNeighbors(new NullButton(one), two, four, new NullButton(one));
            two.SetNeighbors(new NullButton(two), three, five, one);
            three.SetNeighbors(new NullButton(three), new NullButton(three), six, two);
            four.SetNeighbors(one, five, seven, new NullButton(four));
            five.SetNeighbors(two, six, eight, four);
            six.SetNeighbors(three, new NullButton(six), nine, five);
            seven.SetNeighbors(four, eight, new NullButton(seven), new NullButton(seven));
            eight.SetNeighbors(five, nine, new NullButton(eight), seven);
            nine.SetNeighbors(six, new NullButton(nine), new NullButton(nine), eight);

            _startingButton = five;


        }

        public void SetStartingButton(string buttonLabel)
        {
            var buttonIndex = Array.IndexOf(_buttons, buttonLabel);
            _startingButton = _buttons[buttonIndex];
        }

        public void ProcessSequence(string line)
        {
            var buttonAtTheEndOfSequence = _startingButton.Move(line);
            _startingButton = buttonAtTheEndOfSequence;
            Sequence += buttonAtTheEndOfSequence.Label;
        }



        public string Sequence { get; set; }


    }
}
