using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "LoginValidator", menuName = "TextMeshPro/Text Validator/LoginValidator", order = 1)]
public class LoginValidator : TMP_InputValidator
{
    /*CHARACTERS ALLOWED
     * Uppercase and lowercase letters
     * numbers 0-9
     * underscore
     */
 
    public override char Validate(ref string text, ref int pos, char ch)
    {
        if (Regex.IsMatch(ch.ToString(), @"^[a-zA-Z0-9]*$")) {
            
            text = text.Insert(pos, char.ToUpper(ch).ToString());
            pos += 1;
            
            
            return char.ToUpper(ch);
        }
        else {
            return '\0';
        }
    }
}