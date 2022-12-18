namespace NT.AlgorithmsHackathon;

public class CesarDecoder
{
    private readonly char[] _uppers = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    private readonly char[] _lowers = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
    private readonly char[] _numbers = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

    public string FromCesar(string txt)
    {
        var plainText = "";

        foreach(var c in txt)
        {
            if(_uppers.Contains(c))
            {
                plainText += _uppers[(Array.IndexOf(_uppers, c) + 9) % 26];
            }
            else if(_lowers.Contains(c))
            {
                plainText += _lowers[(Array.IndexOf(_lowers, c) + 9) % 26];
            }
            else if(_numbers.Contains(c))
            {
                plainText += _numbers[(Array.IndexOf(_numbers, c) + 3) % 10];
            }
            else plainText += c;
        }

        return plainText;
    }
}