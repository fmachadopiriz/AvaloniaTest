namespace AvaloniaTest.Models.Tests
{
    using System;
    using Xunit;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using AvaloniaTest.Models;

    public class KeyboardFileTests
    {
        [Fact]
        public void SaveAndLoadTest()
        {
            const string keyboardName1 = "Keyboard1";
            const string keyboardName2 = "Keyboard2";
            const string keyImage1 = "KeyImage1";
            const string keyImage2 = "KeyImage2";
            const string keyImage3 = "KeyImage4";
            const string keyImage4 = "KeyImage1";
            const string keyText1 = "KeyText1";
            const string keyText2 = "KeyText2";
            const string keyText3 = "KeyText4";
            const string keyText4 = "KeyText1";

            Keyboard keyboard1 = new Keyboard(keyboardName1);
            keyboard1.AddKey(new Key(keyImage1, keyText1, new NextKeyboardCommand(keyboardName2)));
            keyboard1.AddKey(new Key(keyImage2, keyText2, null));
            KeyboardFile.Instance.AddKeyboard(keyboard1);

            Keyboard keyboard2 = new Keyboard(keyboardName1);
            keyboard1.AddKey(new Key(keyImage3, keyText3, new NextKeyboardCommand(keyboardName1)));
            keyboard1.AddKey(new Key(keyImage4, keyText4, null));
            KeyboardFile.Instance.AddKeyboard(keyboard2);

            string data;
            using (MemoryStream stream = new MemoryStream())
            {
                KeyboardFile.Instance.SaveToStream(stream);
                byte[] json = stream.ToArray();
                stream.Close();
                data = Encoding.UTF8.GetString(json, 0, json.Length);
            }

            KeyboardFile.Instance.Reset();

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                KeyboardFile.Instance.LoadFromStream(stream);
                stream.Close();
            }

            Keyboard loadedKeyboard1 = KeyboardFile.Instance.GetKeyboardByName(keyboardName1);
            Assert.Equal(loadedKeyboard1, keyboard1);

        }

        private void AddKeyboard(string keyboardName, string nextKeyboardName)
        {

        }
    }
}
