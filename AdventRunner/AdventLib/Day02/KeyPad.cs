using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventLib.Day02
{
    public class KeyPad
    {
        IButton _startingButton;

        public KeyPad()
        {
            
        }



        public void Init()
        {
            var one = new Button(1);
            var two = new Button(2);
            var three = new Button(3);
            var four = new Button(4);
            var five = new Button(5);
            var six = new Button(6);
            var seven = new Button(7);
            var eight = new Button(8);
            var nine = new Button(9);
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

        public void ProcessSequence(string line)
        {
            var buttonAtTheEndOfSequence = _startingButton.Move(line);
            _startingButton = buttonAtTheEndOfSequence;
            Sequence += buttonAtTheEndOfSequence.Number;
        }



        public string Sequence { get; set; }


    }
}
