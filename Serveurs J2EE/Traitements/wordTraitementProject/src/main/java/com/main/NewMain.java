/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.main;

import com.dao.model.EnityManagerController;
import com.traitement.bean.DicoVerification;
import javax.persistence.EntityManager;

/**
 *
 * @author gueryacine
 */
public class NewMain {

    /**
     * @param args the command line arguments
     */
    public void main() {
        // TODO code application logic here
            EnityManagerController emc = new EnityManagerController();
            
             DicoVerification t = new DicoVerification();
             t.setDocumentText("yavd aziubd aziohd iabzdazbd abaissé   abandon abandonnant abandonnant");
             t.setColonneName("mot");
             t.setQueryName("Dico.findByMot");
             t.setEntityManager(emc.getEm());
             Double result = t.executerTraitement();
             
             System.out.println(result);

    }
    
    
    
}
