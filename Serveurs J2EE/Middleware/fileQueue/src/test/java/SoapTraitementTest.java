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
        String t = st.TransformationFonction("01100001011000100110001101100100",8);
        System.out.println(t);
    }
}
