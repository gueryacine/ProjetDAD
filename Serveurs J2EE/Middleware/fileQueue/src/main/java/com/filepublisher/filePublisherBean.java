/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.filepublisher;

import java.io.Serializable;
import javax.annotation.Resource;
import javax.enterprise.context.SessionScoped;
import javax.inject.Inject;
import javax.inject.Named;
import javax.jms.BytesMessage;
import javax.jms.JMSContext;
import javax.jms.JMSException;
import javax.jms.Queue;
/**
 *
 * @author Ewen Auffret
 */
@Named(value="filePublisherBean")
@SessionScoped
public class filePublisherBean implements Serializable {


  public filePublisherBean()
  {}
  
  @Inject
  private JMSContext context;
  
  private String message; 
  
  @Resource(lookup="jms/fileParsingQueue")
  private Queue fileParsingQueue;
  
  public void addMessageToQueue() throws JMSException {
    BytesMessage byteMessage = context.createBytesMessage();  
    byteMessage.writeBytes( getMessage().getBytes() );
    System.out.println( getMessage());
    context.createProducer().send(fileParsingQueue, byteMessage);
  }
  
      /**
     * @return the message
     */
    public String getMessage() {
        return message;
    }

    /**
     * @param message the message to set
     */
    public void setMessage(String message) {
        this.message = message;
    }
  
}
  

