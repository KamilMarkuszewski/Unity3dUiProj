using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ButtonsScripts
{
    public abstract class UiWriter : MonoBehaviour
    {
        public Sprite SpriteNum0;
        public Sprite SpriteNum1;
        public Sprite SpriteNum2;
        public Sprite SpriteNum3;
        public Sprite SpriteNum4;
        public Sprite SpriteNum5;
        public Sprite SpriteNum6;
        public Sprite SpriteNum7;
        public Sprite SpriteNum8;
        public Sprite SpriteNum9;

        protected virtual void ShowDigitSprite(int digits, int position, Transform obj)
        {
            var digitsString = Reverse(digits.ToString());
            var digit = 0;
            if (digitsString.Length >= position)
            {
                digit = Int16.Parse(digitsString[position - 1].ToString());
            }
            Sprite chosenSpr = null;
            switch (digit)
            {
                case 0:
                    chosenSpr = SpriteNum0;
                    break;
                case 1:
                    chosenSpr = SpriteNum1;
                    break;
                case 2:
                    chosenSpr = SpriteNum2;
                    break;
                case 3:
                    chosenSpr = SpriteNum3;
                    break;
                case 4:
                    chosenSpr = SpriteNum4;
                    break;
                case 5:
                    chosenSpr = SpriteNum5;
                    break;
                case 6:
                    chosenSpr = SpriteNum6;
                    break;
                case 7:
                    chosenSpr = SpriteNum7;
                    break;
                case 8:
                    chosenSpr = SpriteNum8;
                    break;
                case 9:
                    chosenSpr = SpriteNum9;
                    break;
            }
            var sr = obj.GetComponent<SpriteRenderer>();
            sr.sprite = chosenSpr;
        }

        public static string Reverse( string s )
{
    char[] charArray = s.ToCharArray();
    Array.Reverse( charArray );
    return new string( charArray );
}
    }
}
