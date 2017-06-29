/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import com.soapservice.SoapTraitement;
import org.junit.Test;

/**
 *
 * @author gueryacine
 */
public class SoapTraitementTest {
    

    @Test
    public void bintochartest() {
        
         SoapTraitement st = new SoapTraitement();
        // System.out.println(st.binnarytochar("01110100"));
    
    }
    
    @Test
    public void bintexttotext(){
        SoapTraitement st = new SoapTraitement();
        String t = st.TransformationFonction("0111010001100101011100110111010000100000011110010110010101110011001000000111100101100101011000010110100000100000001000010010000100100001");
        System.out.println(t);
    }
}
