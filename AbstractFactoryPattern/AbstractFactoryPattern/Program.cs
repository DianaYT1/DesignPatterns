using System;

namespace AbstractFactoryPattern
{
    public class Program
    {
        //'AbstractFactory'
        abstract class SmartPhoneViewFactory
        {
            public abstract Background CreateBackground();
            public abstract TextColor CreateTextColor();
        }

        //'ConcreteFactory1'
        class Mode1 : SmartPhoneViewFactory
        {
            public override Background CreateBackground()
            {
                return new WhiteBackground();
            }

            public override TextColor CreateTextColor()
            {
                return new DarkTextColor();
            }
        }


        //'ConcreateFacrory2'
        class Mode2 : SmartPhoneViewFactory
        {
            public override Background CreateBackground()
            {
                return new DarkBackground();
            }

            public override TextColor CreateTextColor()
            {
                return new WitheTextColor();
            }
        }
        
        //'AbstractProductA'
        abstract class TextColor
        {
            
        }

        //'AbstractProductB'
        abstract class Background
        {
            public abstract void Color(TextColor textColor);
        }

       
        //'ProductB1'
        class DarkBackground : Background
        {
             public override void Color(TextColor textColor)
            {
                Console.WriteLine(this.GetType().Name + " change the text color to " + textColor.GetType().Name);
            }
        } 
        
        //'ProductA1'
        class DarkTextColor : TextColor
        {
           
        }
        //'ProductB2'
        class WhiteBackground : Background
        {
        public override void Color(TextColor textColor)
            {
                Console.WriteLine(this.GetType().Name + " change the text color to " + textColor.GetType().Name);
            }
        }

        //'ProductA2'
        class WitheTextColor : TextColor
        {
           
        }

        //'Client'
        class SmartPhone
        {
            private Background _background;
            private TextColor _textColor;

            public SmartPhone(SmartPhoneViewFactory factory)
            {
                _background = factory.CreateBackground();
                _textColor = factory.CreateTextColor();
            }

            public void RunModeChange()
            {

                _background.Color(_textColor);
            }
        }

        static void Main(string[] args)
        {
            SmartPhoneViewFactory darkmode = new Mode1();
            SmartPhone smartPhone = new SmartPhone(darkmode);
            smartPhone.RunModeChange();


            SmartPhoneViewFactory whitemode = new Mode2();
            smartPhone = new SmartPhone(whitemode);
            smartPhone.RunModeChange();

            Console.ReadKey();
        }
    }
}
