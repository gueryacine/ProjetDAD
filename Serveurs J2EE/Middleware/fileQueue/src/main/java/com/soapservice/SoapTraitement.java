package com.soapservice;

/**
 *
 * @author gueryacine
 */
public class SoapTraitement {

        
     public String TransformationFonction(String info){

        String stringConvertie = "";
        String[] binaryChar = splitByNumber(info, 8);
         for (String string : binaryChar) {
             char c = binnarytochar(string);
             stringConvertie += c;
         }
        return stringConvertie;
    }
    
    public char binnarytochar(String txt){
        int parseInt = Integer.parseInt(txt, 2);
        return (char)parseInt;
    }
    
    private String[] splitByNumber(String str, int size) {
        return (size<1 || str==null) ? null : str.split("(?<=\\G.{"+size+"})");
    }
    
}
