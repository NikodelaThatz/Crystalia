using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
[ExecuteInEditMode]
public class TranslationHandler : MonoBehaviour {

    public static TranslationHandler instance;
    public TextAsset english, italian;
    string currentTranslation;
    private void Awake() {
        instance = this;
        SwitchLanguage(italian);
    }

    public string Translate(int textLine) {
        if (true) {
            ///TODO: multi language
            var text = currentTranslation;
            string [] stringSep = new string[] { "-" + textLine + "-" };
            string[] result = text.Split(stringSep, System.StringSplitOptions.None);
            if (1 > result.Length - 1) {
                return null;
            } else {
                return result[1];
            }
        }

    }

    public void SwitchLanguage(TextAsset language) {
        currentTranslation = language.text.ToString();
    }
}