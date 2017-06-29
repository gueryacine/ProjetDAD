package com.soapservice;

/**
 *
 * @author gueryacine
 */
public class SoapTraitement {

        
     public String TransformationFonction(String info, int nbBitPerCharacters){
        int foo = 0;
        long charCode;
        String stringConvertie = "";
        String [] binaryChar = info.split("(?<=\\G.{"+nbBitPerCharacters+"})");
                
        
        for(int i = 0; i < binaryChar.length; i++){
            charCode = Long.parseLong(binaryChar[i], 2);
            stringConvertie += new Character((char)charCode).toString();
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
