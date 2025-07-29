namespace MoneyExtension;

public static class Money
{
    
    public static int ToCents(this decimal amout){
        if(amout <= 0){
            return 0;
        }

        var text = amout.ToString("N2").Replace(",","").Replace(".",",");
        if(string.IsNullOrEmpty(text)){
            return 0;
        }

        int.TryParse(text, out var result);
        return result;
    }

}
