using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Source.Core
{
    /// <summary>
    ///     Class for handling text on user interface (UI)
    /// </summary>
    public class UserInterface : MonoBehaviour
    {
        private float _lastFrame = 0;
        private bool _keyPressed = false;
        public enum TextPosition : byte
        {
            TopLeft,
            TopCenter,
            TopRight,
            MiddleLeft,
            MiddleCenter,
            MiddleRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        }

        /// <summary>
        ///     User Interface singleton
        /// </summary>
        public static UserInterface Singleton { get; private set; }

        private TextMeshProUGUI[] _textComponents;

        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }

            Singleton = this;

            _textComponents = GetComponentsInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (_lastFrame > 3 && _keyPressed)
            {
                PrintNotification(string.Empty, false, TextPosition.BottomCenter);
            }

            if (Input.GetKeyDown(KeyCode.F5))
            {
                PrintNotification("Saved", true, TextPosition.BottomCenter);
            }

            if (Input.GetKeyDown(KeyCode.F9))
            {
                PrintNotification("Loaded", true, TextPosition.BottomCenter);
            }
            _lastFrame += Time.deltaTime;
        }

        public void PrintNotification(string notification, bool state, TextPosition textPosition)
        {
            _lastFrame = 0;
            _keyPressed = state;
            SetText(notification, textPosition);
        }

        /// <summary>
        ///     Changes text at given screen position
        /// </summary>
        /// <param name="text"></param>
        /// <param name="textPosition"></param>
        public void SetText(string text, TextPosition textPosition)
        {
            _textComponents[(int)textPosition].text = text;
        }

        public void AddToText(string text, TextPosition textPosition)
        {
            _textComponents[(int)textPosition].text += $"{text}\n";
        }

        public void PrintInterface(Dictionary<string, int> inventory,int MaxHealth, int Health, int Strength, int Shield)
        {
            string inventoryToPrint = string.Empty;
            string items = string.Empty;
            foreach (var item in inventory)
            {
                if (item.Value > 0)
                {
                    items += $"{(char.ToUpper(item.Key[0])) + item.Key.Substring(1)} x{item.Value}\n";
                }
            }
            if (items != string.Empty)
            {
                inventoryToPrint += "Inventory:\n" + items;
            }
            Singleton.SetText(inventoryToPrint, TextPosition.BottomRight);
            Singleton.SetText($"HP: {Health}/{MaxHealth} STR: {Strength} SHI: {Shield}", UserInterface.TextPosition.BottomLeft);
        }

        public void PrintNewGameText(int newGameCount)
        {
            string newGameText = CreateNewGameText(newGameCount);
            Singleton.SetText(newGameText, UserInterface.TextPosition.TopLeft);
        }

        public string CreateNewGameText(int newGameCount)
        {
            string pluses;
            if (newGameCount < 10)
            {
                pluses = String.Concat(Enumerable.Repeat("+", newGameCount));
            }
            else
            {
                pluses = " x" + newGameCount;
            }
            return "NewGame" + pluses;
        }

        public void PrintGameOverText()
        {
            Singleton.SetText("Game Over", UserInterface.TextPosition.MiddleCenter);
        }

        public void ClearUi()
        {
            foreach (var position in Enum.GetValues(typeof(TextPosition)))
            {
                Singleton.SetText(String.Empty, (TextPosition)position);
            }
        }

        public void PrintExp(int exp, int expNeeded)
        {
            Singleton.SetText($"XP: {exp} / {expNeeded}", TextPosition.TopRight);
        }

        public void PrintException(Exception ex)
        {
            var stringException = Convert.ToString(ex);
            _textComponents[(int) TextPosition.MiddleLeft].text = stringException;
            _textComponents[(int) TextPosition.MiddleLeft].fontSize = 10;
        }
    }
}
