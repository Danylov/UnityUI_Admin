using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "GroupValidator", menuName = "TextMeshPro/Text Validator/GroupValidator", order = 1)]
public class GroupValidator : TMP_InputValidator
{
    /*CHARACTERS ALLOWED
     * Uppercase and lowercase letters
     * numbers 0-9
     * underscore
     */
 
    public override char Validate(ref string text, ref int pos, char ch)
    {
        if (Regex.IsMatch(ch.ToString(), @"\p{IsCyrillic}|[0-9]|[_-]|\s")) {
            
            text = text.Insert(pos, char.ToUpper(ch).ToString());
            pos += 1;
            
            
            return char.ToUpper(ch);
        }
        else {
            return '\0';
        }
    }
}