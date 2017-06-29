package com.soapservice;

/**
 *
 * @author gueryacine
 */
public class SoapTraitement {

        
    public String TransformationFonction(String text){
      String resultat = "";
      String[] tabBin =  splitByNumber(text, 8);
      
        for (String bintxt : tabBin) {
            resultat = resultat + binnarytochar(bintxt);
        }
        return resultat;
    }
    
    public char binnarytochar(String txt){
        int parseInt = Integer.parseInt(txt, 2);
        return (char)parseInt;
    }
    
    private String[] splitByNumber(String str, int size) {
        return (size<1 || str==null) ? null : str.split("(?<=\\G.{"+size+"})");
    }
    
}
