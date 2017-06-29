/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.soapservice;

import com.filepublisher.FilePublisherBean;
import javax.annotation.Resource;
import javax.inject.Inject;
import javax.jms.JMSConnectionFactory;
import javax.jms.JMSContext;
import javax.jms.JMSException;
import javax.jms.Queue;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;

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

        System.out.println(fileString);
        System.out.println(key);
        System.out.println(DecrypteText);
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
          //Check if id it's ok
          Responseclass rc = new Responseclass(false,"dzadazd", "dzadaz@zdzad.de");
          return rc;
    }
}
