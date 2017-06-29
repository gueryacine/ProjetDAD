/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.soapservice;

import com.filepublisher.filePublisherBean;
import java.util.concurrent.TimeUnit;
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
    
    SoapTraitement straitement = new SoapTraitement();
    
    @Resource(mappedName = "jms/fileParsingQueue")
    private Queue queue;
    
    @Inject
    @JMSConnectionFactory("java:comp/DefaultJMSConnectionFactory")
    private JMSContext context;
    
    /**
     * This is a sample web service operation
     */
    @WebMethod(operationName = "SendFileForControl")
    public int sendFileForTraitement(@WebParam(name = "nameFile") String txt,@WebParam(name = "key") String key,@WebParam(name = "DecrypteString") String DecrypteText) throws JMSException, InterruptedException {

        System.out.println(txt);
        System.out.println(key);
        System.out.println(DecrypteText);
        
        
        context.createProducer().send(queue, txt);
        //return queuePublicher.getMessage();
  
        
        
        return 52;
    }
    
        @WebMethod(operationName = "SendResponseTraitement")
        public Responseclass sendResponseTraitement() throws JMSException {
          //Check if id it's ok
          Responseclass rc = new Responseclass(false,"dzadazd", "dzadaz@zdzad.de");
          return rc;
    }
}
