/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.soapservice;

import com.filepublisher.filePublisherBean;
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
    
    /**
     * This is a sample web service operation
     */
    @WebMethod(operationName = "sendDecrypteFile")
    public String hello(@WebParam(name = "nameFile") String txt,@WebParam(name = "key") String key) throws JMSException {

        context.createProducer().send(queue, txt);
        //return queuePublicher.getMessage();
        System.out.println(txt);
        System.out.println(key);
        return "YES!";
    }
}