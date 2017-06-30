/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.soapservice;

import com.dao.model.Dechiffrage;
import com.dao.model.EntityManagerController;
import com.filepublisher.FilePublisherBean;
import java.util.List;
import javax.annotation.Resource;
import javax.inject.Inject;
import javax.jms.JMSConnectionFactory;
import javax.jms.JMSContext;
import javax.jms.JMSException;
import javax.jms.Queue;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;

/**
 *
 * @author gueryacine
 */
@WebService(serviceName = "SoapService")
public class SoapService {
    
    
    
    @Resource(mappedName = "jms/fileParsingQueue")
    private Queue queue;
    
    @Inject
    @JMSConnectionFactory("java:comp/DefaultJMSConnectionFactory")
    private JMSContext context;
    
    @Inject
    private FilePublisherBean fpb;
    
    SoapTraitement straitement = new SoapTraitement();
    

    
    /**
     * This is a sample web service operation
     */
    @WebMethod(operationName = "SendFileForControl")

    public boolean sendFileForTraitement(@WebParam(name = "nameFile") String fileString,@WebParam(name = "key") String key,@WebParam(name = "DecrypteString") String DecrypteText)throws JMSException{
        try
        {

        SoapTraitement straitement = new SoapTraitement();
        DecrypteText=  straitement.TransformationFonction(DecrypteText);

        fpb.setDecryptedText(DecrypteText);
        fpb.setFileName(fileString);
        fpb.setKeyValue(key);
        fpb.addMessageToQueue();
        
        //context.createProducer().send(queue, txt);
        //return queuePublicher.getMessage();
        return true;
        } catch(Exception e)
        {
        return false;
        }
        
    }
    
        @WebMethod(operationName = "SendResponseTraitement")
        public Responseclass sendResponseTraitement() throws JMSException {
            EntityManagerController emc = new EntityManagerController();
            EntityManager em = emc.getEm();
            EntityTransaction etx = em.getTransaction();
            etx.begin();
            List<Dechiffrage> list_dich = em.createNamedQuery("Dechiffrage.findBySend").setParameter("send", 0).getResultList();
            if(list_dich.isEmpty() == false)
            {
                Dechiffrage dechiffrage = list_dich.get(0);
                Responseclass response = new Responseclass(true, dechiffrage.getCleDecodage(), dechiffrage.getEmail(),dechiffrage.getPathTxtFichier());
                
                if(!em.getTransaction().isActive())
                    em.getTransaction().begin();


                dechiffrage.setSend(1);
                etx.commit();
                System.out.println(list_dich.get(0).getIdDechiffrage());
                
                return response;
            }
            etx.commit();
            
            
            
            
          
          return null;
    }
}
