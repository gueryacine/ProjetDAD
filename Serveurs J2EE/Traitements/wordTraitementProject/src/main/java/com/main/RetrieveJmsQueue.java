/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.main;
import javax.jms.*;
import javax.naming.Context;
import javax.naming.InitialContext;
import com.dao.model.EntityManagerController;
import com.traitement.bean.DicoVerification;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.ActivationConfigProperty;
import javax.ejb.MessageDriven;
import javax.persistence.EntityManager;
/**
 *
 * @author Ewen Auffret, Yacine Guerboukha
 */


@MessageDriven(activationConfig= {
    @ActivationConfigProperty(propertyName = "acknowledgeMode", propertyValue = "Auto-acknowledge"),
    @ActivationConfigProperty(propertyName = "destinationLookup", propertyValue = "jms/fileParsingQueue"), 
    @ActivationConfigProperty(propertyName = "destinationType", propertyValue = "javax.jms.Queue")
})
public class RetrieveJmsQueue implements MessageListener {
    
    public RetrieveJmsQueue() {
        
    }
    
    @Override
    public void onMessage(Message message)
    {
        try {
            String fileName = message.getStringProperty("FileName");
            String keyValue = message.getStringProperty("KeyValue");
            String decryptedText = message.getStringProperty("DecryptedText");
                
            EntityManagerController emc = new EntityManagerController();

            DicoVerification t = new DicoVerification();
            t.setDocumentText(decryptedText);
            t.setColonneName("mot");
            t.setQueryName("Dico.findByMot");
            t.setEntityManager(emc.getEm());

            Double result = t.executerTraitement();
            
            Logger.getLogger(RetrieveJmsQueue.class.getName()).log(Level.FINE, null, "Traitement sur : " + fileName + 
                    " avec la cle : " + keyValue + " Resultat : " + result.toString() + "%");
        } catch (JMSException ex) {
            Logger.getLogger(RetrieveJmsQueue.class.getName()).log(Level.SEVERE, null, ex);
        }

        
    }
}